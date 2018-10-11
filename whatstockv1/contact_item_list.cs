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
    public partial class contact_item_list : UserControl
    {
       // private object resources;

        public contact_item_list()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
        public void setNom(string nom)
        {
            lbl_nom.Text = nom;
        }
        public void setNumero(string nom)
        {
            label2.Text = nom;
        }
        public void setImage(string app)
        {
        //    this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));

        }
        public void setColor(Color color)
        {
            panel2.BackColor = color;
        }
        private void label2_Click_1(object sender, EventArgs e)
        {
         
        }
        public void setTime(String t)
        {
            label1.Text = t;
        }

        public void panel2_Paint_2(object sender, PaintEventArgs e)
        {
          //  MessageBox.Show("C'est OK");

        }
        public String getNom()
        {
            return lbl_nom.Text;
        }
        

        public String lbl_nom_Click(object sender, EventArgs e)
        {
            MessageBox.Show(getNom());
            return getNom();
        }
        public Label lbl_t()
        {
            return lbl_nom;
        }
    }
}
