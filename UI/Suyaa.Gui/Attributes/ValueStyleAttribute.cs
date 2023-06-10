using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 值样式特性
    /// </summary>
    public class ValueStyleAttribute<T> : StyleAttribute
        where T : notnull
    {
        public T Value { get; }

        /// <summary>
        /// 值样式特性
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        public ValueStyleAttribute(StyleType style, T value) : base(style)
        {
            this.Value = value;
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Styles styles)
        {
            styles.Set(this.Style, this.Value);
        }
    }
}
