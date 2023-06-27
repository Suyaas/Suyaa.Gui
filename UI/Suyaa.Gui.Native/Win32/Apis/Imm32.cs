using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /// <summary>
    /// imm32.dll
    /// </summary>
    public partial class Imm32
    {
        /// <summary>
        /// CFS_DEFAULT
        /// </summary>
        public const int CFS_DEFAULT = 0x0000;
        /// <summary>
        /// CFS_RECT
        /// </summary>
        public const int CFS_RECT = 0x0001;
        /// <summary>
        /// CFS_POINT
        /// </summary>
        public const int CFS_POINT = 0x0002;
        /// <summary>
        /// CFS_FORCE_POSITION
        /// </summary>
        public const int CFS_FORCE_POSITION = 0x0020;
        /// <summary>
        /// CFS_EXCLUDE
        /// </summary>
        public const int CFS_EXCLUDE = 0x0080;
        /// <summary>
        /// CFS_CANDIDATEPOS
        /// </summary>
        public const int CFS_CANDIDATEPOS = 0x0040;

        /// <summary>
        /// IMN
        /// </summary>
        public enum IMN
        {
            /// <summary>
            /// CLOSESTATUSWINDOW
            /// </summary>
            CLOSESTATUSWINDOW = 0x0001,
            /// <summary>
            /// OPENSTATUSWINDOW
            /// </summary>
            OPENSTATUSWINDOW = 0x0002,
            /// <summary>
            /// CHANGECANDIDATE
            /// </summary>
            CHANGECANDIDATE = 0x0003,
            /// <summary>
            /// CLOSECANDIDATE
            /// </summary>
            CLOSECANDIDATE = 0x0004,
            /// <summary>
            /// OPENCANDIDATE
            /// </summary>
            OPENCANDIDATE = 0x0005,
            /// <summary>
            /// SETCONVERSIONMODE
            /// </summary>
            SETCONVERSIONMODE = 0x0006,
            /// <summary>
            /// SETSENTENCEMODE
            /// </summary>
            SETSENTENCEMODE = 0x0007,
            /// <summary>
            /// SETOPENSTATUS
            /// </summary>
            SETOPENSTATUS = 0x0008,
            /// <summary>
            /// SETCANDIDATEPOS
            /// </summary>
            SETCANDIDATEPOS = 0x0009,
            /// <summary>
            /// SETCOMPOSITIONFONT
            /// </summary>
            SETCOMPOSITIONFONT = 0x000A,
            /// <summary>
            /// SETCOMPOSITIONWINDOW
            /// </summary>
            SETCOMPOSITIONWINDOW = 0x000B,
            /// <summary>
            /// SETSTATUSWINDOWPOS
            /// </summary>
            SETSTATUSWINDOWPOS = 0x000C,
            /// <summary>
            /// GUIDELINE
            /// </summary>
            GUIDELINE = 0x000D,
            /// <summary>
            /// PRIVATE
            /// </summary>
            PRIVATE = 0x000E
        }

        /// <summary>
        /// COMPOSITIONFORM
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct COMPOSITIONFORM
        {
            /// <summary>
            /// dwStyle
            /// </summary>
            public uint dwStyle;
            /// <summary>
            /// ptCurrentPos
            /// </summary>
            public POINT ptCurrentPos;
            /// <summary>
            /// rcArea
            /// </summary>
            public RECT rcArea;
        }
    }
}
