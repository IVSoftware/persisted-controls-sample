using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hybrid_tabcontrol_richtextbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            tabControl1.AddRTFPage();
        }

        private void buttonAddRtfTab_Click(object sender, EventArgs e)
        {
            tabControl1.AddRTFPage();
        }
    }
}
