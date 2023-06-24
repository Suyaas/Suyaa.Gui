using SkiaSharp;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Controls.EventArgs
{
    /// <summary>
    /// 绘图事件参数
    /// </summary>
    public class PaintEventArgs : GuiEventArgs
    {
        /// <summary>
        /// 画布
        /// </summary>
        public SKCanvas Canvas { get; }
        /// <summary>
        /// 样式
        /// </summary>
        public StyleCollection Styles { get; set; }
        /// <summary>
        /// 矩形
        /// </summary>
        public Rectangle Rectangle { get; set; }
        /// <summary>
        /// 比例
        /// </summary>
        public float Scale { get; set; }
        /// <summary>
        /// 绘图事件参数
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        public PaintEventArgs(SKCanvas cvs, StyleCollection styles)
        {
            this.Canvas = cvs;
            this.Styles = styles;
        }
    }
}
