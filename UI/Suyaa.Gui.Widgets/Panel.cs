using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Helpers;
using Suyaa.Gui.Messages;
using static Suyaa.Gui.Native.Win32.Apis.User32;
using Suyaa.Gui.Native.Win32.Apis;
using static System.Formats.Asn1.AsnWriter;

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
                    break;
                // 鼠标移动事件
                case MouseButtonMessage mouseButton:
                    if (!OnMouseButtonMessage(mouseButton)) return false;
                    break;
            }
            return base.OnMessage(msg);
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