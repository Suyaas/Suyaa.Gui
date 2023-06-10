using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /// <summary>
    /// Gdi32
    /// </summary>
    public partial class Gdi32
    {
        #region 颜色压缩
        /// <summary>
        /// BI_RGB
        /// </summary>
        public const int BI_RGB = 0;
        /// <summary>
        /// BI_RLE8
        /// </summary>
        public const int BI_RLE8 = 1;
        /// <summary>
        /// BI_RLE4
        /// </summary>
        public const int BI_RLE4 = 2;
        /// <summary>
        /// BI_BITFIELDS
        /// </summary>
        public const int BI_BITFIELDS = 3;
        #endregion

        #region DibColorMode
        /// <summary>
        /// DIB_RGB_COLORS
        /// </summary>
        public const int DIB_RGB_COLORS = 0x00;
        /// <summary>
        /// DIB_PAL_COLORS
        /// </summary>
        public const int DIB_PAL_COLORS = 0x01;
        /// <summary>
        /// DIB_PAL_INDICES
        /// </summary>
        public const int DIB_PAL_INDICES = 0x02;
        #endregion

        #region 位图
        /// <summary>
        /// 位图头表
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BitmapInfoHeader
        {
            /// <summary>
            /// biSize
            /// </summary>
            public uint biSize;
            /// <summary>
            /// biWidth
            /// </summary>
            public int biWidth;
            /// <summary>
            /// biHeight
            /// </summary>
            public int biHeight;
            /// <summary>
            /// biPlanes
            /// </summary>
            public ushort biPlanes;
            /// <summary>
            /// biBitCount
            /// </summary>
            public ushort biBitCount;
            /// <summary>
            /// biCompression
            /// </summary>
            public uint biCompression;
            /// <summary>
            /// biSizeImage
            /// </summary>
            public uint biSizeImage;
            /// <summary>
            /// biXPelsPerMeter
            /// </summary>
            public int biXPelsPerMeter;
            /// <summary>
            /// biYPelsPerMeter
            /// </summary>
            public int biYPelsPerMeter;
            /// <summary>
            /// biClrUsed
            /// </summary>
            public uint biClrUsed;
            /// <summary>
            /// biClrImportant
            /// </summary>
            public uint biClrImportant;

            /// <summary>
            /// 初始化
            /// </summary>
            public void Init()
            {
                biSize = (uint)Marshal.SizeOf(this);
            }
        }

        /// <summary>
        /// 颜色码
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RgbQuad
        {
            /// <summary>
            /// 蓝
            /// </summary>
            public byte rgbBlue;
            /// <summary>
            /// 绿
            /// </summary>
            public byte rgbGreen;
            /// <summary>
            /// 红
            /// </summary>
            public byte rgbRed;
            /// <summary>
            /// Reserved
            /// </summary>
            public byte rgbReserved;
        }

        /// <summary>
        /// 位图信息
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BitmapInfo
        {
            /// <summary>
            /// 位图头表
            /// </summary>
            public BitmapInfoHeader bmiHeader;
            /// <summary>
            /// 颜色定义
            /// </summary>
            public RgbQuad bmiColors;
        }
        #endregion

        /// <summary>
        /// TernaryRasterOperations
        /// </summary>
        public enum TernaryRasterOperations : uint
        {
            /// <summary>
            /// SRCCOPY
            /// </summary>
            SRCCOPY = 0x00CC0020, /* dest = source*/
            /// <summary>
            /// SRCPAINT
            /// </summary>
            SRCPAINT = 0x00EE0086, /* dest = source OR dest*/
            /// <summary>
            /// SRCAND
            /// </summary>
            SRCAND = 0x008800C6, /* dest = source AND dest*/
            /// <summary>
            /// SRCINVERT
            /// </summary>
            SRCINVERT = 0x00660046, /* dest = source XOR dest*/
            /// <summary>
            /// SRCERASE
            /// </summary>
            SRCERASE = 0x00440328, /* dest = source AND (NOT dest )*/
            /// <summary>
            /// NOTSRCCOPY
            /// </summary>
            NOTSRCCOPY = 0x00330008, /* dest = (NOT source)*/
            /// <summary>
            /// NOTSRCERASE
            /// </summary>
            NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
            /// <summary>
            /// MERGECOPY
            /// </summary>
            MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)*/
            /// <summary>
            /// MERGEPAINT
            /// </summary>
            MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest*/
            /// <summary>
            /// PATCOPY
            /// </summary>
            PATCOPY = 0x00F00021, /* dest = pattern*/
            /// <summary>
            /// PATPAINT
            /// </summary>
            PATPAINT = 0x00FB0A09, /* dest = DPSnoo*/
            /// <summary>
            /// PATINVERT
            /// </summary>
            PATINVERT = 0x005A0049, /* dest = pattern XOR dest*/
            /// <summary>
            /// DSTINVERT
            /// </summary>
            DSTINVERT = 0x00550009, /* dest = (NOT dest)*/
            /// <summary>
            /// BLACKNESS
            /// </summary>
            BLACKNESS = 0x00000042, /* dest = BLACK*/
            /// <summary>
            /// WHITENESS
            /// </summary>
            WHITENESS = 0x00FF0062, /* dest = WHITE*/
        };

        /// <summary>
        /// 获取Dpi比例
        /// </summary>
        /// <returns></returns>
        public static float GetDpiScale()
        {
            // 计算dpi比例
            IntPtr screen = User32.GetDC(0);
            int t = Gdi32.GetDeviceCaps(screen, Gdi32.DESKTOPHORZRES);
            int d = Gdi32.GetDeviceCaps(screen, Gdi32.HORZRES);
            User32.ReleaseDC(0, screen);
            return (float)t / d;
        }
    }
}
