using Suyaa.Gui.Enums;
using Suyaa.Gui.Native.Win32;
using Suyaa.Gui.Native.Win32.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Helpers
{
    /// <summary>
    /// 光标助手
    /// </summary>
    public static class CursorHelper
    {
        /// <summary>
        /// 获取光标
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Cursor GetWin32Cursor(this Enums.Cursors type)
        {
            return type switch
            {
                Enums.Cursors.Hand => Cursor.Create(User32.CursorResourceId.IDC_HAND),
                Enums.Cursors.Edit => Cursor.Create(User32.CursorResourceId.IDC_IBEAM),
                _ =>
                    Win32.Cursors.Default
            };
        }
    }
}
