using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.LinuxNative.Apis
{
    /// <summary>
    /// libX11.so.6
    /// </summary>
    public partial class LibX11
    {
        /// <summary>
        /// 库名称
        /// </summary>
        private const string _libName = "libX11.so.6";

        public const int NoEventMask = 0;
        public const int KeyPressMask = 1 << 0;
        public const int KeyReleaseMask = 1 << 1;
        public const int ButtonPressMask = 1 << 2;
        public const int ButtonReleaseMask = 1 << 3;
        public const int EnterWindowMask = 1 << 4;
        public const int LeaveWindowMask = 1 << 5;
        public const int PointerMotionMask = 1 << 6;
        public const int PointerMotionHintMask = 1 << 7;
        public const int Button1MotionMask = 1 << 8;
        public const int Button2MotionMask = 1 << 9;
        public const int Button3MotionMask = 1 << 10;
        public const int Button4MotionMask = 1 << 11;
        public const int Button5MotionMask = 1 << 12;
        public const int ButtonMotionMask = 1 << 13;
        public const int KeymapStateMask = 1 << 14;
        public const int ExposureMask = 1 << 15;
        public const int VisibilityChangeMask = 1 << 16;
        public const int StructureNotifyMask = 1 << 17;
        public const int ResizeRedirectMask = 1 << 18;
        public const int SubstructureNotifyMask = 1 << 19;
        public const int SubstructureRedirectMask = 1 << 20;
        public const int FocusChangeMask = 1 << 21;
        public const int PropertyChangeMask = 1 << 22;
        public const int ColormapChangeMask = 1 << 23;
        public const int OwnerGrabButtonMask = 1 << 24;

        public const int KeyPress = 2;
        public const int KeyRelease = 3;
        public const int ButtonPress = 4;
        public const int ButtonRelease = 5;
        public const int MotionNotify = 6;
        public const int EnterNotify = 7;
        public const int LeaveNotify = 8;
        public const int FocusIn = 9;
        public const int FocusOut = 10;
        public const int KeymapNotify = 11;
        public const int Expose = 12;
        public const int GraphicsExpose = 13;
        public const int NoExpose = 14;
        public const int VisibilityNotify = 15;
        public const int CreateNotify = 16;
        public const int DestroyNotify = 17;
        public const int UnmapNotify = 18;
        public const int MapNotify = 19;
        public const int MapRequest = 20;
        public const int ReparentNotify = 21;
        public const int ConfigureNotify = 22;
        public const int ConfigureRequest = 23;
        public const int GravityNotify = 24;
        public const int ResizeRequest = 25;
        public const int CirculateNotify = 26;
        public const int CirculateRequest = 27;
        public const int PropertyNotify = 28;
        public const int SelectionClear = 29;
        public const int SelectionRequest = 30;
        public const int SelectionNotify = 31;
        public const int ColormapNotify = 32;
        public const int ClientMessage = 33;
        public const int MappingNotify = 34;
        public const int GenericEvent = 35;
        public const int LASTEvent = 36;    /* must be bigger than any event # */

        /* definition for flags of XWMHints */
        public const int InputHint = 1 << 0;
        public const int StateHint = 1 << 1;
        public const int IconPixmapHint = 1 << 2;
        public const int IconWindowHint = 1 << 3;
        public const int IconPositionHint = 1 << 4;
        public const int IconMaskHint = 1 << 5;
        public const int WindowGroupHint = 1 << 6;
        public const int AllHints = InputHint | StateHint | IconPixmapHint | IconWindowHint | IconPositionHint | IconMaskHint | WindowGroupHint;
        public const int XUrgencyHint = 1 << 8;

        /* definitions for initial window state */
        public const int WithdrawnState = 0;    /* for windows that are not mapped */
        public const int NormalState = 1;   /* most applications want to start this way */
        public const int IconicState = 3;   /* application wants to start as an icon */

        /* ImageFormat -- PutImage, GetImage */

        public const int XYBitmap = 0;  /* depth 1, XYFormat */
        public const int XYPixmap = 1;  /* depth == drawable depth */
        public const int ZPixmap = 2;   /* depth == drawable depth */

        /* Byte order  used in imageByteOrder and bitmapBitOrder */

        public const int LSBFirst = 0;
        public const int MSBFirst = 1;
    }
}
