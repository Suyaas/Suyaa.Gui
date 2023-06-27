using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* imm32.dll ImmGetContext */
    public partial class Imm32
    {
        /// <summary>
        /// 获取Ime状态
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.Imm32)]
        public static partial nint ImmGetContext(nint hWnd);
    }
}
