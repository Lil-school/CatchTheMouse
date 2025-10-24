using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    internal interface IUserLoadService
    {
        public bool Load(string filename, List<User>);
    }
}
