using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /// <summary>
    /// 助手类
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// 获取是否为真
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        public static bool IsTrue(this BOOL bl)
            => bl == BOOL.TRUE;

        /// <summary>
        /// 获取是否为假
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        public static bool IsFalse(this BOOL bl)
            => !bl.IsTrue();
    }
}
