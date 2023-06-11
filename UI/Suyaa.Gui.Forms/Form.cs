using Forms;
using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Messages;
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
                .Set(StyleType.TextColor, new SKColor(0xff000000))
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
        /// 消息处理
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected override bool OnMessage(IMessage msg)
        {
            // 处理消息
            switch (msg)
            {
                // 初始化
                case InitMessage _:
                    this.Workarea.Resize();
                    break;
                // 重置大小
                case ResizeMessage _:
                    this.Workarea.Resize();
                    //this.Refresh();
                    break;
                // 绘制
                case PaintMessage pm:
                    // 重绘工作区域
                    using (PaintMessage msgSink = new(this.Workarea.Handle, pm.Canvas, pm.Rectangle, pm.Scale))
                    {
                        this.Workarea.PostMessage(msgSink);
                    }
                    break;
            }
            return true;
        }

        /// <summary>
        /// 标准窗体
        /// </summary>
        public Form()
        {
            // 应用反射特性
            this.ApplyStyles();
        }
    }
}
