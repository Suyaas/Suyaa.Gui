using Suyaa.Gui.Drawing;
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
        /// Z轴索引
        /// </summary>
        int ZIndex { get; }

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
        T GetInheritableStyle<T>(StyleType style);
    }
}
