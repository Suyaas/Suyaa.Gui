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
using Suyaa.Gui.Enums;
using System.Runtime.ConstrainedExecution;

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
        private readonly User32.WNDPROC _windProc;
        // 光标
        private CursorType? _cursor;
        // 是否绘制中
        private bool _isPainting = false;

        /// <summary>
        /// Win32窗体
        /// </summary>
        public Win32Form()
        {
            // 申请句柄
            this.Handle = Application.GetNewHandle();
            // 初始化委托
            _windProc = new User32.WNDPROC(Win32Message.Proc);
            // 初始化样式表
            this.Styles = new Styles(this, true);
            //this.Styles.Set<float>(StyleType.Width, 300);
            //this.Styles.Set<float>(StyleType.Height, 300);
        }

        #endregion

        #region 私有函数

        /// <summary>
        /// 获取默认光标
        /// </summary>
        /// <returns></returns>
        private CursorType OnGetDefaultCursor()
        {
            CursorType cur = CursorType.Default;
            User32.SetCursor(cur.GetWin32Cursor());
            return cur;
        }

        /// <summary>
        /// 获取默认光标
        /// </summary>
        /// <returns></returns>
        private void OnSetCursor(CursorType cursor)
        {
            User32.SetCursor(cursor.GetWin32Cursor());
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
        public SKBitmap? CacheBitmap { get; internal set; }

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

        /// <summary>
        /// 光标
        /// </summary>
        public CursorType Cursor
        {
            get => _cursor ??= OnGetDefaultCursor();
            set
            {
                _cursor = value;
                OnSetCursor(value);
            }
        }

        #endregion

        #region 公共函数

        /// <summary>
        /// 初始化
        /// </summary>
        public unsafe void Initialize()
        {
            // 忽略DPI
            SHCore.SetProcessDpiAwareness(SHCore.PROCESS_DPI_AWARENESS.Process_Per_Monitor_DPI_Aware);

            // 计算dpi比例
            //var scale = Gdi32.GetDpiScale();
            var scale = Application.GetScale();

            // 获取系统工作区
            var rect = User32.GetSystemWorkarea();

            #region 处理尺寸
            var width = this.Styles.Get<float>(StyleType.Width);
            var height = this.Styles.Get<float>(StyleType.Height);
            var widthUnit = this.Styles.Get<UnitType>(StyleType.WidthUnit);
            var heightUnit = this.Styles.Get<UnitType>(StyleType.HeightUnit);
            if (widthUnit == UnitType.Percentage)
            {
                width = rect.Width * (width / 100);
            }
            else
            {
                width = width * scale;
            }
            if (heightUnit == UnitType.Percentage)
            {
                height = rect.Height * (height / 100);
            }
            else
            {
                height = height * scale;
            }
            #endregion

            #region 处理对齐
            var x = this.Styles.Get<float>(StyleType.X);
            var y = this.Styles.Get<float>(StyleType.Y);
            var left = x;
            var top = y;
            var xAlign = this.Styles.Get<AlignType>(StyleType.XAlign);
            var yAlign = this.Styles.Get<AlignType>(StyleType.YAlign);
            switch (xAlign)
            {
                case AlignType.Center:
                    left = (rect.Width - width) / 2 + x;
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
            // 设置默认处理函数
            Win32Message.SetDefWindowProc(wc.lpfnWndProc);
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
            // 显示窗体
            this.Styles.Set(StyleType.Visible, true);
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
            // 计算dpi比例
            //var scale = Gdi32.GetDpiScale();
            var scale = Application.GetScale();
            Win32Message.ProcResize(this, scale);
            Win32Message.ProcPaint(this.Hwnd);
        }

        /// <summary>
        /// 获取样式值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        public T GetStyle<T>(StyleType style)
            => this.Styles.Get<T>(style);

        /// <summary>
        /// 获取样式值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetStyle<T>(StyleType style, T defaultValue)
            => this.Styles.Get(style, defaultValue);

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public IWidget UseStyles(Action<Styles> action)
        {
            action(this.Styles);
            return this;
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IWidget UseStyles<T>()
        {
            this.Styles.SetStyles<T>();
            return this;
        }

        /// <summary>
        /// 处理绘制消息
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="rectangle"></param>
        private void OnPaint(SKCanvas cvs, Rectangle rectangle)
        {
            // 读取背景
            using (PaintMessage msg = new(this.Handle, cvs, rectangle, Application.GetScale()))
            {
                Application.SendMessage(msg);
            }
        }

        /// <summary>
        /// 处理绘制消息
        /// </summary>
        public void Repaint(bool force)
        {
            // 绘制中则退出
            if (_isPainting) return;
            _isPainting = true;
            // 未显示状态则直接退出
            if (!this.GetStyle(StyleType.Visible, false))
            {
                _isPainting = false;
                return;
            }
            // 获取是否使用缓存
            var useCache = this.GetStyle(StyleType.UseCache, false);
            // 获取窗口工作区
            var rect = User32.GetClientRect(this.Hwnd);
            if (rect.Width <= 0 || rect.Height <= 0)
            {
                _isPainting = false;
                return;
            }
            // 判断是否使用缓存
            if (useCache)
            {
                // 判断是否需要重新绘制
                if (this.CacheBitmap != null)
                {
                    if (this.CacheBitmap.Width != rect.Width || this.CacheBitmap.Height != rect.Height || force)
                    {
                        this.CacheBitmap.Dispose();
                        this.CacheBitmap = null;
                    }
                }
                // 判断是否有缓存
                if (this.CacheBitmap is null)
                {
                    this.CacheBitmap = new SKBitmap((int)rect.Width, (int)rect.Height);
                    using (SKCanvas cvs = new SKCanvas(this.CacheBitmap))
                    {
                        OnPaint(cvs, rect);
                    }
                }
                this.CacheBitmap.BitBltToHwnd(this.Hwnd);
            }
            else
            {
                // 直接绘制
                using (SKBitmap bmp = new SKBitmap((int)rect.Width, (int)rect.Height))
                {
                    using (SKCanvas cvs = new SKCanvas(bmp))
                    {
                        OnPaint(cvs, rect);
                    }
                    bmp.BitBltToHwnd(this.Hwnd);
                }
            }
            _isPainting = false;
        }

        #endregion
    }
}