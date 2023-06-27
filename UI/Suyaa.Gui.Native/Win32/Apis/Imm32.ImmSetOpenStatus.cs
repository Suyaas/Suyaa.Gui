using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* imm32.dll ImmSetOpenStatus */
    public partial class Imm32
    {
        /// <summary>
        /// 设置Ime状态
        /// </summary>
        /// <param name="hIMC"></param>
        /// <param name="open"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.Imm32)]
        public static partial BOOL ImmSetOpenStatus(IntPtr hIMC, BOOL open);
    }
}
