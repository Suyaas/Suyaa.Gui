using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 高度
    /// </summary>
    public class HeightAttribute : ValueStyleAttribute<float>
    {
        /// <summary>
        /// 高度
        /// </summary>
        /// <param name="value"></param>
        public HeightAttribute(float value) : base(StyleType.Height, value)
        {
        }
    }
}
