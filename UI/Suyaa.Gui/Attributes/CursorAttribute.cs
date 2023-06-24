using Suyaa.Gui.Enums;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 光标
    /// </summary>
    public class CursorAttribute : ValueStyleAttribute<Cursors>
    {
        /// <summary>
        /// 光标
        /// </summary>
        /// <param name="value"></param>
        public CursorAttribute(Cursors value) : base(Styles.Cursor, value)
        {
        }
    }
}
