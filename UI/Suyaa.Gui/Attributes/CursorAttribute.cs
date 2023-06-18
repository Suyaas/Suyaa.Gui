using Suyaa.Gui.Enums;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 光标
    /// </summary>
    public class CursorAttribute : ValueStyleAttribute<CursorType>
    {
        /// <summary>
        /// 光标
        /// </summary>
        /// <param name="value"></param>
        public CursorAttribute(CursorType value) : base(StyleType.Cursor, value)
        {
        }
    }
}
