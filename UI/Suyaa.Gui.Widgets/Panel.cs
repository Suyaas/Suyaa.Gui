using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Helpers;
using Suyaa.Gui.Messages;
using static System.Formats.Asn1.AsnWriter;

namespace Suyaa.Gui.Controls
{
    /// <summary>
    /// 面板
    /// </summary>
    public class Panel : Block, IContainerControl
    {
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
            foreach (Control c in Controls.OrderBy(d => d.ZIndex).ThenBy(d => d.Handle).ToList())
            {
                // 发送绘制消息
                using (PaintMessage msg = new(c.Handle, cvs, rect, scale))
                {
                    c.PostMessage(msg);
                }
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