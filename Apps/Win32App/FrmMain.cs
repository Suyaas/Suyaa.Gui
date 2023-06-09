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
    [Styles(typeof(FormStyle))]
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 主窗体
        /// </summary>
        public FrmMain()
        {
            this.Title = "Win32App 测试";
            this.Styles
                .SetStyles<Css.MainFormSize>()
                .Set<float>(StyleType.Width, 800)
                .Set<float>(StyleType.Height, 500)
                .Set(StyleType.UseCache, true);

            // 添加控件
            Block block = new Block();
            block.Styles.SetStyles<Css.TestBlockStyle>();
            this.Controls.Add(block);
        }

        /// <summary>
        /// 重载加载
        /// </summary>
        protected override void OnLoad()
        {
            base.OnLoad();
            FrmDialog frmDialog = new FrmDialog();
            frmDialog.Show();
        }

        protected override void OnShow()
        {
            base.OnShow();
            //FrmDialog frmDialog = new FrmDialog();
            //frmDialog.Show();
        }

        // 绘制事件
        protected override void OnPaint(SKCanvas canvas)
        {
            base.OnPaint(canvas);

            // 红色边框笔刷
            SKPaint redBorderPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 2,
                //设置抗锯齿
                IsAntialias = true,
            };

            // 红色填充笔刷
            SKPaint blueFillPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Blue,
                StrokeWidth = 2,
                //设置抗锯齿
                IsAntialias = true,
            };

            SKCanvas cvs = canvas;
            cvs.Clear(SKColors.DarkGreen);
            cvs.DrawRect(10, 10, 100, 100, redBorderPaint);
            cvs.DrawRect(50, 50, 100, 100, blueFillPaint);

            redBorderPaint.Dispose();
        }
    }
}
