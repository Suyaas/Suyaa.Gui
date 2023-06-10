using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Linux.Apis
{
    /*
     * 函数列表
     */
    public partial class LibX11
    {

        /// <summary>
        /// 与Xserver建立连接
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial IntPtr XOpenDisplay(IntPtr display);

        /// <summary>
        /// XDefaultScreen
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial short XDefaultScreen(IntPtr display);

        /// <summary>
        /// XRootWindow
        /// </summary>
        /// <param name="display"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial IntPtr XRootWindow(IntPtr display, short s);

        /// <summary>
        /// XBlackPixel
        /// </summary>
        /// <param name="display"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial uint XBlackPixel(IntPtr display, short s);

        /// <summary>
        /// XWhitePixel
        /// </summary>
        /// <param name="display"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial uint XWhitePixel(IntPtr display, short s);

        /// <summary>
        /// 创建一个窗口
        /// </summary>
        /// <param name="display"></param>
        /// <param name="parent"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="borderWidth"></param>
        /// <param name="border"></param>
        /// <param name="background"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial IntPtr XCreateSimpleWindow(IntPtr display, IntPtr parent, short x, short y, ushort width, ushort height, ushort borderWidth, uint border, uint background);

        /// <summary>
        /// 事件监听
        /// </summary>
        /// <param name="display"></param>
        /// <param name="window"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial short XSelectInput(IntPtr display, IntPtr window, int mask);

        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="display"></param>
        /// <param name="window"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial short XMapWindow(IntPtr display, IntPtr window);

        /// <summary>
        /// 事件监听
        /// </summary>
        /// <param name="display"></param>
        /// <param name="evt"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial short XNextEvent(IntPtr display, ref XEvent evt);

        /// <summary>
        /// XStringListToTextProperty
        /// </summary>
        /// <param name="str"></param>
        /// <param name="count"></param>
        /// <param name="textProperty"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public unsafe static partial short XStringListToTextProperty(char* str, short count, ref XTextProperty textProperty);

        /// <summary>
        /// 将TextProperty转化为字符串列表
        /// </summary>
        /// <param name="textProperty"></param>
        /// <param name="str"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public unsafe static partial short XTextPropertyToStringList(ref XTextProperty textProperty, ref char** str, ref short count);

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="display"></param>
        /// <param name="window"></param>
        /// <param name="textProperty"></param>
        [LibraryImport(_libName)]
        public static partial void XSetWMName(IntPtr display, IntPtr window, ref XTextProperty textProperty);

        /// <summary>
        /// 设置支持本地化
        /// </summary>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial BOOL XSupportsLocale();

        /// <summary>
        /// 将字符串列表转化为TextProperty
        /// </summary>
        /// <param name="display"></param>
        /// <param name="str"></param>
        /// <param name="count"></param>
        /// <param name="style"></param>
        /// <param name="textProperty"></param>
        [LibraryImport(_libName)]
        public unsafe static partial void XmbTextListToTextProperty(IntPtr display, char* str, short count, XICCEncodingStyle style, ref XTextProperty textProperty);

        /// <summary>
        /// 将字符串列表转化为TextProperty
        /// </summary>
        /// <param name="display"></param>
        /// <param name="str"></param>
        /// <param name="count"></param>
        /// <param name="style"></param>
        /// <param name="textProperty"></param>
        [LibraryImport(_libName)]
        public unsafe static partial void Xutf8TextListToTextProperty(IntPtr display, char* str, short count, XICCEncodingStyle style, ref XTextProperty textProperty);

        /// <summary>
        /// 创建Pixmap
        /// </summary>
        /// <param name="display"></param>
        /// <param name="window"></param>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public unsafe static partial IntPtr XCreateBitmapFromData(IntPtr display, IntPtr window, byte* pixels, ushort width, ushort height);

        /// <summary>
        /// 申请Hints
        /// </summary>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial XWMHints XAllocWMHints();

        /// <summary>
        /// 申请Hints
        /// </summary>
        /// <param name="hints"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial int XFree(ref XWMHints hints);

        /// <summary>
        /// 设置Hints
        /// </summary>
        /// <param name="display"></param>
        /// <param name="window"></param>
        /// <param name="hints"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial short XSetWMHints(IntPtr display, IntPtr window, ref XWMHints hints);

        /// <summary>
        /// 获取Hints
        /// </summary>
        /// <param name="display"></param>
        /// <param name="window"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial XWMHints XGetWMHints(IntPtr display, IntPtr window);

        /// <summary>
        /// 初始化XImage
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial short XInitImage(ref XImage image);

        /// <summary>
        /// 创建一个Pixmap
        /// </summary>
        /// <param name="display"></param>
        /// <param name="target"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial IntPtr XCreatePixmap(IntPtr display, IntPtr target, ushort width, ushort height, ushort depth);

        ///// <summary>
        ///// 创建一个Pixmap
        ///// </summary>
        ///// <param name="display"></param>
        ///// <returns></returns>
        //[LibraryImport(_libName, CallingConvention = CallingConvention.Cdecl)]
        //public static partial XImage XCreateImage(
        //    IntPtr display,
        //    IntPtr visual,
        //    ushort depth,
        //    short format,
        //    short offset,
        //    IntPtr data,
        //    ushort width,
        //    ushort height,
        //    short bitmap_pad,
        //    short bytes_per_line
        //    );

        /// <summary>
        /// 创建一个Pixmap
        /// </summary>
        /// <param name="display"></param>
        /// <param name="visual"></param>
        /// <param name="depth"></param>
        /// <param name="format"></param>
        /// <param name="offset"></param>
        /// <param name="data"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="bitmap_pad"></param>
        /// <param name="bytes_per_line"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial _XImage XCreateImage(
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
        /// 创建一个Pixmap
        /// </summary>
        /// <param name="display"></param>
        /// <param name="visual"></param>
        /// <param name="depth"></param>
        /// <param name="format"></param>
        /// <param name="offset"></param>
        /// <param name="data"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="bitmap_pad"></param>
        /// <param name="bytes_per_line"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial XImage XCreateImage(
            IntPtr display,
            IntPtr visual,
            ushort depth,
            short format,
            short offset,
            [MarshalAs(UnmanagedType.LPArray)] byte[] data,
            ushort width,
            ushort height,
            short bitmap_pad,
            short bytes_per_line
            );

        /// <summary>
        /// 获取默认的GC
        /// </summary>
        /// <param name="display"></param>
        /// <param name="screen"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial IntPtr XDefaultGC(IntPtr display, short screen);

        /// <summary>
        /// 获取默认的Visual
        /// </summary>
        /// <param name="display"></param>
        /// <param name="screen"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial IntPtr XDefaultVisual(IntPtr display, short screen);

        /// <summary>
        /// 获取默认的Depth
        /// </summary>
        /// <param name="display"></param>
        /// <param name="screen"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial short XDefaultDepth(IntPtr display, short screen);

        /// <summary>
        /// 绘制XImage
        /// </summary>
        /// <param name="display"></param>
        /// <param name="target"></param>
        /// <param name="gc"></param>
        /// <param name="image"></param>
        /// <param name="scrX"></param>
        /// <param name="srcY"></param>
        /// <param name="destX"></param>
        /// <param name="destY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial short XPutImage(IntPtr display, IntPtr target, IntPtr gc, ref XImage image, short scrX, short srcY, short destX, short destY, ushort width, ushort height);

        /// <summary>
        /// 绘制XImage
        /// </summary>
        /// <param name="display"></param>
        /// <param name="target"></param>
        /// <param name="gc"></param>
        /// <param name="image"></param>
        /// <param name="scrX"></param>
        /// <param name="srcY"></param>
        /// <param name="destX"></param>
        /// <param name="destY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [LibraryImport(_libName)]
        public static partial short XPutImage(IntPtr display, IntPtr target, IntPtr gc, IntPtr image, short scrX, short srcY, short destX, short destY, ushort width, ushort height);
    }
}
