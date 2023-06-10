using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* gdi32.dll GetDeviceCaps */
    public partial class Gdi32
    {
        /// <summary>
        /// DRIVERVERSION
        /// </summary>
        public const int DRIVERVERSION = 0;
        /// <summary>
        /// TECHNOLOGY
        /// </summary>
        public const int TECHNOLOGY = 2;
        /// <summary>
        /// HORZSIZE
        /// </summary>
        public const int HORZSIZE = 4;
        /// <summary>
        /// VERTSIZE
        /// </summary>
        public const int VERTSIZE = 6;
        /// <summary>
        /// HORZRES
        /// </summary>
        public const int HORZRES = 8;
        /// <summary>
        /// VERTRES
        /// </summary>
        public const int VERTRES = 10;
        /// <summary>
        /// BITSPIXEL
        /// </summary>
        public const int BITSPIXEL = 12;
        /// <summary>
        /// PLANES
        /// </summary>
        public const int PLANES = 14;
        /// <summary>
        /// NUMBRUSHES
        /// </summary>
        public const int NUMBRUSHES = 16;
        /// <summary>
        /// NUMPENS
        /// </summary>
        public const int NUMPENS = 18;
        /// <summary>
        /// NUMMARKERS
        /// </summary>
        public const int NUMMARKERS = 20;
        /// <summary>
        /// NUMFONTS
        /// </summary>
        public const int NUMFONTS = 22;
        /// <summary>
        /// NUMCOLORS
        /// </summary>
        public const int NUMCOLORS = 24;
        /// <summary>
        /// PDEVICESIZE
        /// </summary>
        public const int PDEVICESIZE = 26;
        /// <summary>
        /// CURVECAPS
        /// </summary>
        public const int CURVECAPS = 28;
        /// <summary>
        /// LINECAPS
        /// </summary>
        public const int LINECAPS = 30;
        /// <summary>
        /// POLYGONALCAPS
        /// </summary>
        public const int POLYGONALCAPS = 32;
        /// <summary>
        /// TEXTCAPS
        /// </summary>
        public const int TEXTCAPS = 34;
        /// <summary>
        /// CLIPCAPS
        /// </summary>
        public const int CLIPCAPS = 36;
        /// <summary>
        /// RASTERCAPS
        /// </summary>
        public const int RASTERCAPS = 38;
        /// <summary>
        /// ASPECTX
        /// </summary>
        public const int ASPECTX = 40;
        /// <summary>
        /// ASPECTY
        /// </summary>
        public const int ASPECTY = 42;
        /// <summary>
        /// ASPECTXY
        /// </summary>
        public const int ASPECTXY = 44;
        /// <summary>
        /// SHADEBLENDCAPS
        /// </summary>
        public const int SHADEBLENDCAPS = 45;
        /// <summary>
        /// LOGPIXELSX
        /// </summary>
        public const int LOGPIXELSX = 88;
        /// <summary>
        /// LOGPIXELSY
        /// </summary>
        public const int LOGPIXELSY = 90;
        /// <summary>
        /// SIZEPALETTE
        /// </summary>
        public const int SIZEPALETTE = 104;
        /// <summary>
        /// NUMRESERVED
        /// </summary>
        public const int NUMRESERVED = 106;
        /// <summary>
        /// COLORRES
        /// </summary>
        public const int COLORRES = 108;
        /// <summary>
        /// PHYSICALWIDTH
        /// </summary>
        public const int PHYSICALWIDTH = 110;
        /// <summary>
        /// PHYSICALHEIGHT
        /// </summary>
        public const int PHYSICALHEIGHT = 111;
        /// <summary>
        /// PHYSICALOFFSETX
        /// </summary>
        public const int PHYSICALOFFSETX = 112;
        /// <summary>
        /// PHYSICALOFFSETY
        /// </summary>
        public const int PHYSICALOFFSETY = 113;
        /// <summary>
        /// SCALINGFACTORX
        /// </summary>
        public const int SCALINGFACTORX = 114;
        /// <summary>
        /// SCALINGFACTORY
        /// </summary>
        public const int SCALINGFACTORY = 115;
        /// <summary>
        /// VREFRESH
        /// </summary>
        public const int VREFRESH = 116;
        /// <summary>
        /// DESKTOPVERTRES
        /// </summary>
        public const int DESKTOPVERTRES = 117;
        /// <summary>
        /// DESKTOPHORZRES
        /// </summary>
        public const int DESKTOPHORZRES = 118;
        /// <summary>
        /// BLTALIGNMENT
        /// </summary>
        public const int BLTALIGNMENT = 119;

        /// <summary>
        /// GetDeviceCaps
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.Gdi32)]
        public static partial int GetDeviceCaps(
            IntPtr hdc, // handle to DC
            int nIndex // index of capability
        );

    }
}
