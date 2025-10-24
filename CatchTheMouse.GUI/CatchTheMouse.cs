using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CatchTheMouse.Lib;

namespace CatchTheMouse.GUI
{
    public partial class CatchTheMouse : Form
    {
        const int WIDTH = 10;
        const int HEIGHT = 10;
        Game _game = new Game(WIDTH,HEIGHT);
        Button[,] _buttons = new Button[WIDTH,HEIGHT];
        int _mouseMoved = 0;
        internal StatisticsForm StatisticsForm { get; set; }
        public CatchTheMouse()
        {
            InitializeComponent();
            
            CreateButtons();
        }
        internal void CreateButtons()
        {
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    GameButton gb = new GameButton(i, j);
                    gb.Width = 84;
                    gb.Height = 84;

                    if (_game.Mouse.Position.X == i && _game.Mouse.Position.Y == j)
                    {
                        gb.BackgroundImage = GetImageJerry();
                    }
                    else if (_game.Cat.Position.X == i && _game.Cat.Position.Y == j)
                    {
                        gb.BackgroundImage = GetImageTom();
                    }
                    else
                    {
                        gb.BackgroundImage = GetImageCTM();
                    }
                    gb.BackgroundImageLayout = ImageLayout.Zoom;
                    gb.Click += new System.EventHandler(GameButton_Click);
                    flwPlayingArea.Controls.Add(gb);
                    _buttons[i, j] = gb;
                }
                flwPlayingArea.SetFlowBreak(_buttons[i, _buttons.GetLength(1) - 1], true);
            }
        }
        


        public void GameButton_Click(object sender, EventArgs e)
        {
            
            if (_game.GameOver) { Close(); }
            else
            {
                GameButton button = (GameButton)sender;
                _buttons[_game.Mouse.Position.X, _game.Mouse.Position.Y].BackgroundImage = GetImageCTM();

                _buttons[_game.Cat.Position.X, _game.Cat.Position.Y].BackgroundImage = GetImageCTM();
               _game.Play(new Position(button.X, button.Y));


                if (_game.Mouse.IsVisible)
                {
                    _buttons[_game.Mouse.Position.X, _game.Mouse.Position.Y].BackgroundImage = GetImageJerry();
                } 
                else 
                {        
                    _buttons[_game.Mouse.Position.X, _game.Mouse.Position.Y].BackgroundImage = GetImageCTM();
                }

                

                if (_game.GameOver)
                {
                    _buttons[_game.Mouse.Position.X, _game.Mouse.Position.Y].BackgroundImage = GetImageTomCatchesJerry();
                    GameOver();
                    
                }
                else
                {
                    _buttons[_game.Cat.Position.X, _game.Cat.Position.Y].BackgroundImage = GetImageTom();
                }
            }
        }

        void GameOver()
        {
            MessageBox.Show("Game Over - Tom fängt Jerry");
            Hide();
            StatisticsForm.LoadScores();
            StatisticsForm.Show();
            _game= new Game(WIDTH, HEIGHT);
        }

       

        #region ImageMethods
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
        #endregion

    }
}
