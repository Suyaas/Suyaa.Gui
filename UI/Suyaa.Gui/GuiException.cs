using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// Gui异常
    /// </summary>
    public class GuiException : System.Exception
    {
        /// <summary>
        /// Gui异常
        /// </summary>
        /// <param name="message"></param>
        public GuiException(string message) : base(message) { }

        /// <summary>
        /// Gui异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public GuiException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
