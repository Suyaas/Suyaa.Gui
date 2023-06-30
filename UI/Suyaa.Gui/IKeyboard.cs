using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 键盘操作
    /// </summary>
    public interface IKeyboard : IDisposable
    {
        /// <summary>
        /// 扫描键盘状态
        /// </summary>
        void ScanKeyStates();
        /// <summary>
        /// 获取键盘状态
        /// </summary>
        byte GetKeyState(Keys key);
        /// <summary>
        /// 判断键是否被按下
        /// </summary>
        bool IsKeyDown(Keys key);
        /// <summary>
        /// 是否开启大写
        /// </summary>
        bool IsCapital { get; }
        /// <summary>
        /// 是否按下Ctrl键
        /// </summary>
        bool IsControl { get; }
        /// <summary>
        /// 是否按下Alt键
        /// </summary>
        bool IsAlt { get; }
        /// <summary>
        /// 是否按下Shift键
        /// </summary>
        bool IsShift { get; }
    }
}
