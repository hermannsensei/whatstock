using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace whatstockv1
{
    public partial class messageData : UserControl
    {
        public messageData()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void setTextL(String t)
        {
            label1.Text = t;
        }

        private void messageData_Load(object sender, EventArgs e)
        {

        }
    }
}
