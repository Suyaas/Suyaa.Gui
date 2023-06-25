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
    public class Input : Block, IWidgetTextContent, IWidgetOffset
    {
        // 大小写转化数值差
        private const byte CASE_DIFF = 'a' - 'A';

        // 内容
        private string _content;

        /// <summary>
        /// 是否响应鼠标事件
        /// </summary>
        public override bool IsMouseReply => true;

        /// <summary>
        /// 是否响应键盘事件
        /// </summary>
        public override bool IsKeyReply => true;

        /// <summary>
        /// 是否可编辑
        /// </summary>
        public override bool IsEditable => true;

        /// <summary>
        /// 是否响应输入法事件
        /// </summary>
        public override bool IsImeReply => true;

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
                // 设置选择位置
                this.SetSelection(_content.Length, 0);
                // 刷新显示
                this.Refresh();
            }
        }

        #region 文本选择相关

        /// <summary>
        /// 水品偏移
        /// </summary>
        public int OffsetX { get; internal protected set; }

        /// <summary>
        /// 垂直偏移
        /// </summary>
        public int OffsetY { get; internal protected set; }

        #endregion

        #region 文本选择相关

        /// <summary>
        /// 文本选择开始位置
        /// </summary>
        public int SelectionStart { get; private set; }

        /// <summary>
        /// 文本选择结束位置
        /// </summary>
        public int SelectionEnd { get; private set; }

        /// <summary>
        /// 设置文本选择范围
        /// </summary>
        /// <param name="start"></param>
        /// <param name="len"></param>
        public void SetSelection(int start, int len)
        {
            this.SelectionStart = start;
            this.SelectionEnd = start + len;
        }

        #endregion

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

        // 鼠标按下
        protected override void OnMouseDown(MouseOperates button, Point point)
        {
            base.OnMouseDown(button, point);
            if (button == MouseOperates.LButton)
            {
                // 设置窗体当前控件
                this.Form.CurrentControl = this;
                //Debug.WriteLine($"[Input] OnMouseDown {point.X},{point.Y}");
            }
        }

        // 键盘按下
        protected override void OnKeyDown(Keys key)
        {
            base.OnKeyDown(key);
            if (key >= Keys.A && key <= Keys.Z)
            {
                // 添加内容
                _content += (char)(key + CASE_DIFF);
                // 设置选择
                this.SetSelection(_content.Length, 0);
                // 刷新显示
                this.Refresh();
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
