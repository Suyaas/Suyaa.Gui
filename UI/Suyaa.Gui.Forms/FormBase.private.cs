using Forms.Helpers;
using SkiaSharp;
using Suyaa;
using Suyaa.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms
{
    /* 窗体 - 虚拟方法 */
    public abstract partial class FormBase
    {
        // 界面重绘
        private void RePaint(SKCanvas canvas)
        {

            this.OnPaint(canvas);
        }

        // 生效样式特性
        private void ApplyStyle()
        {
            var type = this.GetType();
        }
    }
}
