using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 宽度
    /// </summary>
    public class WidthAttribute : ValueStyleAttribute<float>
    {
        /// <summary>
        /// 宽度
        /// </summary>
        /// <param name="value"></param>
        public WidthAttribute(float value) : base(StyleType.Width, value)
        {
        }
    }
}
