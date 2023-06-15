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
    /// 右边框样式设置
    /// </summary>
    public class BorderRightAttribute : BorderAttribute
    {
        /// <summary>
        /// 右边框样式设置
        /// </summary>
        public BorderRightAttribute(float size, uint color, BorderStyleType style = BorderStyleType.Solid) : base(size, color, style)
        {
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Styles styles)
        {
            styles
                .Set(StyleType.BorderRightSize, this.Size)
                .Set(StyleType.BorderRightStyle, this.BorderStyle)
                .Set(StyleType.BorderRightColor, this.Color);
        }
    }
}
