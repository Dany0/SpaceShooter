using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    public class TlacitkoZavrit : AVykreslitelnyObjekt
    {
        public int VelikostTlacitka;

        public TlacitkoZavrit(int velikost, Point pozice)
        {
            this.VelikostTlacitka = velikost;
            this.Pozice = pozice;
            this.Sprite = new Bitmap(this.VelikostTlacitka, this.VelikostTlacitka);
            this.BBox = new Rectangle(this.Pozice, this.Sprite.Size);
            using (Graphics g = Graphics.FromImage(this.Sprite))
            {
                //stin
                Pen greyPen = new Pen(new SolidBrush(Color.FromArgb(127, 127, 127, 127)), VelikostTlacitka / 4);
                g.DrawLine(greyPen, VelikostTlacitka / 16, 0, VelikostTlacitka + VelikostTlacitka / 16, VelikostTlacitka);
                g.DrawLine(greyPen, VelikostTlacitka + VelikostTlacitka / 16, 0, VelikostTlacitka / 16, VelikostTlacitka);

                //krizek
                Pen redPen = new Pen(new SolidBrush(Color.FromArgb(255, 254, 0, 0)), VelikostTlacitka / 4);
                g.DrawLine(redPen, 0, 0, VelikostTlacitka, VelikostTlacitka);
                g.DrawLine(redPen, VelikostTlacitka, 0, 0, VelikostTlacitka);
            }
        }
    }
}
