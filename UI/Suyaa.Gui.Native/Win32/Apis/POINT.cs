using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /// <summary>
    /// POINT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        /// <summary>
        /// x
        /// </summary>
        public int x;
        /// <summary>
        /// y
        /// </summary>
        public int y;

        /// <summary>
        /// POINT
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
