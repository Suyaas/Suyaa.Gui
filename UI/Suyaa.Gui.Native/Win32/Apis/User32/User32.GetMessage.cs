﻿using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll GetMessage */
    public partial class User32
    {
        ///// <summary>
        ///// GetMessage
        ///// </summary>
        ///// <param name="msg"></param>
        ///// <param name="hwnd"></param>
        ///// <param name="minFilter"></param>
        ///// <param name="maxFilter"></param>
        ///// <returns></returns>
        //[LibraryImport(Libraries.User32, CharSet = CharSet.Auto)]
        //public static partial bool GetMessage(
        //    ref MSG msg,
        //    IntPtr hwnd = default,
        //    int minFilter = 0,
        //    int maxFilter = 0);

        /// <summary>
        /// GetMessage
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="hwnd"></param>
        /// <param name="minFilter"></param>
        /// <param name="maxFilter"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        public static partial BOOL GetMessage(
            out MSG msg,
            IntPtr hwnd = default,
            int minFilter = 0,
            int maxFilter = 0);

        /// <summary>
        /// GetMessageA
        /// </summary>
        /// <param name="lpMsg"></param>
        /// <param name="hWnd"></param>
        /// <param name="wMsgFilterMin"></param>
        /// <param name="wMsgFilterMax"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        public static partial BOOL GetMessageA(
            ref MSG lpMsg,
            IntPtr hWnd = default,
            uint wMsgFilterMin = 0,
            uint wMsgFilterMax = 0);

        /// <summary>
        /// GetMessageW
        /// </summary>
        /// <param name="lpMsg"></param>
        /// <param name="hWnd"></param>
        /// <param name="wMsgFilterMin"></param>
        /// <param name="wMsgFilterMax"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        public static partial BOOL GetMessageW(
            ref MSG lpMsg,
            IntPtr hWnd = default,
            uint wMsgFilterMin = 0,
            uint wMsgFilterMax = 0);
    }
}
