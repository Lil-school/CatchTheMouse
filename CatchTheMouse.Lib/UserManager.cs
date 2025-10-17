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
        public void AddUsers(User user)
        {
            if (!_users.Contains(user))
            {
                _users.Add(user);
            }
        }
        public User[] GetUsers()
        {
            return _users.ToArray();
        }
    }
}
