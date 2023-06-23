using SkiaSharp;
using Suyaa.Gui.Native.Win32.Apis;
using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Helpers
{
    /// <summary>
    /// 助手类
    /// </summary>
    public static class SKBitmapHelper
    {
        /// <summary>
        /// 贴图到对象
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="hwnd"></param>
        public static void BitBltToHwnd(this SKBitmap bmp, nint hwnd)
        {
            byte[] bytes = bmp.Bytes;

            // 获取DC
            nint hdc = User32.GetDC(hwnd);
            // 创建内存DC
            nint hdcMem = Gdi32.CreateCompatibleDC(hdc);
            // 建立图像信息
            Gdi32.BitmapInfo bmpinfo = new Gdi32.BitmapInfo();
            bmpinfo.bmiHeader.biSize = (uint)Marshal.SizeOf<Gdi32.BitmapInfoHeader>();
            bmpinfo.bmiHeader.biWidth = bmp.Width;
            bmpinfo.bmiHeader.biHeight = -bmp.Height;
            bmpinfo.bmiHeader.biPlanes = 1;
            bmpinfo.bmiHeader.biBitCount = 32;
            bmpinfo.bmiHeader.biCompression = Gdi32.BI_RGB;
            bmpinfo.bmiHeader.biSizeImage = (uint)(bmp.Width * bmp.Height * 4);
            bmpinfo.bmiHeader.biXPelsPerMeter = 0;
            bmpinfo.bmiHeader.biClrImportant = 0;
            bmpinfo.bmiHeader.biClrUsed = 0;
            // 创建内存图像
            nint hBmp = Gdi32.CreateDIBSection(hdcMem, ref bmpinfo, Gdi32.DIB_RGB_COLORS, out nint pDibs, nint.Zero, 0);
            // 复制字节数组到内存图像
            Marshal.Copy(bytes, 0, pDibs, bytes.Length);
            // 将bmp内存空间分配给内存DC
            nint hOldSel = Gdi32.SelectObject(hdcMem, hBmp);
            //将内存DC的内容复制到屏幕显示DC中,完成显示
            Gdi32.BitBlt(hdc, 0, 0, bmp.Width, bmp.Height, hdcMem, 0, 0, Gdi32.TernaryRasterOperations.SRCCOPY);//SRCCOPY 完全覆盖
            // 清除资源                                                                                       
            Gdi32.SelectObject(hdcMem, hOldSel);
            // 释放内存DC
            Gdi32.DeleteDC(hdcMem);
            // 释放句柄
            User32.ReleaseDC(hwnd, hdc);
            // 释放其他数据
            Gdi32.DeleteObject(pDibs);
            Gdi32.DeleteObject(hBmp);
            Gdi32.DeleteObject(hOldSel);
            bytes = new byte[0];
        }

        /// <summary>
        /// 根据贴图创建图标句柄
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static nint CreateIcon(this SKBitmap bmp)
        {
            // 获取图像的字节数组
            byte[] bytes = bmp.Bytes;
            // 获取DC
            nint hdc = User32.GetDC(IntPtr.Zero);
            // 创建内存DC
            nint hdcMem = Gdi32.CreateCompatibleDC(hdc);
            // 建立图像信息
            Gdi32.BitmapInfo bmpinfo = new Gdi32.BitmapInfo();
            bmpinfo.bmiHeader.biSize = (uint)Marshal.SizeOf<Gdi32.BitmapInfoHeader>();
            bmpinfo.bmiHeader.biWidth = bmp.Width;
            bmpinfo.bmiHeader.biHeight = -bmp.Height;
            bmpinfo.bmiHeader.biPlanes = 1;
            bmpinfo.bmiHeader.biBitCount = 32;
            bmpinfo.bmiHeader.biCompression = Gdi32.BI_RGB;
            bmpinfo.bmiHeader.biSizeImage = (uint)(bmp.Width * bmp.Height * 4);
            bmpinfo.bmiHeader.biXPelsPerMeter = 0;
            bmpinfo.bmiHeader.biClrImportant = 0;
            bmpinfo.bmiHeader.biClrUsed = 0;
            // 创建内存图像
            var hBmp = (Gdi32.HBITMAP)Gdi32.CreateDIBSection(hdcMem, ref bmpinfo, Gdi32.DIB_RGB_COLORS, out nint pDibs, nint.Zero, 0);
            // 复制字节数组到内存图像
            Marshal.Copy(bytes, 0, pDibs, bytes.Length);
            // 建立遮罩
            Gdi32.HBITMAP hbmpMask = Gdi32.CreateCompatibleBitmap((Gdi32.HDC)hdc, bmp.Width, bmp.Height);
            User32.ICONINFO ii = new User32.ICONINFO();
            ii.fIcon = BOOL.TRUE;
            ii.hbmMask = hbmpMask;
            ii.hbmColor = hBmp;
            nint hIcon = User32.CreateIconIndirect(ref ii);
            // 释放内存DC
            Gdi32.DeleteDC(hdcMem);
            // 释放句柄
            User32.ReleaseDC(IntPtr.Zero, hdc);
            // 释放其他数据
            Gdi32.DeleteObject(pDibs);
            Gdi32.DeleteObject(hBmp);
            Gdi32.DeleteObject(hbmpMask);
            // 释放数组
            bytes = new byte[0];
            return hIcon;
        }
    }
}
