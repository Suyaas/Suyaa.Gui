using Forms;
using static Suyaa.Gui.Win32Native.Win32Api;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Messages;
using Suyaa.Gui.Native.Win32.Apis;
using Suyaa.Gui.Native.Skia;

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
        private IntPtr _defWindowProc = IntPtr.Zero;
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
            this.Styles = new Styles();
            this.Styles.Set<float>(StyleType.Width, 300);
            this.Styles.Set<float>(StyleType.Height, 300);
        }

        #endregion

        #region 私有函数

        // 接收到绘制消息
        private void WinProcPaint()
        {
            IntPtr hwnd = this.Hwnd;
            // 获取 是否使用缓存 样式
            var useCache = this.Styles.Get<bool>(StyleType.UseCache);
            // 获取宽高
            var width = this.Styles.Get<float>(StyleType.Width);
            var height = this.Styles.Get<float>(StyleType.Height);
            // 判断是否使用缓存
            if (useCache)
            {
                // 判断是否有缓存
                if (this.CacheBitmap is null)
                {
                    this.CacheBitmap = new SKBitmap((int)width, (int)height);
                    using (SKCanvas cvs = new SKCanvas(this.CacheBitmap))
                    {
                        Application.PostMessage(new PaintMessage(this.Handle, cvs));
                    }
                }
                this.CacheBitmap.BitBltToHwnd(hwnd);
            }
            else
            {
                // 直接绘制
                using (SKBitmap bmp = new SKBitmap((int)width, (int)height))
                {
                    using (SKCanvas cvs = new SKCanvas(bmp))
                    {
                        Application.PostMessage(new PaintMessage(this.Handle, cvs));
                    }
                    bmp.BitBltToHwnd(hwnd);
                }
            }
        }

        // 窗口过程
        private int WinProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            User32.WM wm = (User32.WM)msg;
            Debug.WriteLine($"[WinProc] Hwnd: 0x{hwnd.ToString("X2")}, Message: {wm.ToString()}(0x{msg.ToString("X2")})");
            User32.SetWindowLong(hwnd, User32.GWL.WNDPROC, _defWindowProc);
            switch (msg)
            {
                // 创建
                case WM_CREATE: break;
                // 绘制界面
                case WM_PAINT: WinProcPaint(); break;
                case WM_DESTROY:
                    PostQuitMessage(0);
                    break;
            }
            var res = User32.DefWindowProc(hwnd, msg, wParam, lParam);
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
        public void Initialize()
        {
            // 获取宽高
            var top = this.Styles.Get<float>(StyleType.Top);
            var left = this.Styles.Get<float>(StyleType.Left);
            var width = this.Styles.Get<float>(StyleType.Width);
            var height = this.Styles.Get<float>(StyleType.Height);

            // 初始化窗口类结构
            User32.WNDCLASS wc = new User32.WNDCLASS();

            _defWindowProc = wc.lpfnWndProc;

            wc.style = 0;
            wc.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_windProc);
            wc.hInstance = GetModuleHandle(null);
            wc.hbrBackground = (IntPtr)6;
            wc.lpszClassName = nameof(Win32Form);
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
            User32.RegisterClass(wc);
            // 创建并显示窗口
            IntPtr hwnd;
            hwnd = CreateWindowEx(0,
              wc.lpszClassName,
              this.Title,
              (int)WS_STYLE.WS_OVERLAPPEDWINDOW,
              (int)left, (int)top, (int)width, (int)height,
              IntPtr.Zero, IntPtr.Zero, GetModuleHandle(null), IntPtr.Zero);

            this.Hwnd = hwnd;
            Debug.WriteLine($"[Win32Form] Create 0x{hwnd.ToString("X2")}");

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
            ShowWindow(hwnd, 1);
            UpdateWindow(hwnd);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendMessage(IMessage msg)
        {
            return true;
        }

        /// <summary>
        /// 提交消息
        /// </summary>
        /// <param name="msg"></param>
        public void PostMessage(IMessage msg)
        {

        }

        #endregion
    }
}