using Forms;
using SkiaSharp;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Native.Win32;
using Suyaa.Gui.Native.Win32.Apis;
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
            this.Styles.Set(StyleType.Visible, true);
        }

        // 重新设置大小
        internal void Resize()
        {
            var form = (FormBase)this.Form;
            var win32Form = (Win32Form)form.NativeForm;
            // 获取窗体工作区域
            var rect = User32.GetClientRect(win32Form.Hwnd);
            var scale = Gdi32.GetDpiScale();
            // 兼容 宽度 和 高度 的变更
            //var width = form.Styles.Get<float>(StyleType.Width);
            //var height = form.Styles.Get<float>(StyleType.Height);
            // 设置 宽度 和 高度
            this.Styles.Set(StyleType.Width, rect.Width * scale);
            this.Styles.Set(StyleType.Height, rect.Height * scale);
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="rect"></param>
        /// <param name="scale"></param>
        protected override void OnPainting(SKCanvas cvs, Rectangle rect, float scale)
        {
            var form = (FormBase)this.Form;
            form.WorkareaRepaint(cvs);
            base.OnPainting(cvs, rect, scale);
        }
    }
}
