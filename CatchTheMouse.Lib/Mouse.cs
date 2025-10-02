using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class Mouse:Player
    {
        
        public Mouse(PlayingArea playingArea) : base(playingArea)
        {
        }

        public override Position Move()
        {
            while (true)
            {
                MouseMove msMove = MouseMove.GetMove();     //Gets a random move
                Position position = new Position(Position.X + msMove.DeltaX, Position.Y + msMove.DeltaY);
                if (_playingArea.IsValid(position)) 
                {
                    Move(position); 
                    return position; 
                }
            }
        }
    }
}
