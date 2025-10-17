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
       

        public StatisticsForm()
        {
            InitializeComponent();
            LoadScores(_userManager.GetUsers());
        }
        public void LoadScores(User[] scores)
        {
            lstScore.Items.Clear();
            foreach (var score in scores)
            {
                lstScore.Items.Add(score);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tbxFirstName.Text != null && tbxLastName.Text != null)
            {
                _userManager.AddUser(new User(tbxFirstName.Text,tbxLastName.Text,DateTime.Now,0));
            }
            if (lstScore.SelectedItem != null) 
            {
                _user = (User)lstScore.SelectedItem;
                _catchTheMouse.Show();
            }
        }
    }
}
