using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class UserManager
    {
        List<User> _users = new List<User>();
        public void AddUser(User user)
        {
            if (!_users.Contains(user))
            {
                _users.Add(user);
            }
        }

        public int CompareTo(User firstUser, User secondUser)
        {
            int result = secondUser.HighScore.CompareTo(firstUser.HighScore);
            if(result== 0)
            {
                return firstUser.LastName.CompareTo(secondUser.LastName);
            }
            return result;
        }

        public User[] GetUsers()
        {
            return _users.ToArray();
        }
        public User[] GetUserSortedByScore()
        {
            _users.Sort();
            return _users.ToArray();
        }
    }
}
