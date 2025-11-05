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
            if (!_users.Contains(user))
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
        using (StreamReader sr = new StreamReader(@"..\..\..\" + FILENAME + ".CSV", Encoding.UTF8))
            {
                try
                {
                    
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split(';');
                        User user = new User(parts[0], parts[1], DateTime.Parse(parts[2]), int.Parse(parts[3]));
                        _users.Add(user);
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Save(string filename, List<User> users)
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\..\" + FILENAME + ".CSV"))
            {
                try
                {
                    foreach (User user in _users)
                    {
                        sw.WriteLine($"{user.FirstName};{user.LastName};{user.LastGame};{user.HighScore}");
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
            return _saveService.Save(FILENAME, _users);
        }
    }
}
