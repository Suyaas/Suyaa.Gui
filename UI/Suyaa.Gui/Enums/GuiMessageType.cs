using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Enums
{
    /// <summary>
    /// 界面消息类型
    /// </summary>
    public enum GuiMessageType
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
    }
}
