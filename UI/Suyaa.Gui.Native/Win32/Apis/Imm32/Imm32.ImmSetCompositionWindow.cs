using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* imm32.dll ImmSetCompositionWindow */
    public partial class Imm32
    {
        /// <summary>
        /// 设置IME位置
        /// </summary>
        /// <param name="hIMC"></param>
        /// <param name="lpCompForm"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.Imm32)]
        public static partial BOOL ImmSetCompositionWindow(IntPtr hIMC, ref COMPOSITIONFORM lpCompForm);
    }
}
