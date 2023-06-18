using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Helpers;
using Suyaa.Gui.Messages;
using static System.Formats.Asn1.AsnWriter;
using Suyaa.Gui.Native.Win32.Apis;
using Suyaa.Gui.Enums;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Suyaa.Gui.Controls.EventArgs;
using static Suyaa.Gui.Native.Win32.Apis.User32;
//using System.Drawing;

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
        private IContainerControl? _parent;
        // 是否强制刷新
        private bool _refresh;
        private bool _mouseOn;
        // 最后一次鼠标点击
        private int _lastMouseClick;

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
            // 初始化刷新属性
            _refresh = false;
            _mouseOn = false;
            _lastMouseClick = 0;
            // 初始化矩形区域
            this.Rectangle = new Rectangle();
            // 设置Z轴深度
            this.ZIndex = 0;
            // 初始化样式表
            this.Styles = new Styles(this);
            // 生成新的唯一句柄
            this.Handle = Application.GetNewHandle();
        }

        #region 公用属性

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
        /// 是否需要重新绘制
        /// </summary>
        public bool IsNeedRepaint
        {
            get => _refresh;
            protected internal set => _refresh = value;
        }

        /// <summary>
        /// 父对象
        /// </summary>
        public IContainerControl Parent
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
        /// Z轴深度
        /// </summary>
        public int ZIndex { get; internal protected set; }

        /// <summary>
        /// 外边距
        /// </summary>
        public Margin Margin { get; internal protected set; }

        /// <summary>
        /// 内边距
        /// </summary>
        public Margin Padding { get; internal protected set; }

        /// <summary>
        /// 主体区域
        /// </summary>
        public Rectangle Rectangle { get; private set; }

        /// <summary>
        /// 主体尺寸
        /// </summary>
        public Size Size => this.Rectangle.Size;

        /// <summary>
        /// 主体宽度
        /// </summary>
        public float Width => this.Rectangle.Width;

        /// <summary>
        /// 主体高度
        /// </summary>
        public float Height => this.Rectangle.Height;

        /// <summary>
        /// 主体位置
        /// </summary>
        public Point Point => this.Rectangle.Point;

        /// <summary>
        /// 主体相对父对象的左边距
        /// </summary>
        public float Left => this.Rectangle.Left;

        /// <summary>
        /// 主体相对父对象的上边距
        /// </summary>
        public float Top => this.Rectangle.Top;

        ///// <summary>
        ///// 矩形显示区域
        ///// </summary>
        //public Rectangle DisplayRectangle { get; private set; }

        /// <summary>
        /// 更新主体区域
        /// </summary>
        /// <param name="size"></param>
        /// <param name="scale"></param>
        /// <param name="relayout"></param>
        protected void Resize(Size size, float scale, bool relayout = false)
        {
            // 如果没有变化则退出
            if (this.Rectangle.Size.Equals(size)) return;
            // 重新刷新有效区域
            this.Rectangle = new Rectangle(this.Rectangle.Left, this.Rectangle.Top, size.Width, size.Height);
            // 计算内外边距
            this.Padding = this.Styles.GetPadding(scale);
            this.Margin = this.Styles.GetMargin(scale);
            if (relayout)
            {
                // 控件无效则不处理
                if (!this.IsVaild) return;
                // 触发父对象重新执行布局
                using (ResizeMessage msg = new(_parent!.Handle, size, scale))
                {
                    _parent!.SendMessage(msg);
                }
            }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsVaild
        {
            get
            {
                // 判断可见性
                var visible = this.GetStyle<bool>(StyleType.Visible);
                if (!visible) return false;
                // 判断是否拥有父对象
                if (_parent is null)
                {
                    // 没有父对象则判断是否关联窗体
                    if (_form is null) return false;
                    return true;
                }
                else
                {
                    // 带有父对象以父对象为依据
                    return _parent.IsVaild;
                }
            }
        }

        /// <summary>
        /// 是否响应鼠标事件
        /// </summary>
        public virtual bool IsMouseReply => true;

        #endregion

        #region 事件处理

        /// <summary>
        /// 绘制中事件
        /// </summary>
        protected virtual void OnPainting(PaintEventArgs e) { }

        /// <summary>
        /// 绘制结束事件
        /// </summary>
        protected virtual void OnPainted(PaintEventArgs e) { }

        /// <summary>
        /// 绘制标准样式
        /// </summary>
        public void PaintStandardStyles(PaintEventArgs e)
        {
            // 组织变量
            var styles = e.Styles;
            var cvs = e.Canvas;
            var marginDisplay = this.Styles.GetDisplayMargin(e.Scale);
            var rect = e.Rectangle.Padding(marginDisplay);
            // 绘制阴影
            cvs.DrawShadowStyles(styles, rect, e.Scale);
            // 绘制背景
            cvs.DrawBackgroundStyles(styles, rect.Padding(styles.GetBorders(e.Scale)));
            // 绘制上边框
            cvs.DrawBorderTopStyles(styles, rect);
            // 绘制右边框
            cvs.DrawBorderRightStyles(styles, rect);
            // 绘制下边框
            cvs.DrawBorderBottomStyles(styles, rect);
            // 绘制左边框
            cvs.DrawBorderLeftStyles(styles, rect);
            // 绘制阴影
            //cvs.DrawShadowStyles(styles, rect, e.Scale);
        }

        /// <summary>
        /// 绘制预处理事件
        /// </summary>
        private void OnPaintMessage(SKBitmap bitmap, float scale)
        {
            using (SKCanvas cvs = new SKCanvas(bitmap))
            {
                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                //cvs.DrawStyles(this.Styles, rect);
                using (PaintEventArgs e = new(cvs, this.Styles))
                {
                    e.Rectangle = rect;
                    e.Scale = scale;
                    this.PaintStandardStyles(e);
                    this.OnPainting(e);
                    this.OnPainted(e);
                }
#if DEBUG
                // 调试输出
                if (this.Styles.Get(StyleType.UseDebug, false))
                {
                    using (SKPaint paint = new SKPaint(new SKFont(SKTypeface.FromFamilyName("Consolas")))
                    {
                        Color = new SKColor(0x88333333),
                        TextSize = 9,
                    })
                    {
                        paint.GetFontMetrics(out SKFontMetrics metrics);
                        cvs.DrawText($"{this.Left},{this.Top},{this.Width},{this.Height}", 1, 1 - metrics.Top, paint);
                        cvs.DrawText($"{this.Margin.ToString("Margin")}", 1, 13 - metrics.Top, paint);
                        cvs.DrawText($"{this.Padding.ToString("Padding")}", 1, 25 - metrics.Top, paint);
                    }
                    using (SKPaint paint = new SKPaint(new SKFont(SKTypeface.FromFamilyName("Consolas")))
                    {
                        Color = new SKColor(0x88ffffff),
                        TextSize = 9,
                    })
                    {
                        paint.GetFontMetrics(out SKFontMetrics metrics);
                        cvs.DrawText($"{this.Left},{this.Top},{this.Width},{this.Height}", 0, 0 - metrics.Top, paint);
                        cvs.DrawText($"{this.Margin.ToString("Margin")}", 0, 12 - metrics.Top, paint);
                        cvs.DrawText($"{this.Padding.ToString("Padding")}", 0, 24 - metrics.Top, paint);
                    }
                }
#endif
            }
        }

        // 处理绘制消息
        private void OnPaintMessage(PaintMessage pm)
        {
            // 跳过不需要绘制的情况
            if (this.Width <= 0 || this.Height <= 0) return;

            // 判断有效性
            if (!this.IsVaild) return;

            // 获取 是否使用缓存 样式
            var useCache = this.Styles.Get<bool>(StyleType.UseCache);
            //var rect = pm.Rectangle;

            // 获取属性信息
            var margin = this.Margin;
            var marginDisplay = this.Styles.GetDisplayMargin(pm.Scale);
            var rectDisplay = this.Rectangle.Margin(marginDisplay);

            //var drawWidth = this.Width + margin.Left + margin.Right;
            //var drawHeight = this.Height + margin.Top + margin.Bottom;

            // 判断是否使用缓存
            if (useCache)
            {
                if (this.CacheBitmap != null)
                {
                    if (this.CacheBitmap.Width != rectDisplay.Width || this.CacheBitmap.Height != rectDisplay.Height || _refresh)
                    {
                        this.CacheBitmap.Dispose();
                        this.CacheBitmap = null;
                    }
                }
                // 判断是否有缓存
                if (this.CacheBitmap is null)
                {
                    //this.CacheBitmap = new SKBitmap((int)(width * pm.Scale), (int)(height * pm.Scale));
                    this.CacheBitmap = new SKBitmap((int)rectDisplay.Width, (int)rectDisplay.Height);
                    OnPaintMessage(this.CacheBitmap, pm.Scale);
                }
                using (SKPaint paint = new SKPaint())
                {
                    paint.FilterQuality = SKFilterQuality.High;
                    pm.Canvas.DrawBitmap(this.CacheBitmap, this.Left - marginDisplay.Left, this.Top - marginDisplay.Top, paint);
                    //pm.Canvas.DrawBitmap(this.CacheBitmap, new SKRect(left, top, left + width, top + height), paint);
                }
            }
            else
            {
                // 直接绘制
                //using (SKBitmap bmp = new SKBitmap((int)(width * pm.Scale), (int)(height * pm.Scale)))
                using (SKBitmap bmp = new SKBitmap((int)rectDisplay.Width, (int)rectDisplay.Height))
                {
                    OnPaintMessage(bmp, pm.Scale);
                    using (SKPaint paint = new SKPaint())
                    {
                        paint.FilterQuality = SKFilterQuality.High;
                        pm.Canvas.DrawBitmap(bmp, this.Left - marginDisplay.Left, this.Top - marginDisplay.Top, paint);
                        //pm.Canvas.DrawBitmap(bmp, new SKRect(left, top, left + width, top + height), paint);
                    }
                }
            }
            // 还原强制刷新
            _refresh = false;
        }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="point"></param>
        protected virtual bool OnMouseMove(Point point) { return true; }

        /// <summary>
        /// 鼠标移入事件
        /// </summary>
        protected virtual void OnMouseHover() { }

        /// <summary>
        /// 鼠标移出事件
        /// </summary>
        protected virtual void OnMouseLeave() { }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="point"></param>
        protected virtual void OnMouseDown(MouseOperateType button, Point point) { }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="point"></param>
        protected virtual void OnMouseUp(MouseOperateType button, Point point) { }

        /// <summary>
        /// 鼠标单击事件
        /// </summary>
        /// <param name="point"></param>
        protected virtual void OnMouseClick() { }

        /// <summary>
        /// 鼠标双击事件
        /// </summary>
        /// <param name="point"></param>
        protected virtual void OnMouseDoubleClick() { }

        // 处理绘制消息
        private void OnMouseButtonMessage(MouseButtonMessage mouseButton)
        {
            var button = (MouseOperateType)((int)mouseButton.OperateType & 0xf0);
            var opreate = (MouseOperateType)((int)mouseButton.OperateType & 0xf);
            if (opreate == MouseOperateType.Down) this.OnMouseDown(button, mouseButton.Point);
            if (opreate == MouseOperateType.Up)
            {
                this.OnMouseUp(button, mouseButton.Point);
                if (button == MouseOperateType.LButton)
                {
                    var tick = Environment.TickCount;
                    var doubleClickTime = (int)User32.GetDoubleClickTime();
                    if (_lastMouseClick + doubleClickTime >= tick)
                    {
                        _lastMouseClick = 0;
                        this.OnMouseDoubleClick();
                    }
                    else
                    {
                        _lastMouseClick = tick;
                        this.OnMouseClick();
                    }
                }
            }
        }

        /// <summary>
        /// 重置大小事件
        /// </summary>
        /// <param name="size"></param>
        /// <param name="scale"></param>
        protected virtual void OnResize(Size size, float scale)
        {
            this.Resize(size, scale);
        }

        /// <summary>
        /// 移动事件
        /// </summary>
        /// <param name="point"></param>
        protected virtual void OnMove(Point point)
        {
            // 没变化跳过
            if (this.Rectangle.Point.Equals(point)) return;
            // 重新刷新有效区域
            this.Rectangle = new Rectangle(point.X, point.Y, this.Rectangle.Width, this.Rectangle.Height);
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
                case MouseMoveMessage mouseMove:
                    if (!(new Rectangle(0, 0, this.Width, this.Height)).Contain(mouseMove.Point))
                    {
                        // 触发鼠标移出事件
                        if (_mouseOn)
                        {
                            _mouseOn = false;
                            this.OnMouseLeave();
                        }
                        return true;
                    }
                    // 触发鼠标移入事件
                    if (!_mouseOn)
                    {
                        _mouseOn = true;
                        this.OnMouseHover();
                    }
                    return OnMouseMove(mouseMove.Point);
                case MouseLeaveMessage _:
                    // 触发鼠标移出事件
                    if (_mouseOn)
                    {
                        _mouseOn = false;
                        this.OnMouseLeave();
                    }
                    break;
                // 鼠标操作事件
                case MouseButtonMessage mouseButton:
                    this.OnMouseButtonMessage(mouseButton);
                    return false;
                // 布局
                case ResizeMessage resize:
                    this.OnResize(resize.Size, resize.Scale);
                    return true;
                // 移动事件
                case MoveMessage move:
                    this.OnMove(move.Point);
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
        /// 刷新显示事件
        /// </summary>
        protected virtual bool OnRefresh()
        {
            // 计算dpi比例
            var scale = Application.GetScale();
            // 触发重设大小
            using (ResizeMessage msg = new(this.Handle, this.Size, scale))
            {
                this.SendMessage(msg);
            }
            return true;
        }

        #endregion

        #region 公用函数

        /// <summary>
        /// 获取可继承样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        public T GetInheritableStyle<T>(StyleType style)
        {
            if (this.Styles.ContainsKey(style)) return this.Styles.Get<T>(style);
            if (_parent is null) return this.Form.GetStyle<T>(style);
            return _parent.GetInheritableStyle<T>(style);
        }

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
                // 兼容全局消息
                if (msg.Handle == 0) this.OnMessage(msg);
                this.OnPostMessage(msg);
            }
        }

        /// <summary>
        /// 刷新显示
        /// </summary>
        public void Refresh()
        {
            // 执行刷新事件并设定刷新标志
            _refresh = this.OnRefresh();
            // 判断有效性
            if (!this.IsVaild) return;
            // 执行窗体刷新
            if (_parent is null)
            {
                this.Form.Refresh();
            }
            else
            {
                _parent.Refresh();
            }
        }

        /// <summary>
        /// 获取样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        public T GetStyle<T>(StyleType style)
            => this.Styles.Get<T>(style);

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public IWidget UseStyles(Action<Styles> action)
        {
            action(this.Styles);
            return this;
        }

        #endregion
    }
}
