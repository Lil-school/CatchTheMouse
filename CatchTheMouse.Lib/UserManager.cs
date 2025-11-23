using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class UserManager:IUserLoadService, IUserSaveService
    {
        const string FILENAME ="User";
        List<User> _users = new List<User>();
        IUserSaveService _saveService;  
        
        public UserManager(IUserLoadService loadService,IUserSaveService saveService)
        {
            Load(FILENAME, _users);
        }
        
        public void AddUser(User user)
        {
            int index = _users.FindIndex(u => u.FirstName == user.FirstName && u.LastName == user.LastName);

            if (index >= 0)
            {
                _users[index] = user;      // replace in place
            }
            else
            {
                _users.Add(user);
            }
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

        public bool Load(string filename, List<User> users)
        {
                try
                {
                foreach (var line in File.ReadAllLines(@"..\..\..\" + FILENAME + ".CSV", Encoding.UTF8))
                {
                    
                    string[] parts = line.Split(';');
                    User user = new User(parts[0], parts[1], DateTime.Parse(parts[5]), int.Parse(parts[3]));
                    _users.Add(user);
                }
                    return true;
                }
                catch
                {
                    return false;
                }
        }
        

        public bool Save(string filename, List<User> users)
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\..\"+FILENAME+".CSV",false,Encoding.UTF8))
            {
                try
                {
                   foreach (var user in users)
                   {
                        sw.WriteLine(user.ToString());
                   }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool SaveUsers()
        {
            return Save(FILENAME, _users);
        }
    }
}
