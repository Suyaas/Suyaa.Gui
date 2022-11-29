using SkiaSharp;
using SuyaaUI.Blocks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using static SuyaaUI.Windows.Natives.Win32Api;
using static SuyaaUI.Windows.Natives.Win32Msg;

namespace SuyaaUI.Windows.Natives
{
    /// <summary>
    /// Windows原生接口
    /// </summary>
    public partial class Win32NativeWindow : Block, INativeWindow
    {
        private void OnWMPiant()
        {
            SKBitmap bmp = base.Bitmap;
            // 获取DC
            IntPtr hdc = GetDC(_hWnd);
            //创建内存DC
            IntPtr hdcMem = CreateCompatibleDC(hdc);
            // 创建图像信息
            BitmapInfo bmpinfo = new BitmapInfo();
            bmpinfo.bmiHeader.biSize = (uint)Marshal.SizeOf<BitmapInfoHeader>();
            bmpinfo.bmiHeader.biWidth = bmp.Width;
            bmpinfo.bmiHeader.biHeight = -bmp.Height;
            bmpinfo.bmiHeader.biPlanes = 1;
            bmpinfo.bmiHeader.biBitCount = 32;
            bmpinfo.bmiHeader.biCompression = BI_RGB;
            bmpinfo.bmiHeader.biSizeImage = (uint)(bmp.Width * bmp.Height * 4);
            bmpinfo.bmiHeader.biXPelsPerMeter = 0;
            bmpinfo.bmiHeader.biClrImportant = 0;
            bmpinfo.bmiHeader.biClrUsed = 0;
            // 创建内存图像
            IntPtr hBmp = CreateDIBSection(hdcMem, ref bmpinfo, DIB_RGB_COLORS, out IntPtr pDibs, IntPtr.Zero, 0);
            // 填充图像内容
            Marshal.Copy(base.Bitmap.Bytes, 0, pDibs, base.Bitmap.Bytes.Length);
            // 将bmp内存空间分配给内存DC
            IntPtr hOldSel = SelectObject(hdcMem, hBmp);
            // 将内存DC的内容复制到屏幕显示DC中,完成显示
            BitBlt(hdc, 0, 0, bmp.Width, bmp.Height, hdcMem, 0, 0, (uint)TernaryRasterOperations.SRCCOPY);//SRCCOPY 完全覆盖
            // 清除资源
            SelectObject(hdcMem, hOldSel);
            DeleteDC(hdcMem);
            DeleteDC(hdc);
        }

        // 窗口过程
        private int SplashWindowProcedure(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case Win32Msg.WM_DESTROY: // 退出程序
                    PostQuitMessage(0);
                    Environment.Exit(0);
                    break;
                case WM_DWMNCRENDERINGCHANGED: Debug.WriteLine(nameof(WM_DWMNCRENDERINGCHANGED)); break;
                case WM_TIMER: Debug.WriteLine(nameof(WM_TIMER)); break;
                case WM_NCMOUSEMOVE: Debug.WriteLine(nameof(WM_NCMOUSEMOVE)); break;
                case WM_NCLBUTTONDOWN: Debug.WriteLine(nameof(WM_NCLBUTTONDOWN)); break;
                case WM_MOUSEMOVE: Debug.WriteLine(nameof(WM_MOUSEMOVE)); break;
                case WM_GETMINMAXINFO: Debug.WriteLine(nameof(WM_GETMINMAXINFO)); break;
                case WM_NCCREATE: Debug.WriteLine(nameof(WM_NCCREATE)); break;
                case WM_NCCALCSIZE: Debug.WriteLine(nameof(WM_NCCALCSIZE)); break;
                case WM_CREATE: Debug.WriteLine(nameof(WM_CREATE)); break;
                case WM_SHOWWINDOW: Debug.WriteLine(nameof(WM_SHOWWINDOW)); break;
                case WM_WINDOWPOSCHANGING: Debug.WriteLine(nameof(WM_WINDOWPOSCHANGING)); break;
                case WM_ACTIVATEAPP: Debug.WriteLine(nameof(WM_ACTIVATEAPP)); break;
                case WM_NCACTIVATE: Debug.WriteLine(nameof(WM_NCACTIVATE)); break;
                case WM_GETICON: Debug.WriteLine(nameof(WM_GETICON)); break;
                case WM_ACTIVATE: Debug.WriteLine(nameof(WM_ACTIVATE)); break;
                case WM_SETFOCUS: Debug.WriteLine(nameof(WM_SETFOCUS)); break;
                case WM_NCPAINT: Debug.WriteLine(nameof(WM_NCPAINT)); break;
                case WM_ERASEBKGND: Debug.WriteLine(nameof(WM_ERASEBKGND)); break;
                case WM_WINDOWPOSCHANGED: Debug.WriteLine(nameof(WM_WINDOWPOSCHANGED)); break;
                case WM_SIZE: Debug.WriteLine(nameof(WM_SIZE)); break;
                case WM_MOVE: Debug.WriteLine(nameof(WM_MOVE)); break;
                case WM_PAINT: OnWMPiant(); break;
                case WM_KILLFOCUS: Debug.WriteLine(nameof(WM_KILLFOCUS)); break;
                case WM_IME_SETCONTEXT: Debug.WriteLine(nameof(WM_IME_SETCONTEXT)); break;
                case WM_IME_NOTIFY: Debug.WriteLine(nameof(WM_IME_NOTIFY)); break;
                case WM_IME_REQUEST: Debug.WriteLine(nameof(WM_IME_REQUEST)); break;
                default: Debug.WriteLine($"Message = {msg}(0x{msg.ToString("X2")})"); break;
            }
            return DefWindowProc(hwnd, msg, wParam, lParam);
        }

        // 私有变量
        private IntPtr _hWnd;

        /// <summary>
        /// Windows原生接口
        /// </summary>
        public Win32NativeWindow() : base(320, 240)
        {
            _hWnd = IntPtr.Zero;
        }

    }
}
