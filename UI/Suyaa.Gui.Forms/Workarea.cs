using Forms;
using Suyaa.Gui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Forms
{
    /// <summary>
    /// 工作区域
    /// </summary>
    public class Workarea : Panel
    {
        /// <summary>
        /// 工作区域
        /// </summary>
        /// <param name="form"></param>
        public Workarea(FormBase form)
        {
            this.Form = form;
        }
    }
}
