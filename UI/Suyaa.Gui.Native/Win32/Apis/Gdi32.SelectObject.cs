﻿using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* gdi32.dll SelectObject */
    public partial class Gdi32
    {
        /// <summary>
        /// SelectObject
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="hgdiobj"></param>
        /// <returns></returns>
        [DllImport(Libraries.Gdi32)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
    }
}
