using SkiaSharp;
using Suyaa.Gui.Native.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Linux.Apis
{
    /*
     * 通用函数
     */
    public partial class LibX11
    {

        /// <summary>
        /// 创建一个简单窗口
        /// </summary>
        /// <param name="display"></param>
        /// <param name="screen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static IntPtr CreateSimpleWindow(IntPtr display, short screen, short x, short y, ushort width, ushort height)
        {
            return XCreateSimpleWindow(display, XRootWindow(display, screen), x, y, width, height, 1, XBlackPixel(display, screen), XWhitePixel(display, screen));
        }

        /// <summary>
        /// 设置窗口标题
        /// </summary>
        /// <param name="display"></param>
        /// <param name="window"></param>
        /// <param name="title"></param>
        public unsafe static void SetWindowTitle(IntPtr display, IntPtr window, string title)
        {
            XTextProperty textProperty = new XTextProperty();
            Xutf8TextListToTextProperty(display, title.AsPtr(), 1, LibX11.XICCEncodingStyle.XCompoundTextStyle, ref textProperty);
            XSetWMName(display, window, ref textProperty);
        }

        ///// <summary>
        ///// 将SKBitmap转化为XImage
        ///// </summary>
        ///// <param name="skBitmap"></param>
        ///// <returns></returns>
        //public static IntPtr ConvertSKBitmapToXImage(IntPtr display, short screen, SKBitmap bitmap)
        //{
        //    //short bpp = (short)(8 * bitmap.BytesPerPixel);
        //    //XImage image = XCreateImage(
        //    //    display,
        //    //    XDefaultVisual(display, screen),
        //    //    (ushort)(bitmap.AlphaType == SKAlphaType.Premul ? 32 : 24),
        //    //    ZPixmap,
        //    //    0,
        //    //    bitmap.GetPixels(),
        //    //    (ushort)bitmap.Width,
        //    //    (ushort)bitmap.Height,
        //    //    bpp,
        //    //    (short)(bitmap.RowBytes - 4 * bitmap.Width)
        //    //    );
        //    //Console.WriteLine($"SizeOf(short) = {Marshal.SizeOf((short)0)}");
        //    //Console.WriteLine($"SizeOf(uint) = {Marshal.SizeOf((uint)0)}");
        //    //Console.WriteLine($"SizeOf(image) = {Marshal.SizeOf(image)}");

        //    //image.Width = (short)bitmap.Width;
        //    //image.Height = (short)bitmap.Height;
        //    //image.Format = ZPixmap;
        //    //image.Data = bitmap.GetPixels();
        //    //image.ByteOrder = LSBFirst;
        //    //image.BitmapUnit = bpp;
        //    //image.BitmapBitOrder = LSBFirst;
        //    //image.BitmapPad = bpp;
        //    ////image.Depth = (bitmap.AlphaType ==  kPremul_SkAlphaType ? 32 : 24);
        //    //image.Depth = (short)(bitmap.AlphaType == SKAlphaType.Premul ? 32 : 24);
        //    //image.BytesPerLine = (short)(bitmap.RowBytes - 4 * bitmap.Width);
        //    //image.BitsPerPixel = bpp;
        //    //int res = XInitImage(ref image);
        //    //Console.WriteLine($"XInitImage = {res}");
        //    //return image;
        //}

    }
}
