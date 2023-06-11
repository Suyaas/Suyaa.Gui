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
    public static class IntegerHelper
    {
        /// <summary>
        /// 获取高位值
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int GetHWord(this int n)
        {
            return (n >> 16) & 0xffff;
        }

        /// <summary>
        /// 获取低位值
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int GetLWord(this int n)
        {
            return n & 0xffff;
        }
    }
}
