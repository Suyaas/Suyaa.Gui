using Suyaa;
using Suyaa.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Helpers
{
    /// <summary>
    /// 列表助手
    /// </summary>
    public static class ListHelper
    {
        /// <summary>
        /// 连接成字符串
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string Join(this List<char> list)
        {
            StringBuilder sb = new StringBuilder();
            list.ForEach(x => sb.Append(x));
            return sb.ToString();
        }

        /// <summary>
        /// 连接成字符串
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string Join(this List<char> list, int start, int len)
        {
            int end = start + len;
            StringBuilder sb = new StringBuilder();
            for (int i = start; i < end; i++) sb.Append(list[i]);
            return sb.ToString();
        }

        /// <summary>
        /// 清除多个
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static void Removes<T>(this List<T> list, int start, int len)
        {
            int end = start + len;
            for (int i = end - 1; i >= start; i--) list.RemoveAt(i);
        }
    }
}
