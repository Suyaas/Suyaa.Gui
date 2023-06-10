using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
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
        /// 重置大小
        /// </summary>
        Resize = 0x201,
    }
}
