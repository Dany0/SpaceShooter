using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    public abstract class AVykreslitelnyObjekt
    {
        private Point _pozice = new Point(0, 0);

        public Point Pozice
        {
            get { return _pozice; }
            set { _pozice = value; }
        }

        //Bounding Box = Ohraničovací Rámeček?
        //Neco v tom smyslu, velikost zbytecna
        private Rectangle _bBox;

        public Rectangle BBox
        {
            get
            {
                Size oldSize = _bBox.Size;
                _bBox = new Rectangle(this._pozice, oldSize); // mozna by bylo lepsi rovnou odstranit vlastnost pozice
                return _bBox;
            }
            set { _bBox = value; }
        }

        //Misto metody vykresli
        private Image _sprite;

        public Image Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

    }
}
