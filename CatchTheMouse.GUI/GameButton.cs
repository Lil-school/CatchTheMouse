using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.GUI
{
    internal class GameButton
    {
        int Y { get; set; }
        int X { get; set; }
        GameButton(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
