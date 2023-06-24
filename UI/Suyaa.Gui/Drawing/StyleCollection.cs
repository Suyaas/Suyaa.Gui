using Suyaa.Gui.Attributes;
using Suyaa.Gui.Enums;
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
    public class StyleCollection : Dictionary<Styles, object>, IDisposable
    {
        // 组件
        private readonly IWidget _widget;

        // 检测值类型
        private void CheckValueType(Enums.Styles style, Type type)
        {
            var typeStyle = typeof(Enums.Styles);
            string columnTypeName = style.ToString();
            var field = typeStyle.GetFields().Where(d => d.Name == columnTypeName).FirstOrDefault();
            if (field is null) throw new GuiException($"Style type '{columnTypeName}' not found.");
            var styleValueAttr = field.GetCustomAttribute<StyleValueAttribute>();
            if (styleValueAttr is null) return;
            if (!type.IsBased(styleValueAttr.Type)) throw new GuiException($"Style '{columnTypeName}' type '{type.FullName}' not based '{styleValueAttr.Type.FullName}'.");
        }

        /// <summary>
        /// 设置样式设置集合
        /// </summary>
        /// <returns></returns>
        public StyleCollection SetStyles(Type type)
        {
            // 获取所有样式特性
            var styleAttrs = type.GetCustomAttributes<StyleAttribute>(true);
            foreach (var styleAttr in styleAttrs)
            {
                // 生效样式
                styleAttr.Apply(this);
            }
            // 兼容IStyles接口
            if (type.HasInterface<IStyles>())
            {
                var obj = Activator.CreateInstance(type, new object[0]);
                //type.Create<IStyles>();
                if (obj is null) return this;
                ((IStyles)obj).Apply(this);
            }
            return this;
        }

        /// <summary>
        /// 设置样式设置集合
        /// </summary>
        /// <returns></returns>
        public StyleCollection SetStyles<T>()
        {
            Type type = typeof(T);
            // 获取所有样式特性
            var styleAttrs = type.GetCustomAttributes<StyleAttribute>(true);
            foreach (var styleAttr in styleAttrs)
            {
                // 生效样式
                styleAttr.Apply(this);
            }
            // 兼容IStyles接口
            if (type.HasInterface<IStyles>())
            {
                var obj = Activator.CreateInstance<T>();
                //type.Create<IStyles>();
                if (obj is null) return this;
                ((IStyles)obj).Apply(this);
            }
            return this;
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public StyleCollection Set(Enums.Styles style, object value)
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
        public StyleCollection Set<T>(Enums.Styles style, T value) where T : notnull
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
        public StyleCollection Set(StyleCollection styles)
        {
            foreach (var style in styles)
            {
                Set(style.Key, style.Value);
            }
            return this;
        }

        /// <summary>
        /// 获取样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        public T Get<T>(Enums.Styles style)
        {
            if (!this.ContainsKey(style)) throw new GuiException($"Style '{style}' not set.");
            // 检测值类型
            CheckValueType(style, typeof(T));
            return (T)this[style];
        }

        /// <summary>
        /// 获取样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        public T Get<T>(Enums.Styles style, T value)
        {
            if (!this.ContainsKey(style)) return value;
            // 检测值类型
            CheckValueType(style, typeof(T));
            return (T)this[style];
        }

        /// <summary>
        /// 生效样式
        /// </summary>
        public void Apply()
        {
            _widget.Refresh();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            this.Clear();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 样式列表
        /// </summary>
        /// <param name="widget">所属组件</param>
        /// <param name="hasStandardStyles">是否拥有标准样式</param>
        public StyleCollection(IWidget widget, bool hasStandardStyles)
        {
            // 所属组件
            _widget = widget;
            // 设置标准样式
            if (hasStandardStyles)
            {
                // 可见性
                Set(Enums.Styles.Visible, false);
                // 是否启用缓存
                Set(Enums.Styles.UseCache, false);
                // 是否启用抗锯齿
                Set(Enums.Styles.Antialias, true);
                // 对齐方式
                Set(Enums.Styles.XAlign, AlignType.Normal);
                Set(Enums.Styles.YAlign, AlignType.Normal);
                // 显示单位
                Set(Enums.Styles.WidthUnit, UnitType.Pixel);
                Set(Enums.Styles.HeightUnit, UnitType.Pixel);
                // 设置定位模式为浮动
                Set(Enums.Styles.Position, Positions.Float);
                //// 上边距
                //Set<float>(StyleType.X, 0);
                //// 左边距
                //Set<float>(StyleType.Y, 0);
                // 宽度
                Set(Enums.Styles.Width, (float)0);
                // 高度
                Set(Enums.Styles.Height, (float)0);
            }
        }
    }
}
