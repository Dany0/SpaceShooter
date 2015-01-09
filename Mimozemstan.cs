using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceShooter
{
    public class Mimozemstan : AVykreslitelnyObjekt
    {
        public Point Smer;

        protected int _alienZivoty;

        protected int _velikost;

        public Mimozemstan(Point poz)
        {
            this._alienZivoty = Hra.randomInstance.Next(2, 5); //2 az 4
            this._velikost = this._alienZivoty * 32; //16 az 64
            this.Pozice = poz;
            this.Sprite = this.vykresliMimozemstana(0);
            this.BBox = new Rectangle(this.Pozice, this.Sprite.Size);
            this.Smer = new Point(-1 * this._velikost, Hra.randomInstance.Next(this._velikost, 480 - this._velikost));
        }

        public virtual Image vykresliMimozemstana(int delta)
        {
            Image imgAlien = new Bitmap(this._velikost, this._velikost);
            using (Graphics g = Graphics.FromImage(imgAlien))
            {
                g.FillPie(Brushes.Yellow, 0, 0, imgAlien.Width, imgAlien.Height, 180 + 22 - (delta % 22), 340 - (delta % 23));
                g.FillEllipse(Brushes.Red, new Rectangle(imgAlien.Width / 4, imgAlien.Width / 4, imgAlien.Width / 8, imgAlien.Width / 8));
            }
            return imgAlien;
        }

        public virtual bool ZasahAliena()
        {
            this.Smer = new Point(0, Hra.randomInstance.Next(this._velikost * (3 + 1 - this._alienZivoty), 480 - this._velikost * 2));
            this._velikost /= 2;
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
