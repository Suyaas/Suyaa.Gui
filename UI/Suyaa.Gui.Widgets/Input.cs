using Forms.Helpers;
using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Controls.EventArgs;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Helpers;
using Suyaa.Gui.Native.Helpers;
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
        // 鼠标是否按下
        private bool _mouseDown;

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
                //for (int i = 0; i < strValue.Length; i++)
                //{
                //    _content.Add(strValue[i]);
                //}
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
                    // 判断是否多出空白
                    if (width - OffsetX < rect.Width && OffsetX > 0)
                    {
                        this.OffsetX = (int)(width - rect.Width);
                        if (this.OffsetX < 0) this.OffsetX = 0;
                    }
                    // 计算位置
                    float left = borders.Left + this.Padding.Left - this.OffsetX + width;
                    float top = borders.Top + this.Padding.Top + (rect.Height - height) / 2;
                    this.InputCursorRectangle = new Rectangle(left, top, 1, height);
                    // 更新Ime位置
                    this.Form.UpdateImePosition();
                }
            }
        }

        // 变更选区并申请重绘
        private void ChangeSelectionAndRepaint(int start, int len)
        {
            // 设置选择范围
            this.SetSelection(start, len);
            // 申请窗体重绘
            Application.SetInputCursorShow(this.Form.Handle, true);
            this.Form.Repaint(false);
        }

        // 变更选区并直接刷新元素
        private void ChangeSelectionAndRefresh(int start, int len)
        {
            // 设置选择范围
            this.SetSelection(start, len);
            // 刷新元素
            Application.SetInputCursorShow(this.Form.Handle, true);
            this.Refresh();
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
            if (content is not null)
            {
                _content.Append(content);
            }
            this.SetSelection(_content.Length, 0);
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        protected override void OnInitialize()
        {
            base.OnInitialize();
            // 初始化字段
            _mouseDown = false;
            // 设置需要重绘
            this.IsNeedRepaint = true;
            // 设置样式
            this.Style.SetStyles(this.GetType());
        }

        // 鼠标抬起
        protected override void OnMouseUp(MouseOperates button, Point point)
        {
            base.OnMouseUp(button, point);
        }

        // 鼠标按下
        protected override void OnMouseDown(MouseOperates button, Point point)
        {
            base.OnMouseDown(button, point);
            if (button == MouseOperates.LButton)
            {
                // 鼠标按下
                _mouseDown = true;
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

        // 向右方向变更
        private void OnRightArrowChange()
        {
            // 带选择时，取消选择
            if (this.SelectionEnd > this.SelectionStart)
            {
                ChangeSelectionAndRepaint(this.SelectionEnd, 0);
                return;
            }
            if (this.SelectionEnd < this.SelectionStart)
            {
                ChangeSelectionAndRepaint(this.SelectionStart, 0);
                return;
            }
            // 当光标处于最最左边时不处理
            if (this.SelectionStart >= _content.Length) return;
            // 光标左移
            ChangeSelectionAndRepaint(this.SelectionStart + 1, 0);
        }

        // 向左方向变更
        private void OnLeftArrowChange()
        {
            // 带选择时，取消选择
            if (this.SelectionEnd > this.SelectionStart)
            {
                ChangeSelectionAndRepaint(this.SelectionStart, 0);
                return;
            }
            if (this.SelectionEnd < this.SelectionStart)
            {
                ChangeSelectionAndRepaint(this.SelectionEnd, 0);
                return;
            }
            // 当光标处于最最左边时不处理
            if (this.SelectionStart <= 0) return;
            // 光标左移
            ChangeSelectionAndRepaint(this.SelectionStart - 1, 0);
        }

        // 按下向左键
        private void OnLeftKeyDown()
        {
            // 创建一个键盘处理器
            using (var keyboard = sy.Keyboard.Create())
            {
                if (keyboard.IsShift)
                {
                    // 已经选择最第一个，则跳过
                    if (this.SelectionEnd <= 0) return;
                    // 变更选择
                    ChangeSelectionAndRefresh(this.SelectionStart, this.SelectionEnd - 1 - this.SelectionStart);
                }
                else
                {
                    OnLeftArrowChange();
                }
            }
        }

        // 按下向右键
        private void OnRightKeyDown()
        {
            // 创建一个键盘处理器
            using (var keyboard = sy.Keyboard.Create())
            {
                if (keyboard.IsShift)
                {
                    // 已经选择最后，则跳过
                    if (this.SelectionEnd >= _content.Length) return;
                    // 变更选择
                    ChangeSelectionAndRefresh(this.SelectionStart, this.SelectionEnd + 1 - this.SelectionStart);
                }
                else
                {
                    OnRightArrowChange();
                }
            }
        }

        // 按下字母键
        private void OnLetterKeyDown(Keys key)
        {
            // 创建一个键盘处理器
            using (var keyboard = sy.Keyboard.Create())
            {
                #region 由ImeChar处理
                //// 是否大写
                //bool isCaps = keyboard.IsCapital;
                //if (keyboard.IsShift) isCaps = !isCaps;
                //Debug.WriteLine($"[Input] OnKeyDown " +
                //    $"isCaps:{isCaps}/{keyboard.GetKeyState(Keys.Capital)}, " +
                //    $"IsCapital:{keyboard.IsCapital}, " +
                //    $"_isShift:{keyboard.IsKeyDown(Keys.ShiftKey)}/{keyboard.IsKeyDown(Keys.LShiftKey)}/{keyboard.IsKeyDown(Keys.RShiftKey)}/{keyboard.IsShift}, " +
                //    $"_isCtrl:{keyboard.IsKeyDown(Keys.ControlKey)}/{keyboard.IsKeyDown(Keys.LControlKey)}/{keyboard.IsKeyDown(Keys.RControlKey)}/{keyboard.IsControl}, " +
                //    $"_isAlt:{keyboard.IsKeyDown(Keys.Menu)}/{keyboard.IsAlt}, ");
                //char chr = (char)(isCaps ? key : key + CASE_DIFF);
                //OnCharKeyDown(chr);
                #endregion
                if (keyboard.IsControl)
                {
                    switch (key)
                    {
                        // 剪切
                        case Keys.X: break;
                        // 复制
                        case Keys.C: break;
                        // 粘贴
                        case Keys.V: break;
                        // 撤销
                        case Keys.Z: break;
                    }
                }
            }
        }

        // 按下字符键
        private void OnCharKeyDown(char chr)
        {
            // 添加内容
            _content.Insert(this.SelectionStart, chr);
            // 设置选择
            this.SetSelection(this.SelectionStart + 1, 0);
            // 刷新显示
            Application.SetInputCursorShow(this.Form.Handle, true);
            this.Refresh();
        }

        // 按下字符键
        private void OnCharKeyDown(char chr, IKeyboard keyboard)
        {
            // 添加内容
            _content.Insert(this.SelectionStart, chr);
            // 设置选择
            ChangeSelectionAndRefresh(this.SelectionStart + 1, 0);
        }

        // 按下字符键 (兼容Shift)
        private void OnCharKeyDown(char chr, char chrShift)
        {
            // 创建一个键盘处理器
            using (var keyboard = sy.Keyboard.Create())
            {
                Debug.WriteLine($"[Input] OnCharKeyDown {chr} - {chrShift}  _isShift:{keyboard.IsShift}");
                if (keyboard.IsShift)
                {
                    // 添加内容
                    _content.Insert(this.SelectionStart, chrShift);
                }
                else
                {
                    // 添加内容
                    _content.Insert(this.SelectionStart, chr);
                }
                // 设置选择
                ChangeSelectionAndRefresh(this.SelectionStart + 1, 0);
            }
        }

        // 按下回退键
        private void OnBackKeyDown()
        {
            // 带选择时，删除选择内容
            if (this.SelectionEnd > this.SelectionStart)
            {
                _content.Remove(this.SelectionStart, this.SelectionEnd - this.SelectionStart);
                ChangeSelectionAndRefresh(this.SelectionStart, 0);
                return;
            }
            if (this.SelectionEnd < this.SelectionStart)
            {
                _content.Remove(this.SelectionEnd, this.SelectionStart - this.SelectionEnd);
                ChangeSelectionAndRefresh(this.SelectionEnd, 0);
                return;
            }
            // 当光标在最前，则不处理
            if (this.SelectionStart <= 0) return;
            // 删除一个内容
            _content.Remove(this.SelectionStart - 1, 1);
            ChangeSelectionAndRefresh(this.SelectionStart - 1, 0);
        }

        // 按下回退键
        private void OnDeleteKeyDown()
        {
            // 带选择时，删除选择内容
            if (this.SelectionEnd > this.SelectionStart)
            {
                _content.Remove(this.SelectionStart, this.SelectionEnd - this.SelectionStart);
                ChangeSelectionAndRefresh(this.SelectionStart, 0);
                return;
            }
            if (this.SelectionEnd < this.SelectionStart)
            {
                _content.Remove(this.SelectionEnd, this.SelectionStart - this.SelectionEnd);
                ChangeSelectionAndRefresh(this.SelectionEnd, 0);
                return;
            }
            // 当光标在最前，则不处理
            if (this.SelectionStart >= _content.Length) return;
            // 删除一个内容
            _content.Remove(this.SelectionStart, 1);
            // 刷新显示
            ChangeSelectionAndRefresh(this.SelectionStart - 1, 0);
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
            // 数字键
            if (key >= Keys.NumPad0 && key <= Keys.NumPad9)
            {
                OnCharKeyDown((char)(key - Keys.NumPad0 + '0'));
                return;
            }
            switch (key)
            {
                // 左键
                case Keys.Left: OnLeftKeyDown(); return;
                // 右键
                case Keys.Right: OnRightKeyDown(); return;
                // 回退键
                case Keys.Back: OnBackKeyDown(); return;
                // 删除键
                case Keys.Delete: OnDeleteKeyDown(); return;
                // 键盘第一行 `1-0-=
                case Keys.Oemtilde: OnCharKeyDown('`', '~'); return;
                case Keys.D1: OnCharKeyDown('1', '!'); return;
                case Keys.D2: OnCharKeyDown('2', '@'); return;
                case Keys.D3: OnCharKeyDown('3', '#'); return;
                case Keys.D4: OnCharKeyDown('4', '$'); return;
                case Keys.D5: OnCharKeyDown('5', '%'); return;
                case Keys.D6: OnCharKeyDown('6', '^'); return;
                case Keys.D7: OnCharKeyDown('7', '&'); return;
                case Keys.D8: OnCharKeyDown('8', '*'); return;
                case Keys.D9: OnCharKeyDown('9', '('); return;
                case Keys.D0: OnCharKeyDown('0', ')'); return;
                case Keys.OemMinus: OnCharKeyDown('-', '_'); return;
                case Keys.Oemplus: OnCharKeyDown('=', '+'); return;
                // 键盘第二行
                case Keys.Oem4: OnCharKeyDown('[', '{'); return;
                case Keys.Oem6: OnCharKeyDown(']', '}'); return;
                case Keys.OemPipe: OnCharKeyDown('\\', '|'); return;
                // 键盘第三行
                case Keys.OemSemicolon: OnCharKeyDown(';', ':'); return;
                case Keys.OemQuotes: OnCharKeyDown('\'', '"'); return;
                // 键盘第四行
                case Keys.Oemcomma: OnCharKeyDown(',', '<'); return;
                case Keys.OemPeriod: OnCharKeyDown('.', '>'); return;
                case Keys.Oem2: OnCharKeyDown('/', '?'); return;
            }
        }

        // 键盘抬起
        protected override void OnKeyUp(Keys key)
        {
            base.OnKeyUp(key);
        }

        // IME输入
        protected override void OnImeChar(char chr)
        {
            base.OnImeChar(chr);
            if (chr > 256)
            {
                OnCharKeyDown(chr);
            }
            else
            {
                // 兼容字母
                if (chr >= 'a' && chr <= 'z') OnCharKeyDown(chr);
                if (chr >= 'A' && chr <= 'Z') OnCharKeyDown(chr);
                //OnKeyDown((Keys)chr);
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
            // 建立前景色画笔
            using (SKPaint paint = new SKPaint(this.Font)
            {
                Color = this.Color,
                TextSize = this.FontSize * e.Scale,
                IsAntialias = this.IsAntialias,
            })
            // 建立选中文本颜色
            using (SKPaint paintSelect = new SKPaint(this.Font)
            {
                Color = SKColors.White,
                TextSize = this.FontSize * e.Scale,
                IsAntialias = this.IsAntialias,
            })
            // 建立选中文本背景色
            using (SKPaint paintSelectBg = new SKPaint()
            {
                Color = SKColors.Blue,
                Style = SKPaintStyle.Fill,
            })
            {
                paint.GetFontMetrics(out SKFontMetrics metrics);
                List<string> contents = new List<string>() { string.Empty, string.Empty, string.Empty };
                // 自右到左选择
                if (this.SelectionStart > this.SelectionEnd)
                {
                    if (this.SelectionEnd > 0) contents[0] = _content.ToString(0, this.SelectionEnd);
                    contents[1] = _content.ToString(this.SelectionEnd, this.SelectionStart - this.SelectionEnd);
                    if (this.SelectionStart < _content.Length) contents[2] = _content.ToString(this.SelectionStart, _content.Length - this.SelectionStart);
                }
                // 自左到右选择
                else if (this.SelectionStart < this.SelectionEnd)
                {
                    if (this.SelectionStart > 0) contents[0] = _content.ToString(0, this.SelectionStart);
                    contents[1] = _content.ToString(this.SelectionStart, this.SelectionEnd - this.SelectionStart);
                    if (this.SelectionEnd < _content.Length) contents[2] = _content.ToString(this.SelectionEnd, _content.Length - this.SelectionEnd);
                }
                else
                {
                    if (this.SelectionStart > 0) contents[0] = _content.ToString(0, this.SelectionStart);
                    if (this.SelectionEnd < _content.Length) contents[2] = _content.ToString(this.SelectionEnd, _content.Length - this.SelectionEnd);
                }
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
                        // 绘制选择前文本
                        if (!contents[0].IsNullOrWhiteSpace())
                        {
                            float width = paint.MeasureText(contents[0]);
                            if (left + width > 0) cvs.DrawText(contents[0], left, top, paint);
                            left += width;
                        }
                        // 绘制选择中文本
                        if (!contents[1].IsNullOrWhiteSpace())
                        {
                            float width = paint.MeasureText(contents[1]);
                            cvs.DrawRect(new SKRect(left, top + metrics.Top, left + width, top + height + metrics.Top), paintSelectBg);
                            cvs.DrawText(contents[1], left, top, paintSelect);
                            left += width;
                        }
                        // 绘制选择后文本
                        if (!contents[2].IsNullOrWhiteSpace() && left < rect.Height)
                        {
                            cvs.DrawText(contents[2], left, top, paint);
                        }
                    }
                    // 绘制缓存图像
                    e.Canvas.DrawBitmap(bmp, rect.Left, rect.Top);
                }
            }
        }
    }
}
