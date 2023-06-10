using Forms;
using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Forms
{
    /// <summary>
    /// 标准窗体
    /// </summary>
    public class Form : FormBase
    {
        // 设置默认样式
        private void SetDefaultStyles()
        {
            this.Styles
                .Set<float>(StyleType.Width, 300)
                .Set<float>(StyleType.Height, 300)
                .Set(StyleType.BackgroundColor, new SKColor(0xfffdfdfd));
        }

        // 生效样式特性
        private void ApplyStyles()
        {
            // 设置默认样式
            this.SetDefaultStyles();
            // 获取类型
            var type = this.GetType();
            // 处理自身的Styles特性
            var stylesAttr = type.GetCustomAttribute<StylesAttribute>();
            if (stylesAttr != null)
            {
                foreach (var style in stylesAttr.Styles)
                {
                    this.Styles.SetStyles(style);
                }
            }
            // 处理自身的具体样式特性
            this.Styles.SetStyles(type);
        }

        /// <summary>
        /// 标准窗体
        /// </summary>
        public Form() {
            // 应用反射特性
            this.ApplyStyles();
        }
    }
}
