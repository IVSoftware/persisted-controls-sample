using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.TabControl;

namespace hybrid_tabcontrol_richtextbox
{
    public static class Extensions
    {
        public static void AddRTFPage(this TabControl tabControl)
        {
            RichTextBox richTextBox = new RichTextBox()
            {
                Dock = DockStyle.Fill
            };

            TabPage rtfTabPage =
                new TabPage("RTF" + (tabControl.TabCount + 1).ToString());

            rtfTabPage.Controls.Add(richTextBox);
            tabControl.TabPages.Add(rtfTabPage);
        }
    }
}
