using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NikolaV2
{
    public partial class Menu1 : Form
    {
        public Bitmap logo = new Bitmap(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "NikolaBigLogo.png"));
        public bool musak = false;
        public String botname;
        public int intensity;
        public Menu1()
        {
            InitializeComponent();
            pictureBox1.BackgroundImage = logo;
            instance = this;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            botname = "Nikola Tesla";
            intensity = 1;
            Form1 form1 = new Form1();
            playButton.Enabled = false;
            form1.Show();
        }
        public static Menu1 instance { get; set; }

        private void musicCheck_CheckedChanged(object sender, EventArgs e)
        {
            musak = !musak;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            Help Guide = new Help();
            Guide.Show();
        }

        private void GalleryButton_Click(object sender, EventArgs e)
        {
            Gallery Gex = new Gallery(); //change to the gallery
            Gex.Show();
        }
    }

}
