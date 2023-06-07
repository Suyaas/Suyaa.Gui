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
            /// <summary>
            /// Type
            /// </summary>
            public short Type;
        }

        /// <summary>
        /// XTextProperty
        /// </summary>
        public struct XTextProperty
        {
            /// <summary>
            /// Value
            /// </summary>
            public IntPtr Value;       /* same as Property routines */
            /// <summary>
            /// Encoding
            /// </summary>
            public uint Encoding;          /* prop type */
            /// <summary>
            /// Format
            /// </summary>
            public short Format;             /* prop data format: 8, 16, or 32 */
            /// <summary>
            /// NItems
            /// </summary>
            public uint NItems;		/* number of data items in value */
        }

        /// <summary>
        /// XWMHints
        /// </summary>
        public struct XWMHints
        {
            /// <summary>
            /// Flags
            /// </summary>
            public int Flags; /* marks which fields in this structure are defined */
            /// <summary>
            /// Input
            /// </summary>
            public short Input; /* does this application rely on the window manager to
			get keyboard input? */
            /// <summary>
            /// InitialState
            /// </summary>
            public short InitialState;  /* see below */
            /// <summary>
            /// IconPixmap
            /// </summary>
            public IntPtr IconPixmap; /* pixmap to be used as icon */
            /// <summary>
            /// IconWindow
            /// </summary>
            public IntPtr IconWindow;     /* window to be used as icon */
            /// <summary>
            /// IconX
            /// </summary>
            public short IconX;
            /// <summary>
            /// IconY
            /// </summary>
            public short IconY;     /* initial position of icon */
            /// <summary>
            /// IconMask
            /// </summary>
            public IntPtr IconMask;   /* icon mask bitmap */
            /// <summary>
            /// WindowGroup
            /// </summary>
            public uint WindowGroup;	/* id of related window group */
        }

        /// <summary>
        /// Data structure for "image" data, used by image manipulation routines.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct XImage
        {
            /// <summary>
            /// Funcs
            /// </summary>
            public XImageFuncs Funcs;
            /// <summary>
            /// Width
            /// </summary>
            public short Width;
            /// <summary>
            /// Height
            /// </summary>
            public short Height;      /* size of image */
            /// <summary>
            /// Xoffset
            /// </summary>
            public short Xoffset;        /* number of pixels offset in X direction */
            /// <summary>
            /// Format
            /// </summary>
            public short Format;         /* XYBitmap, XYPixmap, ZPixmap */
            /// <summary>
            /// Data
            /// </summary>
            public IntPtr Data;         /* pointer to image data */
            /// <summary>
            /// ByteOrder
            /// </summary>
            public short ByteOrder;     /* data byte order, LSBFirst, MSBFirst */
            /// <summary>
            /// BitmapUnit
            /// </summary>
            public short BitmapUnit;        /* quant. of scanline 8, 16, 32 */
            /// <summary>
            /// BitmapBitOrder
            /// </summary>
            public short BitmapBitOrder;   /* LSBFirst, MSBFirst */
            /// <summary>
            /// BitmapPad
            /// </summary>
            public short BitmapPad;     /* 8, 16, 32 either XY or ZPixmap */
            /// <summary>
            /// Depth
            /// </summary>
            public short Depth;          /* depth of image */
            /// <summary>
            /// BytesPerLine
            /// </summary>
            public short BytesPerLine;     /* accelerator to next line */
            /// <summary>
            /// BitsPerPixel
            /// </summary>
            public short BitsPerPixel;     /* bits per pixel (ZPixmap) */
            /// <summary>
            /// RedMask
            /// </summary>
            public uint RedMask; /* bits in z arrangement */
            /// <summary>
            /// GreenMask
            /// </summary>
            public uint GreenMask;
            /// <summary>
            /// BlueMask
            /// </summary>
            public uint BlueMask;
            /// <summary>
            /// Obdata
            /// </summary>
            public IntPtr Obdata;       /* hook for the object routines to hang on */
        }

        /// <summary>
        /// XImageFuncs
        /// </summary>
        public struct XImageFuncs
        {
            /// <summary>
            /// create_image
            /// </summary>
            public IntPtr create_image;
            /// <summary>
            /// destroy_image
            /// </summary>
            public IntPtr destroy_image;
            /// <summary>
            /// get_pixel
            /// </summary>
            public IntPtr get_pixel;
            /// <summary>
            /// put_pixel
            /// </summary>
            public IntPtr put_pixel;
            /// <summary>
            /// sub_image
            /// </summary>
            public IntPtr sub_image;
            /// <summary>
            /// add_pixel
            /// </summary>
            public IntPtr add_pixel;
        }

        /// <summary>
        /// _XImage
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct _XImage
        {
            /// <summary>
            /// f
            /// </summary>
            public XImageFuncs f;
            /// <summary>
            /// width, height
            /// </summary>
            public int width, height;          /* size of image */
            /// <summary>
            /// xoffset
            /// </summary>
            public int xoffset;                /* number of pixels offset in X direction */
            /// <summary>
            /// format
            /// </summary>
            public int format;             /* XYBitmap, XYPixmap, ZPixmap */
            /// <summary>
            /// data
            /// </summary>
            public IntPtr /*char* */data;           /* pointer to image data */
            /// <summary>
            /// byte_order
            /// </summary>
            public int byte_order;         /* data byte order, LSBFirst, MSBFirst */
            /// <summary>
            /// bitmap_unit
            /// </summary>
            public int bitmap_unit;            /* quant. of scanline 8, 16, 32 */
            /// <summary>
            /// bitmap_bit_order
            /// </summary>
            public int bitmap_bit_order;       /* LSBFirst, MSBFirst */
            /// <summary>
            /// bitmap_pad
            /// </summary>
            public int bitmap_pad;         /* 8, 16, 32 either XY or ZPixmap */
            /// <summary>
            /// depth
            /// </summary>
            public int depth;                  /* depth of image */
            /// <summary>
            /// bytes_per_line
            /// </summary>
            public int bytes_per_line;     /* accelerator to next scanline */
            /// <summary>
            /// bits_per_pixel
            /// </summary>
            public int bits_per_pixel;     /* bits per pixel (ZPixmap) */
            /// <summary>
            /// red_mask
            /// </summary>
            public ulong red_mask;         /* bits in z arrangement */
            /// <summary>
            /// green_mask
            /// </summary>
            public ulong green_mask;
            /// <summary>
            /// blue_mask
            /// </summary>
            public ulong blue_mask;
            /// <summary>
            /// obdata
            /// </summary>
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
