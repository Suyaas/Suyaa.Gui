using Suyaa.Gui.Enums;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll GetAsyncKeyState */
    public partial class User32
    {
        /// <summary>
        /// 获取键值
        /// </summary>
        /// <param name="vkey"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32)]
        public static partial ushort GetAsyncKeyState(int vkey);

        /// <summary>
        /// 判断键是否被按下
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool CheckKeyDown(Keys key)
        {
            var state = GetAsyncKeyState((int)key) & 0x8000;
            //Debug.WriteLine($"[User32] CheckKeyDown key:{key}, state:{state}(0x{state.ToString("x").PadLeft(4, '0')})");
            return state > 0;
        }
    }
}
