using Forms;
using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Forms;
using Suyaa.Gui.Native.Win32;

namespace Win32App
{
    public partial class FrmMain
    {
        /// <summary>
        /// 窗口样式
        /// </summary>
        [Size(800, 500)]
        [Position(0, -50, AlignType.Center, AlignType.Center)]
        [BackgroundColor(0xff0094ff)]
        //[BackgroundColor(0xffffffff)]
        [UseCache(true)]
        [Font(Names = "微软雅黑", Size = 14)]
        [Padding(10)]
        class FormStyle { }

        /// <summary>
        /// 块样式
        /// </summary>
        [Size(50, 100, UnitType.Percentage, UnitType.Pixel)]
        //[Position(0, 20, AlignType.Center, AlignType.Normal)]
        [BackgroundColor(0xff003300)]
        [Margin(50, 20, 10, 50)]
        //[UseDebug]
        [UseCache]
        [BorderShadow(0, 0, 50, 0xff000000)]
        [BorderTop(1, 0xffffffff, BorderStyles.Dashed)]
        [BorderRight(2, 0xffffff00, BorderStyles.Dashed)]
        [BorderBottom(3, 0xffff0000, BorderStyles.Dashed)]
        [BorderLeft(4, 0xffff00ff, BorderStyles.Solid)]
        [BorderRadius(10)]
        class TestBlockStyle { }

        /// <summary>
        /// 块2样式
        /// </summary>
        //[Position(0, 20, AlignType.Center, AlignType.Normal)]
        [BackgroundColor(0xff993300)]
        //[UseDebug]
        [BorderShadow(2, 2, 10, 0x99000000)]
        [UseCache]
        [BorderRadius(40, 10, 20, 30)]
        [Margin(0, 0, 20, 0)]
        [BorderTop(2, 0xffffffff, BorderStyles.Dashed)]
        [BorderRight(4, 0xffffff00, BorderStyles.Dashed)]
        [BorderBottom(8, 0xffff0000, BorderStyles.Dashed)]
        [BorderLeft(16, 0xffff00ff, BorderStyles.Dashed)]
        class TestBlock2Style : IStyles
        {
            public void Apply(Suyaa.Gui.Drawing.StyleCollection styles)
            {
                styles
                    .Set<float>(Suyaa.Gui.Enums.Styles.Width, 200)
                    .Set<float>(Suyaa.Gui.Enums.Styles.Height, 120);
            }
        }

        // Hello 按钮
        [Position(10, 40)]
        class BtnHelloStyle { }
    }
}
