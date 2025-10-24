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
    public partial class StatisticsForm : Form
    {
        UserManager _userManager = new UserManager();
        CatchTheMouse _catchTheMouse;
        Game _game = new Game(10,10);

        public StatisticsForm()
        {
            InitializeComponent();
            _catchTheMouse = new CatchTheMouse();
            _catchTheMouse.StatisticsForm = this; 
            LoadScores();
        }
        public void LoadScores()
        {
            lstScore.Items.Clear();
            foreach (var score in _userManager.GetUsers())
            {
                lstScore.Items.Add(score);
            }
        }       

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxFirstName.Text) && !string.IsNullOrEmpty(tbxLastName.Text))
            {
                _userManager.AddUser(new User(tbxFirstName.Text,tbxLastName.Text,DateTime.Now,0));
                Hide();
                _catchTheMouse.Show();
            }
            else if (lstScore.SelectedItem != null) 
            {
                _game.CurrentUser = (User)lstScore.SelectedItem;
                Hide();
                _catchTheMouse.Show();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
