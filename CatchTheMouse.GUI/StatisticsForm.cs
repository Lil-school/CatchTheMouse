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
        User newUser;
        IUserSaveService _saveService;
        IUserLoadService _loadService;
        UserManager _userManager;
        CatchTheMouse _catchTheMouse;
        internal User CurrentUser { get; set; }
        public StatisticsForm()
        {
            InitializeComponent();
            _userManager = new UserManager(_loadService, _saveService);
            _catchTheMouse = new CatchTheMouse();
            _catchTheMouse.StatisticsForm = this; 
            LoadScores();
        }
        public void LoadScores()
        {
            lstScore.Items.Clear();
            foreach (var user in _userManager.GetUserSortedByScore())
            {
                lstScore.Items.Add(user);
            }
        }       

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxFirstName.Text) && !string.IsNullOrEmpty(tbxLastName.Text))
            {
                newUser = new User(tbxFirstName.Text, tbxLastName.Text, DateTime.Now, 0);
                CurrentUser = newUser;
                _userManager.AddUser(newUser);
                Hide();
                _catchTheMouse.Show();
            }
            else if (lstScore.SelectedItem != null) 
            {
                CurrentUser = (User)lstScore.SelectedItem;
                Hide();
                _catchTheMouse.Show();
            }
        }
        #region unused
        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
