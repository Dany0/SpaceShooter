using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceShooter
{
    public class Strela : AVykreslitelnyObjekt
    {
        public Strela(int velikost, Point pozice)
        {
            this.Pozice = pozice;
            this.Sprite = new Bitmap(velikost, velikost);
            this.BBox = new Rectangle(this.Pozice, this.Sprite.Size);
            using (Graphics g = Graphics.FromImage(this.Sprite))
            {
                g.FillEllipse(Brushes.Red, new Rectangle(0, 0, this.Sprite.Width, this.Sprite.Height));
                g.FillRectangle(Brushes.Red, new Rectangle(0, 0, this.Sprite.Width / 4 * 3, this.Sprite.Height));
            }
        }
    }
}
