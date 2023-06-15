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
    /// 左边框样式设置
    /// </summary>
    public class BorderLeftAttribute : BorderAttribute
    {
        /// <summary>
        /// 左边框样式设置
        /// </summary>
        public BorderLeftAttribute(float size, uint color, BorderStyleType style = BorderStyleType.Solid) : base(size, color, style)
        {
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Styles styles)
        {
            styles
                .Set(StyleType.BorderLeftSize, this.Size)
                .Set(StyleType.BorderLeftStyle, this.BorderStyle)
                .Set(StyleType.BorderLeftColor, this.Color);
        }
    }
}
