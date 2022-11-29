using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using static SuyaaUI.Windows.Natives.Win32Api;
using static SuyaaUI.Windows.Natives.Win32Msg;

namespace SuyaaUI.Windows.Natives
{
    /* 方法 */
    public partial class Win32NativeWindow : INativeWindow
    {

        /// <summary>
        /// 创建窗口
        /// </summary>
        /// <returns></returns>
        public void Create(int left, int top, int width, int height)
        {
            // 初始化窗口类结构
            WNDCLASS wc = new WNDCLASS();
            wc.style = 0;
            wc.lpfnWndProc = SplashWindowProcedure;
            wc.hInstance = GetModuleHandle(null);
            wc.hbrBackground = (IntPtr)6;
            wc.lpszClassName = "SWindow";
            wc.cbClsExtra = 0;
            wc.cbWndExtra = 0;
            wc.hIcon = IntPtr.Zero;
            wc.hCursor = IntPtr.Zero;
            wc.lpszMenuName = "";

            // 注册窗口类
            RegisterClass(wc);
            // 创建并显示窗口
            _hWnd = CreateWindowEx(0,
              wc.lpszClassName,
              "这是一个Win32窗口",
              (int)WS_STYLE.WS_OVERLAPPEDWINDOW,
              left, top, width, height,
              IntPtr.Zero, IntPtr.Zero, GetModuleHandle(null), IntPtr.Zero);


            //// 获取DC
            //IntPtr hdc = GetDC(hwnd);

        }

        /// <summary>
        /// 设置图标
        /// </summary>
        /// <param name="bitmap"></param>
        public void SetIcon(SKBitmap bitmap)
        {
            using (Bitmap bmp = new Bitmap(bitmap.Width, bitmap.Height))
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        var color = bitmap.GetPixel(x, y);
                        bmp.SetPixel(x, y, Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue));
                    }
                }
                IntPtr icon = bmp.GetHicon();
                SendMessage(_hWnd, WM_SETICON, ICON_BIG, icon);
                SendMessage(_hWnd, WM_SETICON, ICON_SMALL, icon);
            }
        }

        /// <summary>
        /// 设置图标
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetIcon(string path)
        {
            using (var fs = egg.IO.OpenFile(path))
            {
                using (var stream = new SKManagedStream(fs))
                {
                    using (SKBitmap bmp = SKBitmap.Decode(stream))
                    {
                        SetIcon(bmp);
                    }
                }
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        public void Show()
        {
            ShowWindow(_hWnd, 1);
            UpdateWindow(_hWnd);
            // 进入消息循环
            MSG msg = new MSG();
            while (true)
            {
                try
                {
                    GetMessage(ref msg, IntPtr.Zero, 0, 0);
                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
                }
                catch { }
            }
        }

    }
}
