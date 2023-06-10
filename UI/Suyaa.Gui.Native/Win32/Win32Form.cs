using Forms;
using static Suyaa.Gui.Win32Native.Win32Api;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Messages;
using Suyaa.Gui.Native.Win32.Apis;
using static System.Formats.Asn1.AsnWriter;
using System.Runtime.CompilerServices;
using Suyaa.Gui.Native.Helpers;

namespace Suyaa.Gui.Native.Win32
{
    /// <summary>
    /// Win32窗体
    /// </summary>
    public class Win32Form : INativeForm
    {
        #region 构造函数及私有变量

        // 标题
        private string _title = string.Empty;
        // 默认线程操作对象
        private static IntPtr _defWindowProc = IntPtr.Zero;
        private readonly User32.WNDPROC _windProc;

        /// <summary>
        /// Win32窗体
        /// </summary>
        public Win32Form()
        {
            // 申请句柄
            this.Handle = Application.GetNewHandle();
            // 初始化委托
            _windProc = new User32.WNDPROC(WinProc);
            // 初始化样式表
            this.Styles = new Styles(this);
            //this.Styles.Set<float>(StyleType.Width, 300);
            //this.Styles.Set<float>(StyleType.Height, 300);
        }

        #endregion

        #region 消息处理函数

        // 获取Win32Form
        private static Win32Form GetWin32FormByHwnd(IntPtr hwnd)
        {
            Win32Application win32 = (Win32Application)Application.GetCurrent();
            long handle = win32.GetHandleByHwnd(hwnd);
            var form = Application.GetFormByHandle(handle);
            if (form is null) throw new GuiException($"Native form '0x{hwnd.ToString("x").PadLeft(12, '0')}' not found.");
            return (Win32Form)form.NativeForm;
        }

        // 接收到绘制消息
        private static void WinProcPaint(Win32Form form, SKCanvas cvs, Rectangle rectangle)
        {
            // 读取背景
            using (PaintMessage msg = new(form.Handle, cvs, rectangle))
            {
                Application.PostMessage(msg);
            }
        }

        // 接收到绘制消息
        private static void WinProcPaint(Win32Form form)
        {
            // 获取是否使用缓存
            var useCache = form.Styles.Get<bool>(StyleType.UseCache);
            // 获取窗口工作区
            var rect = User32.GetClientRect(form.Hwnd);
            if (rect.Width <= 0 || rect.Height <= 0) return;
            // 判断是否使用缓存
            if (useCache)
            {
                // 判断是否需要重新绘制
                if (form.CacheBitmap != null)
                {
                    if (form.CacheBitmap.Width != rect.Width || form.CacheBitmap.Height != rect.Height)
                    {
                        form.CacheBitmap.Dispose();
                        form.CacheBitmap = null;
                    }
                }
                // 判断是否有缓存
                if (form.CacheBitmap is null)
                {
                    form.CacheBitmap = new SKBitmap((int)rect.Width, (int)rect.Height);
                    using (SKCanvas cvs = new SKCanvas(form.CacheBitmap))
                    {
                        WinProcPaint(form, cvs, rect);
                    }
                }
                form.CacheBitmap.BitBltToHwnd(form.Hwnd);
            }
            else
            {
                // 直接绘制
                using (SKBitmap bmp = new SKBitmap((int)rect.Width, (int)rect.Height))
                {
                    using (SKCanvas cvs = new SKCanvas(bmp))
                    {
                        WinProcPaint(form, cvs, rect);
                    }
                    bmp.BitBltToHwnd(form.Hwnd);
                }
            }
        }

        // 接收到绘制消息
        private static void WinProcPaint(IntPtr hwnd)
        {
            var form = GetWin32FormByHwnd(hwnd);
            WinProcPaint(form);
        }

        // 窗口过程
        private static IntPtr WinProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            User32.WM wm = (User32.WM)msg;
            Debug.WriteLine($"[WinProc] Hwnd: 0x{hwnd.ToString("X2")}, Message: {wm.ToString()}(0x{msg.ToString("X2")})");
            User32.SetWindowLong(hwnd, User32.GWL.WNDPROC, _defWindowProc);
            switch (wm)
            {
                // 创建
                case User32.WM.CREATE: break;
                // 绘制界面
                case User32.WM.PAINT: WinProcPaint(hwnd); break;
                case User32.WM.DESTROY:
                    //User32.PostQuitMessage(0);
                    Win32Application win32 = (Win32Application)Application.GetCurrent();
                    Application.PostMessage(new CloseMessage(win32.GetHandleByHwnd(hwnd)));
                    break;
            }
            var res = User32.DefWindowProcW(hwnd, wm, wParam, lParam);
            Debug.WriteLine($"[WinProc] Hwnd: 0x{hwnd.ToString("X2")}, Message: {wm.ToString()}(0x{msg.ToString("X2")}), Result: {res}");
            return res;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// Hwnd
        /// </summary>
        public IntPtr Hwnd { get; private set; }

        /// <summary>
        /// 窗口句柄
        /// </summary>
        public long Handle { get; }

        /// <summary>
        /// 样式列表
        /// </summary>
        public Styles Styles { get; }

        /// <summary>
        /// 缓存图像
        /// </summary>
        public SKBitmap? CacheBitmap { get; private set; }

        /// <summary>
        /// 窗体标题
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }

        #endregion

        #region 公共函数

        /// <summary>
        /// 初始化
        /// </summary>
        public unsafe void Initialize()
        {
            // 计算dpi比例
            var scale = Gdi32.GetDpiScale();

            // 获取系统工作区
            var rect = User32.GetSystemWorkarea();

            // 获取宽高
            var x = this.Styles.Get<float>(StyleType.X);
            var y = this.Styles.Get<float>(StyleType.Y);
            var width = this.Styles.Get<float>(StyleType.Width) / scale;
            var height = this.Styles.Get<float>(StyleType.Height) / scale;

            #region 处理对齐
            var left = x;
            var top = y;
            var xAlign = this.Styles.Get<AlignType>(StyleType.XAlign);
            var yAlign = this.Styles.Get<AlignType>(StyleType.YAlign);
            switch (xAlign)
            {
                case AlignType.Center:
                    left = (rect.right - width) / 2 + x;
                    break;
                case AlignType.Opposite:
                    left = rect.right - width - x;
                    break;
            }
            switch (yAlign)
            {
                case AlignType.Center:
                    top = (rect.bottom - height) / 2 + y;
                    break;
                case AlignType.Opposite:
                    top = rect.bottom - height - y;
                    break;
            }
            #endregion

            // 初始化窗口类结构
            User32.WNDCLASS wc = new User32.WNDCLASS();

            _defWindowProc = wc.lpfnWndProc;

            wc.style = 0;
            wc.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_windProc);
            wc.hInstance = Kernel32.GetModuleHandleW(null);
            wc.hbrBackground = new Gdi32.HBRUSH(6);
            wc.lpszClassName = nameof(Win32Form).AsPtr();
            wc.cbClsExtra = 0;
            wc.cbWndExtra = 0;
            wc.hIcon = IntPtr.Zero;
            wc.hCursor = IntPtr.Zero;
            wc.lpszMenuName = null;

            //// 绘制图标
            //using (var fs = sy.IO.OpenFile($"{sy.IO.GetExecutionPath("make2.png")}"))
            //{
            //    using (var stream = new SKManagedStream(fs))
            //    {
            //        using (SKBitmap bmp = SKBitmap.Decode(stream))
            //        {
            //            //using (Bitmap bitmap = new Bitmap(bmp.Width, bmp.Height))
            //            //{
            //            //    for (int y = 0; y < bmp.Height; y++)
            //            //    {
            //            //        for (int x = 0; x < bmp.Width; x++)
            //            //        {
            //            //            var color = bmp.GetPixel(x, y);
            //            //            bitmap.SetPixel(x, y, Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue));
            //            //        }
            //            //    }
            //            //    wc.hIcon = bitmap.GetHicon();
            //            //}
            //            //    Bitmap? bitmap = ByteToBitmap(bmp.Bytes);
            //            //if(bitmap is null)
            //            //{
            //            //    wc.hIcon = IntPtr.Zero;
            //            //}
            //            //else
            //            //{
            //            //    wc.hIcon = bitmap.GetHicon();
            //            //}
            //        }
            //    }
            //}

            // 注册窗口类
            User32.RegisterClassW(ref wc);
            // 创建并显示窗口
            IntPtr hwnd;
            hwnd = User32.CreateWindowExW(
                User32.WS_EX.DEFAULT,
                wc.lpszClassName,
                this.Title.AsPtr(),
                //(int)User32.WS_STYLE.WS_OVERLAPPEDWINDOW,
                User32.WS.OVERLAPPEDWINDOW,
                (int)left, (int)top, (int)width, (int)height,
                IntPtr.Zero, IntPtr.Zero, Kernel32.GetModuleHandleW(null), IntPtr.Zero);

            this.Hwnd = hwnd;
            Debug.WriteLine($"[Win32Form] Create 0x{hwnd.ToString("X2")}");

            // 注册窗体关联
            Win32Application win32 = (Win32Application)Application.GetCurrent();
            win32.Handles[hwnd] = this.Handle;

            // 发送初始化消息
            using (InitMessage msg = new(this.Handle))
            {
                Application.PostMessage(msg);
            }

            // 显示
            if (this.Styles.Get<bool>(StyleType.Visible))
            {
                this.Show();
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        public void Show()
        {
            if (this.Hwnd == IntPtr.Zero)
            {
                this.Initialize();
            }
            IntPtr hwnd = this.Hwnd;
            User32.ShowWindow(hwnd, User32.SW.NORMAL);
            User32.UpdateWindow(hwnd);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 刷新显示
        /// </summary>
        public void Refresh()
        {
            this.CacheBitmap?.Dispose();
            WinProcPaint(this);
        }

        #endregion
    }
}