using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 支持内容的组件
    /// </summary>
    public interface IWidgetContent<T>
    {
        /// <summary>
        /// 内容
        /// </summary>
        T Content { get; set; }
    }

    /// <summary>
    /// 支持文本内容的组件
    /// </summary>
    public interface IWidgetTextContent : IWidgetContent<string>
    {

        /// <summary>
        /// 文本选择开始位置
        /// </summary>
        int SelectionStart { get; }

        /// <summary>
        /// 文本选择结束位置
        /// </summary>
        int SelectionEnd { get; }

        /// <summary>
        /// 输入光标矩形
        /// </summary>
        Rectangle InputCursorRectangle { get; }

        /// <summary>
        /// 设置选择范围
        /// </summary>
        /// <param name="start"></param>
        /// <param name="len"></param>
        void SetSelection(int start, int len);

        /// <summary>
        /// 获取部分内容
        /// </summary>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        string GetContent(int start, int len);
    }
}
