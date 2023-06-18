using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 是否使用缓存
    /// </summary>
    public class UserCacheAttribute : ValueStyleAttribute<bool>
    {
        /// <summary>
        /// 是否使用缓存
        /// </summary>
        /// <param name="value"></param>
        public UserCacheAttribute(bool value) : base(StyleType.UseCache, value)
        {
        }

        /// <summary>
        /// 使用缓存
        /// </summary>
        public UserCacheAttribute() : base(StyleType.UseCache, true)
        {
        }
    }
}
