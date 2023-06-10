using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Messages;

namespace Suyaa.Gui.Controls
{
    /// <summary>
    /// 面板
    /// </summary>
    public class Panel : Block
    {
        /// <summary>
        /// 子控件集合
        /// </summary>
        public ControlContainer Controls { get; set; }

        /// <summary>
        /// 面板
        /// </summary>
        public Panel()
        {
            this.Controls = new ControlContainer(this);
        }

        /// <summary>
        /// 绘制界面
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="rect"></param>
        protected override void OnPaint(SKCanvas cvs, Rectangle rect)
        {
            base.OnPaint(cvs, rect);
            // 依次绘制cvs
            foreach (Control c in Controls)
            {
                // 发送绘制消息
                using (PaintMessage msg = new(c.Handle, cvs, rect))
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