using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /// <summary>
    /// RECT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>
        ///  left
        /// </summary>
        public int left;
        /// <summary>
        /// top
        /// </summary>
        public int top;
        /// <summary>
        /// right
        /// </summary>
        public int right;
        /// <summary>
        /// bottom
        /// </summary>
        public int bottom;

        /// <summary>
        /// RECT
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        public RECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        /// <summary>
        /// X
        /// </summary>
        public int X => left;

        /// <summary>
        /// Y
        /// </summary>
        public int Y => top;

        /// <summary>
        /// Width
        /// </summary>
        public int Width
            => right - left;

        /// <summary>
        /// Height
        /// </summary>
        public int Height
            => bottom - top;

        /// <summary>
        /// 转为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"{{{left}, {top}, {right}, {bottom} (LTRB)}}";
    }
}
