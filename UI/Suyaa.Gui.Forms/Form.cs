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
        // 是否强制刷新
        private bool _refresh;

        /// <summary>
        /// 窗体状态
        /// </summary>
        public FormStatusTypes FormStatus { get; internal protected set; }

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
        /// 鼠标移动事件
        /// </summary>
        /// <param name="point"></param>
        protected virtual void OnMouseMove(Point point) { }

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
                    if (this.FormStatus == FormStatusTypes.Minimize) break;
                    // 重置大小
                    this.Workarea.Resize();
                    // 刷新
                    if (_refresh)
                    {
                        this.Refresh();
                        _refresh = false;
                    }
                    break;
                // 绘制
                case PaintMessage paint:
                    // 重绘工作区域
                    using (PaintMessage msgSink = new(this.Workarea.Handle, paint.Canvas, paint.Rectangle, paint.Scale))
                    {
                        this.Workarea.SendMessage(msgSink);
                    }
                    break;
                // 鼠标移动
                case MouseMoveMessage mouseMove:
                    // 重绘工作区域
                    using (MouseMoveMessage msgSink = new(this.Workarea.Handle, mouseMove.Point))
                    {
                        if (this.Workarea.SendMessage(msgSink))
                        {
                            this.OnMouseMove(mouseMove.Point);
                        }
                    }
                    break;
                // 状态变化
                case StatusChangeMessage statusChange:
                    if (this.FormStatus == FormStatusTypes.Maximize && statusChange.FormStatus == FormStatusTypes.Normal)
                    {
                        _refresh = true;
                    }
                    this.FormStatus = statusChange.FormStatus;
                    break;
            }
            return true;
        }

        /// <summary>
        /// 标准窗体
        /// </summary>
        public Form()
        {
            // 设置默认刷新
            _refresh = false;
            // 设置初始状态
            this.FormStatus = FormStatusTypes.Normal;
            // 应用反射特性
            this.ApplyStyles();
        }
    }
}
