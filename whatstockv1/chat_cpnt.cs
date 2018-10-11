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
    public partial class chat_cpnt : UserControl
    {
        public chat_cpnt()
        {
            InitializeComponent();
        }
        public void setNumero(String numero)
        {
            this.lbl_chat.Text = numero;
        }
        public void setText(String txt)
        {
            this.lbl_txt.Text = txt;
        }
        public String getNumero()
        {
            return this.lbl_chat.Text;
        }
        public String getText()
        {
            return this.lbl_txt.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
