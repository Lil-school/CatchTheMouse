using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class Position
    {
        public int X { get;internal set; }
        public int Y { get; internal set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Position() : this(0, 0) { }
    }
}
