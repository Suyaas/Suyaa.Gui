using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Controls.EventArgs;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Helpers;
using Suyaa.Gui.Native.Win32.Apis;
using sy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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
        private StringBuilder _content;
        // Shift是否按下
        private bool _isShift;

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

        #region 偏移相关

        /// <summary>
        /// 水品偏移
        /// </summary>
        public int OffsetX { get; internal protected set; }

        /// <summary>
        /// 垂直偏移
        /// </summary>
        public int OffsetY { get; internal protected set; }

        #endregion

        #region 文本内容相关

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get => _content.ToString();
            set
            {
                // 获取提出换行的内容
                string strValue = value.Replace("\n", "").Replace("\"", "");
                if (_content.ToString() == strValue) return;
                // 设置内容
                _content.Clear();
                _content.Append(strValue);
                // 设置选择位置
                this.SetSelection(_content.Length, 0);
                // 刷新显示
                Application.SetInputCursorShow(this.Form.Handle, true);
                this.Refresh();
            }
        }

        /// <summary>
        /// 文本选择开始位置
        /// </summary>
        public int SelectionStart { get; private set; }

        /// <summary>
        /// 文本选择结束位置
        /// </summary>
        public int SelectionEnd { get; private set; }

        /// <summary>
        /// 输入光标矩形区域
        /// </summary>
        public Rectangle InputCursorRectangle { get; private set; }

        /// <summary>
        /// 设置文本选择范围
        /// </summary>
        /// <param name="start"></param>
        /// <param name="len"></param>
        public void SetSelection(int start, int len)
        {
            this.SelectionStart = start;
            this.SelectionEnd = start + len;
            // 计算光标位置
            int pos = len >= 0 ? SelectionStart : SelectionEnd;
            // 获取放大比例
            var scale = Application.GetScale();
            // 获取显示区域
            var borders = this.Style.GetBorders(scale);
            var rect = this.Rectangle.Padding(borders).Padding(this.Padding);
            // 获取当前选择宽度
            if (this.IsVaild)
            {

                using (SKPaint paint = new SKPaint(this.Font)
                {
                    Color = this.Color,
                    TextSize = this.FontSize * scale,
                    IsAntialias = this.IsAntialias,
                })
                {
                    paint.GetFontMetrics(out SKFontMetrics metrics);
                    // 计算尺寸
                    var width = (int)paint.MeasureText(_content.ToString(0, pos));
                    var height = metrics.Bottom - metrics.Top;
                    // 判断是否超出左边界
                    if (width < OffsetX) this.OffsetX = width;
                    // 判断是否超出右边界
                    if (width > OffsetX + rect.Width) this.OffsetX = (int)(width - rect.Width);
                    // 计算位置
                    float left = borders.Left + this.Padding.Left - this.OffsetX + width;
                    float top = borders.Top + this.Padding.Top + (rect.Height - height) / 2;
                    this.InputCursorRectangle = new Rectangle(left, top, 1, height);
                }
            }
        }

        /// <summary>
        /// 获取部分内容
        /// </summary>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public string GetContent(int start, int len)
        {
            return _content.ToString(start, len);
        }

        #endregion

        /// <summary>
        /// 输入框
        /// </summary>
        public Input()
        {
            _content = new StringBuilder();
            this.SelectionStart = 0;
        }

        /// <summary>
        /// 输入框
        /// </summary>
        public Input(string? content)
        {
            _content = new StringBuilder();
            if (content is not null) _content.Append(content);
            this.SetSelection(_content.Length, 0);
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        protected override void OnInitialize()
        {
            base.OnInitialize();
            // 初始化字段
            _isShift = false;
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
                // 获取放大比例
                var scale = Application.GetScale();
                // 获取显示区域
                var borders = this.Style.GetBorders(scale);
                var rect = new Rectangle(0, 0, this.Width, this.Height).Padding(borders).Padding(this.Padding);
                var x = point.X - rect.Left + this.OffsetX;
                // 计算文本
                using (SKPaint paint = new SKPaint(this.Font)
                {
                    Color = this.Color,
                    TextSize = this.FontSize * scale,
                    IsAntialias = this.IsAntialias,
                })
                {
                    // 循环计算长度
                    bool isSelected = false;
                    for (int i = 1; i <= _content.Length; i++)
                    {
                        // 计算尺寸
                        var width = (int)paint.MeasureText(_content.ToString(0, i));
                        if (x < width - 2)
                        {
                            this.SetSelection(i - 1, 0);
                            isSelected = true;
                            break;
                        }
                    }
                    // 选择末尾
                    if (!isSelected) this.SetSelection(_content.Length, 0);
                }
                // 刷新显示
                Application.SetInputCursorShow(this.Form.Handle, true);
                this.Form.Repaint(false);
                //Debug.WriteLine($"[Input] OnMouseDown {point.X},{point.Y}");
            }
        }

        #region 键盘处理

        // 按下向左键
        private void OnLeftKeyDown()
        {
            // 带选择时，取消选择
            if (this.SelectionEnd > this.SelectionStart)
            {
                this.SetSelection(this.SelectionStart, 0);
                return;
            }
            if (this.SelectionEnd < this.SelectionStart)
            {
                this.SetSelection(this.SelectionEnd, 0);
                return;
            }
            // 当光标处于最最左边时不处理
            if (this.SelectionStart <= 0) return;
            // 光标左移
            this.SetSelection(this.SelectionStart - 1, 0);
            // 申请窗体重绘
            Application.SetInputCursorShow(this.Form.Handle, true);
            this.Form.Repaint(false);
        }

        // 按下向右键
        private void OnRightKeyDown()
        {
            // 带选择时，取消选择
            if (this.SelectionEnd > this.SelectionStart)
            {
                this.SetSelection(this.SelectionEnd, 0);
                return;
            }
            if (this.SelectionEnd < this.SelectionStart)
            {
                this.SetSelection(this.SelectionStart, 0);
                return;
            }
            // 当光标处于最最左边时不处理
            if (this.SelectionStart >= _content.Length) return;
            // 光标左移
            this.SetSelection(this.SelectionStart + 1, 0);
            // 申请窗体重绘
            Application.SetInputCursorShow(this.Form.Handle, true);
            this.Form.Repaint(false);
        }

        // 按下字母键
        private void OnLetterKeyDown(Keys key)
        {
            // 创建一个键盘处理器
            using (var keyboard = sy.Keyboard.Create())
            {
                // 是否大写
                bool isCaps = keyboard.IsCapital;
                if (_isShift) isCaps = !isCaps;
                Debug.WriteLine($"[Input] OnKeyDown isCaps:{isCaps}, IsCapital:{keyboard.IsCapital}, _isShift:{_isShift}");
                char chr = (char)(isCaps ? key : key + CASE_DIFF);
                // 添加内容
                _content.Insert(this.SelectionStart, chr);
                // 设置选择
                this.SetSelection(this.SelectionStart + 1, 0);
                // 刷新显示
                Application.SetInputCursorShow(this.Form.Handle, true);
                this.Refresh();
            }
        }

        // 键盘按下
        protected override void OnKeyDown(Keys key)
        {
            base.OnKeyDown(key);
            Debug.WriteLine($"[Input] OnKeyDown key:{key}");
            // 字母键
            if (key >= Keys.A && key <= Keys.Z)
            {
                OnLetterKeyDown(key);
                return;
            }
            switch (key)
            {
                // 左键
                case Keys.Left: OnLeftKeyDown(); return;
                // 右键
                case Keys.Right: OnRightKeyDown(); return;
                // Shift键
                case Keys.ShiftKey: _isShift = true; return;
            }
        }

        // 键盘抬起
        protected override void OnKeyUp(Keys key)
        {
            base.OnKeyUp(key);
            switch (key)
            {
                // Shift键
                case Keys.ShiftKey: _isShift = false; return;
            }
        }

        #endregion

        // 获取绘制左边距
        private float GetPaintLeft(SKPaint paint, Rectangle rect, string content)
        {
            var width = paint.MeasureText(content);
            switch (this.GetStyle(Styles.TextAlign, AlignType.Normal))
            {
                case AlignType.Center:
                    return rect.Left + (rect.Width - width) / 2;
                case AlignType.Opposite:
                    return rect.Right - width;
                default:
                    return rect.Left;
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
            string content = _content.ToString();
            // 计算实际尺寸
            var borders = this.Style.GetBorders(e.Scale);
            var rect = e.Rectangle.Padding(borders).Padding(this.Padding);
            using (SKPaint paint = new SKPaint(this.Font)
            {
                Color = this.Color,
                TextSize = this.FontSize * e.Scale,
                IsAntialias = this.IsAntialias,
            })
            {
                paint.GetFontMetrics(out SKFontMetrics metrics);
                //var width = paint.MeasureText(_content.ToString());
                var height = metrics.Bottom - metrics.Top;
                // 计算定位
                var left = GetPaintLeft(paint, new Rectangle(0, 0, rect.Width, rect.Height), content) - OffsetX;
                var top = (rect.Height - height) / 2 - metrics.Top;
                // 缓存图像
                using (SKBitmap bmp = new SKBitmap((int)rect.Width, (int)rect.Height))
                {
                    using (SKCanvas cvs = new SKCanvas(bmp))
                    {
                        // 绘制文本
                        cvs.DrawText(content, left, top, paint);
                    }
                    // 绘制缓存图像
                    e.Canvas.DrawBitmap(bmp, rect.Left, rect.Top);
                }
            }
        }
    }
}
