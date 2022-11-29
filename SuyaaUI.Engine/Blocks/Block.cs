using SkiaSharp;
using SuyaaUI.Engine.Blocks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SuyaaUI.Blocks
{
    /// <summary>
    /// 区块
    /// </summary>
    public class Block : IBlock
    {
        // 私有变量
        private int _left;
        private int _top;
        private int _width;
        private int _height;

        /// <summary>
        /// 获取缓存图像
        /// </summary>
        public SKBitmap Bitmap { get; }

        /// <summary>
        /// 边界
        /// </summary>
        public Rectangle Bounds
        {
            get { return new Rectangle(_left, _top, _width, _height); }
            set
            {
                _left = value.Left;
                _top = value.Top;
                _width = value.Width;
                _height = value.Height;
            }
        }

        /// <summary>
        /// 获取样式集合
        /// </summary>
        public Dictionary<string, string> Styles { get; }

        /// <summary>
        /// 左边距
        /// </summary>
        public int Left
        {
            get { return _left; }
            set { _left = value; }
        }

        /// <summary>
        /// 上边距
        /// </summary>
        public int Top
        {
            get { return _top; }
            set { _top = value; }
        }

        /// <summary>
        /// 宽度
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// 高度
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// 区块
        /// </summary>
        public Block(int width, int height)
        {
            _left = 0;
            _top = 0;
            _width = width;
            _height = height;
            this.Bitmap = new SKBitmap(width, height);
            this.Styles = new Dictionary<string, string>();
        }

        /// <summary>
        /// 更新显示
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateDisplay()
        {
            using (var canvas = new SKCanvas(this.Bitmap))
            {
                canvas.Clear(new SKColor(0xffffffff));
                canvas.DrawText("SkiaSharp!", 50, 50, new SKPaint() { Color = new SKColor(0, 0, 0), TextSize = 13 });
                canvas.DrawText("L.Z", new SKPoint(50, 100), new SKPaint(new SKFont(SKTypeface.FromFamilyName("微软雅黑")))
                {
                    Color = new SKColor(0x99, 0, 0),
                    TextSize = 20
                });
            }
        }
    }
}
