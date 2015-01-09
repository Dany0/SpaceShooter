namespace SpaceShooter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxHra = new System.Windows.Forms.PictureBox();
            this.pictureBoxSideBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSideBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxHra
            // 
            this.pictureBoxHra.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxHra.Name = "pictureBoxHra";
            this.pictureBoxHra.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxHra.TabIndex = 0;
            this.pictureBoxHra.TabStop = false;
            this.pictureBoxHra.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // pictureBoxSideBar
            // 
            this.pictureBoxSideBar.Enabled = false;
            this.pictureBoxSideBar.Image = global::SpaceShooter.Properties.Resources.shooter;
            this.pictureBoxSideBar.Location = new System.Drawing.Point(640, 0);
            this.pictureBoxSideBar.Name = "pictureBoxSideBar";
            this.pictureBoxSideBar.Size = new System.Drawing.Size(64, 480);
            this.pictureBoxSideBar.TabIndex = 1;
            this.pictureBoxSideBar.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 480);
            this.Controls.Add(this.pictureBoxSideBar);
            this.Controls.Add(this.pictureBoxHra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSideBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHra;
        private System.Windows.Forms.PictureBox pictureBoxSideBar;
    }
}

