﻿//using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.User32;

namespace Suyaa.Gui.Win32Native
{
    /// <summary>
    /// Win32 Apis
    /// </summary>
    public class Win32Api
    {
        ///// <summary>
        ///// 创建一个窗口 
        ///// </summary>
        //public const int WM_CREATE = 0x01;
        ///// <summary>
        ///// 当一个窗口被破坏时发送
        ///// </summary>
        //public const int WM_DESTROY = 0x02;
        ////移动一个窗口  
        //public const int WM_MOVE = 0x03;
        ////改变一个窗口的大小  
        //public const int WM_SIZE = 0x05;
        ////一个窗口被激活或失去激活状态  
        //public const int WM_ACTIVATE = 0x06;
        ////一个窗口获得焦点  
        //public const int WM_SETFOCUS = 0x07;
        ////一个窗口失去焦点  
        //public const int WM_KILLFOCUS = 0x08;
        ////一个窗口改变成Enable状态  
        //public const int WM_ENABLE = 0x0A;
        ////设置窗口是否能重画  
        //public const int WM_SETREDRAW = 0x0B;
        ////应用程序发送此消息来设置一个窗口的文本  
        //public const int WM_SETTEXT = 0x0C;
        ////应用程序发送此消息来复制对应窗口的文本到缓冲区  
        //public const int WM_GETTEXT = 0x0D;
        ////得到与一个窗口有关的文本的长度（不包含空字符）  
        //public const int WM_GETTEXTLENGTH = 0x0E;
        ////要求一个窗口重画自己  
        //public const int WM_PAINT = 0x0F;
        ////当一个窗口或应用程序要关闭时发送一个信号  
        //public const int WM_CLOSE = 0x10;
        ////当用户选择结束对话框或程序自己调用ExitWindows函数  
        //public const int WM_QUERYENDSESSION = 0x11;
        ////用来结束程序运行  
        //public const int WM_QUIT = 0x12;
        ////当用户窗口恢复以前的大小位置时，把此消息发送给某个图标  
        //public const int WM_QUERYOPEN = 0x13;
        ////当窗口背景必须被擦除时（例在窗口改变大小时）  
        //public const int WM_ERASEBKGND = 0x14;
        ////当系统颜色改变时，发送此消息给所有***窗口  
        //public const int WM_SYSCOLORCHANGE = 0x15;
        ////当系统进程发出WM_QUERYENDSESSION消息后，此消息发送给应用程序，通知它对话是否结束  
        //public const int WM_ENDSESSION = 0x16;
        ////当隐藏或显示窗口是发送此消息给这个窗口  
        //public const int WM_SHOWWINDOW = 0x18;
        ////发此消息给应用程序哪个窗口是激活的，哪个是非激活的  
        //public const int WM_ACTIVATEAPP = 0x1C;
        ////当系统的字体资源库变化时发送此消息给所有***窗口  
        //public const int WM_FONTCHANGE = 0x1D;
        ////当系统的时间变化时发送此消息给所有***窗口  
        //public const int WM_TIMECHANGE = 0x1E;
        ////发送此消息来取消某种正在进行的摸态（操作）  
        //public const int WM_CANCELMODE = 0x1F;
        ////如果鼠标引起光标在某个窗口中移动且鼠标输入没有被捕获时，就发消息给某个窗口  
        //public const int WM_SETCURSOR = 0x20;
        ////当光标在某个非激活的窗口中而用户正按着鼠标的某个键发送此消息给//当前窗口  
        //public const int WM_MOUSEACTIVATE = 0x21;
        ////发送此消息给MDI子窗口//当用户点击此窗口的标题栏，或//当窗口被激活，移动，改变大小  
        //public const int WM_CHILDACTIVATE = 0x22;
        ////此消息由基于计算机的训练程序发送，通过WH_JOURNALPALYBACK的hook程序分离出用户输入消息  
        //public const int WM_QUEUESYNC = 0x23;
        ////此消息发送给窗口当它将要改变大小或位置  
        //public const int WM_GETMINMAXINFO = 0x24;
        ////发送给最小化窗口当它图标将要被重画  
        //public const int WM_PAINTICON = 0x26;
        ////此消息发送给某个最小化窗口，仅//当它在画图标前它的背景必须被重画  
        //public const int WM_ICONERASEBKGND = 0x27;
        ////发送此消息给一个对话框程序去更改焦点位置  
        //public const int WM_NEXTDLGCTL = 0x28;
        ////每当打印管理列队增加或减少一条作业时发出此消息   
        //public const int WM_SPOOLERSTATUS = 0x2A;
        ////当button，combobox，listbox，menu的可视外观改变时发送  
        //public const int WM_DRAWITEM = 0x2B;
        ////当button, combo box, list box, list view control, or menu item 被创建时  
        //public const int WM_MEASUREITEM = 0x2C;
        ////此消息有一个LBS_WANTKEYBOARDINPUT风格的发出给它的所有者来响应WM_KEYDOWN消息   
        //public const int WM_VKEYTOITEM = 0x2E;
        ////此消息由一个LBS_WANTKEYBOARDINPUT风格的列表框发送给他的所有者来响应WM_CHAR消息   
        //public const int WM_CHARTOITEM = 0x2F;
        ////当绘制文本时程序发送此消息得到控件要用的颜色  
        //public const int WM_SETFONT = 0x30;
        ////应用程序发送此消息得到当前控件绘制文本的字体  
        //public const int WM_GETFONT = 0x31;
        ////应用程序发送此消息让一个窗口与一个热键相关连   
        //public const int WM_SETHOTKEY = 0x32;
        ////应用程序发送此消息来判断热键与某个窗口是否有关联  
        //public const int WM_GETHOTKEY = 0x33;
        ////此消息发送给最小化窗口，当此窗口将要被拖放而它的类中没有定义图标，应用程序能返回一个图标或光标的句柄，当用户拖放图标时系统显示这个图标或光标  
        //public const int WM_QUERYDRAGICON = 0x37;
        ////发送此消息来判定combobox或listbox新增加的项的相对位置  
        //public const int WM_COMPAREITEM = 0x39;
        ////显示内存已经很少了  
        //public const int WM_COMPACTING = 0x41;
        ////发送此消息给那个窗口的大小和位置将要被改变时，来调用setwindowpos函数或其它窗口管理函数  
        //public const int WM_WINDOWPOSCHANGING = 0x46;
        ////发送此消息给那个窗口的大小和位置已经被改变时，来调用setwindowpos函数或其它窗口管理函数  
        //public const int WM_WINDOWPOSCHANGED = 0x47;
        ////当系统将要进入暂停状态时发送此消息  
        //public const int WM_POWER = 0x48;
        ////当一个应用程序传递数据给另一个应用程序时发送此消息  
        //public const int WM_COPYDATA = 0x4A;
        ////当某个用户取消程序日志激活状态，提交此消息给程序  
        //public const int WM_CANCELJOURNA = 0x4B;
        ////当某个控件的某个事件已经发生或这个控件需要得到一些信息时，发送此消息给它的父窗口   
        //public const int WM_NOTIFY = 0x4E;
        ////当用户选择某种输入语言，或输入语言的热键改变  
        //public const int WM_INPUTLANGCHANGEREQUEST = 0x50;
        ////当平台现场已经被改变后发送此消息给受影响的最***窗口  
        //public const int WM_INPUTLANGCHANGE = 0x51;
        ////当程序已经初始化windows帮助例程时发送此消息给应用程序  
        //public const int WM_TCARD = 0x52;
        ////此消息显示用户按下了F1，如果某个菜单是激活的，就发送此消息个此窗口关联的菜单，否则就发送给有焦点的窗口，如果//当前都没有焦点，就把此消息发送给//当前激活的窗口  
        //public const int WM_HELP = 0x53;
        ////当用户已经登入或退出后发送此消息给所有的窗口，//当用户登入或退出时系统更新用户的具体设置信息，在用户更新设置时系统马上发送此消息  
        //public const int WM_USERCHANGED = 0x54;
        ////公用控件，自定义控件和他们的父窗口通过此消息来判断控件是使用ANSI还是UNICODE结构  
        //public const int WM_NOTIFYFORMAT = 0x55;
        ////当用户某个窗口中点击了一下右键就发送此消息给这个窗口  
        ////const int WM_CONTEXTMENU = ??;  
        ////当调用SETWINDOWLONG函数将要改变一个或多个 窗口的风格时发送此消息给那个窗口  
        //public const int WM_STYLECHANGING = 0x7C;
        ////当调用SETWINDOWLONG函数一个或多个 窗口的风格后发送此消息给那个窗口  
        //public const int WM_STYLECHANGED = 0x7D;
        ////当显示器的分辨率改变后发送此消息给所有的窗口  
        //public const int WM_DISPLAYCHANGE = 0x7E;
        ////此消息发送给某个窗口来返回与某个窗口有关连的大图标或小图标的句柄  
        //public const int WM_GETICON = 0x7F;
        ////程序发送此消息让一个新的大图标或小图标与某个窗口关联  
        //public const int WM_SETICON = 0x80;
        ////当某个窗口第一次被创建时，此消息在WM_CREATE消息发送前发送  
        //public const int WM_NCCREATE = 0x81;
        ////此消息通知某个窗口，非客户区正在销毁   
        //public const int WM_NCDESTROY = 0x82;
        ////当某个窗口的客户区域必须被核算时发送此消息  
        //public const int WM_NCCALCSIZE = 0x83;
        ////移动鼠标，按住或释放鼠标时发生  
        //public const int WM_NCHITTEST = 0x84;
        ////程序发送此消息给某个窗口当它（窗口）的框架必须被绘制时  
        //public const int WM_NCPAINT = 0x85;
        ////此消息发送给某个窗口仅当它的非客户区需要被改变来显示是激活还是非激活状态  
        //public const int WM_NCACTIVATE = 0x86;
        ////发送此消息给某个与对话框程序关联的控件，widdows控制方位键和TAB键使输入进入此控件通过应  
        //public const int WM_GETDLGCODE = 0x87;
        ////当光标在一个窗口的非客户区内移动时发送此消息给这个窗口 非客户区为：窗体的标题栏及窗 的边框体  
        //public const int WM_NCMOUSEMOVE = 0xA0;
        ////当光标在一个窗口的非客户区同时按下鼠标左键时提交此消息  
        //public const int WM_NCLBUTTONDOWN = 0xA1;
        ////当用户释放鼠标左键同时光标某个窗口在非客户区十发送此消息   
        //public const int WM_NCLBUTTONUP = 0xA2;
        ////当用户双击鼠标左键同时光标某个窗口在非客户区十发送此消息  
        //public const int WM_NCLBUTTONDBLCLK = 0xA3;
        ////当用户按下鼠标右键同时光标又在窗口的非客户区时发送此消息  
        //public const int WM_NCRBUTTONDOWN = 0xA4;
        ////当用户释放鼠标右键同时光标又在窗口的非客户区时发送此消息  
        //public const int WM_NCRBUTTONUP = 0xA5;
        ////当用户双击鼠标右键同时光标某个窗口在非客户区十发送此消息  
        //public const int WM_NCRBUTTONDBLCLK = 0xA6;
        ////当用户按下鼠标中键同时光标又在窗口的非客户区时发送此消息  
        //public const int WM_NCMBUTTONDOWN = 0xA7;
        ////当用户释放鼠标中键同时光标又在窗口的非客户区时发送此消息  
        //public const int WM_NCMBUTTONUP = 0xA8;
        ////当用户双击鼠标中键同时光标又在窗口的非客户区时发送此消息  
        //public const int WM_NCMBUTTONDBLCLK = 0xA9;
        ////WM_KEYDOWN 按下一个键  
        //public const int WM_KEYDOWN = 0x0100;
        ////释放一个键  
        //public const int WM_KEYUP = 0x0101;
        ////按下某键，并已发出WM_KEYDOWN， WM_KEYUP消息  
        //public const int WM_CHAR = 0x102;
        ////当用translatemessage函数翻译WM_KEYUP消息时发送此消息给拥有焦点的窗口  
        //public const int WM_DEADCHAR = 0x103;
        ////当用户按住ALT键同时按下其它键时提交此消息给拥有焦点的窗口  
        //public const int WM_SYSKEYDOWN = 0x104;
        ////当用户释放一个键同时ALT 键还按着时提交此消息给拥有焦点的窗口  
        //public const int WM_SYSKEYUP = 0x105;
        ////当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后提交此消息给拥有焦点的窗口  
        //public const int WM_SYSCHAR = 0x106;
        ////当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后发送此消息给拥有焦点的窗口  
        //public const int WM_SYSDEADCHAR = 0x107;
        ////在一个对话框程序被显示前发送此消息给它，通常用此消息初始化控件和执行其它任务  
        //public const int WM_INITDIALOG = 0x110;
        ////当用户选择一条菜单命令项或当某个控件发送一条消息给它的父窗口，一个快捷键被翻译  
        //public const int WM_COMMAND = 0x111;
        ////当用户选择窗口菜单的一条命令或//当用户选择最大化或最小化时那个窗口会收到此消息  
        //public const int WM_SYSCOMMAND = 0x112;
        ////发生了定时器事件  
        //public const int WM_TIMER = 0x113;
        ////当一个窗口标准水平滚动条产生一个滚动事件时发送此消息给那个窗口，也发送给拥有它的控件  
        //public const int WM_HSCROLL = 0x114;
        ////当一个窗口标准垂直滚动条产生一个滚动事件时发送此消息给那个窗口也，发送给拥有它的控件  
        //public const int WM_VSCROLL = 0x115;
        ////当一个菜单将要被激活时发送此消息，它发生在用户菜单条中的某项或按下某个菜单键，它允许程序在显示前更改菜单  
        //public const int WM_INITMENU = 0x116;
        ////当一个下拉菜单或子菜单将要被激活时发送此消息，它允许程序在它显示前更改菜单，而不要改变全部  
        //public const int WM_INITMENUPOPUP = 0x117;
        ////当用户选择一条菜单项时发送此消息给菜单的所有者（一般是窗口）  
        //public const int WM_MENUSELECT = 0x11F;
        ////当菜单已被激活用户按下了某个键（不同于加速键），发送此消息给菜单的所有者  
        //public const int WM_MENUCHAR = 0x120;
        ////当一个模态对话框或菜单进入空载状态时发送此消息给它的所有者，一个模态对话框或菜单进入空载状态就是在处理完一条或几条先前的消息后没有消息它的列队中等待  
        //public const int WM_ENTERIDLE = 0x121;
        ////在windows绘制消息框前发送此消息给消息框的所有者窗口，通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置消息框的文本和背景颜色  
        //public const int WM_CTLCOLORMSGBOX = 0x132;
        ////当一个编辑型控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色  
        //public const int WM_CTLCOLOREDIT = 0x133;

        ////当一个列表框控件将要被绘制前发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置列表框的文本和背景颜色  
        //public const int WM_CTLCOLORLISTBOX = 0x134;
        ////当一个按钮控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置按纽的文本和背景颜色  
        //public const int WM_CTLCOLORBTN = 0x135;
        ////当一个对话框控件将要被绘制前发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置对话框的文本背景颜色  
        //public const int WM_CTLCOLORDLG = 0x136;
        ////当一个滚动条控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置滚动条的背景颜色  
        //public const int WM_CTLCOLORSCROLLBAR = 0x137;
        ////当一个静态控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以 通过使用给定的相关显示设备的句柄来设置静态控件的文本和背景颜色  
        //public const int WM_CTLCOLORSTATIC = 0x138;
        ////当鼠标***转动时发送此消息个当前有焦点的控件  
        //public const int WM_MOUSEWHEEL = 0x20A;
        ////双击鼠标中键  
        //public const int WM_MBUTTONDBLCLK = 0x209;
        ////释放鼠标中键  
        //public const int WM_MBUTTONUP = 0x208;
        ////移动鼠标时发生，同WM_MOUSEFIRST  
        //public const int WM_MOUSEMOVE = 0x200;
        ////按下鼠标左键  
        //public const int WM_LBUTTONDOWN = 0x201;
        ////释放鼠标左键  
        //public const int WM_LBUTTONUP = 0x202;
        ////双击鼠标左键  
        //public const int WM_LBUTTONDBLCLK = 0x203;
        ////按下鼠标右键  
        //public const int WM_RBUTTONDOWN = 0x204;
        ////释放鼠标右键  
        //public const int WM_RBUTTONUP = 0x205;
        ////双击鼠标右键  
        //public const int WM_RBUTTONDBLCLK = 0x206;
        ////按下鼠标中键  
        //public const int WM_MBUTTONDOWN = 0x207;

        ///// <summary>
        ///// WM_DWMNCRENDERINGCHANGED - 799
        ///// </summary>
        //public const int WM_DWMNCRENDERINGCHANGED = 0x031F;

        //// 颜色压缩
        //public const int BI_RGB = 0;
        //public const int BI_RLE8 = 1;
        //public const int BI_RLE4 = 2;
        //public const int BI_BITFIELDS = 3;

        //public const int WM_USER = 0x0400;
        //public const int MK_LBUTTON = 0x0001;
        //public const int MK_RBUTTON = 0x0002;
        //public const int MK_SHIFT = 0x0004;
        //public const int MK_CONTROL = 0x0008;
        //public const int MK_MBUTTON = 0x0010;
        //public const int MK_XBUTTON1 = 0x0020;
        //public const int MK_XBUTTON2 = 0x0040;

        //// DibColorMode 
        //public const int DIB_RGB_COLORS = 0x00;
        //public const int DIB_PAL_COLORS = 0x01;
        //public const int DIB_PAL_INDICES = 0x02;

        //public enum TernaryRasterOperations : uint
        //{
        //    SRCCOPY = 0x00CC0020, /* dest = source*/
        //    SRCPAINT = 0x00EE0086, /* dest = source OR dest*/
        //    SRCAND = 0x008800C6, /* dest = source AND dest*/
        //    SRCINVERT = 0x00660046, /* dest = source XOR dest*/
        //    SRCERASE = 0x00440328, /* dest = source AND (NOT dest )*/
        //    NOTSRCCOPY = 0x00330008, /* dest = (NOT source)*/
        //    NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
        //    MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)*/
        //    MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest*/
        //    PATCOPY = 0x00F00021, /* dest = pattern*/
        //    PATPAINT = 0x00FB0A09, /* dest = DPSnoo*/
        //    PATINVERT = 0x005A0049, /* dest = pattern XOR dest*/
        //    DSTINVERT = 0x00550009, /* dest = (NOT dest)*/
        //    BLACKNESS = 0x00000042, /* dest = BLACK*/
        //    WHITENESS = 0x00FF0062, /* dest = WHITE*/
        //};

        ///// <summary>
        ///// 二维坐标
        ///// </summary>
        //[StructLayout(LayoutKind.Sequential)]
        //public struct Point
        //{
        //    public int x;
        //    public int y;

        //    /// <summary>
        //    /// 二维坐标
        //    /// </summary>
        //    /// <param name="x"></param>
        //    /// <param name="y"></param>
        //    public Point(int x, int y)
        //    {
        //        this.x = x;
        //        this.y = y;
        //    }
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //public struct Rect
        //{
        //    public int Left; //最左坐标
        //    public int Top; //最上坐标
        //    public int Right; //最右坐标
        //    public int Bottom; //最下坐标

        //    public int Width => Right - Left;
        //    public int Height => Bottom - Top;
        //}

        //[StructLayout(LayoutKind.Sequential, Pack = 2)]
        //public struct BitmapFileHeader
        //{
        //    public ushort bfType;
        //    public uint bfSize;
        //    public ushort bfReserved1;
        //    public ushort bfReserved2;
        //    public uint bfOffBits;
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //public struct BitmapInfoHeader
        //{
        //    public uint biSize;
        //    public int biWidth;
        //    public int biHeight;
        //    public ushort biPlanes;
        //    public ushort biBitCount;
        //    public uint biCompression;
        //    public uint biSizeImage;
        //    public int biXPelsPerMeter;
        //    public int biYPelsPerMeter;
        //    public uint biClrUsed;
        //    public uint biClrImportant;

        //    public void Init()
        //    {
        //        biSize = (uint)Marshal.SizeOf(this);
        //    }
        //}

        //[StructLayout(LayoutKind.Sequential, Pack = 1)]
        //public struct RgbQuad
        //{
        //    public byte rgbBlue;
        //    public byte rgbGreen;
        //    public byte rgbRed;
        //    public byte rgbReserved;
        //}

        //[StructLayout(LayoutKind.Sequential, Pack = 1)]
        //public struct BitmapInfo
        //{
        //    public BitmapInfoHeader bmiHeader;
        //    public RgbQuad bmiColors;
        //}

        //[Flags]
        //public enum WS_STYLE : long
        //{
        //    WS_OVERLAPPED = 0x00000000L,
        //    WS_CAPTION = 0x00C00000L,    /* WS_BORDER | WS_DLGFRAME  */
        //    WS_SYSMENU = 0x00080000L,
        //    WS_THICKFRAME = 0x00040000L,

        //    WS_MINIMIZEBOX = 0x00020000L,
        //    WS_MAXIMIZEBOX = 0x00010000L,

        //    WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED |
        //                     WS_CAPTION |
        //                     WS_SYSMENU |
        //                     WS_THICKFRAME |
        //                     WS_MINIMIZEBOX |
        //                     WS_MAXIMIZEBOX),
        //}

        ////[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        ////public class WNDCLASS
        ////{
        ////    public int style = 0;
        ////    public WNDPROC? lpfnWndProc = null;
        ////    public int cbClsExtra = 0;
        ////    public int cbWndExtra = 0;
        ////    public IntPtr hInstance = IntPtr.Zero;
        ////    public IntPtr hIcon = IntPtr.Zero;
        ////    public IntPtr hCursor = IntPtr.Zero;
        ////    public IntPtr hbrBackground = IntPtr.Zero;
        ////    public string? lpszMenuName = null;
        ////    public string? lpszClassName = null;
        ////}

        ////public const int WM_DESTROY = 2;
        ////public const int WM_CLOSE = 0x10;

        ///// <summary>
        ///// PostMessage
        ///// </summary>
        ///// <param name="hWnd"></param>
        ///// <param name="msg"></param>
        ///// <param name="wParam"></param>
        ///// <param name="lParam"></param>
        ///// <returns></returns>
        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        ///// <summary>
        ///// GetModuleHandle
        ///// </summary>
        ///// <param name="moduleName"></param>
        ///// <returns></returns>
        //[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        //public static extern IntPtr GetModuleHandle(string? moduleName);

        ///// <summary>
        ///// CreateWindowEx
        ///// </summary>
        ///// <param name="dwExStyle"></param>
        ///// <param name="lpszClassName"></param>
        ///// <param name="lpszWindowName"></param>
        ///// <param name="style"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="hWndParent"></param>
        ///// <param name="hMenu"></param>
        ///// <param name="hInst"></param>
        ///// <param name="pvParam"></param>
        ///// <returns></returns>
        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern IntPtr CreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, IntPtr hWndParent, IntPtr hMenu, IntPtr hInst, IntPtr pvParam);
        ////public static extern IntPtr CreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, IntPtr hWndParent, IntPtr hMenu, IntPtr hInst, [MarshalAs(UnmanagedType.AsAny)] object pvParam);
        ///// <summary>
        ///// ShowWindow
        ///// </summary>
        ///// <param name="hWnd"></param>
        ///// <param name="nCmdShow"></param>
        ///// <returns></returns>
        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        ///// <summary>
        ///// UpdateWindow
        ///// </summary>
        ///// <param name="hWnd"></param>
        ///// <returns></returns>
        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern bool UpdateWindow(IntPtr hWnd);

        ///// <summary>
        ///// TranslateMessage
        ///// </summary>
        ///// <param name="msg"></param>
        ///// <returns></returns>
        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern bool TranslateMessage(ref MSG msg);

        ///// <summary>
        ///// PostQuitMessage
        ///// </summary>
        ///// <param name="nExitCode"></param>
        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern void PostQuitMessage(int nExitCode);

        ///// <summary>
        ///// BitBlt
        ///// </summary>
        ///// <param name="hdcDest"></param>
        ///// <param name="nXDest"></param>
        ///// <param name="nYDest"></param>
        ///// <param name="nWidth"></param>
        ///// <param name="nHeight"></param>
        ///// <param name="hdcSrc"></param>
        ///// <param name="nXSrc"></param>
        ///// <param name="nYSrc"></param>
        ///// <param name="dwRop"></param>
        ///// <returns></returns>
        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, UInt32 dwRop);
        ///// <summary>
        ///// CreateDIBSection
        ///// </summary>
        ///// <param name="hdc"></param>
        ///// <param name="pbmi"></param>
        ///// <param name="iUsage"></param>
        ///// <param name="ppvBits"></param>
        ///// <param name="hSection"></param>
        ///// <param name="dwOffset"></param>
        ///// <returns></returns>
        //[DllImport("gdi32.dll", EntryPoint = "CreateDIBSection")]
        //public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BitmapInfo pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);
        ///// <summary>
        ///// GetDC
        ///// </summary>
        ///// <param name="hWnd"></param>
        ///// <returns></returns>
        //[DllImport("User32.dll", EntryPoint = "GetDC")]
        //public extern static IntPtr GetDC(IntPtr hWnd);

        ////[DllImport("User32.dll", EntryPoint = "ReleaseDC")]
        ////private extern static int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        ///// <summary>
        ///// 创建桌面句柄
        ///// </summary>
        ///// <param name="lpszDriver"></param>
        ///// <param name="lpszDevice"></param>
        ///// <param name="lpszOutput"></param>
        ///// <param name="lpInitData"></param>
        ///// <returns></returns>
        //[System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        //public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, int lpInitData);
        ///// <summary>
        ///// CreateCompatibleDC
        ///// </summary>
        ///// <param name="hdc"></param>
        ///// <returns></returns>
        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        ///// <summary>
        ///// 转换为本地的图像资源
        ///// </summary>
        ///// <param name="hdc"></param>
        ///// <param name="nWidth"></param>
        ///// <param name="nHeight"></param>
        ///// <returns></returns>
        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        ///// <summary>
        ///// SelectObject
        ///// </summary>
        ///// <param name="hdc"></param>
        ///// <param name="hgdiobj"></param>
        ///// <returns></returns>
        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        ///// <summary>
        ///// DeleteDC
        ///// </summary>
        ///// <param name="hdc"></param>
        ///// <returns></returns>
        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern int DeleteDC(IntPtr hdc);

        ///// <summary>
        ///// 释放用过的画笔等资源
        ///// </summary>
        ///// <param name="hdc"></param>
        ///// <returns></returns>
        //[DllImport("gdi32.dll")]
        //public static extern bool DeleteObject(IntPtr hdc);
    }
}
