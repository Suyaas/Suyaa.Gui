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
    public class FontAttribute : StyleAttribute
    {
        /// <summary>
        /// 字体名称
        /// </summary>
        public string? Names { get; set; }

        /// <summary>
        /// 高度单位
        /// </summary>
        public float Size { get; set; }

        /// <summary>
        /// 字体
        /// </summary>
        public FontAttribute() : base(StyleType.None)
        {
            this.Size = 0;
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Styles styles)
        {
            if (!this.Names.IsNullOrWhiteSpace()) styles.Set(StyleType.TextFont, this.Names!);
            if (this.Size > 0) styles.Set(StyleType.TextSize, this.Size);
        }
    }
}
