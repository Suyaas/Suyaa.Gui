using Forms;
using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
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
        // 是否鼠标在区域内
        private bool _mouseOn;

        /// <summary>
        /// 窗体状态
        /// </summary>
        public FormStatusType FormStatus { get; internal protected set; }

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
        /// 鼠标移入事件
        /// </summary>
        protected virtual void OnMouseHover() { }

        /// <summary>
        /// 鼠标移出事件
        /// </summary>
        protected virtual void OnMouseLeave() { }

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
                    // 获取dpi比例
                    float scale = Application.GetScale();
                    // 重置尺寸
                    using (ResizeMessage msgSink = new(this.Workarea.Handle, new Size(), scale))
                    {
                        this.Workarea.SendMessage(msgSink);
                    }
                    break;
                // 重置大小
                case ResizeMessage resize:
                    if (this.FormStatus == FormStatusType.Minimize) break;
                    // 获取dpi比例
                    scale = Application.GetScale();
                    // 重置尺寸
                    using (ResizeMessage msgSink = new(this.Workarea.Handle, new Size(), scale))
                    {
                        this.Workarea.SendMessage(msgSink);
                    }
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
                    // 判断是否触发鼠标移入
                    if (!_mouseOn)
                    {
                        _mouseOn = true;
                        this.OnMouseHover();
                    }
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
                    //if (this.FormStatus == FormStatusType.Maximize && statusChange.FormStatus == FormStatusType.Normal)
                    //{
                    //    _refresh = true;
                    //}
                    this.FormStatus = statusChange.FormStatus;
                    break;
                // 非工作区鼠标移动
                case NCMouseMoveMessage ncMouseMove:
                    // 触发鼠标移除事件
                    if (_mouseOn)
                    {
                        _mouseOn = false;
                        this.OnMouseLeave();
                        // 触发全局鼠标移开事件
                        using (MouseLeaveMessage msgSink = new(0))
                        {
                            this.Workarea.PostMessage(msgSink);
                        }
                    }
                    break;
                // 鼠标操作事件
                case MouseButtonMessage mouseButton:
                    using (MouseButtonMessage msgSink = new(this.Workarea.Handle, mouseButton.OperateType, mouseButton.Point))
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
            // 设置默认值
            _refresh = false;
            _mouseOn = false;
            // 设置初始状态
            this.FormStatus = FormStatusType.Normal;
            // 应用反射特性
            this.ApplyStyles();
        }
    }
}
