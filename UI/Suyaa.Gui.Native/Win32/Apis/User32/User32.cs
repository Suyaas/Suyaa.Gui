using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.Enums;
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
        public delegate IntPtr WNDPROC(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Win32 Message
        /// </summary>
        public enum WM : uint
        {
            /// <summary>
            /// NULL
            /// </summary>
            NULL = 0x0000,
            /// <summary>
            /// CREATE
            /// </summary>
            CREATE = 0x0001,
            /// <summary>
            /// DESTROY
            /// </summary>
            DESTROY = 0x0002,
            /// <summary>
            /// MOVE
            /// </summary>
            MOVE = 0x0003,
            /// <summary>
            /// SIZE
            /// </summary>
            SIZE = 0x0005,
            /// <summary>
            /// ACTIVATE
            /// </summary>
            ACTIVATE = 0x0006,
            /// <summary>
            /// SETFOCUS
            /// </summary>
            SETFOCUS = 0x0007,
            /// <summary>
            /// KILLFOCUS
            /// </summary>
            KILLFOCUS = 0x0008,
            /// <summary>
            /// ENABLE
            /// </summary>
            ENABLE = 0x000A,
            /// <summary>
            /// SETREDRAW
            /// </summary>
            SETREDRAW = 0x000B,
            /// <summary>
            /// SETTEXT
            /// </summary>
            SETTEXT = 0x000C,
            /// <summary>
            /// GETTEXT
            /// </summary>
            GETTEXT = 0x000D,
            /// <summary>
            /// GETTEXTLENGTH
            /// </summary>
            GETTEXTLENGTH = 0x000E,
            /// <summary>
            /// PAINT
            /// </summary>
            PAINT = 0x000F,
            /// <summary>
            /// CLOSE
            /// </summary>
            CLOSE = 0x0010,
            /// <summary>
            /// QUERYENDSESSION
            /// </summary>
            QUERYENDSESSION = 0x0011,
            /// <summary>
            /// QUERYOPEN
            /// </summary>
            QUERYOPEN = 0x0013,
            /// <summary>
            /// ENDSESSION
            /// </summary>
            ENDSESSION = 0x0016,
            /// <summary>
            /// QUIT
            /// </summary>
            QUIT = 0x0012,
            /// <summary>
            /// ERASEBKGND
            /// </summary>
            ERASEBKGND = 0x0014,
            /// <summary>
            /// SYSCOLORCHANGE
            /// </summary>
            SYSCOLORCHANGE = 0x0015,
            /// <summary>
            /// SHOWWINDOW
            /// </summary>
            SHOWWINDOW = 0x0018,
            /// <summary>
            /// CTLCOLOR
            /// </summary>
            CTLCOLOR = 0x0019,
            /// <summary>
            /// SETTINGCHANGE
            /// </summary>
            SETTINGCHANGE = 0x001A,
            /// <summary>
            /// WININICHANGE
            /// </summary>
            WININICHANGE = 0x001A,
            /// <summary>
            /// DEVMODECHANGE
            /// </summary>
            DEVMODECHANGE = 0x001B,
            /// <summary>
            /// ACTIVATEAPP
            /// </summary>
            ACTIVATEAPP = 0x001C,
            /// <summary>
            /// FONTCHANGE
            /// </summary>
            FONTCHANGE = 0x001D,
            /// <summary>
            /// TIMECHANGE
            /// </summary>
            TIMECHANGE = 0x001E,
            /// <summary>
            /// CANCELMODE
            /// </summary>
            CANCELMODE = 0x001F,
            /// <summary>
            /// SETCURSOR
            /// </summary>
            SETCURSOR = 0x0020,
            /// <summary>
            /// MOUSEACTIVATE
            /// </summary>
            MOUSEACTIVATE = 0x0021,
            /// <summary>
            /// CHILDACTIVATE
            /// </summary>
            CHILDACTIVATE = 0x0022,
            /// <summary>
            /// QUEUESYNC
            /// </summary>
            QUEUESYNC = 0x0023,
            /// <summary>
            /// GETMINMAXINFO
            /// </summary>
            GETMINMAXINFO = 0x0024,
            /// <summary>
            /// PAINTICON
            /// </summary>
            PAINTICON = 0x0026,
            /// <summary>
            /// ICONERASEBKGND
            /// </summary>
            ICONERASEBKGND = 0x0027,
            /// <summary>
            /// NEXTDLGCTL
            /// </summary>
            NEXTDLGCTL = 0x0028,
            /// <summary>
            /// SPOOLERSTATUS
            /// </summary>
            SPOOLERSTATUS = 0x002A,
            /// <summary>
            /// DRAWITEM
            /// </summary>
            DRAWITEM = 0x002B,
            /// <summary>
            /// MEASUREITEM
            /// </summary>
            MEASUREITEM = 0x002C,
            /// <summary>
            /// DELETEITEM
            /// </summary>
            DELETEITEM = 0x002D,
            /// <summary>
            /// VKEYTOITEM
            /// </summary>
            VKEYTOITEM = 0x002E,
            /// <summary>
            /// CHARTOITEM
            /// </summary>
            CHARTOITEM = 0x002F,
            /// <summary>
            /// SETFONT
            /// </summary>
            SETFONT = 0x0030,
            /// <summary>
            /// GETFONT
            /// </summary>
            GETFONT = 0x0031,
            /// <summary>
            /// SETHOTKEY
            /// </summary>
            SETHOTKEY = 0x0032,
            /// <summary>
            /// GETHOTKEY
            /// </summary>
            GETHOTKEY = 0x0033,
            /// <summary>
            /// QUERYDRAGICON
            /// </summary>
            QUERYDRAGICON = 0x0037,
            /// <summary>
            /// COMPAREITEM
            /// </summary>
            COMPAREITEM = 0x0039,
            /// <summary>
            /// GETOBJECT
            /// </summary>
            GETOBJECT = 0x003D,
            /// <summary>
            /// COMPACTING
            /// </summary>
            COMPACTING = 0x0041,
            /// <summary>
            /// COMMNOTIFY
            /// </summary>
            COMMNOTIFY = 0x0044,
            /// <summary>
            /// WINDOWPOSCHANGING
            /// </summary>
            WINDOWPOSCHANGING = 0x0046,
            /// <summary>
            /// WINDOWPOSCHANGED
            /// </summary>
            WINDOWPOSCHANGED = 0x0047,
            /// <summary>
            /// POWER
            /// </summary>
            POWER = 0x0048,
            /// <summary>
            /// COPYDATA
            /// </summary>
            COPYDATA = 0x004A,
            /// <summary>
            /// CANCELJOURNAL
            /// </summary>
            CANCELJOURNAL = 0x004B,
            /// <summary>
            /// NOTIFY
            /// </summary>
            NOTIFY = 0x004E,
            /// <summary>
            /// INPUTLANGCHANGEREQUEST
            /// </summary>
            INPUTLANGCHANGEREQUEST = 0x0050,
            /// <summary>
            /// INPUTLANGCHANGE
            /// </summary>
            INPUTLANGCHANGE = 0x0051,
            /// <summary>
            /// TCARD
            /// </summary>
            TCARD = 0x0052,
            /// <summary>
            /// HELP
            /// </summary>
            HELP = 0x0053,
            /// <summary>
            /// USERCHANGED
            /// </summary>
            USERCHANGED = 0x0054,
            /// <summary>
            /// NOTIFYFORMAT
            /// </summary>
            NOTIFYFORMAT = 0x0055,
            /// <summary>
            /// CONTEXTMENU
            /// </summary>
            CONTEXTMENU = 0x007B,
            /// <summary>
            /// STYLECHANGING
            /// </summary>
            STYLECHANGING = 0x007C,
            /// <summary>
            /// STYLECHANGED
            /// </summary>
            STYLECHANGED = 0x007D,
            /// <summary>
            /// DISPLAYCHANGE
            /// </summary>
            DISPLAYCHANGE = 0x007E,
            /// <summary>
            /// GETICON
            /// </summary>
            GETICON = 0x007F,
            /// <summary>
            /// SETICON
            /// </summary>
            SETICON = 0x0080,
            /// <summary>
            /// NCCREATE
            /// </summary>
            NCCREATE = 0x0081,
            /// <summary>
            /// NCDESTROY
            /// </summary>
            NCDESTROY = 0x0082,
            /// <summary>
            /// NCCALCSIZE
            /// </summary>
            NCCALCSIZE = 0x0083,
            /// <summary>
            /// NCHITTEST
            /// </summary>
            NCHITTEST = 0x0084,
            /// <summary>
            /// NCPAINT
            /// </summary>
            NCPAINT = 0x0085,
            /// <summary>
            /// NCACTIVATE
            /// </summary>
            NCACTIVATE = 0x0086,
            /// <summary>
            /// GETDLGCODE
            /// </summary>
            GETDLGCODE = 0x0087,
            /// <summary>
            /// SYNCPAINT
            /// </summary>
            SYNCPAINT = 0x0088,
            /// <summary>
            /// NCMOUSEMOVE
            /// </summary>
            NCMOUSEMOVE = 0x00A0,
            /// <summary>
            /// NCLBUTTONDOWN
            /// </summary>
            NCLBUTTONDOWN = 0x00A1,
            /// <summary>
            /// NCLBUTTONUP
            /// </summary>
            NCLBUTTONUP = 0x00A2,
            /// <summary>
            /// NCLBUTTONDBLCLK
            /// </summary>
            NCLBUTTONDBLCLK = 0x00A3,
            /// <summary>
            /// NCRBUTTONDOWN
            /// </summary>
            NCRBUTTONDOWN = 0x00A4,
            /// <summary>
            /// NCRBUTTONUP
            /// </summary>
            NCRBUTTONUP = 0x00A5,
            /// <summary>
            /// NCRBUTTONDBLCLK
            /// </summary>
            NCRBUTTONDBLCLK = 0x00A6,
            /// <summary>
            /// NCMBUTTONDOWN
            /// </summary>
            NCMBUTTONDOWN = 0x00A7,
            /// <summary>
            /// NCMBUTTONUP
            /// </summary>
            NCMBUTTONUP = 0x00A8,
            /// <summary>
            /// NCMBUTTONDBLCLK
            /// </summary>
            NCMBUTTONDBLCLK = 0x00A9,
            /// <summary>
            /// NCXBUTTONDOWN
            /// </summary>
            NCXBUTTONDOWN = 0x00AB,
            /// <summary>
            /// NCXBUTTONUP
            /// </summary>
            NCXBUTTONUP = 0x00AC,
            /// <summary>
            /// NCXBUTTONDBLCLK
            /// </summary>
            NCXBUTTONDBLCLK = 0x00AD,
            /// <summary>
            /// INPUT_DEVICE_CHANGE
            /// </summary>
            INPUT_DEVICE_CHANGE = 0x00FE,
            /// <summary>
            /// INPUT
            /// </summary>
            INPUT = 0x00FF,
            /// <summary>
            /// KEYFIRST
            /// </summary>
            KEYFIRST = 0x0100,
            /// <summary>
            /// KEYDOWN
            /// </summary>
            KEYDOWN = 0x0100,
            /// <summary>
            /// KEYUP
            /// </summary>
            KEYUP = 0x0101,
            /// <summary>
            /// CHAR
            /// </summary>
            CHAR = 0x0102,
            /// <summary>
            /// DEADCHAR
            /// </summary>
            DEADCHAR = 0x0103,
            /// <summary>
            /// SYSKEYDOWN
            /// </summary>
            SYSKEYDOWN = 0x0104,
            /// <summary>
            /// SYSKEYUP
            /// </summary>
            SYSKEYUP = 0x0105,
            /// <summary>
            /// SYSCHAR
            /// </summary>
            SYSCHAR = 0x0106,
            /// <summary>
            /// SYSDEADCHAR
            /// </summary>
            SYSDEADCHAR = 0x0107,
            /// <summary>
            /// UNICHAR
            /// </summary>
            UNICHAR = 0x0109,
            /// <summary>
            /// KEYLAST
            /// </summary>
            KEYLAST = 0x0109,
            /// <summary>
            /// IME_STARTCOMPOSITION
            /// </summary>
            IME_STARTCOMPOSITION = 0x010D,
            /// <summary>
            /// IME_ENDCOMPOSITION
            /// </summary>
            IME_ENDCOMPOSITION = 0x010E,
            /// <summary>
            /// IME_COMPOSITION
            /// </summary>
            IME_COMPOSITION = 0x010F,
            /// <summary>
            /// IME_KEYLAST
            /// </summary>
            IME_KEYLAST = 0x010F,
            /// <summary>
            /// INITDIALOG
            /// </summary>
            INITDIALOG = 0x0110,
            /// <summary>
            /// COMMAND
            /// </summary>
            COMMAND = 0x0111,
            /// <summary>
            /// SYSCOMMAND
            /// </summary>
            SYSCOMMAND = 0x0112,
            /// <summary>
            /// TIMER
            /// </summary>
            TIMER = 0x0113,
            /// <summary>
            /// HSCROLL
            /// </summary>
            HSCROLL = 0x0114,
            /// <summary>
            /// VSCROLL
            /// </summary>
            VSCROLL = 0x0115,
            /// <summary>
            /// INITMENU
            /// </summary>
            INITMENU = 0x0116,
            /// <summary>
            /// INITMENUPOPUP
            /// </summary>
            INITMENUPOPUP = 0x0117,
            /// <summary>
            /// GESTURE
            /// </summary>
            GESTURE = 0x0119,
            /// <summary>
            /// GESTURENOTIFY
            /// </summary>
            GESTURENOTIFY = 0x011A,
            /// <summary>
            /// MENUSELECT
            /// </summary>
            MENUSELECT = 0x011F,
            /// <summary>
            /// MENUCHAR
            /// </summary>
            MENUCHAR = 0x0120,
            /// <summary>
            /// ENTERIDLE
            /// </summary>
            ENTERIDLE = 0x0121,
            /// <summary>
            /// MENURBUTTONUP
            /// </summary>
            MENURBUTTONUP = 0x0122,
            /// <summary>
            /// MENUDRAG
            /// </summary>
            MENUDRAG = 0x0123,
            /// <summary>
            /// MENUGETOBJECT
            /// </summary>
            MENUGETOBJECT = 0x0124,
            /// <summary>
            /// UNINITMENUPOPUP
            /// </summary>
            UNINITMENUPOPUP = 0x0125,
            /// <summary>
            /// MENUCOMMAND
            /// </summary>
            MENUCOMMAND = 0x0126,
            /// <summary>
            /// CHANGEUISTATE
            /// </summary>
            CHANGEUISTATE = 0x0127,
            /// <summary>
            /// UPDATEUISTATE
            /// </summary>
            UPDATEUISTATE = 0x0128,
            /// <summary>
            /// QUERYUISTATE
            /// </summary>
            QUERYUISTATE = 0x0129,
            /// <summary>
            /// CTLCOLORMSGBOX
            /// </summary>
            CTLCOLORMSGBOX = 0x0132,
            /// <summary>
            /// CTLCOLOREDIT
            /// </summary>
            CTLCOLOREDIT = 0x0133,
            /// <summary>
            /// CTLCOLORLISTBOX
            /// </summary>
            CTLCOLORLISTBOX = 0x0134,
            /// <summary>
            /// CTLCOLORBTN
            /// </summary>
            CTLCOLORBTN = 0x0135,
            /// <summary>
            /// CTLCOLORDLG
            /// </summary>
            CTLCOLORDLG = 0x0136,
            /// <summary>
            /// CTLCOLORSCROLLBAR
            /// </summary>
            CTLCOLORSCROLLBAR = 0x0137,
            /// <summary>
            /// CTLCOLORSTATIC
            /// </summary>
            CTLCOLORSTATIC = 0x0138,
            /// <summary>
            /// MOUSEFIRST
            /// </summary>
            MOUSEFIRST = 0x0200,
            /// <summary>
            /// MOUSEMOVE
            /// </summary>
            MOUSEMOVE = 0x0200,
            /// <summary>
            /// LBUTTONDOWN
            /// </summary>
            LBUTTONDOWN = 0x0201,
            /// <summary>
            /// LBUTTONUP
            /// </summary>
            LBUTTONUP = 0x0202,
            /// <summary>
            /// LBUTTONDBLCLK
            /// </summary>
            LBUTTONDBLCLK = 0x0203,
            /// <summary>
            /// RBUTTONDOWN
            /// </summary>
            RBUTTONDOWN = 0x0204,
            /// <summary>
            /// RBUTTONUP
            /// </summary>
            RBUTTONUP = 0x0205,
            /// <summary>
            /// RBUTTONDBLCLK
            /// </summary>
            RBUTTONDBLCLK = 0x0206,
            /// <summary>
            /// MBUTTONDOWN
            /// </summary>
            MBUTTONDOWN = 0x0207,
            /// <summary>
            /// MBUTTONUP
            /// </summary>
            MBUTTONUP = 0x0208,
            /// <summary>
            /// MBUTTONDBLCLK
            /// </summary>
            MBUTTONDBLCLK = 0x0209,
            /// <summary>
            /// MOUSEWHEEL
            /// </summary>
            MOUSEWHEEL = 0x020A,
            /// <summary>
            /// XBUTTONDOWN
            /// </summary>
            XBUTTONDOWN = 0x020B,
            /// <summary>
            /// XBUTTONUP
            /// </summary>
            XBUTTONUP = 0x020C,
            /// <summary>
            /// XBUTTONDBLCLK
            /// </summary>
            XBUTTONDBLCLK = 0x020D,
            /// <summary>
            /// MOUSEHWHEEL
            /// </summary>
            MOUSEHWHEEL = 0x020E,
            /// <summary>
            /// MOUSELAST
            /// </summary>
            MOUSELAST = 0x020E,
            /// <summary>
            /// PARENTNOTIFY
            /// </summary>
            PARENTNOTIFY = 0x0210,
            /// <summary>
            /// ENTERMENULOOP
            /// </summary>
            ENTERMENULOOP = 0x0211,
            /// <summary>
            /// EXITMENULOOP
            /// </summary>
            EXITMENULOOP = 0x0212,
            /// <summary>
            /// NEXTMENU
            /// </summary>
            NEXTMENU = 0x0213,
            /// <summary>
            /// SIZING
            /// </summary>
            SIZING = 0x0214,
            /// <summary>
            /// CAPTURECHANGED
            /// </summary>
            CAPTURECHANGED = 0x0215,
            /// <summary>
            /// MOVING
            /// </summary>
            MOVING = 0x0216,
            /// <summary>
            /// POWERBROADCAST
            /// </summary>
            POWERBROADCAST = 0x0218,
            /// <summary>
            /// DEVICECHANGE
            /// </summary>
            DEVICECHANGE = 0x0219,
            /// <summary>
            /// MDICREATE
            /// </summary>
            MDICREATE = 0x0220,
            /// <summary>
            /// MDIDESTROY
            /// </summary>
            MDIDESTROY = 0x0221,
            /// <summary>
            /// MDIACTIVATE
            /// </summary>
            MDIACTIVATE = 0x0222,
            /// <summary>
            /// MDIRESTORE
            /// </summary>
            MDIRESTORE = 0x0223,
            /// <summary>
            /// MDINEXT
            /// </summary>
            MDINEXT = 0x0224,
            /// <summary>
            /// MDIMAXIMIZE
            /// </summary>
            MDIMAXIMIZE = 0x0225,
            /// <summary>
            /// MDITILE
            /// </summary>
            MDITILE = 0x0226,
            /// <summary>
            /// MDICASCADE
            /// </summary>
            MDICASCADE = 0x0227,
            /// <summary>
            /// MDIICONARRANGE
            /// </summary>
            MDIICONARRANGE = 0x0228,
            /// <summary>
            /// MDIGETACTIVE
            /// </summary>
            MDIGETACTIVE = 0x0229,
            /// <summary>
            /// MDISETMENU
            /// </summary>
            MDISETMENU = 0x0230,
            /// <summary>
            /// ENTERSIZEMOVE
            /// </summary>
            ENTERSIZEMOVE = 0x0231,
            /// <summary>
            /// EXITSIZEMOVE
            /// </summary>
            EXITSIZEMOVE = 0x0232,
            /// <summary>
            /// DROPFILES
            /// </summary>
            DROPFILES = 0x0233,
            /// <summary>
            /// MDIREFRESHMENU
            /// </summary>
            MDIREFRESHMENU = 0x0234,
            /// <summary>
            /// POINTERDEVICECHANGE
            /// </summary>
            POINTERDEVICECHANGE = 0x0238,
            /// <summary>
            /// POINTERDEVICEINRANGE
            /// </summary>
            POINTERDEVICEINRANGE = 0x0239,
            /// <summary>
            /// POINTERDEVICEOUTOFRANGE
            /// </summary>
            POINTERDEVICEOUTOFRANGE = 0x023A,
            /// <summary>
            /// TOUCH
            /// </summary>
            TOUCH = 0x0240,
            /// <summary>
            /// NCPOINTERUPDATE
            /// </summary>
            NCPOINTERUPDATE = 0x0241,
            /// <summary>
            /// NCPOINTERDOWN
            /// </summary>
            NCPOINTERDOWN = 0x0242,
            /// <summary>
            /// NCPOINTERUP
            /// </summary>
            NCPOINTERUP = 0x0243,
            /// <summary>
            /// POINTERUPDATE
            /// </summary>
            POINTERUPDATE = 0x0245,
            /// <summary>
            /// POINTERDOWN
            /// </summary>
            POINTERDOWN = 0x0246,
            /// <summary>
            /// POINTERUP
            /// </summary>
            POINTERUP = 0x0247,
            /// <summary>
            /// POINTERENTER
            /// </summary>
            POINTERENTER = 0x0249,
            /// <summary>
            /// POINTERLEAVE
            /// </summary>
            POINTERLEAVE = 0x024A,
            /// <summary>
            /// POINTERACTIVATE
            /// </summary>
            POINTERACTIVATE = 0x024B,
            /// <summary>
            /// POINTERCAPTURECHANGED
            /// </summary>
            POINTERCAPTURECHANGED = 0x024C,
            /// <summary>
            /// TOUCHHITTESTING
            /// </summary>
            TOUCHHITTESTING = 0x024D,
            /// <summary>
            /// POINTERWHEEL
            /// </summary>
            POINTERWHEEL = 0x024E,
            /// <summary>
            /// POINTERHWHEEL
            /// </summary>
            POINTERHWHEEL = 0x024F,
            /// <summary>
            /// POINTERROUTEDTO
            /// </summary>
            POINTERROUTEDTO = 0x0251,
            /// <summary>
            /// POINTERROUTEDAWAY
            /// </summary>
            POINTERROUTEDAWAY = 0x0252,
            /// <summary>
            /// POINTERROUTEDRELEASED
            /// </summary>
            POINTERROUTEDRELEASED = 0x0253,
            /// <summary>
            /// IME_SETCONTEXT
            /// </summary>
            IME_SETCONTEXT = 0x0281,
            /// <summary>
            /// IME_NOTIFY
            /// </summary>
            IME_NOTIFY = 0x0282,
            /// <summary>
            /// IME_CONTROL
            /// </summary>
            IME_CONTROL = 0x0283,
            /// <summary>
            /// IME_COMPOSITIONFULL
            /// </summary>
            IME_COMPOSITIONFULL = 0x0284,
            /// <summary>
            /// IME_SELECT
            /// </summary>
            IME_SELECT = 0x0285,
            /// <summary>
            /// IME_CHAR
            /// </summary>
            IME_CHAR = 0x0286,
            /// <summary>
            /// IME_REQUEST
            /// </summary>
            IME_REQUEST = 0x0288,
            /// <summary>
            /// IME_KEYDOWN
            /// </summary>
            IME_KEYDOWN = 0x0290,
            /// <summary>
            /// IME_KEYUP
            /// </summary>
            IME_KEYUP = 0x0291,
            /// <summary>
            /// MOUSEHOVER
            /// </summary>
            MOUSEHOVER = 0x02A1,
            /// <summary>
            /// MOUSELEAVE
            /// </summary>
            MOUSELEAVE = 0x02A3,
            /// <summary>
            /// NCMOUSEHOVER
            /// </summary>
            NCMOUSEHOVER = 0x02A0,
            /// <summary>
            /// NCMOUSELEAVE
            /// </summary>
            NCMOUSELEAVE = 0x02A2,
            /// <summary>
            /// WTSSESSION_CHANGE
            /// </summary>
            WTSSESSION_CHANGE = 0x02B1,
            /// <summary>
            /// DPICHANGED
            /// </summary>
            DPICHANGED = 0x02E0,
            /// <summary>
            /// DPICHANGED_BEFOREPARENT
            /// </summary>
            DPICHANGED_BEFOREPARENT = 0x02E2,
            /// <summary>
            /// DPICHANGED_AFTERPARENT
            /// </summary>
            DPICHANGED_AFTERPARENT = 0x02E3,
            /// <summary>
            /// GETDPISCALEDSIZE
            /// </summary>
            GETDPISCALEDSIZE = 0x02E4,
            /// <summary>
            /// CUT
            /// </summary>
            CUT = 0x0300,
            /// <summary>
            /// COPY
            /// </summary>
            COPY = 0x0301,
            /// <summary>
            /// PASTE
            /// </summary>
            PASTE = 0x0302,
            /// <summary>
            /// CLEAR
            /// </summary>
            CLEAR = 0x0303,
            /// <summary>
            /// UNDO
            /// </summary>
            UNDO = 0x0304,
            /// <summary>
            /// RENDERFORMAT
            /// </summary>
            RENDERFORMAT = 0x0305,
            /// <summary>
            /// RENDERALLFORMATS
            /// </summary>
            RENDERALLFORMATS = 0x0306,
            /// <summary>
            /// DESTROYCLIPBOARD
            /// </summary>
            DESTROYCLIPBOARD = 0x0307,
            /// <summary>
            /// DRAWCLIPBOARD
            /// </summary>
            DRAWCLIPBOARD = 0x0308,
            /// <summary>
            /// PAINTCLIPBOARD
            /// </summary>
            PAINTCLIPBOARD = 0x0309,
            /// <summary>
            /// VSCROLLCLIPBOARD
            /// </summary>
            VSCROLLCLIPBOARD = 0x030A,
            /// <summary>
            /// SIZECLIPBOARD
            /// </summary>
            SIZECLIPBOARD = 0x030B,
            /// <summary>
            /// ASKCBFORMATNAME
            /// </summary>
            ASKCBFORMATNAME = 0x030C,
            /// <summary>
            /// CHANGECBCHAIN
            /// </summary>
            CHANGECBCHAIN = 0x030D,
            /// <summary>
            /// HSCROLLCLIPBOARD
            /// </summary>
            HSCROLLCLIPBOARD = 0x030E,
            /// <summary>
            /// QUERYNEWPALETTE
            /// </summary>
            QUERYNEWPALETTE = 0x030F,
            /// <summary>
            /// PALETTEISCHANGING
            /// </summary>
            PALETTEISCHANGING = 0x0310,
            /// <summary>
            /// PALETTECHANGED
            /// </summary>
            PALETTECHANGED = 0x0311,
            /// <summary>
            /// HOTKEY
            /// </summary>
            HOTKEY = 0x0312,
            /// <summary>
            /// PRINT
            /// </summary>
            PRINT = 0x0317,
            /// <summary>
            /// PRINTCLIENT
            /// </summary>
            PRINTCLIENT = 0x0318,
            /// <summary>
            /// APPCOMMAND
            /// </summary>
            APPCOMMAND = 0x0319,
            /// <summary>
            /// THEMECHANGED
            /// </summary>
            THEMECHANGED = 0x031A,
            /// <summary>
            /// CLIPBOARDUPDATE
            /// </summary>
            CLIPBOARDUPDATE = 0x031D,
            /// <summary>
            /// DWMCOMPOSITIONCHANGED
            /// </summary>
            DWMCOMPOSITIONCHANGED = 0x031E,
            /// <summary>
            /// DWMNCRENDERINGCHANGED
            /// </summary>
            DWMNCRENDERINGCHANGED = 0x031F,
            /// <summary>
            /// DWMCOLORIZATIONCOLORCHANGED
            /// </summary>
            DWMCOLORIZATIONCOLORCHANGED = 0x0320,
            /// <summary>
            /// DWMWINDOWMAXIMIZEDCHANGE
            /// </summary>
            DWMWINDOWMAXIMIZEDCHANGE = 0x0321,
            /// <summary>
            /// DWMSENDICONICTHUMBNAIL
            /// </summary>
            DWMSENDICONICTHUMBNAIL = 0x0323,
            /// <summary>
            /// DWMSENDICONICLIVEPREVIEWBITMAP
            /// </summary>
            DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326,
            /// <summary>
            /// GETTITLEBARINFOEX
            /// </summary>
            GETTITLEBARINFOEX = 0x033F,
            /// <summary>
            /// HANDHELDFIRST
            /// </summary>
            HANDHELDFIRST = 0x0358,
            /// <summary>
            /// HANDHELDLAST
            /// </summary>
            HANDHELDLAST = 0x035F,
            /// <summary>
            /// AFXFIRST
            /// </summary>
            AFXFIRST = 0x0360,
            /// <summary>
            /// AFXLAST
            /// </summary>
            AFXLAST = 0x037F,
            /// <summary>
            /// PENWINFIRST
            /// </summary>
            PENWINFIRST = 0x0380,
            /// <summary>
            /// PENWINLAST
            /// </summary>
            PENWINLAST = 0x038F,
            /// <summary>
            /// USER
            /// </summary>
            USER = 0x0400,
            /// <summary>
            /// CHOOSEFONT_GETLOGFONT
            /// </summary>
            CHOOSEFONT_GETLOGFONT = USER + 1,
            /// <summary>
            /// APP
            /// </summary>
            APP = 0x8000,
            /// <summary>
            /// REFLECT
            /// </summary>
            REFLECT = USER + 0x1C00,

            // Messages that are a combination of REFLECT with other messages.
            /// <summary>
            /// REFLECT_NOTIFY
            /// </summary>
            REFLECT_NOTIFY = REFLECT + NOTIFY,
            /// <summary>
            /// REFLECT_NOTIFYFORMAT
            /// </summary>
            REFLECT_NOTIFYFORMAT = REFLECT + NOTIFYFORMAT,
            /// <summary>
            /// REFLECT_COMMAND
            /// </summary>
            REFLECT_COMMAND = REFLECT + COMMAND,
            /// <summary>
            /// REFLECT_CHARTOITEM
            /// </summary>
            REFLECT_CHARTOITEM = REFLECT + CHARTOITEM,
            /// <summary>
            /// REFLECT_VKEYTOITEM
            /// </summary>
            REFLECT_VKEYTOITEM = REFLECT + VKEYTOITEM,
            /// <summary>
            /// REFLECT_DRAWITEM
            /// </summary>
            REFLECT_DRAWITEM = REFLECT + DRAWITEM,
            /// <summary>
            /// REFLECT_MEASUREITEM
            /// </summary>
            REFLECT_MEASUREITEM = REFLECT + MEASUREITEM,
            /// <summary>
            /// REFLECT_HSCROLL
            /// </summary>
            REFLECT_HSCROLL = REFLECT + HSCROLL,
            /// <summary>
            /// REFLECT_VSCROLL
            /// </summary>
            REFLECT_VSCROLL = REFLECT + VSCROLL,
            /// <summary>
            /// REFLECT_CTLCOLOR
            /// </summary>
            REFLECT_CTLCOLOR = REFLECT + CTLCOLOR,
            /// <summary>
            /// REFLECT_CTLCOLORBTN
            /// </summary>
            REFLECT_CTLCOLORBTN = REFLECT + CTLCOLORBTN,
            /// <summary>
            /// REFLECT_CTLCOLORDLG
            /// </summary>
            REFLECT_CTLCOLORDLG = REFLECT + CTLCOLORDLG,
            /// <summary>
            /// REFLECT_CTLCOLORMSGBOX
            /// </summary>
            REFLECT_CTLCOLORMSGBOX = REFLECT + CTLCOLORMSGBOX,
            /// <summary>
            /// REFLECT_CTLCOLORSCROLLBAR
            /// </summary>
            REFLECT_CTLCOLORSCROLLBAR = REFLECT + CTLCOLORSCROLLBAR,
            /// <summary>
            /// REFLECT_CTLCOLOREDIT
            /// </summary>
            REFLECT_CTLCOLOREDIT = REFLECT + CTLCOLOREDIT,
            /// <summary>
            /// REFLECT_CTLCOLORLISTBOX
            /// </summary>
            REFLECT_CTLCOLORLISTBOX = REFLECT + CTLCOLORLISTBOX,
            /// <summary>
            /// REFLECT_CTLCOLORSTATIC
            /// </summary>
            REFLECT_CTLCOLORSTATIC = REFLECT + CTLCOLORSTATIC
        }

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

        ///// <summary>
        ///// WNDCLASS
        ///// </summary>
        //[StructLayout(LayoutKind.Sequential)]
        //public struct WNDCLASS
        //{
        //    /// <summary>
        //    /// style
        //    /// </summary>
        //    public int style;
        //    /// <summary>
        //    /// lpfnWndProc
        //    /// </summary>
        //    public IntPtr lpfnWndProc;
        //    /// <summary>
        //    /// cbClsExtra
        //    /// </summary>
        //    public int cbClsExtra;
        //    /// <summary>
        //    /// cbWndExtra
        //    /// </summary>
        //    public int cbWndExtra;
        //    /// <summary>
        //    /// hInstance
        //    /// </summary>
        //    public IntPtr hInstance;
        //    /// <summary>
        //    /// hIcon
        //    /// </summary>
        //    public IntPtr hIcon;
        //    /// <summary>
        //    /// hCursor
        //    /// </summary>
        //    public IntPtr hCursor;
        //    /// <summary>
        //    /// hbrBackground
        //    /// </summary>
        //    public IntPtr hbrBackground;
        //    /// <summary>
        //    /// lpszMenuName
        //    /// </summary>
        //    public string? lpszMenuName;
        //    /// <summary>
        //    /// lpszClassName
        //    /// </summary>
        //    public string? lpszClassName;
        //}

        /// <summary>
        /// WS_STYLE
        /// </summary>
        [Flags]
        public enum WS_STYLE : long
        {
            /// <summary>
            /// WS_OVERLAPPED
            /// </summary>
            WS_OVERLAPPED = 0x00000000L,
            /// <summary>
            /// WS_CAPTION
            /// </summary>
            WS_CAPTION = 0x00C00000L,    /* WS_BORDER | WS_DLGFRAME  */
            /// <summary>
            /// WS_SYSMENU
            /// </summary>
            WS_SYSMENU = 0x00080000L,
            /// <summary>
            /// WS_THICKFRAME
            /// </summary>
            WS_THICKFRAME = 0x00040000L,
            /// <summary>
            /// WS_MINIMIZEBOX
            /// </summary>
            WS_MINIMIZEBOX = 0x00020000L,
            /// <summary>
            /// WS_MAXIMIZEBOX
            /// </summary>
            WS_MAXIMIZEBOX = 0x00010000L,
            /// <summary>
            /// WS_OVERLAPPEDWINDOW
            /// </summary>
            WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED |
                             WS_CAPTION |
                             WS_SYSMENU |
                             WS_THICKFRAME |
                             WS_MINIMIZEBOX |
                             WS_MAXIMIZEBOX),
        }

        #region SPI
        /// <summary>
        /// SPI
        /// </summary>
        public enum SPI : uint
        {
            /// <summary>
            /// GETBORDER
            /// </summary>
            GETBORDER = 0x0005,
            /// <summary>
            /// GETKEYBOARDSPEED
            /// </summary>
            GETKEYBOARDSPEED = 0x000A,
            /// <summary>
            /// ICONHORIZONTALSPACING
            /// </summary>
            ICONHORIZONTALSPACING = 0x000D,
            /// <summary>
            /// SETSCREENSAVEACTIVE
            /// </summary>
            SETSCREENSAVEACTIVE = 0x0011,
            /// <summary>
            /// SETDESKWALLPAPER
            /// </summary>
            SETDESKWALLPAPER = 0x0014,
            /// <summary>
            /// GETKEYBOARDDELAY
            /// </summary>
            GETKEYBOARDDELAY = 0x0016,
            /// <summary>
            /// SETKEYBOARDDELAY
            /// </summary>
            SETKEYBOARDDELAY = 0x0017,
            /// <summary>
            /// ICONVERTICALSPACING
            /// </summary>
            ICONVERTICALSPACING = 0x0018,
            /// <summary>
            /// GETICONTITLEWRAP
            /// </summary>
            GETICONTITLEWRAP = 0x0019,
            /// <summary>
            /// GETMENUDROPALIGNMENT
            /// </summary>
            GETMENUDROPALIGNMENT = 0x001B,
            /// <summary>
            /// SETMENUDROPALIGNMENT
            /// </summary>
            SETMENUDROPALIGNMENT = 0x001C,
            /// <summary>
            /// SETDOUBLECLICKTIME
            /// </summary>
            SETDOUBLECLICKTIME = 0x0020,
            /// <summary>
            /// GETDRAGFULLWINDOWS
            /// </summary>
            GETDRAGFULLWINDOWS = 0x0026,
            /// <summary>
            /// GETNONCLIENTMETRICS
            /// </summary>
            GETNONCLIENTMETRICS = 0x0029,
            /// <summary>
            /// GETICONMETRICS
            /// </summary>
            GETICONMETRICS = 0x002D,
            /// <summary>
            /// GETWORKAREA
            /// </summary>
            GETWORKAREA = 0x0030,
            /// <summary>
            /// GETHIGHCONTRAST
            /// </summary>
            GETHIGHCONTRAST = 0x0042,
            /// <summary>
            /// SETHIGHCONTRAST
            /// </summary>
            SETHIGHCONTRAST = 0x0043,
            /// <summary>
            /// GETKEYBOARDPREF
            /// </summary>
            GETKEYBOARDPREF = 0x0044,
            /// <summary>
            /// GETANIMATION
            /// </summary>
            GETANIMATION = 0x0048,
            /// <summary>
            /// GETFONTSMOOTHING
            /// </summary>
            GETFONTSMOOTHING = 0x004A,
            /// <summary>
            /// SETLOWPOWERACTIVE
            /// </summary>
            SETLOWPOWERACTIVE = 0x0055,
            /// <summary>
            /// GETDEFAULTINPUTLANG
            /// </summary>
            GETDEFAULTINPUTLANG = 0x0059,
            /// <summary>
            /// GETSNAPTODEFBUTTON
            /// </summary>
            GETSNAPTODEFBUTTON = 0x005F,
            /// <summary>
            /// GETMOUSEHOVERWIDTH
            /// </summary>
            GETMOUSEHOVERWIDTH = 0x0062,
            /// <summary>
            /// GETMOUSEHOVERHEIGHT
            /// </summary>
            GETMOUSEHOVERHEIGHT = 0x0064,
            /// <summary>
            /// GETMOUSEHOVERTIME
            /// </summary>
            GETMOUSEHOVERTIME = 0x0066,
            /// <summary>
            /// GETWHEELSCROLLLINES
            /// </summary>
            GETWHEELSCROLLLINES = 0x0068,
            /// <summary>
            /// GETMENUSHOWDELAY
            /// </summary>
            GETMENUSHOWDELAY = 0x006A,
            /// <summary>
            /// GETMOUSESPEED
            /// </summary>
            GETMOUSESPEED = 0x0070,
            /// <summary>
            /// GETACTIVEWINDOWTRACKING
            /// </summary>
            GETACTIVEWINDOWTRACKING = 0x1000,
            /// <summary>
            /// GETMENUANIMATION
            /// </summary>
            GETMENUANIMATION = 0x1002,
            /// <summary>
            /// GETCOMBOBOXANIMATION
            /// </summary>
            GETCOMBOBOXANIMATION = 0x1004,
            /// <summary>
            /// GETLISTBOXSMOOTHSCROLLING
            /// </summary>
            GETLISTBOXSMOOTHSCROLLING = 0x1006,
            /// <summary>
            /// GETGRADIENTCAPTIONS
            /// </summary>
            GETGRADIENTCAPTIONS = 0x1008,
            /// <summary>
            /// GETKEYBOARDCUES
            /// </summary>
            GETKEYBOARDCUES = 0x100A,
            /// <summary>
            /// SETKEYBOARDCUES
            /// </summary>
            SETKEYBOARDCUES = 0x100B,
            /// <summary>
            /// GETHOTTRACKING
            /// </summary>
            GETHOTTRACKING = 0x100E,
            /// <summary>
            /// GETMENUFADE
            /// </summary>
            GETMENUFADE = 0x1012,
            /// <summary>
            /// GETSELECTIONFADE
            /// </summary>
            GETSELECTIONFADE = 0x1014,
            /// <summary>
            /// GETTOOLTIPANIMATION
            /// </summary>
            GETTOOLTIPANIMATION = 0x1016,
            /// <summary>
            /// GETFLATMENU
            /// </summary>
            GETFLATMENU = 0x1022,
            /// <summary>
            /// GETDROPSHADOW
            /// </summary>
            GETDROPSHADOW = 0x1024,
            /// <summary>
            /// GETUIEFFECTS
            /// </summary>
            GETUIEFFECTS = 0x103E,
            /// <summary>
            /// GETCLIENTAREAANIMATION
            /// </summary>
            GETCLIENTAREAANIMATION = 0x1042,
            /// <summary>
            /// SETCLIENTAREAANIMATION
            /// </summary>
            SETCLIENTAREAANIMATION = 0x1043,
            /// <summary>
            /// GETACTIVEWNDTRKTIMEOUT
            /// </summary>
            GETACTIVEWNDTRKTIMEOUT = 0x2002,
            /// <summary>
            /// GETCARETWIDTH
            /// </summary>
            GETCARETWIDTH = 0x2006,
            /// <summary>
            /// GETFONTSMOOTHINGTYPE
            /// </summary>
            GETFONTSMOOTHINGTYPE = 0x200A,
            /// <summary>
            /// GETFONTSMOOTHINGCONTRAST
            /// </summary>
            GETFONTSMOOTHINGCONTRAST = 0x200C,
        }
        #endregion

        #region 图标
        /// <summary>
        /// ICONINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public ref struct ICONINFO
        {
            /// <summary>
            /// fIcon
            /// </summary>
            public BOOL fIcon;
            /// <summary>
            /// xHotspot
            /// </summary>
            public uint xHotspot;
            /// <summary>
            /// yHotspot
            /// </summary>
            public uint yHotspot;
            /// <summary>
            /// hbmMask
            /// </summary>
            public Gdi32.HBITMAP hbmMask;
            /// <summary>
            /// hbmColor
            /// </summary>
            public Gdi32.HBITMAP hbmColor;
        }
        #endregion
    }


}
