using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Messages;
using Suyaa.Gui.Native.Skia;
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
        /// <summary>
        /// 绘制事件
        /// </summary>
        protected virtual void OnPaint(SKCanvas cvs)
        {

        }

        private void OnPaintMessage(PaintMessage pm)
        {
            // 获取 是否使用缓存 样式
            var useCache = this.Styles.Get<bool>(StyleType.UseCache);
            // 获取 边距 样式
            var left = this.Styles.Get<float>(StyleType.Left);
            var top = this.Styles.Get<float>(StyleType.Top);
            // 判断是否使用缓存
            if (useCache)
            {
                // 判断是否有缓存
                if (this.CacheBitmap is null)
                {
                    // 获取宽高
                    var width = this.Styles.Get<float>(StyleType.Width);
                    var height = this.Styles.Get<float>(StyleType.Height);
                    this.CacheBitmap = new SKBitmap((int)width, (int)height);
                    using (SKCanvas cvs = new SKCanvas(this.CacheBitmap))
                    {
                        this.OnPaint(cvs);
                    }
                }
                pm.Canvas.DrawBitmap(this.CacheBitmap, left, top);
            }
            else
            {
                // 获取宽高
                var width = this.Styles.Get<float>(StyleType.Width);
                var height = this.Styles.Get<float>(StyleType.Height);
                // 直接绘制
                using (SKBitmap bmp = new SKBitmap((int)width, (int)height))
                {
                    using (SKCanvas cvs = new SKCanvas(bmp))
                    {
                        this.OnPaint(cvs);
                    }
                    pm.Canvas.DrawBitmap(bmp, left, top);
                }
            }
        }

        // 消息处理
        protected override bool OnMessage(IMessage msg)
        {
            return base.OnMessage(msg);
        }
    }
}
