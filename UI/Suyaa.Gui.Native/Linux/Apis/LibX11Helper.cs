using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Linux.Apis
{
    /// <summary>
    /// libX11Helper
    /// </summary>
    public static class LibX11Helper
    {
        /// <summary>
        /// 库名称
        /// </summary>
        private const string _libName = "libX11Helper.so";

        /// <summary>
        /// 测试接口，获取标准整型字节数
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [DllImport(_libName)]
        public static extern short SizeOfInt();

        /// <summary>
        /// 创建一个XImage
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [DllImport(_libName)]
        public static extern IntPtr XCreateImage2(
            IntPtr display,
            IntPtr visual,
            uint depth,
            int format,
            int offset,
            IntPtr data,
            uint width,
            uint height,
            int bitmap_pad,
            int bytes_per_line
            );

        /// <summary>
        /// 创建一个XImage
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [DllImport(_libName)]
        public static extern uint GetXImageWidth(IntPtr image);

        /// <summary>
        /// 创建Pixmap
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [DllImport(_libName)]
        public static extern IntPtr XCreateBitmapFromData2(IntPtr display, IntPtr window, IntPtr pixels, uint width, uint height);

        /// <summary>
        /// 创建窗体
        /// </summary>
        /// <param name="display"></param>
        /// <param name="screen"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [DllImport(_libName)]
        public static extern IntPtr XCreateWindow2(IntPtr display, int screen, uint width, uint height);

        /// <summary>
        /// 设置窗口图标
        /// </summary>
        /// <param name="display"></param>
        /// <param name="window"></param>
        /// <param name="icon"></param>
        /// <param name="icon_length"></param>
        /// <returns></returns>
        [DllImport(_libName)]
        public static extern int SetWindowIcon(IntPtr display, IntPtr window, IntPtr icon, int icon_length);

        /// <summary>
        /// 创建一个事件指针
        /// </summary>
        /// <returns></returns>
        [DllImport(_libName)]
        public static extern IntPtr CreateXEvent();

        /// <summary>
        /// 获取触发的事件类型
        /// </summary>
        /// <returns></returns>
        [DllImport(_libName)]
        public static extern int GetXNextEventType(IntPtr display, IntPtr evt);
    }
}
