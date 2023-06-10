using Forms.Helpers;
using SkiaSharp;
using Suyaa;
using Suyaa.Gui;
using Suyaa.Gui.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms
{
    /* 窗体 - 内部 */
    public abstract partial class FormBase
    {
        // 界面重绘
        internal void WorkareaRepaint(SKCanvas canvas)
        {
            // 绘制标准样式结果
            canvas.DrawStyles(this.Styles);
            this.OnWorkareaPaint(canvas);
        }
    }
}
