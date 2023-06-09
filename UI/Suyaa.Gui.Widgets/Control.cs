using SkiaSharp;
using Suyaa.Gui.Drawing;

namespace Suyaa.Gui.Controls
{
    /// <summary>
    /// 组件基类
    /// </summary>
    public abstract class Control : IControl
    {
        // 关联窗体
        private IForm? _form;
        // 关联窗体
        private IControl? _parent;

        /// <summary>
        /// 组件基类
        /// </summary>
        public Control()
        {
            // 初始化样式表
            this.Styles = new Styles();
            // 生成新的唯一句柄
            this.Handle = Application.GetNewHandle();
        }

        /// <summary>
        /// 唯一句柄
        /// </summary>
        public long Handle { get; }

        /// <summary>
        /// 关联窗体
        /// </summary>
        public IForm Form
        {
            get
            {
                // 优先使用父对象的窗体，无父对象则以获取设置窗体
                if (_parent is null)
                {
                    return _form.Fixed();
                }
                return _parent.Form;
            }
            protected set
            {
                // 设置关联窗体
                _form = value;
            }
        }

        /// <summary>
        /// 父对象
        /// </summary>
        public IControl Parent
        {
            get => _parent.Fixed();
            internal protected set
            {
                _parent = value;
            }
        }

        /// <summary>
        /// 样式列表
        /// </summary>
        public Styles Styles { get; }

        /// <summary>
        /// 缓存图像
        /// </summary>
        public SKBitmap? CacheBitmap { get; protected set; }

        /// <summary>
        /// 消息事件
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual bool OnMessage(IMessage msg) { return true; }

        /// <summary>
        /// 消息发送事件
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual bool OnSendMessage(IMessage msg) { return true; }

        /// <summary>
        /// 消息提交事件
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual void OnPostMessage(IMessage msg) { }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendMessage(IMessage msg)
        {
            if (msg.Handle == this.Handle)
            {
                return this.OnMessage(msg);
            }
            else
            {
                return this.OnSendMessage(msg);
            }
        }

        /// <summary>
        /// 提交消息
        /// </summary>
        /// <param name="msg"></param>
        public void PostMessage(IMessage msg)
        {
            if (msg.Handle == this.Handle)
            {
                this.OnMessage(msg);
            }
            else
            {
                this.OnPostMessage(msg);
            }
        }
    }
}
