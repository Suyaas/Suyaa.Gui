using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Controls.EventArgs;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Controls
{
    /// <summary>
    /// 输入框
    /// </summary>
    [Border(1, 0xff888888, BorderStyles.Solid)]
    [Size(150, 24)]
    [Padding(2, 3)]
    [BackgroundColor(0xffffffff)]
    [BorderRadius(2)]
    [Cursor(Cursors.Edit)]
    public class Input : Block
    {
        // 内容
        private string _content;

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
                // 获取提出换行的内容
                string strValue = value.Replace("\n", "").Replace("\"", "");
                if (_content == strValue) return;
                // 设置内容
                _content = strValue;
                // 刷新显示
                this.Refresh();
            }
        }

        /// <summary>
        /// 输入框
        /// </summary>
        public Input()
        {
            _content = string.Empty;
            // 设置需要重绘
            this.IsNeedRepaint = true;
        }

        /// <summary>
        /// 输入框
        /// </summary>
        public Input(string? content = null)
        {
            _content = content ?? string.Empty;
            // 设置需要重绘
            this.IsNeedRepaint = true;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        protected override void OnInitialize()
        {
            base.OnInitialize();
            // 设置需要重绘
            this.IsNeedRepaint = true;
            // 设置样式
            this.Style.SetStyles(this.GetType());
        }

        protected override void OnMouseDown(MouseOperates button, Point point)
        {
            base.OnMouseDown(button, point);
            if (button == MouseOperates.LButton)
            {
                Debug.WriteLine($"[Input] OnMouseDown {point.X},{point.Y}");
            }
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
            var rect = e.Rectangle.Padding(this.Padding);
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
                switch (this.GetStyle(Enums.Styles.TextAlign, AlignType.Normal))
                {
                    case AlignType.Center:
                        e.Canvas.DrawText(this.Content, rect.Left + (rect.Width - width) / 2, rect.Top + (rect.Height - height) / 2 - metrics.Top, paint);
                        break;
                    case AlignType.Opposite:
                        e.Canvas.DrawText(this.Content, rect.Right - width, rect.Top + (rect.Height - height) / 2 - metrics.Top, paint);
                        break;
                    default:
                        e.Canvas.DrawText(this.Content, rect.Left, rect.Top + (rect.Height - height) / 2 - metrics.Top, paint);
                        break;
                }

            }
        }
    }
}
