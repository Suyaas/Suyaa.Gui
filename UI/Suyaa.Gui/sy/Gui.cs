using SkiaSharp;
using Suyaa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sy
{
    /// <summary>
    /// Gui工具
    /// </summary>
    public static class Gui
    {
        /// <summary>
        /// 获取字体
        /// </summary>
        /// <param name="fontNames"></param>
        /// <returns></returns>
        public static SKFont GetFont(string? fontNames)
        {
            // 字体未设置则使用默认字体
            if (fontNames.IsNullOrWhiteSpace()) return new SKFont(SKTypeface.Default);
            // 循环读取字体设定，取第一个存在的字体
            var fonts = fontNames!.Split(',');
            foreach (var font in fonts)
            {
                var name = font.Trim();
                if (name.IsNullOrWhiteSpace()) continue;
                if (name == "\"") continue;
                if (name.StartsWith("\"") && name.EndsWith("\"")) name = name.Substring(1, name.Length - 2);
                var type = SKTypeface.FromFamilyName(name);
                if (type is null) continue;
                return new SKFont(type);
            }
            return new SKFont(SKTypeface.Default);
        }
    }
}
