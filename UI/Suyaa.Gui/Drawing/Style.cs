using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Gui.Enums;

namespace Suyaa.Gui.Drawing
{
    /// <summary>
    /// 样式
    /// </summary>
    public class Style<T> where T : notnull
    {
        /// <summary>
        /// 样式类型
        /// </summary>
        public StyleType StyleType { get; set; }

        /// <summary>
        /// 样式值
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        public Style(StyleType style, T value)
        {
            this.StyleType = style;
            this.Value = value;
        }
    }

    /// <summary>
    /// 样式
    /// </summary>
    public class Style : Style<object>
    {
        /// <summary>
        /// 样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        public Style(StyleType style, object value) : base(style, value) { }
    }
}
