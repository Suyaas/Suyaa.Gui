using Forms.Helpers;
using SkiaSharp;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win32App
{
    /// <summary>
    /// 鼠标测试面板样式
    /// </summary>
    [Offset(160, 80)]
    [Size(240, 200)]
    [BackgroundColor(0xaa000033)]
    //[UserCache(true)]
    class MouseTestPanelStyles { }

    /// <summary>
    /// 鼠标测试面板
    /// </summary>
    public class MouseTestPanel : Panel
    {
        private readonly Label _labInfo;
        private SKColor _backgroundColor;

        /// <summary>
        /// 鼠标测试面板
        /// </summary>
        public MouseTestPanel()
        {
            this.Styles.SetStyles<MouseTestPanelStyles>();

            // 设置内容标签
            _labInfo = new Label("Label");

            // 添加控件
            this.Controls.AddRange(
                _labInfo.UseStyles(d => d
                    .Set<float>(StyleType.X, 5)
                    .Set<float>(StyleType.Y, 5)
                    .Set(StyleType.TextColor, SKColors.White)
                //.Set(StyleType.BackgroundColor, new SKColor(0xff990000))
                ).AsControl()
                );
        }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected override bool OnMouseMove(Point point)
        {
            _labInfo.Content = $"{point.X},{point.Y}";
            return base.OnMouseMove(point);
        }

        /// <summary>
        /// 鼠标移入
        /// </summary>
        protected override void OnMouseHover()
        {
            base.OnMouseHover();
            _backgroundColor = this.GetStyle<SKColor>(StyleType.BackgroundColor);
            this.Styles.Set(StyleType.BackgroundColor, new SKColor(0xffff6600));
        }

        protected override void OnMouseLeave()
        {
            base.OnMouseLeave();
            this.Styles.Set(StyleType.BackgroundColor, _backgroundColor);
        }

        protected override void OnMouseClick()
        {
            base.OnMouseClick();
            
        }

        protected override void OnMouseDoubleClick()
        {
            base.OnMouseDoubleClick();
            FrmDialog dialog = new FrmDialog();
            dialog.Show();
        }
    }
}
