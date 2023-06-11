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
    /// 文本
    /// </summary>
    public class Label : Block
    {
        // 内容
        private string _content;

        // 重新设置显示尺寸
        private void Resize()
        {
            // 判断可见性
            var visible = this.GetStyle<bool>(StyleType.Visible);
            if (!visible) return;
            using (SKPaint p = new SKPaint(this.Font))
            {
                var width = p.MeasureText(_content);
                this.UseStyles(d => d
                    .Set(StyleType.Width, width)
                    .Set(StyleType.Height, this.FontSize)
                );
            }
        }

        /// <summary>
        /// 刷新事件
        /// </summary>
        protected override void OnRefresh()
        {
            base.OnRefresh();
            this.Resize();
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get => _content;
            set
            {
                // 设置内容
                _content = value;
                // 刷新显示
                this.Refresh();
            }
        }

        /// <summary>
        /// 文本
        /// </summary>
        public Label(string? content = null)
        {
            _content = content ?? string.Empty;
            this.Resize();
        }

        /// <summary>
        /// 绘制事件
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="rect"></param>
        /// <param name="scale"></param>
        protected override void OnPainting(SKCanvas cvs, Rectangle rect, float scale)
        {
            base.OnPainting(cvs, rect, scale);
            //cvs.Clear(SKColors.White);
            using (SKPaint paint = new SKPaint(this.Font)
            {
                Color = this.Color,
                TextSize = this.FontSize,
            })
            {
                cvs.DrawText(this.Content, new SKPoint(1, this.FontSize), paint);
            }
        }
    }
}
