using SkiaSharp;
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
    /// 文本
    /// </summary>
    public class Label : Block
    {
        // 内容
        private string _content;

        /// <summary>
        /// 是否响应鼠标事件
        /// </summary>
        public override bool IsMouseReply => false;

        // 重新设置显示尺寸
        private void Resize(float scale)
        {
            // 判断可用性
            if (!this.IsVaild) return;
            // 计算动态尺寸
            using (SKPaint paint = new SKPaint(this.Font)
            {
                IsAntialias = this.IsAntialias,
                TextSize = this.FontSize * scale,
            })
            {
                paint.GetFontMetrics(out SKFontMetrics metrics);
                var width = paint.MeasureText(_content);
                // 创建
                var labSize = new Size((int)width, (int)(metrics.Bottom - metrics.Top));
                //// 变更样式
                //this.UseStyles(d => d
                //    .Set(StyleType.Width, width / scale)
                //    .Set(StyleType.Height, (metrics.Bottom - metrics.Top) / scale)
                //);
                // 重置尺寸
                base.Resize(labSize, scale);
            }
        }

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
        /// 文本
        /// </summary>
        public Label()
        {
            _content = string.Empty;
            // 设置需要重绘
            this.IsNeedRepaint = true;
        }

        /// <summary>
        /// 文本
        /// </summary>
        public Label(string? content = null)
        {
            _content = content ?? string.Empty;
            // 设置需要重绘
            this.IsNeedRepaint = true;
        }

        /// <summary>
        /// 重置尺寸
        /// </summary>
        /// <param name="size"></param>
        /// <param name="scale"></param>
        protected override void OnResize(Size size, float scale)
        {
            this.Resize(scale);
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
            using (SKPaint paint = new SKPaint(this.Font)
            {
                Color = this.Color,
                TextSize = this.FontSize * e.Scale,
                IsAntialias = this.IsAntialias,
            })
            {
                paint.GetFontMetrics(out SKFontMetrics metrics);
                e.Canvas.DrawText(this.Content, 0, 0 - metrics.Top, paint);
            }
        }
    }
}
