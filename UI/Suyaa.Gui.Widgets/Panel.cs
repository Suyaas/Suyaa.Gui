using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Helpers;
using Suyaa.Gui.Messages;
using static Suyaa.Gui.Native.Win32.Apis.User32;
using Suyaa.Gui.Native.Win32.Apis;
using static System.Formats.Asn1.AsnWriter;
using Suyaa.Gui.Enums;
using System.Runtime.InteropServices;

namespace Suyaa.Gui.Controls
{
    /// <summary>
    /// 面板
    /// </summary>
    public class Panel : Block, IContainerControl
    {
        /// <summary>
        /// 是否响应鼠标事件
        /// </summary>
        public override bool IsMouseReply => true;

        /// <summary>
        /// 子控件集合
        /// </summary>
        public IControlCollection<IControl> Controls { get; }

        /// <summary>
        /// 面板
        /// </summary>
        public Panel()
        {
            this.Controls = new ControlContainer(this);
        }

        /// <summary>
        /// 绘制结束事件
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="rect"></param>
        /// <param name="scale"></param>
        protected override void OnPainted(SKCanvas cvs, Rectangle rect, float scale)
        {
            base.OnPainted(cvs, rect, scale);
            // 按照Z轴深度和创建先后依次绘制子控件
            var controls = Controls.Where(d => d.IsVaild).OrderBy(d => d.ZIndex).ThenBy(d => d.Handle).ToList();
            foreach (Control c in controls)
            {
                // 发送绘制消息
                using (PaintMessage msg = new(c.Handle, cvs, rect, scale))
                {
                    c.SendMessage(msg);
                }
            }
        }

        // 处理鼠标移动消息
        private bool OnMouseMoveMessage(MouseMoveMessage mouseMove)
        {
            // 按照Z轴深度和创建先后依次绘制子控件
            var controls = Controls.Where(d => d.IsVaild && d.IsMouseReply).OrderByDescending(d => d.ZIndex).ThenByDescending(d => d.Handle).ToList();
            foreach (Control c in controls)
            {
                // 发送绘制消息
                using (MouseMoveMessage msg = new(c.Handle, new Point(mouseMove.Point.X - c.Left, mouseMove.Point.Y - c.Top)))
                {
                    c.PostMessage(msg);
                }
            }
            return true;
        }

        // 处理鼠标操作消息
        private bool OnMouseButtonMessage(MouseButtonMessage mouseButton)
        {
            // 按照Z轴深度和创建先后依次绘制子控件
            var controls = Controls.Where(d => d.IsVaild && d.IsMouseReply).OrderByDescending(d => d.ZIndex).ThenByDescending(d => d.Handle).ToList();
            foreach (Control c in controls)
            {
                // 跳过无关元素
                if (!c.Rectangle.Contain(mouseButton.Point)) continue;
                // 发送绘制消息
                using (MouseButtonMessage msg = new(c.Handle, mouseButton.OperateType, new Point(mouseButton.Point.X - c.Left, mouseButton.Point.Y - c.Top)))
                {
                    if (!c.SendMessage(msg)) return false;
                }
            }
            return true;
        }

        // 处理尺寸重置事件
        private bool OnResizeMessage(ResizeMessage resize)
        {
            // 获取对象尺寸
            var size = this.Size;
            // 按照创建先后顺序重置大小
            var controls = Controls.Where(d => d.IsVaild).OrderBy(d => d.Handle).ToList();
            foreach (Control ctl in controls)
            {
                var ctlSize = ctl.Styles.GetSize(size, resize.Scale);
                // 发送绘制消息
                using (ResizeMessage msg = new(ctl.Handle, ctlSize, resize.Scale))
                {
                    if (!ctl.SendMessage(msg)) return false;
                }
            }

            #region 处理浮动定位
            // 处理浮动定位
            var floatControls = Controls.Where(d => d.IsVaild).OrderBy(d => d.Handle).ToList();
            float floatLeft = 0;
            float floatRight = 0;
            float[] floatTops = new float[(int)this.Width];
            foreach (var ctl in floatControls)
            {
                // 跳过固定的
                if (ctl.Styles.Get<PositionType>(StyleType.Position) == PositionType.Fixed) continue;
                // 获取对齐方式
                var xAlign = ctl.Styles.Get<AlignType>(StyleType.XAlign);
                // 浮动不支持居中
                if (xAlign == AlignType.Center) throw new GuiException("Float position not support center align.");
                // 计算左边距
                float x = 0;
                float right = 0;
                if (xAlign == AlignType.Normal)
                {
                    // 左浮动
                    x = floatLeft;
                    // 右占位
                    right = x + ctl.Rectangle.Width;
                    // 超出范围则换入下一行
                    if (right > this.Width)
                    {
                        if (floatLeft > 0)
                        {
                            floatLeft = 0;
                            x = 0;
                            right = x + ctl.Rectangle.Width;
                        }
                        else
                        {
                            right = this.Width;
                        }
                    }
                    // 添加浮动偏移
                    floatLeft += ctl.Rectangle.Width;
                }
                else
                {
                    // 计算右浮动
                    x = size.Width - ctl.Rectangle.Width - floatRight;
                    if (x < 0)
                    {
                        if (floatRight > 0)
                        {
                            floatRight = 0;
                            x = size.Width - ctl.Rectangle.Width;
                        }
                        else
                        {
                            floatRight = size.Width - ctl.Rectangle.Width;
                        }
                    }
                    // 右占位
                    right = x + ctl.Rectangle.Width;
                    // 添加浮动偏移
                    floatRight += ctl.Rectangle.Width;
                }
                // 查找合适的上边距
                float y = 0;
                for (int i = (int)x; i < right; i++)
                {
                    if (x < 0) continue;
                    if (floatTops[i] > y) y = floatTops[i];
                }
                float bottom = y + ctl.Rectangle.Height;
                // 更新上边距占位
                for (int i = (int)x; i < right; i++)
                {
                    if (x < 0) continue;
                    floatTops[i] = bottom;
                }
                // 发送移动事件
                using (MoveMessage msg = new(ctl.Handle, new Point(x, y)))
                {
                    if (!ctl.SendMessage(msg)) return false;
                }
            }
            #endregion

            #region 处理固定定位

            #endregion

            return true;
        }

        /// <summary>
        /// 消息处理事件
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected override bool OnMessage(IMessage msg)
        {
            switch (msg)
            {
                // 鼠标移动事件
                case MouseMoveMessage mouseMove:
                    OnMouseMoveMessage(mouseMove);
                    return base.OnMessage(msg);
                // 鼠标移动事件
                case MouseButtonMessage mouseButton:
                    if (!OnMouseButtonMessage(mouseButton)) return false;
                    return base.OnMessage(msg);
                // 布局事件
                case ResizeMessage resize:
                    if (!base.OnMessage(msg)) return false;
                    return OnResizeMessage(resize);
                default: return base.OnMessage(msg);
            }
        }

        /// <summary>
        /// 转发消息发送
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected override bool OnSendMessage(IMessage msg)
        {
            foreach (Control c in this.Controls)
            {
                if (!c.SendMessage(msg)) return false;
            }
            return base.OnSendMessage(msg);
        }

        /// <summary>
        /// 转发消息提交
        /// </summary>
        /// <param name="msg"></param>
        protected override void OnPostMessage(IMessage msg)
        {
            foreach (Control c in this.Controls)
            {
                c.PostMessage(msg);
            }
            base.OnPostMessage(msg);
        }
    }
}