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
    /// 尺寸样式设置
    /// </summary>
    public class BorderAttribute : StyleAttribute
    {
        /// <summary>
        /// 尺寸
        /// </summary>
        public float Size { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public SKColor Color { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public BorderStyleType BorderStyle { get; set; }

        /// <summary>
        /// 字体
        /// </summary>
        public BorderAttribute(float size, uint color, BorderStyleType style = BorderStyleType.Solid) : base(StyleType.None)
        {
            this.Size = size;
            this.Color = new SKColor(color);
            this.BorderStyle = style;
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Styles styles)
        {
            styles
                .Set(StyleType.BorderTopSize, this.Size)
                .Set(StyleType.BorderTopStyle, this.BorderStyle)
                .Set(StyleType.BorderTopColor, this.Color)
                .Set(StyleType.BorderRightSize, this.Size)
                .Set(StyleType.BorderRightStyle, this.BorderStyle)
                .Set(StyleType.BorderRightColor, this.Color)
                .Set(StyleType.BorderBottomSize, this.Size)
                .Set(StyleType.BorderBottomStyle, this.BorderStyle)
                .Set(StyleType.BorderBottomColor, this.Color)
                .Set(StyleType.BorderLeftSize, this.Size)
                .Set(StyleType.BorderLeftStyle, this.BorderStyle)
                .Set(StyleType.BorderLeftColor, this.Color);
        }
    }
}
