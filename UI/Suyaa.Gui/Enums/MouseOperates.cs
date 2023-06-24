using SkiaSharp;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Enums
{
    /// <summary>
    /// 鼠标操作类型
    /// </summary>
    public enum MouseOperates : int
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,
        /// <summary>
        /// 按下
        /// </summary>
        Down = 0x01,
        /// <summary>
        /// 抬起
        /// </summary>
        Up = 0x02,
        /// <summary>
        /// 左键
        /// </summary>
        LButton = 0x10,
        /// <summary>
        /// 左键按下
        /// </summary>
        LButtonDown = LButton | Down,
        /// <summary>
        /// 左键抬起
        /// </summary>
        LButtonUp = LButton | Up,
        /// <summary>
        /// 右键
        /// </summary>
        RButton = 0x10,
        /// <summary>
        /// 右键按下
        /// </summary>
        RButtonDown = RButton | Down,
        /// <summary>
        /// 右键抬起
        /// </summary>
        RButtonUp = RButton | Up,
        /// <summary>
        /// 中键
        /// </summary>
        MButton = 0x10,
        /// <summary>
        /// 中键按下
        /// </summary>
        MButtonDown = MButton | Down,
        /// <summary>
        /// 中键抬起
        /// </summary>
        MButtonUp = MButton | Up,
    }
}
