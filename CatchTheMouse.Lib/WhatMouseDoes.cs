using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class WhatMouseDoes :Player, IMouse
    {
        int _mouseMoved = 1;
        
        public WhatMouseDoes(PlayingArea playingArea):base (playingArea)
        {
          
        }

        public bool IsVisible { get; private set; }


        public override Position Move()
        {
            while (true)
            {
                MouseMove msMove = MouseMove.GetMove();     //Gets a random move
                Position position = new Position(Position.X + msMove.DeltaX, Position.Y + msMove.DeltaY);
                if (_playingArea.IsValid(position))
                {
                    if (_mouseMoved == 3)
                    {
                        IsVisible = true;
                    
                        _mouseMoved = 1;
                        return position;
                    }
                    else
                    {
                        IsVisible = false;
                        _mouseMoved++;
                        return position;
                    }
                }
            }
            
        }
    }
}
