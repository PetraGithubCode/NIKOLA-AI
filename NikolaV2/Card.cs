using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikolaV2
{
    public class Card
    {
        private string cardname;
        private int cardvalue;
        private int cardcolor;
        private bool stopper;
        private bool puller;
        private float reqvalue;
        private int cardimg;

        public Card(string cardname, int cardvalue, int cardcolor, bool stopper, bool puller, float reqvalue, int cardimg)
        {
            this.cardname = cardname;
            this.cardvalue = cardvalue;
            this.cardcolor = cardcolor;
            this.stopper = stopper;
            this.puller = puller;
            this.reqvalue = reqvalue;
            this.cardimg = cardimg;
        }

        public string Name
        {
            get { return cardname; }
            set { cardname = value; }
        }
        public int Value
        {
            get { return cardvalue; }
            set { cardvalue = value; }
        }
        public int Color
        {
            get { return cardcolor; }
            set { cardcolor = value; }
        }
        public int CImage
        {
            get { return cardimg; }
            set { cardimg = value; }
        }

        public bool Stopper { get { return stopper; } set { stopper = value; } }

        public bool Puller { get { return puller; } set { puller = value; } }
    }
}
