using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Messages
{
    /// <summary>
    /// 鼠标键消息
    /// </summary>
    public class MouseButtonMessage : Message
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public MouseOperateType OperateType { get; }

        /// <summary>
        /// 坐标
        /// </summary>
        public Point Point { get; }

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        public MouseButtonMessage(long handle, MouseOperateType operateType, Point point) : base(GuiMessageType.MouseButton, handle)
        {
            this.OperateType = operateType;
            this.Point = point;
        }
    }
}
