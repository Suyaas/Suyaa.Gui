using Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Gui.Win32Native;
using Suyaa.Gui.Native.Win32;

namespace Win32App
{
    public class FrmDialog : Form<Win32Form>
    {
        public FrmDialog()
        {
            this.Title = "提示";
        }
    }
}
