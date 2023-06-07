using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Drawing
{
    /// <summary>
    /// 样式列表
    /// </summary>
    public class Styles : Dictionary<StyleType, object>
    {
        // 检测值类型
        private void CheckValueType(StyleType style, Type type)
        {
            var typeStyle = typeof(StyleType);
            string columnTypeName = style.ToString();
            var field = typeStyle.GetFields().Where(d => d.Name == columnTypeName).FirstOrDefault();
            if (field is null) throw new GuiException($"Style type '{columnTypeName}' not found.");
            var styleValueAttr = field.GetCustomAttribute<StyleValueAttribute>();
            if (styleValueAttr is null) return;
            if (!type.IsBased(styleValueAttr.Type)) throw new GuiException($"Style '{columnTypeName}' not found.");
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Styles Set(StyleType style, object value)
        {
            // 检测值类型
            CheckValueType(style, value.GetType());
            this[style] = value;
            return this;
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Styles Set<T>(StyleType style, T value) where T : notnull
        {
            // 检测值类型
            CheckValueType(style, typeof(T));
            this[style] = value;
            return this;
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Styles Set(params Style[] styles)
        {
            foreach (var style in styles)
            {
                Set(style.StyleType, style.Value);
            }
            return this;
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Styles Set(List<Style> styles)
        {
            foreach (var style in styles)
            {
                Set(style.StyleType, style.Value);
            }
            return this;
        }

        /// <summary>
        /// 获取样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        public T Get<T>(StyleType style)
        {
            if (!this.ContainsKey(style)) throw new GuiException($"Style '{style}' not set.");
            // 检测值类型
            CheckValueType(style, typeof(T));
            return (T)this[style];
        }

        /// <summary>
        /// 样式列表
        /// </summary>
        public Styles()
        {
            // 可见性
            Set(StyleType.Visible, true);
            // 是否启用缓存
            Set(StyleType.UseCache, false);
            // 上边距
            Set<float>(StyleType.Top, 0);
            // 左边距
            Set<float>(StyleType.Left, 0);
            // 宽度
            Set<float>(StyleType.Width, 0);
            // 高度
            Set<float>(StyleType.Height, 0);
        }
    }
}
