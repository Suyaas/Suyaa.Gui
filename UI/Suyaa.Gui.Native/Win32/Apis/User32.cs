﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Win32Native.Win32Api;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /// <summary>
    /// user32.dll
    /// </summary>
    public partial class User32
    {
        /// <summary>
        /// WNDPROC
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate int WNDPROC(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Win32 Message
        /// </summary>
        public enum WM : uint
        {
            NULL = 0x0000,
            CREATE = 0x0001,
            DESTROY = 0x0002,
            MOVE = 0x0003,
            SIZE = 0x0005,
            ACTIVATE = 0x0006,
            SETFOCUS = 0x0007,
            KILLFOCUS = 0x0008,
            ENABLE = 0x000A,
            SETREDRAW = 0x000B,
            SETTEXT = 0x000C,
            GETTEXT = 0x000D,
            GETTEXTLENGTH = 0x000E,
            PAINT = 0x000F,
            CLOSE = 0x0010,
            QUERYENDSESSION = 0x0011,
            QUERYOPEN = 0x0013,
            ENDSESSION = 0x0016,
            QUIT = 0x0012,
            ERASEBKGND = 0x0014,
            SYSCOLORCHANGE = 0x0015,
            SHOWWINDOW = 0x0018,
            CTLCOLOR = 0x0019,
            SETTINGCHANGE = 0x001A,
            WININICHANGE = 0x001A,
            DEVMODECHANGE = 0x001B,
            ACTIVATEAPP = 0x001C,
            FONTCHANGE = 0x001D,
            TIMECHANGE = 0x001E,
            CANCELMODE = 0x001F,
            SETCURSOR = 0x0020,
            MOUSEACTIVATE = 0x0021,
            CHILDACTIVATE = 0x0022,
            QUEUESYNC = 0x0023,
            GETMINMAXINFO = 0x0024,
            PAINTICON = 0x0026,
            ICONERASEBKGND = 0x0027,
            NEXTDLGCTL = 0x0028,
            SPOOLERSTATUS = 0x002A,
            DRAWITEM = 0x002B,
            MEASUREITEM = 0x002C,
            DELETEITEM = 0x002D,
            VKEYTOITEM = 0x002E,
            CHARTOITEM = 0x002F,
            SETFONT = 0x0030,
            GETFONT = 0x0031,
            SETHOTKEY = 0x0032,
            GETHOTKEY = 0x0033,
            QUERYDRAGICON = 0x0037,
            COMPAREITEM = 0x0039,
            GETOBJECT = 0x003D,
            COMPACTING = 0x0041,
            COMMNOTIFY = 0x0044,
            WINDOWPOSCHANGING = 0x0046,
            WINDOWPOSCHANGED = 0x0047,
            POWER = 0x0048,
            COPYDATA = 0x004A,
            CANCELJOURNAL = 0x004B,
            NOTIFY = 0x004E,
            INPUTLANGCHANGEREQUEST = 0x0050,
            INPUTLANGCHANGE = 0x0051,
            TCARD = 0x0052,
            HELP = 0x0053,
            USERCHANGED = 0x0054,
            NOTIFYFORMAT = 0x0055,
            CONTEXTMENU = 0x007B,
            STYLECHANGING = 0x007C,
            STYLECHANGED = 0x007D,
            DISPLAYCHANGE = 0x007E,
            GETICON = 0x007F,
            SETICON = 0x0080,
            NCCREATE = 0x0081,
            NCDESTROY = 0x0082,
            NCCALCSIZE = 0x0083,
            NCHITTEST = 0x0084,
            NCPAINT = 0x0085,
            NCACTIVATE = 0x0086,
            GETDLGCODE = 0x0087,
            SYNCPAINT = 0x0088,
            NCMOUSEMOVE = 0x00A0,
            NCLBUTTONDOWN = 0x00A1,
            NCLBUTTONUP = 0x00A2,
            NCLBUTTONDBLCLK = 0x00A3,
            NCRBUTTONDOWN = 0x00A4,
            NCRBUTTONUP = 0x00A5,
            NCRBUTTONDBLCLK = 0x00A6,
            NCMBUTTONDOWN = 0x00A7,
            NCMBUTTONUP = 0x00A8,
            NCMBUTTONDBLCLK = 0x00A9,
            NCXBUTTONDOWN = 0x00AB,
            NCXBUTTONUP = 0x00AC,
            NCXBUTTONDBLCLK = 0x00AD,
            INPUT_DEVICE_CHANGE = 0x00FE,
            INPUT = 0x00FF,
            KEYFIRST = 0x0100,
            KEYDOWN = 0x0100,
            KEYUP = 0x0101,
            CHAR = 0x0102,
            DEADCHAR = 0x0103,
            SYSKEYDOWN = 0x0104,
            SYSKEYUP = 0x0105,
            SYSCHAR = 0x0106,
            SYSDEADCHAR = 0x0107,
            UNICHAR = 0x0109,
            KEYLAST = 0x0109,
            IME_STARTCOMPOSITION = 0x010D,
            IME_ENDCOMPOSITION = 0x010E,
            IME_COMPOSITION = 0x010F,
            IME_KEYLAST = 0x010F,
            INITDIALOG = 0x0110,
            COMMAND = 0x0111,
            SYSCOMMAND = 0x0112,
            TIMER = 0x0113,
            HSCROLL = 0x0114,
            VSCROLL = 0x0115,
            INITMENU = 0x0116,
            INITMENUPOPUP = 0x0117,
            GESTURE = 0x0119,
            GESTURENOTIFY = 0x011A,
            MENUSELECT = 0x011F,
            MENUCHAR = 0x0120,
            ENTERIDLE = 0x0121,
            MENURBUTTONUP = 0x0122,
            MENUDRAG = 0x0123,
            MENUGETOBJECT = 0x0124,
            UNINITMENUPOPUP = 0x0125,
            MENUCOMMAND = 0x0126,
            CHANGEUISTATE = 0x0127,
            UPDATEUISTATE = 0x0128,
            QUERYUISTATE = 0x0129,
            CTLCOLORMSGBOX = 0x0132,
            CTLCOLOREDIT = 0x0133,
            CTLCOLORLISTBOX = 0x0134,
            CTLCOLORBTN = 0x0135,
            CTLCOLORDLG = 0x0136,
            CTLCOLORSCROLLBAR = 0x0137,
            CTLCOLORSTATIC = 0x0138,
            MOUSEFIRST = 0x0200,
            MOUSEMOVE = 0x0200,
            LBUTTONDOWN = 0x0201,
            LBUTTONUP = 0x0202,
            LBUTTONDBLCLK = 0x0203,
            RBUTTONDOWN = 0x0204,
            RBUTTONUP = 0x0205,
            RBUTTONDBLCLK = 0x0206,
            MBUTTONDOWN = 0x0207,
            MBUTTONUP = 0x0208,
            MBUTTONDBLCLK = 0x0209,
            MOUSEWHEEL = 0x020A,
            XBUTTONDOWN = 0x020B,
            XBUTTONUP = 0x020C,
            XBUTTONDBLCLK = 0x020D,
            MOUSEHWHEEL = 0x020E,
            MOUSELAST = 0x020E,
            PARENTNOTIFY = 0x0210,
            ENTERMENULOOP = 0x0211,
            EXITMENULOOP = 0x0212,
            NEXTMENU = 0x0213,
            SIZING = 0x0214,
            CAPTURECHANGED = 0x0215,
            MOVING = 0x0216,
            POWERBROADCAST = 0x0218,
            DEVICECHANGE = 0x0219,
            MDICREATE = 0x0220,
            MDIDESTROY = 0x0221,
            MDIACTIVATE = 0x0222,
            MDIRESTORE = 0x0223,
            MDINEXT = 0x0224,
            MDIMAXIMIZE = 0x0225,
            MDITILE = 0x0226,
            MDICASCADE = 0x0227,
            MDIICONARRANGE = 0x0228,
            MDIGETACTIVE = 0x0229,
            MDISETMENU = 0x0230,
            ENTERSIZEMOVE = 0x0231,
            EXITSIZEMOVE = 0x0232,
            DROPFILES = 0x0233,
            MDIREFRESHMENU = 0x0234,
            POINTERDEVICECHANGE = 0x0238,
            POINTERDEVICEINRANGE = 0x0239,
            POINTERDEVICEOUTOFRANGE = 0x023A,
            TOUCH = 0x0240,
            NCPOINTERUPDATE = 0x0241,
            NCPOINTERDOWN = 0x0242,
            NCPOINTERUP = 0x0243,
            POINTERUPDATE = 0x0245,
            POINTERDOWN = 0x0246,
            POINTERUP = 0x0247,
            POINTERENTER = 0x0249,
            POINTERLEAVE = 0x024A,
            POINTERACTIVATE = 0x024B,
            POINTERCAPTURECHANGED = 0x024C,
            TOUCHHITTESTING = 0x024D,
            POINTERWHEEL = 0x024E,
            POINTERHWHEEL = 0x024F,
            POINTERROUTEDTO = 0x0251,
            POINTERROUTEDAWAY = 0x0252,
            POINTERROUTEDRELEASED = 0x0253,
            IME_SETCONTEXT = 0x0281,
            IME_NOTIFY = 0x0282,
            IME_CONTROL = 0x0283,
            IME_COMPOSITIONFULL = 0x0284,
            IME_SELECT = 0x0285,
            IME_CHAR = 0x0286,
            IME_REQUEST = 0x0288,
            IME_KEYDOWN = 0x0290,
            IME_KEYUP = 0x0291,
            MOUSEHOVER = 0x02A1,
            MOUSELEAVE = 0x02A3,
            NCMOUSEHOVER = 0x02A0,
            NCMOUSELEAVE = 0x02A2,
            WTSSESSION_CHANGE = 0x02B1,
            DPICHANGED = 0x02E0,
            DPICHANGED_BEFOREPARENT = 0x02E2,
            DPICHANGED_AFTERPARENT = 0x02E3,
            GETDPISCALEDSIZE = 0x02E4,
            CUT = 0x0300,
            COPY = 0x0301,
            PASTE = 0x0302,
            CLEAR = 0x0303,
            UNDO = 0x0304,
            RENDERFORMAT = 0x0305,
            RENDERALLFORMATS = 0x0306,
            DESTROYCLIPBOARD = 0x0307,
            DRAWCLIPBOARD = 0x0308,
            PAINTCLIPBOARD = 0x0309,
            VSCROLLCLIPBOARD = 0x030A,
            SIZECLIPBOARD = 0x030B,
            ASKCBFORMATNAME = 0x030C,
            CHANGECBCHAIN = 0x030D,
            HSCROLLCLIPBOARD = 0x030E,
            QUERYNEWPALETTE = 0x030F,
            PALETTEISCHANGING = 0x0310,
            PALETTECHANGED = 0x0311,
            HOTKEY = 0x0312,
            PRINT = 0x0317,
            PRINTCLIENT = 0x0318,
            APPCOMMAND = 0x0319,
            THEMECHANGED = 0x031A,
            CLIPBOARDUPDATE = 0x031D,
            DWMCOMPOSITIONCHANGED = 0x031E,
            DWMNCRENDERINGCHANGED = 0x031F,
            DWMCOLORIZATIONCOLORCHANGED = 0x0320,
            DWMWINDOWMAXIMIZEDCHANGE = 0x0321,
            DWMSENDICONICTHUMBNAIL = 0x0323,
            DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326,
            GETTITLEBARINFOEX = 0x033F,
            HANDHELDFIRST = 0x0358,
            HANDHELDLAST = 0x035F,
            AFXFIRST = 0x0360,
            AFXLAST = 0x037F,
            PENWINFIRST = 0x0380,
            PENWINLAST = 0x038F,
            USER = 0x0400,
            CHOOSEFONT_GETLOGFONT = USER + 1,
            APP = 0x8000,
            REFLECT = USER + 0x1C00,

            // Messages that are a combination of REFLECT with other messages.
            REFLECT_NOTIFY = REFLECT + NOTIFY,
            REFLECT_NOTIFYFORMAT = REFLECT + NOTIFYFORMAT,
            REFLECT_COMMAND = REFLECT + COMMAND,
            REFLECT_CHARTOITEM = REFLECT + CHARTOITEM,
            REFLECT_VKEYTOITEM = REFLECT + VKEYTOITEM,
            REFLECT_DRAWITEM = REFLECT + DRAWITEM,
            REFLECT_MEASUREITEM = REFLECT + MEASUREITEM,
            REFLECT_HSCROLL = REFLECT + HSCROLL,
            REFLECT_VSCROLL = REFLECT + VSCROLL,
            REFLECT_CTLCOLOR = REFLECT + CTLCOLOR,
            REFLECT_CTLCOLORBTN = REFLECT + CTLCOLORBTN,
            REFLECT_CTLCOLORDLG = REFLECT + CTLCOLORDLG,
            REFLECT_CTLCOLORMSGBOX = REFLECT + CTLCOLORMSGBOX,
            REFLECT_CTLCOLORSCROLLBAR = REFLECT + CTLCOLORSCROLLBAR,
            REFLECT_CTLCOLOREDIT = REFLECT + CTLCOLOREDIT,
            REFLECT_CTLCOLORLISTBOX = REFLECT + CTLCOLORLISTBOX,
            REFLECT_CTLCOLORSTATIC = REFLECT + CTLCOLORSTATIC
        }

        //[StructLayout(LayoutKind.Sequential)]
        //public struct MSG
        //{
        //    public IntPtr hwnd;
        //    public int message;
        //    public IntPtr wParam;
        //    public IntPtr lParam;
        //    public int time;
        //    public int pt_x;
        //    public int pt_y;
        //}

        /// <summary>
        /// MSG
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            /// <summary>
            /// hwnd
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// message
            /// </summary>
            public int message;
            /// <summary>
            /// wParam
            /// </summary>
            public IntPtr wParam;
            /// <summary>
            /// lParam
            /// </summary>
            public IntPtr lParam;
            /// <summary>
            /// time
            /// </summary>
            public int time;
            /// <summary>
            /// x
            /// </summary>
            public int pt_x;
            /// <summary>
            /// y
            /// </summary>
            public int pt_y;
        }

        ///// <summary>
        ///// MSG
        ///// </summary>
        //[StructLayout(LayoutKind.Sequential)]
        //public struct MSG
        //{
        //    /// <summary>
        //    /// hwnd
        //    /// </summary>
        //    public IntPtr hwnd;
        //    /// <summary>
        //    /// message
        //    /// </summary>
        //    public WM message;
        //    /// <summary>
        //    /// wParam
        //    /// </summary>
        //    public IntPtr wParam;
        //    /// <summary>
        //    /// lParam
        //    /// </summary>
        //    public IntPtr lParam;
        //    /// <summary>
        //    /// time
        //    /// </summary>
        //    public uint time;
        //    ///// <summary>
        //    ///// pt
        //    ///// </summary>
        //    //public Point pt;
        //    /// <summary>
        //    /// x
        //    /// </summary>
        //    public int pt_x;
        //    /// <summary>
        //    /// y
        //    /// </summary>
        //    public int pt_y;
        //}

        /// <summary>
        ///  GWL
        /// </summary>
        public enum GWL : int
        {
            /// <summary>
            /// WNDPROC
            /// </summary>
            WNDPROC = (-4),
            /// <summary>
            /// HWNDPARENT
            /// </summary>
            HWNDPARENT = (-8),
            /// <summary>
            /// STYLE
            /// </summary>
            STYLE = (-16),
            /// <summary>
            /// EXSTYLE
            /// </summary>
            EXSTYLE = (-20),
            /// <summary>
            /// ID
            /// </summary>
            ID = (-12),
        }

        /// <summary>
        /// WNDCLASS
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class WNDCLASS
        {
            /// <summary>
            /// style
            /// </summary>
            public int style = 0;
            /// <summary>
            /// lpfnWndProc
            /// </summary>
            public IntPtr lpfnWndProc = IntPtr.Zero;
            /// <summary>
            /// cbClsExtra
            /// </summary>
            public int cbClsExtra = 0;
            /// <summary>
            /// cbWndExtra
            /// </summary>
            public int cbWndExtra = 0;
            /// <summary>
            /// hInstance
            /// </summary>
            public IntPtr hInstance = IntPtr.Zero;
            /// <summary>
            /// hIcon
            /// </summary>
            public IntPtr hIcon = IntPtr.Zero;
            /// <summary>
            /// hCursor
            /// </summary>
            public IntPtr hCursor = IntPtr.Zero;
            /// <summary>
            /// hbrBackground
            /// </summary>
            public IntPtr hbrBackground = IntPtr.Zero;
            /// <summary>
            /// lpszMenuName
            /// </summary>
            public string? lpszMenuName = null;
            /// <summary>
            /// lpszClassName
            /// </summary>
            public string? lpszClassName = null;
        }
    }


}
