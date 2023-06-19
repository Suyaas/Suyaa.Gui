using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 尺寸样式设置
    /// </summary>
    public class FontAttribute : StyleAttribute
    {
        // 定义私有变量
        private bool? _antialias;
        private string? _names;
        private float? _size;


        /// <summary>
        /// 字体名称
        /// </summary>
        public string Names { get => _names ?? string.Empty; set => _names = value; }

        /// <summary>
        /// 高度单位
        /// </summary>
        public float Size { get => _size ?? 0; set => _size = value; }

        /// <summary>
        /// 抗锯齿
        /// </summary>
        public bool Antialias { get => _antialias ?? false; set => _antialias = value; }

        /// <summary>
        /// 字体
        /// </summary>
        public FontAttribute() : base(StyleType.None)
        {
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Styles styles)
        {
            if (_names != null) styles.Set(StyleType.TextFont, _names);
            if (_size.HasValue) styles.Set(StyleType.TextSize, _size.Value);
            if (_antialias.HasValue) styles.Set(StyleType.TextAntialias, _antialias.Value);
        }
    }
}
