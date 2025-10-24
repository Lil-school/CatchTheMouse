


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    internal interface IUserSaveService
    {
        public bool Save(string filename, List<User> users);
    }
}
