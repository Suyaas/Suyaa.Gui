using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 内边距样式设置
    /// </summary>
    public class MarginAttribute : StyleAttribute
    {
        /// <summary>
        /// 上边距
        /// </summary>
        public float Top { get; set; }

        /// <summary>
        /// 右边距
        /// </summary>
        public float Right { get; set; }

        /// <summary>
        /// 下边距
        /// </summary>
        public float Bottom { get; set; }

        /// <summary>
        /// 左边距
        /// </summary>
        public float Left { get; set; }

        /// <summary>
        /// 内边距样式设置
        /// </summary>
        public MarginAttribute(float size) : base(StyleType.None)
        {
            this.Top = size;
            this.Right = size;
            this.Bottom = size;
            this.Left = size;
        }

        /// <summary>
        /// 内边距样式设置
        /// </summary>
        public MarginAttribute(float topBottom, float leftRight) : base(StyleType.None)
        {
            this.Top = topBottom;
            this.Right = leftRight;
            this.Bottom = topBottom;
            this.Left = leftRight;
        }

        /// <summary>
        /// 内边距样式设置
        /// </summary>
        public MarginAttribute(float top, float right, float bottom, float left) : base(StyleType.None)
        {
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
            this.Left = left;
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Styles styles)
        {
            styles
                .Set(StyleType.MarginTop, this.Top)
                .Set(StyleType.MarginRight, this.Right)
                .Set(StyleType.MarginBottom, this.Bottom)
                .Set(StyleType.MarginLeft, this.Left);
        }
    }
}
