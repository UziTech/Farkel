using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Farkel
{
    partial class AboutBox : Form
    {
        #region Global Variables
        Color[] colorArray = new Color[7];
        int colorIndex = 0;
        #endregion
        public AboutBox()
        {
            InitializeComponent();
            colorArray[0] = Color.Red;
            colorArray[1] = Color.Orange;
            colorArray[2] = Color.Yellow;
            colorArray[3] = Color.Green;
            colorArray[4] = Color.Blue;
            colorArray[5] = Color.Indigo;
            colorArray[6] = Color.Violet;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeColor();
        }
        private void ChangeColor()
        {
            if (++colorIndex == 350)
            {
                colorIndex = 0;
            }
            int index = colorIndex / 50;
            float redS = (float)colorArray[index].R;
            float redE = (float)colorArray[(index == 6) ? 0 : index + 1].R;
            float greenS = (float)colorArray[index].G;
            float greenE = (float)colorArray[(index == 6) ? 0 : index + 1].G;
            float blueS = (float)colorArray[index].B;
            float blueE = (float)colorArray[(index == 6) ? 0 : index + 1].B;
            int red = (int)(label1.ForeColor.R + (redE - redS) / 50);
            int green = (int)(label1.ForeColor.G + (greenE - greenS) / 50);
            int blue = (int)(label1.ForeColor.B + (blueE - blueS) / 50);
            if (red < 0)
            {
                red = 0;
            }
            if (red > 255)
            {
                red = 255;
            }
            if (green < 0)
            {
                green = 0;
            }
            if (green > 255)
            {
                green = 255;
            }
            if (blue < 0)
            {
                blue = 0;
            }
            if (blue > 255)
            {
                blue = 255;
            }
            label1.ForeColor = Color.FromArgb(red, green, blue);
            label2.ForeColor = Color.FromArgb(red, green, blue);
            label3.ForeColor = Color.FromArgb(red, green, blue);
        }
        private void AboutBox_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.freewebs.com/tonysfiles");
        }
    }
}
