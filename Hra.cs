using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceShooter
{
    public class Hra : IDisposable
    {
        const float FPS = 60; //musi nasobek 20 kvuli pozadi

        const float TICK_INTERVAL = (1 / FPS) * 1000;

        const int SPEED_FACTOR = (int)FPS / 10;

        public Timer gameTimer = new Timer();

        private int _gameTime;

        public static Random randomInstance = new Random(DateTime.Now.Millisecond);

        #region singleton

        private static Hra _instance;
        private Hra()
        {
            this.gameTimer.Interval = (int)Math.Floor(TICK_INTERVAL);
            this.gameTimer.Tick += gameTimer_Tick;
            this.gameTimer.Start();
        }

        public static Hra Instance
        {
           get 
           {
               if (_instance == null)
              {
                  _instance = new Hra();
              }
               return _instance;
           }
        }
        #endregion

        private string _strZivoty = string.Empty;
        private PictureBox _pbox;

        private TlacitkoZavrit _closeSign;

        private int _skore = 0;

        private IList<Strela> _strelySeznam = new List<Strela>();

        private IList<Mimozemstan> _alienSeznam = new List<Mimozemstan>();

        private IList<Mimozemstan> _alienLaterSeznam = new List<Mimozemstan>();

        void gameTimer_Tick(object sender, EventArgs e)
        {
            this._gameTime = this._gameTime  >= this._pbox.Width ? 0 : this._gameTime += 1;
            Hra.Instance.HraLoop();
        }

        public void HraLoop()
        {
            if (this._pbox != null)
            {
                foreach (Mimozemstan newAlien in this._alienLaterSeznam)
                {
                    this._alienSeznam.Add(newAlien);
                }
                this._alienLaterSeznam.Clear();

                //pripravit seznamy k odstraneni
                IList<Mimozemstan> mimozemstaneKOdstraneni = new List<Mimozemstan>();
                IList<Strela> strelyKOdstraneni = new List<Strela>();

                //kolize strel
                foreach (Strela s in this._strelySeznam)
                {
                    if (s.Pozice.X > this._pbox.Width)
                    {
                        strelyKOdstraneni.Add(s);
                        continue;
                    }
                    foreach (Mimozemstan alien in this._alienSeznam)
                    {
                        alien.BBox = new Rectangle(alien.Pozice, alien.Sprite.Size);
                        if (alien.BBox.IntersectsWith(s.BBox))
                        {
                            if (!alien.ZasahAliena())
                            {
                                mimozemstaneKOdstraneni.Add(alien);
                            }
                            strelyKOdstraneni.Add(s);

                            this._skore += 1; //pridame skore
                            if (this._skore > 0 && this._skore % 10 == 0)
                            {
                                if (this._skore % 50 == 0) //kazdych 50 skore pridame "bosse"
                                {
                                    this._alienLaterSeznam.Add(new MegaMimozemstan(new Point(this._pbox.Width,
                                        randomInstance.Next(126, this._pbox.Height - 126))));
                                }
                                if (this._skore % 100 == 0) //kazdych 100 nafukujiciho-se mimozemstana
                                {
                                    this._alienLaterSeznam.Add(new InflatableMimozemstan(new Point(this._pbox.Width,
                                        randomInstance.Next(126, this._pbox.Height - 126))));
                                }
                                Hrac.Instance.Zivoty = Math.Min(Hrac.Instance.Zivoty + 1, 15); //odmena pridat zivot kazdych 10 skore
                            }
                        }
                    }
                }

                //procistime strely
                foreach (Strela s in strelyKOdstraneni)
                {
                    this._strelySeznam.Remove(s);
                }

                foreach (Mimozemstan al in this._alienSeznam)
                {
                    if (Hrac.Instance.BBox.IntersectsWith(al.BBox))
                    {
                        if (Hrac.Instance.Zivoty - 1 == 0)
                        {
                            gameTimer.Stop();
                            ((Form1)this._pbox.FindForm()).GameOver();
                        }
                        Hrac.Instance.Zivoty -= 1;
                        mimozemstaneKOdstraneni.Add(al);
                        break;
                    }
                }

                
                foreach (Mimozemstan al in this._alienSeznam)
                {
                    int krokX = (al.Pozice.X - al.Smer.X) / (int)FPS + 1; //plus jedna protoze limity...
                    int krokY = (al.Pozice.Y - al.Smer.Y) / (int)FPS;
                    al.Pozice = new Point(al.Pozice.X - krokX, al.Pozice.Y - krokY);
                    if (al.Pozice.X == al.Smer.X)
                    {
                        mimozemstaneKOdstraneni.Add(al);
                    }
                }

                foreach (Mimozemstan al in mimozemstaneKOdstraneni)
                {
                    this._alienSeznam.Remove(al);
                    this._skore -= 1;
                }

                this._strZivoty = string.Empty;
                for (uint i = 0; i < Hrac.Instance.Zivoty; i += 1)
                {
                    this._strZivoty += "♥";
                }

                foreach (Strela strela in this._strelySeznam)
                {
                    strela.Pozice = new Point(strela.Pozice.X + SPEED_FACTOR, strela.Pozice.Y);
                }

                //vygenerujeme noveho aliena kazdou sekundu
                if (this._gameTime % (int)FPS / 6 == 0)
                {
                    this._alienSeznam.Add(new Mimozemstan(new Point(this._pbox.Width,
                        randomInstance.Next(32, this._pbox.Height - 32))));
                }

                this.Kresli();
            }
        }

        private void Kresli()
        {
            this._pbox.Refresh(); // rucni double buffering

            Image img = new Bitmap(this._pbox.Width, this._pbox.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                int modFaktor = (int)(this._pbox.Width / (SPEED_FACTOR / 2)); //kvuli delce platna
                int pozadiDelta = this._gameTime % modFaktor * SPEED_FACTOR;
                g.DrawImage(Pozadi.Instance.Sprite, new Point(Pozadi.Instance.Pozice.X - pozadiDelta,
                    Pozadi.Instance.Pozice.Y));
                g.DrawImage(Pozadi.Instance.Sprite, new Point(Pozadi.Instance.Sprite.Width - pozadiDelta, //mohli jsme druhe pozadi aspon oriznout, ale my rekli ne-ne-ne
                    Pozadi.Instance.Pozice.Y)); //mohli jsme druhe pozadi malovat jen kdyz je potreba, ale my rekli ne-ne-ne
                foreach (Strela strela in this._strelySeznam)
                {
                    g.DrawImage(strela.Sprite, strela.Pozice);
                }
                g.DrawImage(Hrac.Instance.Sprite, Hrac.Instance.Pozice);
                g.DrawImage(this._closeSign.Sprite, this._closeSign.Pozice);
                foreach (Mimozemstan al in this._alienSeznam)
                {
                    g.DrawImage(al.vykresliMimozemstana(this._gameTime), al.Pozice);
                }
                g.DrawString(this._strZivoty, new Font("Arial", this._pbox.Width / 20), Brushes.Red, 0.0f, (float)(this._pbox.Height - this._pbox.Height / 10));
                g.DrawString(this._skore.ToString(), new Font("Verdana", this._pbox.Width / 20), this._skore >= 0 ? Brushes.Green : Brushes.Red, 0.0f, 0.0f);
            }
            this._pbox.Image = img;

            this._pbox.Refresh();
        }

        public void NastavPBox(PictureBox canvas) //v podstate inicializace hry protoze predavat parametry to singletonu by bylo neprakticke
        {
            this._pbox = canvas;
            this._closeSign = new TlacitkoZavrit(this._pbox.Width / 16,
                new Point(
                    this._pbox.Width - this._pbox.Width / 16 - this._pbox.Width / 16 / 4,
                    this._pbox.Width / 16 / 4));
            Hrac.Instance.Pozice = new Point(0, this._pbox.Height / 2 - Hrac.Instance.Sprite.Height / 2);
        }

        public void OnKlavesaNahoru()
        {
            Hrac.Instance.Pozice = new Point(Hrac.Instance.Pozice.X, Hrac.Instance.Pozice.Y - SPEED_FACTOR);
        }

        public void OnKlavesaDolu()
        {
            Hrac.Instance.Pozice = new Point(Hrac.Instance.Pozice.X, Hrac.Instance.Pozice.Y + SPEED_FACTOR);
        }

        public void OnKlavesaMezernik()
        {
            int strelaSize = 8 * 6 / 2 / (int)Hrac.Instance.Zivoty; //si to zlehcime kdyz to moc nejde
            this._strelySeznam.Add(new Strela(strelaSize, new Point(Hrac.Instance.Pozice.X, Hrac.Instance.Pozice.Y - strelaSize / 2 + Hrac.Instance.Sprite.Height / 2)));
        }

        public void PridejMimozemstana(Point pozice)
        {
            this._alienLaterSeznam.Add(new Mimozemstan(pozice));
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
