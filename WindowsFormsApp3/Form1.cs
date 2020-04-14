using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private int speed_vertical = 4;
        private int speed_hor = 4;
        private int score = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;

            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            this.Bounds = Screen.PrimaryScreen.Bounds;

            _ = gamepanel.Top - Background.Bottom - (Background.Bottom / 10);

        }

        private void Background_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gamepanel.Left = Cursor.Position.X - (gamepanel.Width / 2);

            pictureBox.Left += speed_hor;
            pictureBox.Top += speed_vertical;

            if (pictureBox.Left <= Background.Left)
                speed_hor *= -1;

            if (pictureBox.Right >= Background.Right)
                speed_hor *= -1;

            if (pictureBox.Top <= Background.Top)
                speed_vertical *= -1;

            if (pictureBox.Bottom >= Background.Bottom)
                timer.Enabled = false;

            if (pictureBox.Bottom >= gamepanel.Top && pictureBox.Bottom <= gamepanel.Bottom
                && pictureBox.Left >= gamepanel.Left && pictureBox.Right <= gamepanel.Right)
            {
                speed_hor += 3;
                speed_vertical += 3;
                speed_vertical *= -1;
                score += 1;

            }   
        }
    }
}
