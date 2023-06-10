using Forms;
using SkiaSharp;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Forms
{
    /// <summary>
    /// 工作区域
    /// </summary>
    public class Workarea : Panel
    {
        /// <summary>
        /// 工作区域
        /// </summary>
        /// <param name="form"></param>
        public Workarea(FormBase form)
        {
            this.Form = form;
        }

        // 重新设置大小
        internal void Resize()
        {
            var form = (FormBase)this.Form;
            // 兼容 宽度 和 高度 的变更
            var width = form.Styles.Get<float>(StyleType.Width);
            var height = form.Styles.Get<float>(StyleType.Height);
            // 设置 宽度 和 高度
            this.Styles.Set(StyleType.Width, width);
            this.Styles.Set(StyleType.Height, height);
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="rect"></param>
        protected override void OnPaint(SKCanvas cvs, Rectangle rect)
        {
            var form = (FormBase)this.Form;
            form.WorkareaRepaint(cvs);
            base.OnPaint(cvs, rect);
        }
    }
}
