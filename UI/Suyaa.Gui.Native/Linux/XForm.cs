using Forms;
using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Native.Linux.Apis;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Linux
{
    /// <summary>
    /// X窗体
    /// </summary>
    public class XForm : INativeForm
    {
        #region 全局变量及构造函数

        // 标题
        private string _title = string.Empty;
        // 显示对象
        private nint _display = IntPtr.Zero;
        private nint _window = IntPtr.Zero;
        // 是否释放
        private bool _disposed = false;

        /// <summary>
        /// X窗体
        /// </summary>
        public XForm()
        {
            // 申请句柄
            this.Handle = Application.GetNewHandle();
            // 初始化样式表
            this.Styles = new Styles(this);
            this.Styles.Set<float>(StyleType.Width, 300);
            this.Styles.Set<float>(StyleType.Height, 300);
        }

        #endregion

        /// <summary>
        /// 窗体标题
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// 唯一句柄
        /// </summary>
        public long Handle { get; }

        /// <summary>
        /// 样式列表
        /// </summary>
        public Styles Styles { get; }

        /// <summary>
        /// 绘制缓存
        /// </summary>
        public SKBitmap? CacheBitmap { get; private set; }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 获取样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        public T GetStyle<T>(StyleType style)
            => this.Styles.Get<T>(style);

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            // 获取宽高
            var top = this.Styles.Get<float>(StyleType.X);
            var left = this.Styles.Get<float>(StyleType.X);
            var width = this.Styles.Get<float>(StyleType.Width);
            var height = this.Styles.Get<float>(StyleType.Height);

            //Console.WriteLine($"SizeOfInt = {sizeof.SizeOfInt()}");
            //Console.WriteLine($"SizeOfInt = {LibX11Helper.SizeOfInt()}");
            Console.WriteLine($"XSupportsLocale = {LibX11.XSupportsLocale()}");
            /* 与Xserver建立连接 */
            IntPtr display = LibX11.XOpenDisplay(IntPtr.Zero);
            Console.WriteLine($"display = {display}");
            if (display != IntPtr.Zero)
            {
                IntPtr evt = LibX11Helper.CreateXEvent();
                short screen = LibX11.XDefaultScreen(display);
                IntPtr gc = LibX11.XDefaultGC(display, screen);
                Console.WriteLine($"screen = {screen}");
                /* 创建一个窗口 */
                IntPtr window = LibX11Helper.XCreateWindow2(display, screen, (uint)width, (uint)height);
                /* 选择一种感兴趣的事件进行监听 */
                LibX11.XSelectInput(display, window, LibX11.ExposureMask | LibX11.KeyPressMask);

                //LibX11.XTextProperty textProperty = new LibX11.XTextProperty();
                //string[] titles = new string[] { "Hello" };
                //string title = "这是一个标题";
                //LibX11.Xutf8TextListToTextProperty(display, ref title, 1, LibX11.XICCEncodingStyle.XCompoundTextStyle, ref textProperty);
                //Console.WriteLine($"textProperty = {textProperty.Value}, {textProperty.Encoding}, {textProperty.Format}, {textProperty.NItems}");
                //string[] titles02 = new string[1];
                //short count = 1;
                //LibX11.XTextPropertyToStringList(ref textProperty, ref titles02, ref count);
                //Console.WriteLine($"titles02[0] = {titles02[0]}");
                //LibX11.XSetWMName(display, window, ref textProperty);

                // 设置标题
                LibX11.SetWindowTitle(display, window, this.Title);

                using (var fs = sy.IO.OpenFile($"{sy.IO.GetExecutionPath("make2.png")}"))
                {
                    using (var stream = new SKManagedStream(fs))
                    {
                        using (SKBitmap bmp = SKBitmap.Decode(stream))
                        {
                            using (XIcon icon = new XIcon(bmp.Width, bmp.Height))
                            {
                                for (int y = 0; y < icon.Height; y++)
                                {
                                    for (int x = 0; x < icon.Width; x++)
                                    {
                                        var color = bmp.GetPixel(x, y);
                                        icon.SetPixel(x, y, Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue));
                                    }
                                }
                                IntPtr ptr = icon.ToIntPtr();
                                LibX11Helper.SetWindowIcon(display, window, ptr, icon.Length);
                                Marshal.FreeHGlobal(ptr);
                            }
                            //long[] icon = Icon.Get32RedIcon();
                            //Console.WriteLine($"icon = {icon.Length}");
                            //long[] icon2 = Icon.buffer;
                            //Console.WriteLine($"icon2 = {icon2.Length}");
                            //byte[] bytes = bmp.Bytes;
                            ////byte[] bsBlank = new byte[16];
                            //IntPtr ptr = Marshal.AllocHGlobal(bytes.Length);
                            //IntPtr ptrIcon = Marshal.AllocHGlobal(icon.Length * Marshal.SizeOf<ulong>());
                            //Marshal.Copy(icon, 0, ptrIcon, icon.Length);
                            //Console.WriteLine($"bmp = {bmp.Width}, {bmp.Height}");

                            //byte[] bytes = bmp.Bytes;
                            //var pixmap = LibX11.XCreateBitmapFromData(display, window,ref bytes, 32, 32);
                            //Console.WriteLine($"pixmap = {pixmap}");
                            //IntPtr image = ConvertSKBitmapToXImage(display, screen, bmp);
                            //short bpp = (short)(8 * bmp.BytesPerPixel);
                            //Console.WriteLine($"bpp = {bpp}, {bmp.RowBytes - 4 * bmp.Width}");
                            //IntPtr icon_pixmap = LibX11Helper.XCreateBitmapFromData2(display, window, ptr, (uint)bmp.Width, (uint)bmp.Height);
                            //Console.WriteLine($"icon_pixmap = {icon_pixmap}");
                            //IntPtr image2 = LibX11Helper.XCreateImage2(
                            //    display,
                            //    XDefaultVisual(display, screen),
                            //    //(ushort)(bmp.AlphaType == SKAlphaType.Premul ? 32 : 24),
                            //    (uint)XDefaultDepth(display, screen),
                            //    ZPixmap,
                            //    0,
                            //    ptr,
                            //    (uint)bmp.Width,
                            //    (uint)bmp.Height,
                            //    8,
                            //    0
                            //    //bpp,
                            //    //(short)(bmp.RowBytes - 4 * bmp.Width)
                            //    );
                            //Console.WriteLine($"image2 = {LibX11Helper.GetXImageWidth(image2)}");
                            //_XImage image = XCreateImage(
                            //    display,
                            //    XDefaultVisual(display, screen),
                            //    //(ushort)(bmp.AlphaType == SKAlphaType.Premul ? 32 : 24),
                            //    (ushort)XDefaultDepth(display, screen),
                            //    ZPixmap,
                            //    0,
                            //    ptr,
                            //    (ushort)bmp.Width,
                            //    (ushort)bmp.Height,
                            //    8,
                            //    0
                            //    //bpp,
                            //    //(short)(bmp.RowBytes - 4 * bmp.Width)
                            //    );
                            // 复制数组
                            //Marshal.Copy(bytes, 0, ptr, bytes.Length);
                            //image.ByteOrder = MSBFirst;
                            //image.BitmapBitOrder = MSBFirst;
                            //Console.WriteLine($"image ={Marshal.SizeOf(image)}");
                            //Console.WriteLine($"image ={image.width}, {image.height}, {image.data}");
                            //XInitImage(ref image);
                            //Console.WriteLine($"image ={image.Width}, {image.Height}, {image.Xoffset}, {image.Format}, {image.Data}, {image.ByteOrder}, {image.BitmapUnit}");
                            //Console.WriteLine($"image = {image}");
                            //IntPtr icon_pixmap = XCreatePixmap(display, window, 32, 32, 24);
                            //IntPtr icon_pixmap1 = XCreatePixmap(display, window, 32, 32, 24);
                            //Console.WriteLine($"icon_pixmap = {icon_pixmap}, icon_pixmap1 = {1}");
                            //ximage = XCreateImage(dpy, vis, 24, ZPixmap, 0, &iconData[0], iconWidth, iconHeight, 32, 0);
                            //int res = XPutImage(display, icon_pixmap, gc, image2, 0, 0, 0, 0, 32, 32);
                            //Console.WriteLine($"XPutImage = {res}");

                            //var winHints = XAllocWMHints();
                            //Console.WriteLine($"winHints = {winHints.IconX}");
                            //winHints.Flags = IconPixmapHint | StateHint | IconPositionHint;
                            //winHints.IconPixmap = icon_pixmap;
                            //winHints.InitialState = IconicState;
                            //winHints.IconX = 0;
                            //winHints.IconY = 0;

                            //XSetWMHints(display, window, ref winHints);

                            //XFree(ref winHints);

                        }
                    }
                }

                _display = display;
                _window = window;

                Thread thread = new Thread(() =>
                {
                    while (!_disposed)
                    {
                        //LibX11.XNextEvent(display, ref evt);
                        int tp = LibX11Helper.GetXNextEventType(display, evt);
                        Console.WriteLine($"evt = {tp}");

                        if (tp == LibX11.Expose)
                        {
                            Console.WriteLine($"evt = Expose");
                            // 绘图
                            using (var fs = sy.IO.OpenFile($"{sy.IO.GetExecutionPath("bg.jpg")}"))
                            {
                                using (var stream = new SKManagedStream(fs))
                                {
                                    using (SKBitmap bmp = SKBitmap.Decode(stream))
                                    {
                                        byte[] bytes = bmp.Bytes;
                                        IntPtr ptr = Marshal.AllocHGlobal(bytes.Length);
                                        Marshal.Copy(bytes, 0, ptr, bytes.Length);
                                        IntPtr image2 = LibX11Helper.XCreateImage2(
                                            display,
                                            LibX11.XDefaultVisual(display, screen),
                                            //(ushort)(bmp.AlphaType == SKAlphaType.Premul ? 32 : 24),
                                            (uint)LibX11.XDefaultDepth(display, screen),
                                            LibX11.ZPixmap,
                                            0,
                                            ptr,
                                            (uint)bmp.Width,
                                            (uint)bmp.Height,
                                            8,
                                            0
                                            //bpp,
                                            //(short)(bmp.RowBytes - 4 * bmp.Width)
                                            );
                                        int res = LibX11.XPutImage(display, window, gc, image2, 0, 0, 0, 0, (ushort)bmp.Width, (ushort)bmp.Height);
                                    }
                                }
                            }
                        }
                    }
                });
                thread.Start();


            }
        }

        /// <summary>
        /// 提交消息
        /// </summary>
        /// <param name="msg"></param>
        public void PostMessage(IMessage msg)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 重新显示
        /// </summary>
        public void Refresh()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendMessage(IMessage msg)
        {
            //throw new NotImplementedException();
            return true;
        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        public void Show()
        {
            /* 显示窗口 */
            LibX11.XMapWindow(_display, _window);
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public IWidget UseStyles(Action<Styles> action)
        {
            action(this.Styles);
            return this;
        }
    }
}