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
    public class Styles : Dictionary<StyleType, object>
    {
        // 组件
        private readonly IWidget _widget;

        // 检测值类型
        private void CheckValueType(StyleType style, Type type)
        {
            var typeStyle = typeof(StyleType);
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
        public Styles SetStyles(Type type)
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
        public Styles SetStyles<T>()
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
        /// 获取样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        public T Get<T>(StyleType style, T value)
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
        /// 删除样式
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public new Styles Remove(StyleType style)
        {
            if (this.ContainsKey(style)) this.Remove(style);
            return this;
        }

        /// <summary>
        /// 样式列表
        /// </summary>
        public Styles(IWidget widget)
        {
            // 所属组件
            _widget = widget;
            // 可见性
            Set(StyleType.Visible, false);
            // 是否启用缓存
            Set(StyleType.UseCache, false);
            // 是否启用抗锯齿
            Set(StyleType.Antialias, true);
            // 对齐方式
            Set(StyleType.XAlign, AlignType.Normal);
            Set(StyleType.YAlign, AlignType.Normal);
            // 显示单位
            Set(StyleType.WidthUnit, UnitType.Pixel);
            Set(StyleType.HeightUnit, UnitType.Pixel);
            // 设置定位模式为浮动
            Set(StyleType.Position, PositionType.Float);
            //// 上边距
            //Set<float>(StyleType.X, 0);
            //// 左边距
            //Set<float>(StyleType.Y, 0);
            // 宽度
            Set<float>(StyleType.Width, 0);
            // 高度
            Set<float>(StyleType.Height, 0);
        }
    }
}
