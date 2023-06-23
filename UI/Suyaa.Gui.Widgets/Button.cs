using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Controls.EventArgs;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Messages;
using Suyaa.Gui.Native.Win32.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Controls
{
    /// <summary>
    /// 按钮
    /// </summary>
    [Size(96, 26)]
    [BackgroundColor(0xfff0f0f0)]
    [BorderRadius(2)]
    [BorderShadow(0, 0, 5, 0x66000000)]
    [Cursor(CursorType.Hand)]
    public class Button : Block, IMouseHoverWidget, IMousePressWidget
    {
        // 内容
        private string _content;
        private Styles? _hoverStyles;
        private Styles? _pressStyles;

        /// <summary>
        /// 鼠标点击
        /// </summary>
        public event GuiEventDelegate? Click;

        /// <summary>
        /// 是否响应鼠标事件
        /// </summary>
        public override bool IsMouseReply => true;

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get => _content;
            set
            {
                if (_content == value) return;
                // 设置内容
                _content = value;
                // 刷新显示
                this.Refresh();
            }
        }

        /// <summary>
        /// 鼠标悬停样式
        /// </summary>
        public Styles MouseHoverStyles => _hoverStyles!;

        /// <summary>
        /// 鼠标按下样式
        /// </summary>
        public Styles MousePressStyles => _pressStyles!;

        /// <summary>
        /// 初始化事件
        /// </summary>
        protected override void OnInitialize()
        {
            base.OnInitialize();
            // 设置需要重绘
            this.IsNeedRepaint = true;
            // 设置样式
            this.Styles.SetStyles(this.GetType());
            // 设置鼠标悬停样式
            _hoverStyles = new Styles(this, false);
            _hoverStyles
                .Set(StyleType.BackgroundColor, new SKColor(0xffe0e0e0));
            // 设置鼠标按下样式
            _pressStyles = new Styles(this, false);
            _pressStyles
                .Set(StyleType.BackgroundColor, new SKColor(0xffff6600))
                .Set(StyleType.TextColor, new SKColor(0xffffffff));
            // 申明默认的鼠标点击事件
            this.Click += (sender, e) => { };
        }

        /// <summary>
        /// 按钮
        /// </summary>
        public Button()
        {
            _content = string.Empty;
        }

        /// <summary>
        /// 按钮
        /// </summary>
        public Button(string content)
        {
            _content = content ?? string.Empty;
        }

        /// <summary>
        /// 鼠标单机事件
        /// </summary>
        protected override void OnMouseClick()
        {
            base.OnMouseClick();
            this.Click!(this, new GuiEventArgs());
        }

        /// <summary>
        /// 绘制事件
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="rect"></param>
        /// <param name="scale"></param>
        protected override void OnPainting(PaintEventArgs e)
        {
            base.OnPainting(e);
            //cvs.Clear(SKColors.White);
            var rect = e.Rectangle;
            using (SKPaint paint = new SKPaint(this.Font)
            {
                Color = this.Color,
                TextSize = this.FontSize * e.Scale,
                IsAntialias = this.IsAntialias,
            })
            {
                paint.GetFontMetrics(out SKFontMetrics metrics);
                var width = paint.MeasureText(_content);
                var height = metrics.Bottom - metrics.Top;
                e.Canvas.DrawText(this.Content, (rect.Width - width) / 2, (rect.Height - height) / 2 - metrics.Top, paint);
            }
        }
    }
}
