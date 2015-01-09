using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    public class Pozadi : AVykreslitelnyObjekt
    {
        #region singleton

        private static Pozadi _instance;

        public static Pozadi Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Pozadi();
                }
                return _instance;
            }
        }
        #endregion
        const int _starCount = 2500;

        private Pozadi()
        {
            this.Sprite = new Bitmap(640 * 2, 480);
            this.BBox = new Rectangle(this.Pozice, this.Sprite.Size);
            using (Graphics g = Graphics.FromImage(this.Sprite))
            {
                g.Clear(System.Drawing.Color.Black);
                for (int i = 0; i <= _starCount; i++)
                {
                    int velikostHvezdy = Hra.randomInstance.Next(1, 4); //ruzna velikost pro pocit hloubky

                    int starX = Hra.randomInstance.Next(1, this.Sprite.Width - 1);
                    int starY = Hra.randomInstance.Next(1, this.Sprite.Height - 1);

                    g.FillEllipse(new SolidBrush(Color.FromArgb(31, 255, 255, 255)), starX + velikostHvezdy, starY, velikostHvezdy, velikostHvezdy); //ocas
                    g.FillEllipse(new SolidBrush(Color.FromArgb(63, 255, 255, 255)), starX + velikostHvezdy / 2, starY, velikostHvezdy, velikostHvezdy); //ocas
                    g.FillEllipse(Brushes.White, starX, starY, velikostHvezdy, velikostHvezdy);


                    starX = Hra.randomInstance.Next(1, this.Sprite.Width - 1);
                    starY = Hra.randomInstance.Next(1, this.Sprite.Height - 1);

                    g.FillEllipse(new SolidBrush(Color.FromArgb(31, 255, 255, 255)), starX + velikostHvezdy, starY, velikostHvezdy, velikostHvezdy); //pozadi

                    starX = Hra.randomInstance.Next(1, this.Sprite.Width - 1);
                    starY = Hra.randomInstance.Next(1, this.Sprite.Height - 1);

                    g.FillEllipse(new SolidBrush(Color.FromArgb(15, 131, 131, 255)), starX + velikostHvezdy, starY, velikostHvezdy, velikostHvezdy); //pozadi

                    starX = Hra.randomInstance.Next(1, this.Sprite.Width - 1);
                    starY = Hra.randomInstance.Next(1, this.Sprite.Height - 1);

                    g.FillEllipse(new SolidBrush(Color.FromArgb(7, 131, 131, 255)), starX + velikostHvezdy, starY, velikostHvezdy, velikostHvezdy); //pozadi

                    starX = Hra.randomInstance.Next(1, this.Sprite.Width - 1);
                    starY = Hra.randomInstance.Next(1, this.Sprite.Height - 1);

                    g.FillEllipse(new SolidBrush(Color.FromArgb(3, 131, 131, 255)), starX + velikostHvezdy, starY, velikostHvezdy, velikostHvezdy); //pozadi
                }
            }
        }
    }
}
