using SkiaSharp;
using Suyaa.Gui.Drawing;
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
                var fontNames = this.GetInheritableStyle<string>(StyleType.TextFont);
                if (fontNames.IsNullOrWhiteSpace()) throw new GuiException($"Font not set");
                // 字体无变化时使用缓存
                if (_fontNames == fontNames) return _font!;
                // 清理原有的字体缓存
                if (_font != null)
                {
                    _font.Dispose();
                    _font = null;
                }
                // 循环读取字体设定，取第一个存在的字体
                var fonts = fontNames.Split(',');
                foreach (var font in fonts)
                {
                    var name = font.Trim();
                    if (name.IsNullOrWhiteSpace()) continue;
                    if (name == "\"") continue;
                    if (name.StartsWith("\"") && name.EndsWith("\"")) name = name.Substring(1, name.Length - 2);
                    var type = SKTypeface.FromFamilyName(name);
                    if (type is null) continue;
                    _fontNames = fontNames;
                    _font = new SKFont(type);
                    break;
                }
                if (_font is null) throw new GuiException($"Font not set");
                return _font;
            }
            set
            {
                // 设置字体并更新缓存
                _font = value;
                string fontName = _font.Typeface.FamilyName;
                _fontNames = fontName;
                this.Styles.Set(StyleType.TextFont, fontName);
                // 刷新显示
                this.Refresh();
            }
        }

        /// <summary>
        /// 文本颜色
        /// </summary>
        public SKColor Color
        {
            get => this.GetInheritableStyle<SKColor>(StyleType.TextColor);
            set
            {
                this.Styles.Set(StyleType.TextColor, value);
                // 刷新显示
                this.Refresh();
            }
        }


        /// <summary>
        /// 字体大小
        /// </summary>
        public float FontSize
        {
            get => this.GetInheritableStyle<float>(StyleType.TextSize);
            set
            {
                this.Styles.Set(StyleType.TextSize, value);
                // 刷新显示
                this.Refresh();
            }
        }

        /// <summary>
        /// 可见性
        /// </summary>
        public bool Visible
        {
            get => this.GetStyle<bool>(StyleType.Visible);
            set
            {
                this.Styles.Set(StyleType.Visible, value);
                // 刷新显示
                this.Refresh();
            }
        }
    }
}
