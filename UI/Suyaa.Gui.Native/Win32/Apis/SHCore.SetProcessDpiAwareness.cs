using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* SHCore.dll SetProcessDpiAwareness */
    public partial class SHCore
    {
        /// <summary>
        /// PROCESS_DPI_AWARENESS
        /// </summary>
        public enum PROCESS_DPI_AWARENESS
        {
            /// <summary>
            /// Process_DPI_Unaware
            /// </summary>
            Process_DPI_Unaware = 0,
            /// <summary>
            /// Process_System_DPI_Aware
            /// </summary>
            Process_System_DPI_Aware = 1,
            /// <summary>
            /// Process_Per_Monitor_DPI_Aware
            /// </summary>
            Process_Per_Monitor_DPI_Aware = 2
        }

        /// <summary>
        /// SetProcessDpiAwareness
        /// </summary>
        /// <param name="awareness"></param>
        /// <returns></returns>
        [LibraryImport("SHCore.dll", SetLastError = true)]
        public static partial BOOL SetProcessDpiAwareness(PROCESS_DPI_AWARENESS awareness);
    }
}
