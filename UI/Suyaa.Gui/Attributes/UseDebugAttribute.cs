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
    public class UseDebugAttribute : ValueStyleAttribute<bool>
    {
        /// <summary>
        /// 是否使用调试
        /// </summary>
        /// <param name="value"></param>
        public UseDebugAttribute(bool value) : base(Styles.UseDebug, value)
        {
        }

        /// <summary>
        /// 是否使用调试
        /// </summary>
        public UseDebugAttribute() : base(Styles.UseDebug, true)
        {
        }
    }
}
