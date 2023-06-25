using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 控件
    /// </summary>
    public interface IControl : IWidget
    {
        /// <summary>
        /// 关联窗体
        /// </summary>
        IForm Form { get; }

        /// <summary>
        /// 是否响应鼠标事件
        /// </summary>
        bool IsMouseReply { get; }

        /// <summary>
        /// 是否响应键盘事件
        /// </summary>
        bool IsKeyReply { get; }

        /// <summary>
        /// 是否可编辑
        /// </summary>
        bool IsEditable { get; }

        /// <summary>
        /// 是否响应输入法事件
        /// </summary>
        bool IsImeReply { get; }

        /// <summary>
        /// 是否有效
        /// </summary>
        bool IsVaild { get; }

        /// <summary>
        /// Z轴索引
        /// </summary>
        int ZIndex { get; }

        /// <summary>
        /// 有效区域
        /// </summary>
        Rectangle Rectangle { get; }

        /// <summary>
        /// 内边距
        /// </summary>
        Margin Padding { get; }

        /// <summary>
        /// 外边距
        /// </summary>
        Margin Margin { get; }

        ///// <summary>
        ///// 显示区域
        ///// </summary>
        //Rectangle DisplayRectangle { get; }

        /// <summary>
        /// 父控件
        /// </summary>
        IContainerControl Parent { get; }

        /// <summary>
        /// 发送消息
        /// </summary>
        bool SendMessage(IMessage msg);

        /// <summary>
        /// 提交消息
        /// </summary>
        void PostMessage(IMessage msg);

        /// <summary>
        /// 获取可继承样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        T GetInheritableStyle<T>(Styles style, T defaultValue);

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        new IControl UseStyles(Action<Drawing.StyleCollection> action);

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <returns></returns>
        new IControl UseStyles<T>();

        /// <summary>
        /// 获取针对窗口的偏移坐标
        /// </summary>
        /// <returns></returns>
        Point GetFormOffset();
    }
}
