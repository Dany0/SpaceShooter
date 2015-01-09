using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    public class InflatableMimozemstan : Mimozemstan
    {
        public InflatableMimozemstan(Point poz) : base(poz)
        {
            this._alienZivoty = 4;
            this._velikost = 8;
            this.Pozice = poz;
            this.Sprite = this.vykresliMimozemstana(0);
            this.BBox = new Rectangle(this.Pozice, this.Sprite.Size);
            this.Smer = new Point(120, Hrac.Instance.Pozice.Y);
        }

        public override Image vykresliMimozemstana(int delta)
        {
            Image imgAlien = new Bitmap(this._velikost, this._velikost);
            using (Graphics g = Graphics.FromImage(imgAlien))
            {
                g.FillRectangle(Brushes.Red, new Rectangle(0, 0, imgAlien.Width - delta % 4, imgAlien.Height));
                g.FillRectangle(Brushes.Pink, new Rectangle(0, 0, imgAlien.Width / 4, imgAlien.Height));
            }
            return imgAlien;
        }

        public override bool ZasahAliena()
        {
            this._velikost *= 2;
            this.Sprite = this.vykresliMimozemstana(0);
            this._alienZivoty -= 1;
            if (this._alienZivoty == 0)
            {
                for (int i = 0; i < 8; i += 1)
                {
                    Hra.Instance.PridejMimozemstana(this.Pozice);
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
