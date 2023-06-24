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
    /// 边框样式设置
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
        public BorderStyles BorderStyle { get; set; }

        /// <summary>
        /// 边框样式设置
        /// </summary>
        public BorderAttribute(float size, uint color, BorderStyles style = BorderStyles.Solid) : base(Enums.Styles.None)
        {
            this.Size = size;
            this.Color = new SKColor(color);
            this.BorderStyle = style;
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Drawing.StyleCollection styles)
        {
            styles
                .Set(Enums.Styles.BorderTopSize, this.Size)
                .Set(Enums.Styles.BorderTopStyle, this.BorderStyle)
                .Set(Enums.Styles.BorderTopColor, this.Color)
                .Set(Enums.Styles.BorderRightSize, this.Size)
                .Set(Enums.Styles.BorderRightStyle, this.BorderStyle)
                .Set(Enums.Styles.BorderRightColor, this.Color)
                .Set(Enums.Styles.BorderBottomSize, this.Size)
                .Set(Enums.Styles.BorderBottomStyle, this.BorderStyle)
                .Set(Enums.Styles.BorderBottomColor, this.Color)
                .Set(Enums.Styles.BorderLeftSize, this.Size)
                .Set(Enums.Styles.BorderLeftStyle, this.BorderStyle)
                .Set(Enums.Styles.BorderLeftColor, this.Color);
        }
    }
}
