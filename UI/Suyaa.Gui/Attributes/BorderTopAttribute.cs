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
    /// 上边框样式设置
    /// </summary>
    public class BorderTopAttribute : BorderAttribute
    {
        /// <summary>
        /// 上边框样式设置
        /// </summary>
        public BorderTopAttribute(float size, uint color, BorderStyleType style = BorderStyleType.Solid) : base(size, color, style)
        {
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
                .Set(StyleType.BorderTopColor, this.Color);
        }
    }
}
