using Forms;
using Forms.Helpers;
using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Forms;
using Suyaa.Gui.Native.Win32;

namespace Win32App
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class FrmMain : Form
    {
        private readonly Label _labInfo;

        /// <summary>
        /// 主窗体
        /// </summary>
        public FrmMain()
        {
            this.Title = "Win32App 测试";
            this.Styles.SetStyles<FormStyle>();

            // 设置内容标签
            _labInfo = new Label("Label");

            // 添加控件
            this.Controls.AddRange(
                Control.Create<Block>().UseStyles(d => d.SetStyles<TestBlockStyle>()).AsControl(),
                Control.Create<Block>().UseStyles(d => d.SetStyles<TestBlock2Style>()).AsControl(),
                _labInfo.UseStyles(d => d
                    .Set<float>(StyleType.X, 5)
                    .Set<float>(StyleType.Y, 5)
                //.Set(StyleType.BackgroundColor, new SKColor(0xff990000))
                ).AsControl()
                );
        }
    }
}
