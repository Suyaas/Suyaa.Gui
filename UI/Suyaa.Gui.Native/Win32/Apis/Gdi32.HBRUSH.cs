using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* gdi32.dll HBRUSH */
    public partial class Gdi32
    {
        /// <summary>
        /// HBRUSH
        /// </summary>
        public readonly struct HBRUSH
        {
            /// <summary>
            /// Handle
            /// </summary>
            public nint Handle { get; }

            /// <summary>
            /// HBRUSH
            /// </summary>
            /// <param name="handle"></param>
            public HBRUSH(nint handle) => Handle = handle;

            /// <summary>
            /// IsNull
            /// </summary>
            public bool IsNull => Handle == 0;

            /// <summary>
            /// 赋值给指针
            /// </summary>
            /// <param name="hbrush"></param>
            public static implicit operator nint(HBRUSH hbrush) => hbrush.Handle;
            /// <summary>
            /// 从指针赋值
            /// </summary>
            /// <param name="hbrush"></param>
            public static explicit operator HBRUSH(nint hbrush) => new(hbrush);
            //public static implicit operator HGDIOBJ(HBRUSH hbrush) => new(hbrush.Handle);
            //public static explicit operator HBRUSH(HGDIOBJ hbrush) => new(hbrush.Handle);
        }
    }
}
