using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class PlayingArea
    {
        internal int Width { get; }
        internal int Height { get; }
        public PlayingArea(int width, int height)
        {
            Width = width;
            Height = height;
        }
        internal bool IsValid(Position position)
        {
            return !((position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height));
        }
    }
}
