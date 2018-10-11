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
    public partial class photoCtrl : UserControl
    {
        public photoCtrl()
        {
            InitializeComponent();
        }

        private void panel1_Palong(object sender, PaintEventArgs e)
        {

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
           // ClearImageControls();
            // on mesure le  temps d'exécution
           

            var currentColumn = 0;
            var currentRow = 0;
            // pour toutes les images du répertoire
            foreach (var fileName in System.IO.Directory.GetFiles( "imgs", "*.jpg"))
            {
                // On charge l'image
                Image img = new Bitmap(fileName);
                // On en fait une vignette
                int PictureWidth = 75;
                int PictureMargin = 5;
                var newImage = img.GetThumbnailImage(PictureWidth, PictureWidth, null, IntPtr.Zero);
                // on décharge l'image
                img.Dispose();

                // on crée le PictureBox
                var newPic = new PictureBox
                {
                    Width = PictureWidth,
                    Height = PictureWidth,
                    Location = new Point
                    {
                        X = currentColumn * (PictureWidth + PictureMargin),
                        Y = currentRow * (PictureWidth + PictureMargin)
                    },
                    Image = newImage,
                };

                // On ajoute le PictureBox dans le Panel
                panel1.Controls.Add(newPic);
                int ColumnsNumber = 4;

                // On gère les colonnes, lignes
                currentColumn++;
                if (currentColumn >= ColumnsNumber)
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }

            // Affichage du temps d'exécution
           // lbl.Text = string.Format("{0} ms", sw.ElapsedMilliseconds);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
