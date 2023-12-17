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
    public partial class Gallery : Form
    {
        public List<Bitmap> listableCards = new List<Bitmap>();
        public List<string> listableTitles = new List<string>();
        public int CardNum;

        public Gallery()
        {
            InitializeComponent();
            GalleryDater();
            CardNum = 0;
            cardImg.BackgroundImage = listableCards[CardNum];
            Explanation.Text = listableTitles[CardNum];
        }

        public void GalleryDater()
        {
            //Black Cards
            string BimagePath1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign7Black.png");
            string BimagePath2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign8Black.png");
            string BimagePath3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign9Black.png");
            string BimagePath4 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign10Black.png");
            string BimagePath5 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignStopBlack.png");
            string BimagePath6 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignDownBlack.png");
            string BimagePath7 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignPaintBlack.png");
            //White Cards
            string WimagePath1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign7White.png");
            string WimagePath2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign8White.png");
            string WimagePath3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign9White.png");
            string WimagePath4 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign10White.png");
            string WimagePath5 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignStopWhite.png");
            string WimagePath6 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignDownWhite.png");
            string WimagePath7 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignPaintWhite.png");
            //Red Cards
            string RimagePath1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign7Red.png");
            string RimagePath2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign8Red.png");
            string RimagePath3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign9Red.png");
            string RimagePath4 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign10Red.png");
            string RimagePath5 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignStopRed.png");
            string RimagePath6 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignDownRed.png");
            string RimagePath7 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignPaintRed.png");
            //Blue Cards
            string LimagePath1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign7Blue.png");
            string LimagePath2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign8Blue.png");
            string LimagePath3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign9Blue.png");
            string LimagePath4 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesign10Blue.png");
            string LimagePath5 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignStopBlue.png");
            string LimagePath6 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignDownBlue.png");
            string LimagePath7 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignPaintBlue.png");

            listableCards.Add(new Bitmap(BimagePath1));
            listableCards.Add(new Bitmap(BimagePath2));
            listableCards.Add(new Bitmap(BimagePath3));
            listableCards.Add(new Bitmap(BimagePath4));
            listableCards.Add(new Bitmap(BimagePath5));
            listableCards.Add(new Bitmap(BimagePath6));
            listableCards.Add(new Bitmap(BimagePath7));
            listableCards.Add(new Bitmap(WimagePath1));
            listableCards.Add(new Bitmap(WimagePath2));
            listableCards.Add(new Bitmap(WimagePath3));
            listableCards.Add(new Bitmap(WimagePath4));
            listableCards.Add(new Bitmap(WimagePath5));
            listableCards.Add(new Bitmap(WimagePath6));
            listableCards.Add(new Bitmap(WimagePath7));
            listableCards.Add(new Bitmap(RimagePath1));
            listableCards.Add(new Bitmap(RimagePath2));
            listableCards.Add(new Bitmap(RimagePath3));
            listableCards.Add(new Bitmap(RimagePath4));
            listableCards.Add(new Bitmap(RimagePath5));
            listableCards.Add(new Bitmap(RimagePath6));
            listableCards.Add(new Bitmap(RimagePath7));
            listableCards.Add(new Bitmap(LimagePath1));
            listableCards.Add(new Bitmap(LimagePath2));
            listableCards.Add(new Bitmap(LimagePath3));
            listableCards.Add(new Bitmap(LimagePath4));
            listableCards.Add(new Bitmap(LimagePath5));
            listableCards.Add(new Bitmap(LimagePath6));
            listableCards.Add(new Bitmap(LimagePath7));

            listableTitles.Add("Black 7");
            listableTitles.Add("Black 8");
            listableTitles.Add("Black 9");
            listableTitles.Add("Black 10");
            listableTitles.Add("Black Stop");
            listableTitles.Add("Black Down");
            listableTitles.Add("Black Paint");

            listableTitles.Add("White 7");
            listableTitles.Add("White 8");
            listableTitles.Add("White 9");
            listableTitles.Add("White 10");
            listableTitles.Add("White Stop");
            listableTitles.Add("White Down");
            listableTitles.Add("White Paint");

            listableTitles.Add("Red 7");
            listableTitles.Add("Red 8");
            listableTitles.Add("Red 9");
            listableTitles.Add("Red 10");
            listableTitles.Add("Red Stop");
            listableTitles.Add("Red Down");
            listableTitles.Add("Red Paint");

            listableTitles.Add("Blue 7");
            listableTitles.Add("Blue 8");
            listableTitles.Add("Blue 9");
            listableTitles.Add("Blue 10");
            listableTitles.Add("Blue Stop");
            listableTitles.Add("Blue Down");
            listableTitles.Add("Blue Paint");
        }

        private void cardImg_Click(object sender, EventArgs e)
        {
            CardNum++;
            if(CardNum >= listableCards.Count)
            {
                CardNum = 0;
            }
            cardImg.BackgroundImage = listableCards[CardNum];
            Explanation.Text = listableTitles[CardNum];
        }
    }
}
