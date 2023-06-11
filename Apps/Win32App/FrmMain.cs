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
        // 标签
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
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            // 添加控件
            this.Controls.AddRange(
                Control.Create<Block>().UseStyles(d => d.SetStyles<TestBlockStyle>()).AsControl(),
                Control.Create<Block>().UseStyles(d => d.SetStyles<TestBlock2Style>()).AsControl(),
                Control.Create<MouseTestPanel>(),
                _labInfo.UseStyles(d => d
                    .Set<float>(StyleType.X, 5)
                    .Set<float>(StyleType.Y, 5)
                //.Set(StyleType.BackgroundColor, new SKColor(0xff990000))
                ).AsControl()
                );
        }

        protected override void OnMouseMove(Point point)
        {
            base.OnMouseMove(point);
            _labInfo!.Content = $"{point.X}:{point.Y}";
        }
    }
}
