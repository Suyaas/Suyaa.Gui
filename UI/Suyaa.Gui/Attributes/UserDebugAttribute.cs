using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 是否使用调试
    /// </summary>
    public class UserDebugAttribute : ValueStyleAttribute<bool>
    {
        /// <summary>
        /// 是否使用调试
        /// </summary>
        /// <param name="value"></param>
        public UserDebugAttribute(bool value) : base(StyleType.UseDebug, value)
        {
        }

        /// <summary>
        /// 是否使用调试
        /// </summary>
        public UserDebugAttribute() : base(StyleType.UseDebug, true)
        {
        }
    }
}
