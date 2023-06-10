using Forms.Helpers;
using SkiaSharp;
using Suyaa;
using Suyaa.Gui;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            //this.OnWorkareaPaint(canvas);
        }
    }
}
