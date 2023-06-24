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
        public BorderTopAttribute(float size, uint color, BorderStyles style = BorderStyles.Solid) : base(size, color, style)
        {
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
                .Set(Enums.Styles.BorderTopColor, this.Color);
        }
    }
}
