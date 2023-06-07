using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Linux.Apis
{
    /*
     * 结构体
     */
    public partial class LibX11
    {

        /// <summary>
        /// XEvent
        /// </summary>
        public struct XEvent
        {
            public short Type;
        }

        /// <summary>
        /// XTextProperty
        /// </summary>
        public struct XTextProperty
        {
            public IntPtr Value;       /* same as Property routines */
            public uint Encoding;          /* prop type */
            public short Format;             /* prop data format: 8, 16, or 32 */
            public uint NItems;		/* number of data items in value */
        }

        /// <summary>
        /// XWMHints
        /// </summary>
        public struct XWMHints
        {
            public int Flags; /* marks which fields in this structure are defined */
            public short Input; /* does this application rely on the window manager to
			get keyboard input? */
            public short InitialState;  /* see below */
            public IntPtr IconPixmap; /* pixmap to be used as icon */
            public IntPtr IconWindow;     /* window to be used as icon */
            public short IconX;
            public short IconY;     /* initial position of icon */
            public IntPtr IconMask;   /* icon mask bitmap */
            public uint WindowGroup;	/* id of related window group */
        }

        /// <summary>
        /// Data structure for "image" data, used by image manipulation routines.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XImage
        {
            public XImageFuncs Funcs;
            public short Width;
            public short Height;      /* size of image */
            public short Xoffset;        /* number of pixels offset in X direction */
            public short Format;         /* XYBitmap, XYPixmap, ZPixmap */
            public IntPtr Data;         /* pointer to image data */
            public short ByteOrder;     /* data byte order, LSBFirst, MSBFirst */
            public short BitmapUnit;        /* quant. of scanline 8, 16, 32 */
            public short BitmapBitOrder;   /* LSBFirst, MSBFirst */
            public short BitmapPad;     /* 8, 16, 32 either XY or ZPixmap */
            public short Depth;          /* depth of image */
            public short BytesPerLine;     /* accelerator to next line */
            public short BitsPerPixel;     /* bits per pixel (ZPixmap) */
            public uint RedMask; /* bits in z arrangement */
            public uint GreenMask;
            public uint BlueMask;
            public IntPtr Obdata;       /* hook for the object routines to hang on */
        }

        public struct XImageFuncs
        {
            public IntPtr create_image;
            public IntPtr destroy_image;
            public IntPtr get_pixel;
            public IntPtr put_pixel;
            public IntPtr sub_image;
            public IntPtr add_pixel;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct _XImage
        {
            public XImageFuncs f;
            public int width, height;          /* size of image */
            public int xoffset;                /* number of pixels offset in X direction */
            public int format;             /* XYBitmap, XYPixmap, ZPixmap */
            public IntPtr /*char* */data;           /* pointer to image data */
            public int byte_order;         /* data byte order, LSBFirst, MSBFirst */
            public int bitmap_unit;            /* quant. of scanline 8, 16, 32 */
            public int bitmap_bit_order;       /* LSBFirst, MSBFirst */
            public int bitmap_pad;         /* 8, 16, 32 either XY or ZPixmap */
            public int depth;                  /* depth of image */
            public int bytes_per_line;     /* accelerator to next scanline */
            public int bits_per_pixel;     /* bits per pixel (ZPixmap) */
            public ulong red_mask;         /* bits in z arrangement */
            public ulong green_mask;
            public ulong blue_mask;
            public IntPtr obdata;                   /* hook for the object routines to hang on */
            //	struct funcs {			/* image manipulation routines */
            //		struct _XImage *(*create_image)();
            //		int (*destroy_image)();
            //		unsigned long (*get_pixel)();
            //		int (*put_pixel)();
            //		struct _XImage *(*sub_image)();
            //		int (*add_pixel)();
            //	} f;
        }

    }
}
