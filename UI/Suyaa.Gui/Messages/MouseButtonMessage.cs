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
    public sealed class MouseButtonMessage : Message
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public MouseOperates OperateType { get; }

        /// <summary>
        /// 坐标
        /// </summary>
        public Point Point { get; }

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        public MouseButtonMessage(long handle, MouseOperates operateType, Point point) : base(GuiMessages.MouseButton, handle)
        {
            this.OperateType = operateType;
            this.Point = point;
        }
    }
}
