using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Helpers;
using Suyaa.Gui.Messages;

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
        /// 创建一个控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Create<T>()
            where T : Control
        {
            //return typeof(T).Create<T>();
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// 组件基类
        /// </summary>
        public Control()
        {
            // 初始化样式表
            this.Styles = new Styles(this);
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
        /// 绘制事件
        /// </summary>
        protected virtual void OnPaint(SKCanvas cvs, Rectangle rect) { }

        // 处理绘制消息
        private void OnPaintMessage(PaintMessage pm)
        {
            // 获取 是否使用缓存 样式
            var useCache = this.Styles.Get<bool>(StyleType.UseCache);
            // 获取 边距 样式
            var left = this.Styles.Get<float>(StyleType.X);
            var top = this.Styles.Get<float>(StyleType.Y);
            // 判断是否使用缓存
            if (useCache)
            {
                // 判断是否有缓存
                if (this.CacheBitmap is null)
                {
                    // 获取宽高
                    var width = this.Styles.Get<float>(StyleType.Width);
                    var height = this.Styles.Get<float>(StyleType.Height);
                    if (width <= 0 || height <= 0) return;
                    this.CacheBitmap = new SKBitmap((int)width, (int)height);
                    using (SKCanvas cvs = new SKCanvas(this.CacheBitmap))
                    {
                        cvs.DrawStyles(this.Styles);
                        this.OnPaint(cvs, new Rectangle(0, 0, width, height));
                    }
                }
                pm.Canvas.DrawBitmap(this.CacheBitmap, left, top);
            }
            else
            {
                // 获取宽高
                var width = this.Styles.Get<float>(StyleType.Width);
                var height = this.Styles.Get<float>(StyleType.Height);
                if (width <= 0 || height <= 0) return;
                // 直接绘制
                using (SKBitmap bmp = new SKBitmap((int)width, (int)height))
                {
                    using (SKCanvas cvs = new SKCanvas(bmp))
                    {
                        cvs.DrawStyles(this.Styles);
                        this.OnPaint(cvs, new Rectangle(0, 0, width, height));
                    }
                    pm.Canvas.DrawBitmap(bmp, left, top);
                }
            }
        }

        /// <summary>
        /// 消息事件
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual bool OnMessage(IMessage msg)
        {
            switch (msg)
            {
                case PaintMessage pm:
                    OnPaintMessage(pm);
                    return true;
            }
            return true;
        }

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

        /// <summary>
        /// 刷新显示
        /// </summary>
        public void Refresh()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 使用样式
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Control UseStyles(Action<Styles> action)
        {
            action(this.Styles);
            return this;
        }
    }
}
