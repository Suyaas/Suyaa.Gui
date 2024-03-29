﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Enums
{
    /// <summary>
    /// 界面消息类型
    /// </summary>
    public enum GuiMessages
    {
        /// <summary>
        /// 未知消息
        /// </summary>
        None = 0,
        /// <summary>
        /// 初始化
        /// </summary>
        Init = 0x001,
        /// <summary>
        /// 关闭
        /// </summary>
        Close = 0x0ff,
        /// <summary>
        /// 绘制
        /// </summary>
        Paint = 0x101,
        /// <summary>
        /// 布局
        /// </summary>
        Layout = 0x201,
        /// <summary>
        /// 状态变化
        /// </summary>
        StatusChange = 0x202,
        /// <summary>
        /// 鼠标移动
        /// </summary>
        MouseMove = 0x301,
        /// <summary>
        /// 鼠标按键操作
        /// </summary>
        MouseButton = 0x302,
        /// <summary>
        /// 光标设置
        /// </summary>
        Cursor = 0x311,
        /// <summary>
        /// 鼠标按下
        /// </summary>
        KeyDown = 0x401,
        /// <summary>
        /// 鼠标抬起
        /// </summary>
        KeyUp = 0x402,
        /// <summary>
        /// Ime通知
        /// </summary>
        ImeNotify = 0x411,
        /// <summary>
        /// Ime字符
        /// </summary>
        ImeChar = 0x412,
    }
}
