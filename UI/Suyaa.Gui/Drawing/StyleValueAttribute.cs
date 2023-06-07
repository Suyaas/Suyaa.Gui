using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Drawing
{
    /// <summary>
    /// 样式值类型
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class StyleValueAttribute : Attribute
    {
        /// <summary>
        /// 值类型
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// 样式值类型
        /// </summary>
        /// <param name="type"></param>
        public StyleValueAttribute(
            Type type
            )
        {
            this.Type = type;
        }
    }
}
