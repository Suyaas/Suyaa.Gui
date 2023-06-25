using SkiaSharp;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Controls
{
    /// <summary>
    /// 块
    /// </summary>
    public class Block : Control
    {
        // 字体缓存
        private string _fontNames = string.Empty;
        private SKFont? _font;

        /// <summary>
        /// 字体
        /// </summary>
        public SKFont Font
        {
            get
            {
                var fontNames = this.GetInheritableStyle(Enums.Styles.TextFont, string.Empty);
                //if (fontNames.IsNullOrWhiteSpace()) throw new GuiException($"Font not set");
                // 字体无变化时使用缓存
                if (_fontNames == fontNames) return _font!;
                // 清理原有的字体缓存
                if (_font != null)
                {
                    _font.Dispose();
                    _font = null;
                }
                _font = sy.Gui.GetFont(fontNames);
                _fontNames = fontNames;
                if (_font is null) throw new GuiException($"Font not set");
                return _font;
            }
            set
            {
                // 设置字体并更新缓存
                _font = value;
                string fontName = _font.Typeface.FamilyName;
                _fontNames = fontName;
                this.Style.Set(Enums.Styles.TextFont, fontName);
                // 刷新显示
                this.Refresh();
            }
        }

        /// <summary>
        /// 文本颜色
        /// </summary>
        public SKColor Color
        {
            get => this.GetInheritableStyle(Enums.Styles.TextColor, SKColors.Black);
            set
            {
                this.Style.Set(Enums.Styles.TextColor, value);
                // 刷新显示
                this.Refresh();
            }
        }

        /// <summary>
        /// 文本抗锯齿
        /// </summary>
        public bool IsAntialias
        {
            get => this.GetInheritableStyle(Enums.Styles.TextAntialias, true);
            set
            {
                this.Style.Set(Enums.Styles.TextAntialias, value);
                // 刷新显示
                this.Refresh();
            }
        }


        /// <summary>
        /// 字体大小
        /// </summary>
        public float FontSize
        {
            get => this.GetInheritableStyle(Enums.Styles.TextSize, 9f);
            set
            {
                this.Style.Set(Enums.Styles.TextSize, value);
                // 刷新显示
                this.Refresh();
            }
        }

        /// <summary>
        /// 可见性
        /// </summary>
        public bool Visible
        {
            get => this.GetStyle<bool>(Enums.Styles.Visible);
            set
            {
                this.Style.Set(Enums.Styles.Visible, value);
                // 刷新显示
                this.Refresh();
            }
        }
    }
}
