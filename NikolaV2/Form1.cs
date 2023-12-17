using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace NikolaV2
{

    public partial class Form1 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sounds", "Fig Leaf Times Two.wav"));
        System.Media.SoundPlayer selnoise = new System.Media.SoundPlayer(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sounds", "Select.wav"));
        System.Media.SoundPlayer denynoise = new System.Media.SoundPlayer(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sounds", "No.wav"));
        public Bitmap cardback = new Bitmap (Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "CardDesignBack.png"));
        //Player vars
        public bool isPlayerTurn = true;
        public bool isCounting = false;
        //LISTS 
        //LISTS EVERYWHERE
        List<Card> CardList = new List<Card>();
        List<Card> BaseList = new List<Card>();
        List<Button> EmptySpots = new List<Button>();
        List<Button> ChosenCards = new List<Button>();
        List<Card> AvailibleCards = new List<Card>(new Card[10]);
        List<Bitmap> CardImages = new List<Bitmap>();
        public int BaseYpos = 364;
        public string CardNameCutter = "null";
        public int CardAssigner;
        public bool isStartOfGame = true;
        int beeper;
        List<Card> placedCard = new List<Card>();
        int baseCardValueY = 68;

        List<Card> NikolaCards = new List<Card>(new Card[9]);
        List<Card> MatchingCards = new List<Card>();
        public bool hasCheckedHand;
        List<Bitmap> NikolaPresentCards = new List<Bitmap>();
        Random rnd = new Random();
        public bool nikolaSpecialPlayed = false;

        //save stuff
        public string DeepName;
        public string DeepNamePath;
        public Card IntroCard;
        List<string> FullStringer = new List<string>();

        public Form1()
        {
            NikolaCards.Clear();
            InitializeComponent();
            int DeepNumber = rnd.Next(18, 1337);
            DeepName = "SacredText" + DeepNumber.ToString() + ".txt";
            DeepNamePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "saves", DeepName);
            Imager();
            EmptySpotter(PlayerCard9);
            EmptySpotter(PlayerCard8);
            EmptySpotter(PlayerCard7);
            EmptySpotter(PlayerCard6);
            CardListFill();
            NikolaPresenceFill();
            PullOutCard(PlayerCard2);   
            PullOutCard(PlayerCard3);
            PullOutCard(PlayerCard4);
            PullOutCard(PlayerCard5);
            PullOutCard(PlayerCard1);
            isStartOfGame = false;
            //Nikola Tesla moment
            //let Nikola pull out a card.
            PullOutCardNikola(1);
            PullOutCardNikola(2);
            PullOutCardNikola(3);
            PullOutCardNikola(4);
            PullOutCardNikola(5);
            EndOfTurnForNikola();
            IntroCard = CardList[rnd.Next(0, CardList.Count - 1)];
            placedCard.Add(IntroCard);
            LastCardPlaced.BackgroundImage = CardImages[IntroCard.CImage];
            //isPlayerTurn = true;
            if(Menu1.instance.musak)
            {
                player.Play();
            }



        }

        public void EmptySpotter(Button spott)
        {
            EmptySpots.Add(spott);
            spott.BackgroundImage = cardback;
            spott.Enabled = false;
            spott.Location = new Point(spott.Location.X, baseCardValueY + 8);
        }

        public void CardButcher(Button burton)
        {
            CardNameCutter = burton.Name;
            CardNameCutter = CardNameCutter.Remove(0, 10);
            //label1.Text = CardNameCutter;
            CardAssigner = Int32.Parse(CardNameCutter);
            CardAssigner = CardAssigner--;
        }
        public void BaseSet()
        {

            //ADD THE CARD VALUES NEXT AND HAVE FUN :DDD
            BaseList.Add(new Card("B7", 7, 1, false, true, 1f, 1));
            BaseList.Add(new Card("B8", 8, 1, false, false, 3f, 2));
            BaseList.Add(new Card("B9", 9, 1, false, false, 5f, 3));
            BaseList.Add(new Card("B10", 10, 1, false, false, 5f, 4));
            BaseList.Add(new Card("BS", 1, 1, true, false, 1f, 5));
            BaseList.Add(new Card("BD", 1, 1, true, false, 1f, 6));
            BaseList.Add(new Card("BP", 1, 1, true, true, 1f, 7));
            BaseList.Add(new Card("W7", 7, 2, false, true, 1f, 8));
            BaseList.Add(new Card("W8", 8, 2, false, false, 3f, 9));
            BaseList.Add(new Card("W9", 9, 2, false, false, 5f, 10));
            BaseList.Add(new Card("W10", 10, 2, false, false, 5f, 11));
            BaseList.Add(new Card("WS", 1, 2, true, false, 1f, 12));
            BaseList.Add(new Card("WD", 1, 2, true, false, 1f, 13));
            BaseList.Add(new Card("WP", 1, 2, true, true, 1f, 14));
            BaseList.Add(new Card("R7", 7, 3, false, true, 1f, 15));
            BaseList.Add(new Card("R8", 8, 3, false, false, 3f, 16));
            BaseList.Add(new Card("R9", 9, 3, false, false, 5f, 17));
            BaseList.Add(new Card("R10", 10, 3, false, false, 5f, 18));
            BaseList.Add(new Card("RS", 1, 3, true, false, 1f, 19));
            BaseList.Add(new Card("RD", 1, 3, true, false, 1f, 20));
            BaseList.Add(new Card("RP", 1, 3, true, true, 1f, 21));
            BaseList.Add(new Card("L7", 7, 4, false, true, 1f, 22));
            BaseList.Add(new Card("L8", 8, 4, false, false, 3f, 23));
            BaseList.Add(new Card("L9", 9, 4, false, false, 5f, 24));
            BaseList.Add(new Card("L10", 10, 4, false, false, 5f, 25));
            BaseList.Add(new Card("LS", 1, 4, true, false, 1f, 26));
            BaseList.Add(new Card("LD", 1, 4, true, false, 1f, 27));
            BaseList.Add(new Card("LP", 1, 4, true, true, 1f, 28));
        }

        public void Imager()
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

            //the reader thingamagig
            CardImages.Add(new Bitmap(BimagePath1));
            CardImages.Add(new Bitmap(BimagePath2));
            CardImages.Add(new Bitmap(BimagePath3));
            CardImages.Add(new Bitmap(BimagePath4));
            CardImages.Add(new Bitmap(BimagePath5));
            CardImages.Add(new Bitmap(BimagePath6));
            CardImages.Add(new Bitmap(BimagePath7));
            CardImages.Add(new Bitmap(WimagePath1));
            CardImages.Add(new Bitmap(WimagePath2));
            CardImages.Add(new Bitmap(WimagePath3));
            CardImages.Add(new Bitmap(WimagePath4));
            CardImages.Add(new Bitmap(WimagePath5));
            CardImages.Add(new Bitmap(WimagePath6));
            CardImages.Add(new Bitmap(WimagePath7));
            CardImages.Add(new Bitmap(RimagePath1));
            CardImages.Add(new Bitmap(RimagePath2));
            CardImages.Add(new Bitmap(RimagePath3));
            CardImages.Add(new Bitmap(RimagePath4));
            CardImages.Add(new Bitmap(RimagePath5));
            CardImages.Add(new Bitmap(RimagePath6));
            CardImages.Add(new Bitmap(RimagePath7));
            CardImages.Add(new Bitmap(LimagePath1));
            CardImages.Add(new Bitmap(LimagePath2));
            CardImages.Add(new Bitmap(LimagePath3));
            CardImages.Add(new Bitmap(LimagePath4));
            CardImages.Add(new Bitmap(LimagePath5));
            CardImages.Add(new Bitmap(LimagePath6));
            CardImages.Add(new Bitmap(LimagePath7));


        }

        public void CardListFill()
        {
            BaseSet();
            foreach (Card chicken in BaseList)
            {
                if (!CardList.Contains(chicken))
                {
                    CardList.Add(chicken);
                }
            }

        }

        public void NikolaPresenceFill()
        {
            string Gecco0 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "0.png");
            string Gecco1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "1.png");
            string Gecco2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "2.png");
            string Gecco3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "3.png");
            string Gecco4 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "4.png");
            string Gecco5 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "5.png");
            string Gecco6 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "6.png");
            string Gecco7 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "7.png");
            string Gecco8 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "8.png");
            string Gecco9 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "9.png");
            string Lost = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "NikolaWin.png");
            string Won = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images", "PlayerWin.png");
            NikolaPresentCards.Add(new Bitmap(Gecco0));
            NikolaPresentCards.Add(new Bitmap(Gecco1));
            NikolaPresentCards.Add(new Bitmap(Gecco2));
            NikolaPresentCards.Add(new Bitmap(Gecco3));
            NikolaPresentCards.Add(new Bitmap(Gecco4));
            NikolaPresentCards.Add(new Bitmap(Gecco5));
            NikolaPresentCards.Add(new Bitmap(Gecco6));
            NikolaPresentCards.Add(new Bitmap(Gecco7));
            NikolaPresentCards.Add(new Bitmap(Gecco8));
            NikolaPresentCards.Add(new Bitmap(Gecco9));
            NikolaPresentCards.Add(new Bitmap(Lost));
            NikolaPresentCards.Add(new Bitmap(Won));
        }

        public void PullOutCard(Button burton)
        {
            isCounting = true;
            while (isCounting)
            {
                if (CardList.Count >= 1)
                {
                    CardListFill();
                }
                if (isStartOfGame)
                {
                    CardButcher(burton);
                    Debug.Write(AvailibleCards.Count);
                    AvailibleCards[CardAssigner] = CardList[rnd.Next(0, CardList.Count - 1)];
                    if (AvailibleCards[CardAssigner].CImage != null)
                    {
                        
                        burton.BackgroundImage = CardImages[AvailibleCards[CardAssigner].CImage - 1];
                    }
                    CardList.Remove(AvailibleCards[CardAssigner]);

                    isPlayerTurn = false;
                    isCounting = false;
                }
                else if (EmptySpots.Any() && !EmptySpots.Last().Enabled && !isStartOfGame)
                {
                    Console.WriteLine("yee");
                    EmptySpots.Last().Enabled = true;
                    EmptySpots.Last().Location = new Point(EmptySpots.Last().Location.X, baseCardValueY - 8);
                    EmptySpots.Remove(EmptySpots.Last());
                    CardButcher(burton);
                    AvailibleCards[CardAssigner] = CardList[rnd.Next(1, CardList.Count)];
                    burton.BackgroundImage = CardImages[AvailibleCards[CardAssigner].CImage - 1];
                    CardList.Remove(AvailibleCards[CardAssigner]);
                    isPlayerTurn = false;
                    acceptButton.Enabled = false;
                    if (EmptySpots.Count == 0)
                    {
                        pullButton.Enabled = false;
                    }
                    isCounting = false;
                }
                else if (EmptySpots.Any() && EmptySpots.Last().Enabled && !isStartOfGame && AvailibleCards.Count <= 7)
                {
                    Console.WriteLine("yee");
                    EmptySpots.Remove(EmptySpots.Last());
                }
                else
                {
                    pullButton.Enabled = false;
                    Console.WriteLine("I have no idea");
                    isCounting = false;
                }

            }
            FullStringer.Add("[PULL P1]");
            if (!isStartOfGame)
            {
                ExitRoundPlayer();
            }
        }
        public void ExitRoundPlayer()
        {
            isPlayerTurn = false;
            acceptButton.Enabled = false;
            pullButton.Enabled = false;
            beeper = 0;
            GameStateCheckup();
            NikolaTurn();
        }

        public void GameStateCheckup()
        {
            if(AvailibleCards.Count <= 0 || EmptySpots.Count >= 9) { 
                
                FullStringer.Add("PLAYER WON");
                NikolaCardImg.BackgroundImage = NikolaPresentCards[11];
                NikolaCardImg.Refresh();
                pullButton.Enabled = false;
                HUD.Enabled = false;
                isPlayerTurn = true;
                return;
                
            }
            else if (NikolaCards.Count <= 0)
            {
                
                FullStringer.Add("NIKOLA WON");
                NikolaCardImg.BackgroundImage = NikolaPresentCards[10];
                NikolaCardImg.Refresh();
                pullButton.Enabled = false;
                HUD.Enabled = false;
                isPlayerTurn = false;
                return;
                
            }
            string ReadableTexter = string.Join(Environment.NewLine, FullStringer);
            File.WriteAllText(DeepNamePath, ReadableTexter);
        }
        public void BillCosby(Button cosby)
        {
            if (beeper == 0)
            {
                CardButcher(cosby);
                if(placedCard.Last().Stopper && placedCard.Last().Puller)
                {
                    beeper++;
                    ChosenCards.Add(cosby);
                    cosby.Location = new Point(cosby.Location.X, baseCardValueY - 10);
                    selnoise.Play();
                }
                else if (AvailibleCards[CardAssigner].Value == placedCard.Last().Value || AvailibleCards[CardAssigner].Color == placedCard.Last().Color)
                { 
                    beeper++;
                    ChosenCards.Add(cosby);
                    cosby.Location = new Point(cosby.Location.X, baseCardValueY - 10);
                    selnoise.Play();
                }else if (AvailibleCards[CardAssigner].Stopper && AvailibleCards[CardAssigner].Puller)
                {
                    beeper++;
                    ChosenCards.Add(cosby);
                    cosby.Location = new Point(cosby.Location.X, baseCardValueY - 10);
                    selnoise.Play();
                }
                else
                {
                    System.Media.SystemSounds.Asterisk.Play();
                }
            }
            /*else if (beeper == 1)
            {
                foreach (Button billy in ChosenCards.ToList())
                {
                    //Add so that it checks if the card can even be joined with the other ones
                    CardButcher(cosby);
                    int firstColor = BaseList[CardAssigner].Color;
                    int firstValue = BaseList[CardAssigner].Value;
                    CardButcher(billy);
                    if (AvailibleCards[CardAssigner].Value == firstValue || AvailibleCards[CardAssigner].Color == firstColor) //fix this shit pls.
                    {
                        if (!ChosenCards.Contains(cosby))
                        {
                            ChosenCards.Add(cosby);
                            cosby.Location = new Point(cosby.Location.X, baseCardValueY - 10);
                            
                        }
                    }  I am just gonna make it so you can only pull out one card no need to make it too complex
            }*/
            else
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
                
            

        }
        private void pullButton_Click(object sender, EventArgs e)
        {
            if (!EmptySpots.Any())
            {
                pullButton.Enabled = false;
            }
            if (EmptySpots.Any())
            {
                PullOutCard(EmptySpots.Last());
                //button10.Enabled = true;
            }
        }

        private void PlayerCard1_Click(object sender, EventArgs e)
        {
            BillCosby(PlayerCard1);
        }
        private void PlayerCard2_Click(object sender, EventArgs e)
        {
            BillCosby(PlayerCard2);
        }
        private void PlayerCard3_Click(object sender, EventArgs e)
        {
            BillCosby(PlayerCard3);
        }
        private void PlayerCard4_Click(object sender, EventArgs e)
        {
            BillCosby(PlayerCard4);
        }
        private void PlayerCard5_Click(object sender, EventArgs e)
        {
            BillCosby(PlayerCard5);
        }
        private void PlayerCard6_Click(object sender, EventArgs e)
        {
            BillCosby(PlayerCard6);
        }
        private void PlayerCard7_Click(object sender, EventArgs e)
        {
            BillCosby(PlayerCard7);
        }
        private void PlayerCard8_Click(object sender, EventArgs e)
        {
            BillCosby(PlayerCard8);
        }
        private void PlayerCard9_Click(object sender, EventArgs e)
        {
            BillCosby(PlayerCard9);
        }
        private void acceptButton_Click(object sender, EventArgs e)
        {
            bool specialHasPlayed = false;
            if (ChosenCards.Any())
            {
                foreach (Button doodoo in ChosenCards)
                {
                    CardButcher(doodoo);
                    //check card speciality
                    if(AvailibleCards[CardAssigner].Puller && !AvailibleCards[CardAssigner].Stopper && NikolaCards.Count != 9)
                    {
                        PullOutCardNikola(NikolaCards.Count);
                        specialHasPlayed = true;
                        
                    }else if (AvailibleCards[CardAssigner].Stopper && !AvailibleCards[CardAssigner].Puller)
                    {
                        specialHasPlayed = true;
                    }else if (AvailibleCards[CardAssigner].Stopper && AvailibleCards[CardAssigner].Puller)
                    {
                        specialHasPlayed = true;
                    }
                    placedCard.Add(AvailibleCards[CardAssigner]);
                    LastCardPlaced.BackgroundImage = CardImages[AvailibleCards[CardAssigner].CImage - 1];
                    EmptySpotter(doodoo);
                    FullStringer.Add("[" + AvailibleCards[CardAssigner].Name.ToString() + " P1]");
                    LastCardPlaced.Refresh();
                }

            }

            ChosenCards.Clear();
            beeper = 0;
            GameStateCheckup();
            if (!specialHasPlayed) { 
            ExitRoundPlayer();
            }
            else
            {
                EndOfTurnForNikola();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            denynoise.Play();
            foreach (Button cosby in ChosenCards.ToList())
                cosby.Location = new Point(cosby.Location.X, baseCardValueY + 8);
            ChosenCards.Clear();
            beeper = 0;
        }

        private void LastCardPlaced_Click(object sender, EventArgs e)
        {
            //read/show better q version of the card for people who can't see stuff correctly [REPLACED WITH GALLERY]
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        //NIKOLA LOGIC, SEPERATE FROM THE MAIN PLAYER STUFF

        public void NikolaTurn()
        {
            nikolaSpecialPlayed= false;
            pullButton.Enabled = false;
            acceptButton.Enabled = false;
            hasCheckedHand = false;
            isPlayerTurn = false;
            GameStateCheckup();
            Thread.Sleep(200);
            CheckHand();
               
             if (MatchingCards.Count < 1)
                    {
                        PullOutCardNikola(NikolaCards.Count);
                        EndOfTurnForNikola();
                    }
                    else if (MatchingCards.Count >= 1)
                    {
                        PlayACard(MatchingCards.First());
                        if(!nikolaSpecialPlayed) { 
                            EndOfTurnForNikola();
                        }
                        else
                        {
                            NikolaTurn();
                        }
                    }
                    /*else if (MatchingCards.Count < 1 && NikolaCards.Count == NikolaCards.Capacity)
                    {
                        EndOfTurnForNikola();
                    }*/
                    else
                    {
                        PullOutCardNikola(NikolaCards.Count);
                        EndOfTurnForNikola();
                    }

        }

        public void CheckHand()
        {
            MatchingCards.Clear();
            foreach (Card boopy in NikolaCards)
            {
                if (boopy != null)
                {
                    if (boopy.Value == placedCard.Last().Value || boopy.Color == placedCard.Last().Color)
                    {
                        MatchingCards.Add(boopy);
                    }
                }
            }
            hasCheckedHand = true;
        }

        public void PlayACard(Card beeswax)
        {
            if (beeswax != null)
            {
                placedCard.Add(beeswax);
                LastCardPlaced.BackgroundImage = CardImages[beeswax.CImage - 1] ;
                LastCardPlaced.Update();
                if (beeswax.Puller && !beeswax.Stopper && EmptySpots.Count != 0)
                {
                    PullOutCardNikola(NikolaCards.Count);
                    nikolaSpecialPlayed = true;

                }
                else if (beeswax.Stopper && !beeswax.Puller)
                {
                    nikolaSpecialPlayed = true;
                }
                else if (beeswax.Stopper && beeswax.Puller)
                {
                    nikolaSpecialPlayed = true;
                }
                NikolaCards.Remove(beeswax);
                FullStringer.Add("[" + AvailibleCards[CardAssigner].Name.ToString() + " NK]");
                LastCardPlaced.Refresh();
            }
        }


        public void PullOutCardNikola(int number)
        {
            int skeep = number - 1;
            bool gettys = false;
            while (!gettys)
            {
                if (CardList.Count < 2)
                {
                    CardListFill();
                }
                else //if(NikolaCards.Capacity - 1 != NikolaCards.Count - 1)
                {
                    NikolaCards.Add(CardList[rnd.Next(0, CardList.Count)]);
                    //burton.Image = CardImages[AvailibleCards[CardAssigner].CImage - 1];
                    FullStringer.Add("[PULL NK]");
                    CardList.Remove(NikolaCards[skeep]);
                    gettys = true;
                }
            }

        }
        public void EndOfTurnForNikola()
        {
            isPlayerTurn = true;
            switch (NikolaCards.Count)
            {
                case 1:
                    NikolaCardImg.Image = NikolaPresentCards[1];
                    NikolaCardImg.Refresh();
                    break;
                case 2:
                    NikolaCardImg.Image = NikolaPresentCards[2];
                    NikolaCardImg.Refresh();
                    break;
                case 3:
                    NikolaCardImg.Image = NikolaPresentCards[3];
                    NikolaCardImg.Refresh();
                    break;
                case 4:
                    NikolaCardImg.Image = NikolaPresentCards[4];
                    NikolaCardImg.Refresh();
                    break;
                case 5:
                    NikolaCardImg.Image = NikolaPresentCards[5];
                    NikolaCardImg.Refresh();
                    break;
                case 6:
                    NikolaCardImg.Image = NikolaPresentCards[6];
                    NikolaCardImg.Refresh();
                    break;
                case 7:
                    NikolaCardImg.Image = NikolaPresentCards[7];
                    NikolaCardImg.Refresh();
                    break;
                case 8:
                    NikolaCardImg.Image = NikolaPresentCards[8];
                    NikolaCardImg.Refresh();
                    break;
                case 9:
                    NikolaCardImg.Image = NikolaPresentCards[9];
                    NikolaCardImg.Refresh();
                    break;
                case 0:
                    NikolaCardImg.Image = NikolaPresentCards[0];
                    NikolaCardImg.Refresh();
                    break;
                default:
                    NikolaCardImg.Image = null;
                    NikolaCardImg.Refresh();
                    break;

            }
            if (EmptySpots.Count > 0)
            {
                pullButton.Enabled = true;
            }

            //readability
            string ReadableTexter = string.Join(Environment.NewLine, FullStringer);
            File.WriteAllText(DeepNamePath, ReadableTexter);
            GameStateCheckup();

            hasCheckedHand= false;
            acceptButton.Enabled = true;
        }

        
    }
}
