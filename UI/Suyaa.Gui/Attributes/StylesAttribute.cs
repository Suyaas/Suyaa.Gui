using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 样式基础特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class StylesAttribute : Attribute
    {
        /// <summary>
        /// 样式类型
        /// </summary>
        public List<Type> Styles { get; }

        /// <summary>
        /// 样式基础特性
        /// </summary>
        /// <param name="styles"></param>
        public StylesAttribute(params Type[] styles)
        {
            this.Styles = styles.ToList();
        }
    }
}
