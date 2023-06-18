using Forms.Helpers;
using SkiaSharp;
using Suyaa;
using Suyaa.Gui;
using Suyaa.Gui.Controls.EventArgs;
using Suyaa.Gui.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.User32;

namespace Forms
{
    /* 窗体 - 内部 */
    public abstract partial class FormBase
    {
        // 界面重绘
        internal void WorkareaRepaint(SKCanvas canvas)
        {
            // 绘制标准样式结果
            using (PaintEventArgs e = new(canvas, this.Styles)
            {
                Rectangle = this.Workarea.Rectangle,
                Scale = Application.GetScale(),
            })
            {
                this.Workarea.PaintStandardStyles(e);
                //canvas.DrawStyles(this.Styles, this.Workarea.Rectangle);
            }
            this.OnWorkareaPaint(canvas);
        }
    }
}
