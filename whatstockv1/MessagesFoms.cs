using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace whatstockv1
{
    public partial class MessagesFoms : Form
    {
        public MessagesFoms()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_photo_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //message_panel.Visible = false ;
            //message_panel.SendToBack();
            //panel_search.SendToBack();
            //textBox1.SendToBack();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            MessagesFoms.ActiveForm.Close();
            
        }
    }
}
