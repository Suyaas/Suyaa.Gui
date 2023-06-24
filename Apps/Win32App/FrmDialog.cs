using Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Gui.Win32Native;
using Suyaa.Gui.Native.Win32;
using Suyaa.Gui.Forms;
using SkiaSharp;
using Suyaa.Gui.Enums;

namespace Win32App
{
    public class FrmDialog : Form
    {
        public FrmDialog()
        {
            this.Title = "提示";
            this.UseStyles(d => d
                .Set(Suyaa.Gui.Enums.Styles.XAlign, AlignType.Center)
                .Set(Suyaa.Gui.Enums.Styles.YAlign, AlignType.Center)
            );
        }

        // 绘制事件
        protected override void OnWorkareaPaint(SKCanvas canvas)
        {
            base.OnWorkareaPaint(canvas);
            SKCanvas cvs = canvas;
            cvs.Clear(SKColors.Gray);
        }
    }
}
