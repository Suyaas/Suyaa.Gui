using Forms;
using Forms.Helpers;
using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
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
        private readonly Input _txtHello;
        private readonly Button _btnHello;
        //private int num = 0;

        /// <summary>
        /// 主窗体
        /// </summary>
        public FrmMain()
        {
            //this.Title = "Win32App 测试";
            this.Title = sy.Assembly.FullName;
            this.UseStyles<FormStyle>();

            // 初始化全局控件
            _labInfo = new Label("输入测试");
            _txtHello = new Input("内容");
            _btnHello = new Button("按钮");
            _btnHello.Click += btnHello_Click;
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        protected override void OnLoad()
        {
            base.OnLoad();

            // 添加控件
            this.Controls.AddRange(
                _labInfo.UseStyles<LabHelloStyle>(),
                _txtHello,
                _btnHello.UseStyles<BtnHelloStyle>()
                );
        }

        // 按钮事件
        private void btnHello_Click(object sender, Suyaa.Gui.Controls.EventArgs.GuiEventArgs e)
        {
            //_labInfo.Content = $"{++num}";
        }

        protected override void OnMouseMove(Point point)
        {
            base.OnMouseMove(point);
            //_labInfo!.Content = $"{point.X}:{point.Y}";
        }
    }
}
