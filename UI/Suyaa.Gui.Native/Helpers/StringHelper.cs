using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Helpers
{
    /// <summary>
    /// 字符串助手
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 获取指针
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static unsafe char* AsPtr(this string str)
        {
            fixed (char* ptr = str)
            {
                return ptr;
            }
        }
    }
}
