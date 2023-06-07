using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll TranslateMessage */
    public partial class User32
    {
        /// <summary>
        /// 传送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [DllImport(Libraries.User32, ExactSpelling = true)]
        public static extern BOOL TranslateMessage(ref MSG msg);
    }
}
