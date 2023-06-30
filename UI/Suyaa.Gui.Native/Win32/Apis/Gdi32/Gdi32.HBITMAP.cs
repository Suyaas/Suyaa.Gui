using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* gdi32.dll HBITMAP */
    public partial class Gdi32
    {
        /// <summary>
        /// HBITMAP
        /// </summary>
        public readonly struct HBITMAP : IEquatable<HBITMAP>
        {
            /// <summary>
            /// 句柄
            /// </summary>
            public nint Handle { get; }

            /// <summary>
            /// HBITMAP
            /// </summary>
            /// <param name="handle"></param>
            public HBITMAP(nint handle) => Handle = handle;

            /// <summary>
            /// 是否为空指针
            /// </summary>
            public bool IsNull => Handle == 0;

            /// <summary>
            /// 赋值
            /// </summary>
            /// <param name="hdc"></param>
            public static implicit operator nint(HBITMAP hdc) => hdc.Handle;
            /// <summary>
            /// 赋值
            /// </summary>
            /// <param name="hdc"></param>
            public static explicit operator HBITMAP(nint hdc) => new(hdc);

            /// <summary>
            /// 判断是否相等
            /// </summary>
            /// <param name="value1"></param>
            /// <param name="value2"></param>
            /// <returns></returns>
            public static bool operator ==(HBITMAP value1, HBITMAP value2) => value1.Handle == value2.Handle;
            /// <summary>
            /// 判断是否不相等
            /// </summary>
            /// <param name="value1"></param>
            /// <param name="value2"></param>
            /// <returns></returns>
            public static bool operator !=(HBITMAP value1, HBITMAP value2) => value1.Handle != value2.Handle;
            /// <summary>
            /// 判断是否相等
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object? obj) => obj is HBITMAP hb && hb.Handle == Handle;
            /// <summary>
            /// 判断是否相等
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public bool Equals(HBITMAP other) => other.Handle == Handle;
            /// <summary>
            /// 获取哈希值
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode() => Handle.GetHashCode();
        }
    }
}
