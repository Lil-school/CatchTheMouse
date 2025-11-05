


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public interface IUserSaveService
    {
        bool Save(string filename, List<User> users);
    }
}
