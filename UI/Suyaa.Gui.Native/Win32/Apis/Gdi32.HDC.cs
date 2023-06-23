using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* gdi32.dll HDC */
    public partial class Gdi32
    {
        /// <summary>
        /// HDC
        /// </summary>
        public readonly struct HDC : IEquatable<HDC>
        {
            /// <summary>
            /// 句柄
            /// </summary>
            public nint Handle { get; }

            /// <summary>
            /// HDC
            /// </summary>
            /// <param name="handle"></param>
            public HDC(nint handle) => Handle = handle;

            /// <summary>
            /// 是否为空指针
            /// </summary>
            public bool IsNull => Handle == 0;

            /// <summary>
            /// 赋值
            /// </summary>
            /// <param name="hdc"></param>
            public static implicit operator nint(HDC hdc) => hdc.Handle;
            /// <summary>
            /// 赋值
            /// </summary>
            /// <param name="hdc"></param>
            public static explicit operator HDC(nint hdc) => new(hdc);

            /// <summary>
            /// 判断是否相等
            /// </summary>
            /// <param name="value1"></param>
            /// <param name="value2"></param>
            /// <returns></returns>
            public static bool operator ==(HDC value1, HDC value2) => value1.Handle == value2.Handle;
            /// <summary>
            /// 判断是否不相等
            /// </summary>
            /// <param name="value1"></param>
            /// <param name="value2"></param>
            /// <returns></returns>
            public static bool operator !=(HDC value1, HDC value2) => value1.Handle != value2.Handle;
            /// <summary>
            /// 判断是否相等
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object? obj) => obj is HDC hdc && hdc.Handle == Handle;
            /// <summary>
            /// 判断是否相等
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public bool Equals(HDC other) => other.Handle == Handle;
            /// <summary>
            /// 获取哈希值
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode() => Handle.GetHashCode();
        }
    }
}
