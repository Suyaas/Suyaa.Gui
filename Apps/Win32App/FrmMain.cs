using Forms;
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
        /// <summary>
        /// 主窗体
        /// </summary>
        public FrmMain()
        {
            this.Title = "Win32App 测试";
            this.Styles.SetStyles<FormStyle>();

            // 添加控件
            this.Controls.AddRange(
                Control.Create<Block>().UseStyles(d => d.SetStyles<TestBlockStyle>()),
                Control.Create<Block>().UseStyles(d => d.SetStyles<TestBlock2Style>())
                );
        }
    }
}
