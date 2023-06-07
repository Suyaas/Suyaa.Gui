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
        /// <summary>
        /// 加载事件
        /// </summary>
        protected virtual void OnLoad() { }

        /// <summary>
        /// 绘制事件
        /// </summary>
        protected virtual void OnPaint(SKCanvas canvas) { }

        /// <summary>
        /// 显示事件
        /// </summary>
        protected virtual void OnShow() { }
    }
}
