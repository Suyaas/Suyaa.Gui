using SkiaSharp;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Enums
{
    /// <summary>
    /// 对齐方式
    /// </summary>
    public enum AlignType : int
    {
        /// <summary>
        /// 常规 左对齐或上对齐
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 居中
        /// </summary>
        Center = 1,
        /// <summary>
        /// 相反 右对齐或下对齐
        /// </summary>
        Opposite = 2,
    }

    /// <summary>
    /// 单位类型
    /// </summary>
    public enum UnitType : int
    {
        /// <summary>
        /// 像素
        /// </summary>
        Pixel = 0,
        /// <summary>
        /// 百分比
        /// </summary>
        Percentage = 1,
    }

    /// <summary>
    /// 样式类型
    /// </summary>
    public enum StyleType : int
    {
        #region 基础样式
        /// <summary>
        /// 无样式
        /// </summary>
        None = 0,
        /// <summary>
        /// 可见性
        /// </summary>
        [StyleValue(typeof(bool))]
        Visible = 0x01,
        /// <summary>
        /// 使用调试
        /// </summary>
        [StyleValue(typeof(bool))]
        UseDebug = 0x11,
        /// <summary>
        /// 使用缓存
        /// </summary>
        [StyleValue(typeof(bool))]
        UseCache = 0x12,
        /// <summary>
        /// 定位模式
        /// </summary>
        [StyleValue(typeof(PositionType))]
        Position = 0x21,
        /// <summary>
        /// 光标
        /// </summary>
        [StyleValue(typeof(CursorType))]
        Cursor = 0x31,
        #endregion

        #region 二维样式_0x100
        /// <summary>
        /// 水平偏移
        /// </summary>
        [StyleValue(typeof(float))]
        X = 0x101,
        /// <summary>
        /// 垂直偏移
        /// </summary>
        [StyleValue(typeof(float))]
        Y = 0x102,
        /// <summary>
        /// 水平对齐方式
        /// </summary>
        [StyleValue(typeof(AlignType))]
        XAlign = 0x103,
        /// <summary>
        /// 垂直对齐方式
        /// </summary>
        [StyleValue(typeof(AlignType))]
        YAlign = 0x104,
        /// <summary>
        /// 宽度
        /// </summary>
        [StyleValue(typeof(float))]
        Width = 0x111,
        /// <summary>
        /// 高度
        /// </summary>
        [StyleValue(typeof(float))]
        Height = 0x112,
        /// <summary>
        /// 宽度单位
        /// </summary>
        [StyleValue(typeof(UnitType))]
        WidthUnit = 0x113,
        /// <summary>
        /// 高度单位
        /// </summary>
        [StyleValue(typeof(UnitType))]
        HeightUnit = 0x114,
        /// <summary>
        /// 内上边距
        /// </summary>
        [StyleValue(typeof(float))]
        PaddingTop = 0x121,
        /// <summary>
        /// 内右边距
        /// </summary>
        [StyleValue(typeof(float))]
        PaddingRight = 0x122,
        /// <summary>
        /// 内下边距
        /// </summary>
        [StyleValue(typeof(float))]
        PaddingBottom = 0x123,
        /// <summary>
        /// 内左边距
        /// </summary>
        [StyleValue(typeof(float))]
        PaddingLeft = 0x124,
        /// <summary>
        /// 外上边距
        /// </summary>
        [StyleValue(typeof(float))]
        MarginTop = 0x131,
        /// <summary>
        /// 外右边距
        /// </summary>
        [StyleValue(typeof(float))]
        MarginRight = 0x132,
        /// <summary>
        /// 外下边距
        /// </summary>
        [StyleValue(typeof(float))]
        MarginBottom = 0x133,
        /// <summary>
        /// 外左边距
        /// </summary>
        [StyleValue(typeof(float))]
        MarginLeft = 0x134,
        /// <summary>
        /// 背景颜色
        /// </summary>
        [StyleValue(typeof(SKColor))]
        BackgroundColor = 0x141,
        #endregion

        #region 边框相关样式_0x200
        /// <summary>
        /// 上边框尺寸
        /// </summary>
        [StyleValue(typeof(float))]
        BorderTopSize = 0x201,
        /// <summary>
        /// 上边框类型
        /// </summary>
        [StyleValue(typeof(BorderStyleType))]
        BorderTopStyle = 0x202,
        /// <summary>
        /// 上边框颜色
        /// </summary>
        [StyleValue(typeof(SKColor))]
        BorderTopColor = 0x203,
        /// <summary>
        /// 右边框尺寸
        /// </summary>
        [StyleValue(typeof(float))]
        BorderRightSize = 0x204,
        /// <summary>
        /// 右边框类型
        /// </summary>
        [StyleValue(typeof(BorderStyleType))]
        BorderRightStyle = 0x205,
        /// <summary>
        /// 右边框颜色
        /// </summary>
        [StyleValue(typeof(SKColor))]
        BorderRightColor = 0x206,
        /// <summary>
        /// 右边框尺寸
        /// </summary>
        [StyleValue(typeof(float))]
        BorderBottomSize = 0x207,
        /// <summary>
        /// 右边框类型
        /// </summary>
        [StyleValue(typeof(BorderStyleType))]
        BorderBottomStyle = 0x208,
        /// <summary>
        /// 右边框颜色
        /// </summary>
        [StyleValue(typeof(SKColor))]
        BorderBottomColor = 0x209,
        /// <summary>
        /// 边框尺寸
        /// </summary>
        [StyleValue(typeof(float))]
        BorderLeftSize = 0x20a,
        /// <summary>
        /// 边框类型
        /// </summary>
        [StyleValue(typeof(BorderStyleType))]
        BorderLeftStyle = 0x20b,
        /// <summary>
        /// 边框颜色
        /// </summary>
        [StyleValue(typeof(SKColor))]
        BorderLeftColor = 0x20c,
        /// <summary>
        /// 左上圆角
        /// </summary>
        [StyleValue(typeof(float))]
        BorderRadiusLeftTop = 0x211,
        /// <summary>
        /// 右上圆角
        /// </summary>
        [StyleValue(typeof(float))]
        BorderRadiusRightTop = 0x212,
        /// <summary>
        /// 右下圆角
        /// </summary>
        [StyleValue(typeof(float))]
        BorderRadiusRightBottom = 0x213,
        /// <summary>
        /// 左下圆角
        /// </summary>
        [StyleValue(typeof(float))]
        BorderRadiusLeftBottom = 0x214,
        /// <summary>
        /// 阴影尺寸
        /// </summary>
        [StyleValue(typeof(int))]
        BorderShadowSize = 0x221,
        /// <summary>
        /// 阴影横向偏移
        /// </summary>
        [StyleValue(typeof(float))]
        BorderShadowX = 0x222,
        /// <summary>
        /// 阴影纵向偏移
        /// </summary>
        [StyleValue(typeof(float))]
        BorderShadowY = 0x223,
        /// <summary>
        /// 阴影基准颜色
        /// </summary>
        [StyleValue(typeof(SKColor))]
        BorderShadowColor = 0x224,
        #endregion

        #region 文本样式_0x300
        /// <summary>
        /// 文本颜色
        /// </summary>
        [StyleValue(typeof(SKColor))]
        TextColor = 0x301,
        /// <summary>
        /// 文本字体 使用,分割多个字体设置
        /// </summary>
        [StyleValue(typeof(string))]
        TextFont = 0x302,
        /// <summary>
        /// 文本字号
        /// </summary>
        [StyleValue(typeof(float))]
        TextSize = 0x303,
        /// <summary>
        /// 文本抗锯齿
        /// </summary>
        [StyleValue(typeof(bool))]
        TextAntialias = 0x304,
        #endregion
    }
}
