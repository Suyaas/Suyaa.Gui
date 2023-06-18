using Suyaa.Gui.Native.Win32.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Win32
{
    /// <summary>
    /// 光标
    /// </summary>
    public sealed class Cursor : IHandle, ICursor
    {
        // 句柄
        private readonly IntPtr _handle;

        /// <summary>
        /// 句柄
        /// </summary>
        public nint Handle => _handle;

        /// <summary>
        /// 创建一个光标
        /// </summary>
        /// <param name="handle"></param>
        public Cursor(nint handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// 从系统资源创建一个光标
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public static Cursor Create(int resourceId)
        {
            return new Cursor(User32.LoadCursorW(IntPtr.Zero, (IntPtr)resourceId));
        }
    }

    /// <summary>
    /// 系统默认光标
    /// </summary>
    public static class Cursors
    {
        // 静态变量
        private static Cursor? s_appStarting;
        private static Cursor? s_arrow;
        private static Cursor? s_cross;
        private static Cursor? s_defaultCursor;
        private static Cursor? s_iBeam;
        private static Cursor? s_no;
        private static Cursor? s_sizeAll;
        private static Cursor? s_sizeNESW;
        private static Cursor? s_sizeNS;
        private static Cursor? s_sizeNWSE;
        private static Cursor? s_sizeWE;
        private static Cursor? s_upArrow;
        private static Cursor? s_wait;
        private static Cursor? s_help;
        //private static Cursor? s_hSplit;
        //private static Cursor? s_vSplit;
        //private static Cursor? s_noMove2D;
        //private static Cursor? s_noMoveHoriz;
        //private static Cursor? s_noMoveVert;
        //private static Cursor? s_panEast;
        //private static Cursor? s_panNE;
        //private static Cursor? s_panNorth;
        //private static Cursor? s_panNW;
        //private static Cursor? s_panSE;
        //private static Cursor? s_panSouth;
        //private static Cursor? s_panSW;
        //private static Cursor? s_panWest;
        private static Cursor? s_hand;

        /// <summary>
        /// AppStarting
        /// </summary>
        public static Cursor AppStarting => s_appStarting ??= Cursor.Create(User32.CursorResourceId.IDC_APPSTARTING);

        /// <summary>
        /// Arrow
        /// </summary>
        public static Cursor Arrow => s_arrow ??= Cursor.Create(User32.CursorResourceId.IDC_ARROW);

        /// <summary>
        /// Cross
        /// </summary>
        public static Cursor Cross => s_cross ??= Cursor.Create(User32.CursorResourceId.IDC_CROSS);

        /// <summary>
        /// Default
        /// </summary>
        public static Cursor Default => s_defaultCursor ??= Cursor.Create(User32.CursorResourceId.IDC_ARROW);

        /// <summary>
        /// IBeam
        /// </summary>
        public static Cursor IBeam => s_iBeam ??= Cursor.Create(User32.CursorResourceId.IDC_IBEAM);

        /// <summary>
        /// No
        /// </summary>
        public static Cursor No => s_no ??= Cursor.Create(User32.CursorResourceId.IDC_NO);

        /// <summary>
        /// SizeAll
        /// </summary>
        public static Cursor SizeAll => s_sizeAll ??= Cursor.Create(User32.CursorResourceId.IDC_SIZEALL);

        /// <summary>
        /// SizeNESW
        /// </summary>
        public static Cursor SizeNESW => s_sizeNESW ??= Cursor.Create(User32.CursorResourceId.IDC_SIZENESW);

        /// <summary>
        /// SizeNS
        /// </summary>
        public static Cursor SizeNS => s_sizeNS ??= Cursor.Create(User32.CursorResourceId.IDC_SIZENS);

        /// <summary>
        /// SizeNWSE
        /// </summary>
        public static Cursor SizeNWSE => s_sizeNWSE ??= Cursor.Create(User32.CursorResourceId.IDC_SIZENWSE);

        /// <summary>
        /// SizeWE
        /// </summary>
        public static Cursor SizeWE => s_sizeWE ??= Cursor.Create(User32.CursorResourceId.IDC_SIZEWE);

        /// <summary>
        /// UpArrow
        /// </summary>
        public static Cursor UpArrow => s_upArrow ??= Cursor.Create(User32.CursorResourceId.IDC_UPARROW);

        /// <summary>
        /// WaitCursor
        /// </summary>
        public static Cursor WaitCursor => s_wait ??= Cursor.Create(User32.CursorResourceId.IDC_WAIT);

        /// <summary>
        /// Help
        /// </summary>
        public static Cursor Help => s_help ??= Cursor.Create(User32.CursorResourceId.IDC_HELP);

        /// <summary>
        /// Hand
        /// </summary>
        public static Cursor Hand => s_hand ??= new Cursor(User32.CursorResourceId.IDC_HAND);

        /// <summary>
        /// 预加载
        /// </summary>
        public static void Load()
        {
            s_hand ??= new Cursor(User32.CursorResourceId.IDC_HAND);
        }
    }
}
