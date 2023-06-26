using Suyaa.Gui.Enums;
using Suyaa.Gui.Native.Win32.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Win32
{
    /// <summary>
    /// Windows键盘操作类
    /// </summary>
    public sealed class Win32Keyboard : IKeyboard
    {
        private byte[]? _keyStates;

        /// <summary>
        /// 是否开启大写锁定
        /// </summary>
        public bool IsCapital => GetKeyState(Keys.Capital) == 1;

        /// <summary>
        /// 是否按下Ctrl键
        /// </summary>
        public bool IsControl => GetKeyState(Keys.ControlKey) == 1;

        /// <summary>
        /// 是否按下Alt键
        /// </summary>
        public bool IsAlt => GetKeyState(Keys.Menu) == 1;

        /// <summary>
        /// 是否按下了Alt键
        /// </summary>
        public bool IsShift => GetKeyState(Keys.ShiftKey) == 1;

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _keyStates = null;
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public byte GetKeyState(Keys key)
        {
            if (_keyStates is null) _keyStates = User32.GetKeyboardStates();
            return _keyStates[(int)key];
        }

        /// <summary>
        /// 扫描键盘状态
        /// </summary>
        public void ScanKeyStates()
        {
            _keyStates = User32.GetKeyboardStates();
        }
    }
}
