using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll GetDoubleClickTime */
    public partial class User32
    {
        /// <summary>
        /// 获取系统双击间隔
        /// </summary>
        /// <returns></returns>
        [LibraryImport(Libraries.User32)]
        public static partial uint GetDoubleClickTime();
    }
}
