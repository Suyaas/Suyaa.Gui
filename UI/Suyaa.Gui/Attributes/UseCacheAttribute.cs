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
    public class UseCacheAttribute : ValueStyleAttribute<bool>
    {
        /// <summary>
        /// 是否使用缓存
        /// </summary>
        /// <param name="value"></param>
        public UseCacheAttribute(bool value) : base(Styles.UseCache, value)
        {
        }

        /// <summary>
        /// 使用缓存
        /// </summary>
        public UseCacheAttribute() : base(Styles.UseCache, true)
        {
        }
    }
}
