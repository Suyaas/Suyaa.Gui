using Suyaa;
using Suyaa.Gui;
using Suyaa.Gui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Helpers
{
    /// <summary>
    /// 组件助手
    /// </summary>
    public static class WidgetHelper
    {
        /// <summary>
        /// 将组件转化为控件
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Control AsControl(this IWidget widget)
        {
            return (Control)widget;
        }
    }
}
