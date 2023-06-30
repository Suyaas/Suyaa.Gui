using Suyaa.Gui.Enums;
using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll GetKeyboardState */
    public partial class User32
    {
        /// <summary>
        /// CreateIconIndirect
        /// </summary>
        /// <param name="lpKeyState"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, EntryPoint = "GetKeyboardState")]
        private unsafe static partial BOOL GetKeyboardState(byte* lpKeyState);

        /// <summary>
        /// 获取键盘状态
        /// </summary>
        public unsafe static byte[] GetKeyboardStates()
        {
            Span<byte> keystate = stackalloc byte[256];
            fixed (byte* b = keystate)
            {
                User32.GetKeyboardState(b);
            }
            return keystate.ToArray();
        }

        /// <summary>
        /// 获取键盘状态
        /// </summary>
        /// <param name="key"></param>
        public unsafe static byte GetKeyboardState(Keys key)
        {
            Span<byte> keystate = stackalloc byte[256];
            fixed (byte* b = keystate)
            {
                User32.GetKeyboardState(b);
            }
            return keystate[(int)key];
        }
    }
}
