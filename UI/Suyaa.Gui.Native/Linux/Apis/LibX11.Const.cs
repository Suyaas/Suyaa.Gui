using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Linux.Apis
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

        /// <summary>
        /// NoEventMask
        /// </summary>
        public const int NoEventMask = 0;
        /// <summary>
        /// KeyPressMask
        /// </summary>
        public const int KeyPressMask = 1 << 0;
        /// <summary>
        /// KeyReleaseMask
        /// </summary>
        public const int KeyReleaseMask = 1 << 1;
        /// <summary>
        /// ButtonPressMask
        /// </summary>
        public const int ButtonPressMask = 1 << 2;
        /// <summary>
        /// ButtonReleaseMask
        /// </summary>
        public const int ButtonReleaseMask = 1 << 3;
        /// <summary>
        /// EnterWindowMask
        /// </summary>
        public const int EnterWindowMask = 1 << 4;
        /// <summary>
        /// LeaveWindowMask
        /// </summary>
        public const int LeaveWindowMask = 1 << 5;
        /// <summary>
        /// PointerMotionMask
        /// </summary>
        public const int PointerMotionMask = 1 << 6;
        /// <summary>
        /// PointerMotionHintMask
        /// </summary>
        public const int PointerMotionHintMask = 1 << 7;
        /// <summary>
        /// Button1MotionMask
        /// </summary>
        public const int Button1MotionMask = 1 << 8;
        /// <summary>
        /// Button2MotionMask
        /// </summary>
        public const int Button2MotionMask = 1 << 9;
        /// <summary>
        /// Button3MotionMask
        /// </summary>
        public const int Button3MotionMask = 1 << 10;
        /// <summary>
        /// Button4MotionMask
        /// </summary>
        public const int Button4MotionMask = 1 << 11;
        /// <summary>
        /// Button5MotionMask
        /// </summary>
        public const int Button5MotionMask = 1 << 12;
        /// <summary>
        /// ButtonMotionMask
        /// </summary>
        public const int ButtonMotionMask = 1 << 13;
        /// <summary>
        /// KeymapStateMask
        /// </summary>
        public const int KeymapStateMask = 1 << 14;
        /// <summary>
        /// ExposureMask
        /// </summary>
        public const int ExposureMask = 1 << 15;
        /// <summary>
        /// VisibilityChangeMask
        /// </summary>
        public const int VisibilityChangeMask = 1 << 16;
        /// <summary>
        /// StructureNotifyMask
        /// </summary>
        public const int StructureNotifyMask = 1 << 17;
        /// <summary>
        /// ResizeRedirectMask
        /// </summary>
        public const int ResizeRedirectMask = 1 << 18;
        /// <summary>
        /// SubstructureNotifyMask
        /// </summary>
        public const int SubstructureNotifyMask = 1 << 19;
        /// <summary>
        /// SubstructureRedirectMask
        /// </summary>
        public const int SubstructureRedirectMask = 1 << 20;
        /// <summary>
        /// FocusChangeMask
        /// </summary>
        public const int FocusChangeMask = 1 << 21;
        /// <summary>
        /// PropertyChangeMask
        /// </summary>
        public const int PropertyChangeMask = 1 << 22;
        /// <summary>
        /// ColormapChangeMask
        /// </summary>
        public const int ColormapChangeMask = 1 << 23;
        /// <summary>
        /// OwnerGrabButtonMask
        /// </summary>
        public const int OwnerGrabButtonMask = 1 << 24;

        /// <summary>
        /// KeyPress
        /// </summary>
        public const int KeyPress = 2;
        /// <summary>
        /// KeyRelease
        /// </summary>
        public const int KeyRelease = 3;
        /// <summary>
        /// ButtonPress
        /// </summary>
        public const int ButtonPress = 4;
        /// <summary>
        /// ButtonRelease
        /// </summary>
        public const int ButtonRelease = 5;
        /// <summary>
        /// MotionNotify
        /// </summary>
        public const int MotionNotify = 6;
        /// <summary>
        /// EnterNotify
        /// </summary>
        public const int EnterNotify = 7;
        /// <summary>
        /// LeaveNotify
        /// </summary>
        public const int LeaveNotify = 8;
        /// <summary>
        /// FocusIn
        /// </summary>
        public const int FocusIn = 9;
        /// <summary>
        /// FocusOut
        /// </summary>
        public const int FocusOut = 10;
        /// <summary>
        /// KeymapNotify
        /// </summary>
        public const int KeymapNotify = 11;
        /// <summary>
        /// Expose
        /// </summary>
        public const int Expose = 12;
        /// <summary>
        /// GraphicsExpose
        /// </summary>
        public const int GraphicsExpose = 13;
        /// <summary>
        /// NoExpose
        /// </summary>
        public const int NoExpose = 14;
        /// <summary>
        /// VisibilityNotify
        /// </summary>
        public const int VisibilityNotify = 15;
        /// <summary>
        /// CreateNotify
        /// </summary>
        public const int CreateNotify = 16;
        /// <summary>
        /// DestroyNotify
        /// </summary>
        public const int DestroyNotify = 17;
        /// <summary>
        /// UnmapNotify
        /// </summary>
        public const int UnmapNotify = 18;
        /// <summary>
        /// MapNotify
        /// </summary>
        public const int MapNotify = 19;
        /// <summary>
        /// MapRequest
        /// </summary>
        public const int MapRequest = 20;
        /// <summary>
        /// ReparentNotify
        /// </summary>
        public const int ReparentNotify = 21;
        /// <summary>
        /// ConfigureNotify
        /// </summary>
        public const int ConfigureNotify = 22;
        /// <summary>
        /// ConfigureRequest
        /// </summary>
        public const int ConfigureRequest = 23;
        /// <summary>
        /// GravityNotify
        /// </summary>
        public const int GravityNotify = 24;
        /// <summary>
        /// ResizeRequest
        /// </summary>
        public const int ResizeRequest = 25;
        /// <summary>
        /// CirculateNotify
        /// </summary>
        public const int CirculateNotify = 26;
        /// <summary>
        /// CirculateRequest
        /// </summary>
        public const int CirculateRequest = 27;
        /// <summary>
        /// PropertyNotify
        /// </summary>
        public const int PropertyNotify = 28;
        /// <summary>
        /// SelectionClear
        /// </summary>
        public const int SelectionClear = 29;
        /// <summary>
        /// SelectionRequest
        /// </summary>
        public const int SelectionRequest = 30;
        /// <summary>
        /// SelectionNotify
        /// </summary>
        public const int SelectionNotify = 31;
        /// <summary>
        /// ColormapNotify
        /// </summary>
        public const int ColormapNotify = 32;
        /// <summary>
        /// ClientMessage
        /// </summary>
        public const int ClientMessage = 33;
        /// <summary>
        /// MappingNotify
        /// </summary>
        public const int MappingNotify = 34;
        /// <summary>
        /// GenericEvent
        /// </summary>
        public const int GenericEvent = 35;
        /// <summary>
        /// LASTEvent
        /// </summary>
        public const int LASTEvent = 36;    /* must be bigger than any event # */

        /* definition for flags of XWMHints */
        /// <summary>
        /// InputHint
        /// </summary>
        public const int InputHint = 1 << 0;
        /// <summary>
        /// StateHint
        /// </summary>
        public const int StateHint = 1 << 1;
        /// <summary>
        /// IconPixmapHint
        /// </summary>
        public const int IconPixmapHint = 1 << 2;
        /// <summary>
        /// IconWindowHint
        /// </summary>
        public const int IconWindowHint = 1 << 3;
        /// <summary>
        /// IconPositionHint
        /// </summary>
        public const int IconPositionHint = 1 << 4;
        /// <summary>
        /// IconMaskHint
        /// </summary>
        public const int IconMaskHint = 1 << 5;
        /// <summary>
        /// WindowGroupHint
        /// </summary>
        public const int WindowGroupHint = 1 << 6;
        /// <summary>
        /// AllHints
        /// </summary>
        public const int AllHints = InputHint | StateHint | IconPixmapHint | IconWindowHint | IconPositionHint | IconMaskHint | WindowGroupHint;
        /// <summary>
        /// XUrgencyHint
        /// </summary>
        public const int XUrgencyHint = 1 << 8;

        /* definitions for initial window state */
        /// <summary>
        /// WithdrawnState
        /// </summary>
        public const int WithdrawnState = 0;    /* for windows that are not mapped */
        /// <summary>
        /// NormalState
        /// </summary>
        public const int NormalState = 1;   /* most applications want to start this way */
        /// <summary>
        /// IconicState
        /// </summary>
        public const int IconicState = 3;   /* application wants to start as an icon */

        /* ImageFormat -- PutImage, GetImage */
        /// <summary>
        /// XYBitmap
        /// </summary>
        public const int XYBitmap = 0;  /* depth 1, XYFormat */
        /// <summary>
        /// XYPixmap
        /// </summary>
        public const int XYPixmap = 1;  /* depth == drawable depth */
        /// <summary>
        /// ZPixmap
        /// </summary>
        public const int ZPixmap = 2;   /* depth == drawable depth */

        /* Byte order  used in imageByteOrder and bitmapBitOrder */
        /// <summary>
        /// LSBFirst
        /// </summary>
        public const int LSBFirst = 0;
        /// <summary>
        /// MSBFirst
        /// </summary>
        public const int MSBFirst = 1;
    }
}
