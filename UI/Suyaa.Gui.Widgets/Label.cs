using SkiaSharp;
using Suyaa.Gui.Drawing;
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
        // 是否强制刷新
        private bool _refresh;

        /// <summary>
        /// 是否响应鼠标事件
        /// </summary>
        public override bool IsMouseReply => false;

        // 重新设置显示尺寸
        private void Resize()
        {
            // 判断可用性
            if (!this.IsVaild) return;
            // 计算dpi比例
            //var scale = Gdi32.GetDpiScale();
            var scale = Application.GetScale();
            using (SKPaint paint = new SKPaint(this.Font))
            {
                paint.TextSize = this.FontSize * scale;
                paint.GetFontMetrics(out SKFontMetrics metrics);
                var width = paint.MeasureText(_content);
                this.UseStyles(d => d
                    .Set(StyleType.Width, width / scale)
                    .Set(StyleType.Height, (metrics.Bottom - metrics.Top) / scale)
                );
            }
        }

        /// <summary>
        /// 刷新事件
        /// </summary>
        protected override bool OnRefresh()
        {
            _refresh = true;
            return base.OnRefresh();
        }

        protected override bool OnMessage(IMessage msg)
        {
            switch (msg)
            {
                case PaintMessage _:
                    // 判断是否带有强制刷新
                    if (_refresh)
                    {
                        this.Resize();
                        _refresh = false;
                    }
                    break;
            }
            return base.OnMessage(msg);
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
            _refresh = true;
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
                TextSize = this.FontSize * scale,
            })
            {
                paint.GetFontMetrics(out SKFontMetrics metrics);
                cvs.DrawText(this.Content, 0, 0 - metrics.Top, paint);
            }
        }
    }
}
