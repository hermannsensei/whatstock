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
    public partial class PhotoAff : UserControl
    {
        public PhotoAff()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            
            MessageBox.Show(p.ImageLocation.ToString());
            //System.Diagnostics.Process.Start(p.ImageLocation);
        }
    }
}
