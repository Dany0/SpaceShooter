using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    public class MegaMimozemstan : Mimozemstan
    {
        public MegaMimozemstan(Point poz) : base(poz)
        {
            this._alienZivoty = 16;
            this._velikost = 512;
            this.Pozice = poz;
            this.Sprite = this.vykresliMimozemstana(0);
            this.BBox = new Rectangle(this.Pozice, this.Sprite.Size);
            this.Smer = new Point(this._velikost / 2, Hra.randomInstance.Next(0, 480));
        }

        public override Image vykresliMimozemstana(int delta)
        {
            Image imgAlien = new Bitmap(this._velikost, this._velikost);
            using (Graphics g = Graphics.FromImage(imgAlien))
            {
                g.FillPie(Brushes.DarkGoldenrod, 0, 0, imgAlien.Width, imgAlien.Height, 180 + 22 - (delta % 22), 340 - (delta % 23));
                g.FillEllipse(Brushes.Red, new Rectangle(imgAlien.Width / 4, imgAlien.Width / 4, imgAlien.Width / 8, imgAlien.Width / 8));
                //mohli jsme to udelat cyklem, ale my rekli ne-ne-ne

                g.FillEllipse(Brushes.Red, new Rectangle(imgAlien.Width / 3, imgAlien.Width / 3, imgAlien.Width / 8, imgAlien.Width / 8));


                g.FillEllipse(Brushes.Red, new Rectangle(imgAlien.Width / 5, imgAlien.Width / 5, imgAlien.Width / 8, imgAlien.Width / 8));


                g.FillEllipse(Brushes.Red, new Rectangle(imgAlien.Width / 4, imgAlien.Width / 6, imgAlien.Width / 8, imgAlien.Width / 8));


                g.FillEllipse(Brushes.Red, new Rectangle(imgAlien.Width / 6, imgAlien.Width / 4, imgAlien.Width / 8, imgAlien.Width / 8));


                g.FillEllipse(Brushes.Red, new Rectangle(imgAlien.Width / 4, imgAlien.Width / 3, imgAlien.Width / 8, imgAlien.Width / 8));


                g.FillEllipse(Brushes.Red, new Rectangle(imgAlien.Width / 3, imgAlien.Width / 4, imgAlien.Width / 8, imgAlien.Width / 8));


                g.FillEllipse(Brushes.Red, new Rectangle(imgAlien.Width / 4, imgAlien.Width / 5, imgAlien.Width / 8, imgAlien.Width / 8));


                g.FillEllipse(Brushes.Red, new Rectangle(imgAlien.Width / 5, imgAlien.Width / 4, imgAlien.Width / 8, imgAlien.Width / 8));


                g.FillEllipse(Brushes.Black, new Rectangle(imgAlien.Width / 4, imgAlien.Width / 8, imgAlien.Width / 4, imgAlien.Width / 4));
            }
            return imgAlien;
        }

        public override bool ZasahAliena()
        {
            Hra.Instance.PridejMimozemstana(this.Pozice);
            this.Smer = new Point(0, Hra.randomInstance.Next(Hrac.Instance.Pozice.Y - 32, Hrac.Instance.Pozice.Y + 32));
            this._velikost = this._velikost / 16 * 15;
            this.Sprite = this.vykresliMimozemstana(0);
            this._alienZivoty -= 1;
            if (this._alienZivoty == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
