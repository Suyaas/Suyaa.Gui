using Forms;
using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Drawing;
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
        [Offset(AlignType.Center, 0, AlignType.Center, -50)]
        [BackgroundColor(0xff0094ff)]
        [UserCache(true)]
        class FormStyle { }

        /// <summary>
        /// 块样式
        /// </summary>
        [Size(50, UnitType.Percentage, 100, UnitType.Pixel)]
        [Offset(20, 20)]
        [BackgroundColor(0xff009900)]
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
                    .Set(StyleType.BackgroundColor, new SKColor(0xff990000));
            }
        }
    }
}
