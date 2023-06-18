using Forms;
using SkiaSharp;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Controls.EventArgs;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Native.Win32;
using Suyaa.Gui.Native.Win32.Apis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.User32;
using Size = Suyaa.Gui.Drawing.Size;

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

        /// <summary>
        /// 重置大小事件
        /// </summary>
        /// <param name="size"></param>
        /// <param name="scale"></param>
        protected override void OnResize(Size size, float scale)
        {
            // 获取窗体
            var form = (FormBase)this.Form;
            var win32Form = (Win32Form)form.NativeForm;
            // 获取窗体工作区域
            var rect = User32.GetClientRect(win32Form.Hwnd);
            // 设置 宽度 和 高度
            this.Styles.Set(StyleType.Width, rect.Width / scale);
            this.Styles.Set(StyleType.Height, rect.Height / scale);
            // 更新有效矩形区域
            bool isReduce = rect.Width < this.Width || rect.Height < this.Height;
            this.Resize(new Size(rect.Width, rect.Height), scale);
            // 计算内外边距
            this.Padding = form.Styles.GetPadding(scale);
            if (isReduce) this.Refresh();
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPainting(PaintEventArgs e)
        {
            var form = (FormBase)this.Form;
            form.WorkareaRepaint(e.Canvas);
            base.OnPainting(e);
        }
    }
}
