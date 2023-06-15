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
    /// 下边框样式设置
    /// </summary>
    public class BorderBottomAttribute : BorderAttribute
    {
        /// <summary>
        /// 下边框样式设置
        /// </summary>
        public BorderBottomAttribute(float size, uint color, BorderStyleType style = BorderStyleType.Solid) : base(size, color, style)
        {
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Styles styles)
        {
            styles
                .Set(StyleType.BorderBottomSize, this.Size)
                .Set(StyleType.BorderBottomStyle, this.BorderStyle)
                .Set(StyleType.BorderBottomColor, this.Color);
        }
    }
}
