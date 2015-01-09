using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace SpaceShooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Hra.Instance.NastavPBox(this.pictureBoxHra);
            new SoundPlayer(Properties.Resources.Pixel_Peeker_Polka_faster).Play();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Color pixel = ((Bitmap)this.pictureBoxHra.Image).GetPixel(e.X, e.Y);
            if (pixel.R == 254 && pixel.G == 0 && pixel.B == 0) //moje magicka cervena
            {
                this.Close();
            }
        }

        #region keyhandling
        private void Form1_KeyDown(object sender, KeyEventArgs e) //kvuli tomu jak blbe winforms pracuje s klavesami
        {
            this.OveritKlavesy(e.KeyData);
        }

        protected override bool IsInputKey(Keys keyData) 
        {
            this.OveritKlavesy(keyData); //tohle zmirni ten lag ale neopravi "kolizi" klaves
            return base.IsInputKey(keyData);
        }

        private void OveritKlavesy(Keys keyData) //WPF tohle zrovna ma vyreseny, stejne tak XNA
        {
            switch (keyData) //zkousel jsem timery keylistenery a vselijaky kombinace a nic nepomaha
            {
                case Keys.Up:
                    Hra.Instance.OnKlavesaNahoru();
                    break;
                case Keys.Down:
                    Hra.Instance.OnKlavesaDolu();
                    break;
                case Keys.Space:
                    Hra.Instance.OnKlavesaMezernik();
                    break;
                default:
                    break;
            }
        }

        #endregion

        public void GameOver()
        {
            MessageBox.Show("Game Over!", "Nalehava zprava!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            this.Close();
        }

        //z googlu pro pohyb okna
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
    }
}
