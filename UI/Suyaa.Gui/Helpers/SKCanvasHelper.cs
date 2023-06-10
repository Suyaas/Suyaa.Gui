using SkiaSharp;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Helpers
{
    /// <summary>
    /// SKCanvas助手
    /// </summary>
    public static class SKCanvasHelper
    {
        /// <summary>
        /// 绘制标准样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        public static void DrawStyles(this SKCanvas cvs, Styles styles)
        {
            // 绘制背景
            if (styles.ContainsKey(StyleType.BackgroundColor))
            {
                var color = styles.Get<SKColor>(StyleType.BackgroundColor);
                cvs.Clear(color);
            }
                
        }
    }
}
