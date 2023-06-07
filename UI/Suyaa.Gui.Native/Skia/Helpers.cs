using SkiaSharp;
using Suyaa.Gui.Native.Win32.Apis;
using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Skia
{
    /// <summary>
    /// 助手类
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// 贴图到对象
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="hwnd"></param>
        public static void BitBltToHwnd(this SKBitmap bmp, IntPtr hwnd)
        {
            byte[] bytes = bmp.Bytes;

            // 获取DC
            IntPtr hdc = User32.GetDC(hwnd);
            //创建内存DC
            IntPtr hdcMem = Gdi32.CreateCompatibleDC(hdc);
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

            IntPtr hBmp = Gdi32.CreateDIBSection(hdcMem, ref bmpinfo, Gdi32.DIB_RGB_COLORS, out IntPtr pDibs, IntPtr.Zero, 0);

            //IntPtr ptr = Marshal.AllocHGlobal(bytes.Length);
            // 复制内存
            Marshal.Copy(bytes, 0, pDibs, bytes.Length);
            // 将bmp内存空间分配给内存DC
            IntPtr hOldSel = Gdi32.SelectObject(hdcMem, hBmp);
            //将内存DC的内容复制到屏幕显示DC中,完成显示
            Gdi32.BitBlt(hdc, 0, 0, bmp.Width, bmp.Height, hdcMem, 0, 0, (uint)Gdi32.TernaryRasterOperations.SRCCOPY);//SRCCOPY 完全覆盖
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
    }
}
