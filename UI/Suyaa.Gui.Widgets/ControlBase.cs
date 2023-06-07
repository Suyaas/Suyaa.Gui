using SkiaSharp;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Widgets
{
    /// <summary>
    /// 组件基类
    /// </summary>
    public abstract class ControlBase : IControl
    {
        // 关联窗体
        private IForm? _form;

        /// <summary>
        /// 组件基类
        /// </summary>
        public ControlBase()
        {
            // 初始化样式表
            this.Styles = new Styles();
            // 生成新的唯一句柄
            this.Handle = Application.GetNewHandle();
            // 注册控件
            Application.RegControl(this, null);
        }

        /// <summary>
        /// 唯一句柄
        /// </summary>
        public long Handle { get; }

        /// <summary>
        /// 关联窗体
        /// </summary>
        public IForm? Form
        {
            get => _form;
            internal set
            {
                // 设置关联窗体
                _form = value;
                // 注册控件
                Application.RegControl(this, _form);
            }
        }

        /// <summary>
        /// 样式列表
        /// </summary>
        public Styles Styles { get; }

        /// <summary>
        /// 缓存图像
        /// </summary>
        public SKBitmap? CacheBitmap { get; private set; }

        /// <summary>
        /// 消息事件
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual bool OnMessage(IMessage msg) { return true; }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendMessage(IMessage msg)
        {
            return this.OnMessage(msg);
        }

        /// <summary>
        /// 提交消息
        /// </summary>
        /// <param name="msg"></param>
        public void PostMessage(IMessage msg)
        {
            this.OnMessage(msg);
        }
    }
}
