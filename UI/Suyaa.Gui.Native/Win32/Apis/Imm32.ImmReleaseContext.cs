using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* imm32.dll ImmReleaseContext */
    public partial class Imm32
    {
        /// <summary>
        /// 释放Ime上下文
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hIMC"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.Imm32)]
        public static partial BOOL ImmReleaseContext(nint hWnd, nint hIMC);
    }
}
