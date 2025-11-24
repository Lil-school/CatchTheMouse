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
        public UserManager UserManager => _userManager;
        internal User CurrentUser { get; set; }
        
        public StatisticsForm()
        {
            InitializeComponent();
            _userManager = new UserManager(_loadService, _saveService);
            _catchTheMouse = new CatchTheMouse(UserManager, this);
            LoadScores();
        }
        public void LoadScores()
        {
            lstScore.Items.Clear();
            foreach (var user in UserManager.GetUserSortedByScore())
            {
                lstScore.Items.Add(user.GetInfo());
            }
        }       

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxFirstName.Text) && !string.IsNullOrEmpty(tbxLastName.Text))
            {
                newUser = new User(tbxFirstName.Text, tbxLastName.Text, DateTime.Now, 0);
                tbxFirstName.Clear();
                tbxLastName.Clear();
                CurrentUser = newUser;
                UserManager.AddUser(newUser);
                Hide();
                
                _catchTheMouse.Show();
                _catchTheMouse=new CatchTheMouse(_userManager, this);
            }
            else if (lstScore.SelectedItem != null) 
            {
                CurrentUser = (User)lstScore.SelectedItem;
                Hide();
                
                _catchTheMouse.Show();
                _catchTheMouse=new CatchTheMouse(_userManager, this);
            }
        }
        #region unused
        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
