using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;
using System.Diagnostics;

namespace whatstockv1
{
    public  partial  class Form1 : Form
    {
        private String msg = "";
        private Boolean img = false;
        private Boolean isMsg = false;
        private Database db;
        private List<Messages> liste = new List<Messages>();
        private String rootPath ;
        public Form1()
        {
            InitializeComponent();
            rootPath = Environment.CurrentDirectory;
            if (isMsgstore())
            {
                db = new Database();
                load_chatList(db.listChat());
                db.closeConnection();
            }
            if (System.IO.File.Exists(rootPath + @"\wa.db"))
            {
                db = new Database("wa.db");
                load_contact();
                db.closeConnection();
            }
            // Mettre un boutton en couleur et les autres restent transparentes
            btn_home.BackColor = Color.Gold;
            messageContrl1.BringToFront();
            btn_audio.BackColor = Color.Transparent;
            btn_contact.BackColor = Color.Transparent;            
            btn_photo.BackColor = Color.Transparent;
            btn_message.BackColor = Color.Transparent;
            btn_videos.BackColor = Color.Transparent;
            



        }
        private Boolean isMsgstore()
        {
            return System.IO.File.Exists(rootPath + @"\msgstore.db");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_photo_Click(object sender, EventArgs e)
        {

            btn_audio.BackColor = Color.Transparent;
            btn_contact.BackColor = Color.Transparent;
            btn_home.BackColor = Color.Transparent;
            btn_photo.BackColor = Color.Gold;
            btn_message.BackColor = Color.Transparent;
            btn_videos.BackColor = Color.Transparent;
           
           
            panel7.SendToBack();

                
                OpenFileDialog openfile = new OpenFileDialog();
            if (!img)
            {
                if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    panel9.Controls.Clear();
                    String filepath = openfile.FileName;
                    loadImages(filepath);
                    panel5.SendToBack();

                    //MessageBox.Show("I'm in photo button");
                    panel9.BringToFront();

                }
                else
                {
                    
                    messageContrl1.BringToFront();
                    btn_home.BackColor = Color.Gold;
                    btn_photo.BackColor = Color.Transparent;
                }

            }
            

            

           
           // panel6.BringToFront();
            //photoAff1.BringToFront();
            // photoCtrl1.BringToFront();

        }
        private void ClearImageControls()
        {
            // on supprime les picturebox existants
            
            if (panel9.Controls.Count > 0)
            {
                for (var index = panel1.Controls.Count - 1; index >= 0; index--)
                {
                    var ctrlImage = panel9.Controls[index] as PictureBox;
                    if (ctrlImage != null)
                    {
                        panel9.Controls.RemoveAt(index);
                        ctrlImage.Image = null;
                        ctrlImage.Dispose();
                    }
                }
            }
        }
        public void loadImages(String directory)
        {


            // Résolution de problème de chemins
            String commonpath = Environment.CurrentDirectory;
            String fullpath="";
            System.IO.DirectoryInfo directoryt = new System.IO.DirectoryInfo(directory);
            System.IO.DirectoryInfo myd = directoryt.Parent;
           // fullpath = myd.FullName + @"\" + directory + @"\";
            if (System.IO.Directory.Exists(myd.FullName + @"\"))
            {
                
                ClearImageControls();


                var currentColumn = 0;
                var currentRow = 0;
                int j = 0;
                // pour toutes les images du répertoire
                foreach (var fileName in System.IO.Directory.GetFiles(myd.FullName+@"\", "*.*g"))
                {
                    // On charge l'image
                    Image img = new Bitmap(fileName);
                    // On en fait une vignette
                    int PictureWidth = 150;
                    int PictureHeigth = 80;
                    int PictureMargin = 10;
                    var newImage = img.GetThumbnailImage(PictureWidth, PictureHeigth, null, IntPtr.Zero);
                    // on décharge l'image
                    img.Dispose();

                    // on crée le PictureBox
                    var newPic = new PictureBox
                    {
                        Width = PictureWidth,
                        Height = PictureHeigth,
                        Location = new Point
                        {
                            X = currentColumn * (PictureWidth + PictureMargin),
                            Y = currentRow * ( PictureWidth + PictureMargin)+10
                        },
                        Image = newImage,
                    };
                    newPic.Name = fileName;
                    newPic.Click+=new System.EventHandler(this.open);
                    // On ajoute le PictureBox dans le Panel
                    panel9.Controls.Add(newPic);
                    int ColumnsNumber = 4;

                    // On gère les colonnes, lignes
                    currentColumn++;
                    if (currentColumn >= ColumnsNumber)
                    {
                        currentColumn = 0;
                        currentRow++;
                    }
                    j++;
                }
                if (j > 0)
                {
                    messageContrl1.label3.Text = j.ToString();
                    img = true;
                }
            }

            else
            {
                MessageBox.Show(fullpath + " n'existe malheuresement pas");
            }
                            
        }

        // Fonction d'ouverture d'une image
        private void open(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            System.Diagnostics.Process.Start(pb.Name);
            

        }
        // Fonction home pour afficher la page d'acceuil
        private void button2_Click(object sender, EventArgs e)
        {
           messageContrl1.BringToFront();
            btn_home.BackColor = Color.Gold;
            btn_audio.BackColor = Color.Transparent;
            btn_contact.BackColor = Color.Transparent;
            btn_photo.BackColor = Color.Transparent;
            btn_message.BackColor = Color.Transparent;
            btn_videos.BackColor = Color.Transparent;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        // Fermer la fenetre
        private void btn_close_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();

        }


        private void btn_message_Click(object sender, EventArgs e)
        {
            btn_audio.BackColor = Color.Transparent;
            btn_contact.BackColor = Color.Transparent;
            btn_home.BackColor = Color.Transparent;
            btn_photo.BackColor = Color.Transparent;
            btn_videos.BackColor = Color.Transparent;
            btn_message.BackColor = Color.Gold;
            panel7.SendToBack();
            panel5.BringToFront();
            if (System.IO.File.Exists(@"wa2.db")&& !isMsg) 
                // affiche les messages avec les vrais noms s'ils existent 
            {
                MessageBox.Show("Base de donnée de contact ajoutée");
                Database db = new Database();
                load_chatList(db.listChat());
                isMsg = !isMsg;
                db.closeConnection();
            }
            
            label1.Text = "";

        }

        private void btn_audio_Click(object sender, EventArgs e)
        {
            btn_audio.BackColor = Color.Gold;
            btn_contact.BackColor = Color.Transparent;
            btn_home.BackColor = Color.Transparent;
            btn_photo.BackColor = Color.Transparent;
            btn_message.BackColor = Color.Transparent;
            btn_videos.BackColor = Color.Transparent;
            panel7.SendToBack();

        }

        private void btn_videos_Click(object sender, EventArgs e)
        {
            btn_audio.BackColor = Color.Transparent;
            btn_contact.BackColor = Color.Transparent;
            btn_home.BackColor = Color.Transparent;
            btn_photo.BackColor = Color.Transparent;
            btn_message.BackColor = Color.Transparent;
            btn_videos.BackColor = Color.Gold;
            panel7.SendToBack();
        }

        private void btn_contact_Click(object sender, EventArgs e)
        {
            btn_audio.BackColor = Color.Transparent;
            btn_contact.BackColor = Color.Gold;
            btn_home.BackColor = Color.Transparent;
            btn_photo.BackColor = Color.Transparent;
            btn_message.BackColor = Color.Transparent;
            btn_videos.BackColor = Color.Transparent;
            panel7.SendToBack();
            if (System.IO.File.Exists(@"wa.db"))
            {
                load_contact();
            }
            panel4.BringToFront();
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_audio.BackColor = Color.Transparent;
            btn_contact.BackColor = Color.Transparent;
            btn_home.BackColor = Color.Transparent;
            btn_photo.BackColor = Color.Transparent;
            btn_message.BackColor = Color.Gold;
            btn_videos.BackColor = Color.Transparent;
            panel7.SendToBack();
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                String filepath = openfile.FileName;
                if (filepath.Contains("msgstore.db"))
                {
                    
                    String appPath = rootPath+@"\msgstore.db";
                    if (!System.IO.File.Exists(appPath))
                    {
                        System.IO.File.Copy(filepath, appPath);
                        MessageBox.Show("Base de donnée ajoutée");
                    }
                    else
                    {
                        System.IO.File.Delete(appPath);
                        System.IO.File.Copy(filepath, appPath);
                        MessageBox.Show("Base de donnée ajoutée");

                    }
                    Database db = new Database();
                    this.load_chatList(db.listChat());
                    db.closeConnection();

                }else
                {
                    MessageBox.Show("Ce n'est pas une vraie base de données");
                }

               



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btn_audio.BackColor = Color.Transparent;
            btn_home.BackColor = Color.Transparent;
            btn_photo.BackColor = Color.Transparent;
            btn_message.BackColor = Color.Transparent;
            btn_videos.BackColor = Color.Transparent;
            btn_contact.BackColor = Color.Gold;
            panel7.SendToBack();
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                String appPath = @".\wa.db";
                String appPath2 = @".\wa2.db";


                String filepath = openfile.FileName;
                if (filepath.Contains("wa.db"))
                {
                    if (!System.IO.File.Exists(appPath))
                    {
                        System.IO.File.Copy(filepath, appPath);
                        MessageBox.Show("Base de donnée ajoutée");
                        System.IO.File.Copy(filepath, appPath2);

                    }
                    else
                    {
                        System.IO.File.Delete(appPath);
                        System.IO.File.Delete(appPath2);
                        System.IO.File.Copy(filepath, appPath);
                        System.IO.File.Copy(filepath, appPath2);
                        MessageBox.Show("Base de donnée ajoutée");

                    }

                    this.load_contact();

                }
                else
                {
                    MessageBox.Show("Base de données incorrecte");
                }


            }
        }
        /// <summary>
        /// Juste des couleurs pour décoration de l'affichage des contacts, ces 
        /// couleurs sont choisis aléatoirements
        /// </summary>
       // Color[] clr = new Color[] { Color.Aqua, Color.Azure, Color.Chocolate, Color.FloralWhite, Color.Gold,Color.Teal };
        // La fonction qui charge les contacts de la base de données
        // Fait un formatage de l'affichage des contacts
        private List<Contact> load_contact()
        {
            Database db = new Database("wa.db");
            int j = 0;
            List<Contact> liste = new List<Contact>();
                liste = db.ListeContacts();
            panel4.BringToFront();
            while (j < liste.Count())
            {
                Contact c = new Contact();
                c = liste.ElementAt(j);
               // dataGridView1.Rows.Add(c.getDisplay_name(), "0" + c.getNumber(), c.getStatus());
                contact_item_list cc = new contact_item_list();
                cc.setNom(c.getDisplay_name());
                cc.setNumero(c.getStatus());
                cc.setColor(Color.White);
                cc.setTime("+2120"+c.getNumber().ToString());
                cc.Location = new System.Drawing.Point(0, 65*j);
                panel4.Controls.Add(cc);
                j++;
            }
            db.closeConnection();
            messageContrl1.label4.Text = liste.Count().ToString();
            return liste;

        }
        // Génère les nombres aléatoires
        public int aleatoire()
        {
            Random aleatoire = new Random();
            int mois = aleatoire.Next(0, 6); // Génère un entier compris entre 1 et 12
            return mois;
        }
        // Charge la liste de chats de la base de données
        private void load_chatList(List <ChatList> chListe)
        {
            Database db = new Database();
            //var chListe = db.listChat();
            int j = 0;
            String verif = "";
            panel5.Controls.Clear();
            this.panel5.Controls.Add(btnSearch());
            this.panel5.Controls.Add(textBox());
            while (j < chListe.Count())
            {
                ChatList chL = new ChatList();
                chL = chListe.ElementAt(j);
                //  chat_cpnt cc = new chat_cpnt();
                contact_item_list cc = new contact_item_list();                           
                List<Contact> lc = new List<Contact>();

                    liste = db.listMessages(chL.getKey_remote_jid());
                    cc.setNom(chL.getKey_remote_jid());                
                    cc.setNumero(liste.ElementAt(liste.Count() - 1).getData());


                DateTime t = convertTime(long.Parse(chL.getTimestamp().ToString()) / 1000);                  
                verif = String.Format("{0:dd/MM/yyyy}", t);
                msg = chL.getKey_remote_jid();
                cc.setTime(verif);
                cc.Location = new System.Drawing.Point(0,63*j + 45);
                cc.setColor(Color.White);
                               
                cc.lbl_t().Click += new System.EventHandler(this.test);
                //cc.Click += new System.EventHandler(this.test); 
                System.IO.FileInfo file = new System.IO.FileInfo(@"wa2.db");
                if (System.IO.File.Exists(@"wa2.db") && file.Length > 5)
                cc.setNom(addRealName(chL));          
                panel5.Controls.Add(cc);
                //panel5.Controls.Add(cc);
                // panel5.BringToFront(); 
                liste = null;          
                
                j++;
            }
            panel5.BringToFront();
            panel7.SendToBack();
            //db.closeConnection();
            messageContrl1.label2.Text = chListe.Count().ToString();

        }

        private void test(object sender, EventArgs e)
        {
            
            btn_audio.BackColor = Color.Transparent;
            btn_contact.BackColor = Color.Transparent;
            btn_home.BackColor = Color.Transparent;
            btn_photo.BackColor = Color.Transparent;
            btn_message.BackColor = Color.Gold;
            btn_videos.BackColor = Color.Transparent;
            Label l = (Label)sender;
            Database dbwa = null , db = null;
            System.IO.FileInfo file = new System.IO.FileInfo(@"wa2.db");
            if (System.IO.File.Exists("wa2.db")&&file.Length > 10)
            {
                dbwa= new Database("wa2.db");
                msg = dbwa.searchIdContact(l.Text);
                dbwa.closeConnection();
            }
            else
            {
                msg = l.Text;
            }
            db = new Database();
            liste = db.listMessages(msg);
            label1.Text = l.Text;
            this.load_message(liste);                   
            panel6.BringToFront();
            panel7.BringToFront();
            
            db.closeConnection();
          
        }

        private void load_message(List<Messages> liste)
        {
            
            Database db = new Database();
            int j = 0;
            panel6.Controls.Clear();
            Messages mm = new Messages();
            db.closeConnection();

            while (j < liste.Count())
            {
                mm = liste.ElementAt(j);
              // messageData l = new messageData();
                Label l = new Label();
                l.AutoSize = true;
                //new System.Drawing.Size(145, 160);
                l.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                
               l.AutoEllipsis = true ;
                DateTime t = convertTime(mm.getTimestamp() / 1000);
                String h = String.Format("{0:d/M/yyyy  hh:mm:ss}", t);
                switch (mm.getKey_from_me())
                {
                    case 1:
                        l.Location = new System.Drawing.Point(400, 56* j + 70);
                        l.BackColor = Color.GreenYellow;
                        break;
                    case 0:
                        l.Location = new System.Drawing.Point(23, 56* j + 70);
                        l.BackColor = Color.LightGray;
                        break;
                    default:
                        break;
                }
                //l.ForeColor = System.Drawing.Color.White;
                
                l.Text = mm.getData() + '\n' + h;
                 
                //l.setTextL(mm.getData());
                
                panel6.Controls.Add(l);
                j++;
            }

            
        }

        private String addRealName(ChatList chL)
        {           
                int jj = 0;
                String name = "";
                Database dat = new Database("wa2.db");
                List <Contact> lc = new List<Contact>();
                lc = dat.ListeContacts();
                dat.closeConnection();
                Contact contact = new Contact();
                while (jj < lc.Count())
                {
                    contact = lc.ElementAt(jj);
                    if (chL.getKey_remote_jid() == contact.getJid())
                    {
                        name = contact.getDisplay_name();
                        break;
                    }
                    else
                    {
                    if (chL.getSubject() != null && chL.getSubject() !="")
                        name = chL.getSubject();
                    else
                        name = contact.getJid();
                        jj++;
                    }
                }

            return name;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            String txt = richTextBox1.Text;
            Database db = new Database();
            this.load_chatList(db.search(txt));

            db.closeConnection();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            

        }
        public Control textBox()
        {
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(90, 8);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(345, 33);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            return this.richTextBox1;
        }
        public Control btnSearch()
        {
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.btn_search.FlatAppearance.BorderSize = 0;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.Location = new System.Drawing.Point(480, 8);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(69, 33);
            this.btn_search.TabIndex = 5;
            this.btn_search.Text = "Search";
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);

            return this.btn_search;
        }

        public void loadPhotos()
        {

        }
        public void setMessageTitle(String msg)
        {
           // label1.Text = msg;
        }
        public void setMessages(String msg)
        {
           // label2.Text = msg;
        }

        private void messageContrl1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        public static DateTime convertTime(double unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (long)(unixTime * TimeSpan.TicksPerSecond);
            return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("pfa.pdf");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBox.Show("Pas encore fonctionnelle","Ouups", button);
                     }
    }
}
