using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchTheMouse.GUI
{
    public partial class CatchTheMouse : Form
    {

        public CatchTheMouse()
        {
            InitializeComponent();
            GameButton gb = new GameButton(i, j);
            gb.Width = 84;
            gb.Height = 84;
            gb.BackgroundImage = CatchTheMouse.GUI.Properties.Resources.CTM;
            gb.BackgroundImageLayout = ImageLayout.Zoom;
            gb.Click += new System.EventHandler(this.GameButton_Click);
            flwPlayingArea.Controls.Add(gb);
            _buttons[i, j] = gb;

        }
        Image GetImageJerry()
        {
            return Properties.Resources.jerry;
        }
        Image GetImageTom()
        {
            return Properties.Resources.tom;
        }
        Image GetImageCTM()
        {
            return Properties.Resources.CTM;
        }
        Image GetImageTomCatchesJerry()
        {
            return Properties.Resources.tomcatchesjerry;
        }


    }
}
