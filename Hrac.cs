using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    public class Hrac : AVykreslitelnyObjekt
    {
        #region singleton

        private static Hrac _instance;

        public static Hrac Instance
        {
           get 
           {
               if (_instance == null)
              {
                  _instance = new Hrac();
              }
               return _instance;
           }
        }
        #endregion

        public uint Zivoty = 6;

        private Hrac()
        {
            this.Sprite = Properties.Resources.ship;
            ((Bitmap)(this.Sprite)).MakeTransparent(Color.FromArgb(255, 0, 255)); //MAGIC PINK
            this.BBox = new Rectangle(this.Pozice, this.Sprite.Size);
        }
    }
}
