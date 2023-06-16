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
        [UserCache(true)]
        [Font(Names = "微软雅黑", Size = 14)]
        class FormStyle { }

        /// <summary>
        /// 块样式
        /// </summary>
        [Size(50, 100, UnitType.Percentage, UnitType.Pixel)]
        //[Position(0, 20, AlignType.Center, AlignType.Normal)]
        [BackgroundColor(0xff003300)]
        class TestBlockStyle { }

        /// <summary>
        /// 第二个块
        /// </summary>
        class TestBlock2Style : IStyles
        {
            public void Apply(Styles styles)
            {
                styles
                    .Set<float>(StyleType.Width, 200)
                    .Set<float>(StyleType.Height, 120)
                    .Set<float>(StyleType.X, 50)
                    .Set<float>(StyleType.Y, 50)
                    .Set(StyleType.BackgroundColor, new SKColor(0x99990000));
            }
        }
    }
}
