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
        Mouse mouse;
        public WhatMouseDoes(PlayingArea playingArea):base (playingArea)
        {
          mouse = new Mouse(playingArea);
        }

        public bool IsVisible { get; private set; }

        public bool Test { get; set; }
        public override Position Move()
        {
            if (Test)   // For testing purposes, mouse is always visible and not moving 
            {           // changed in Game class set Test to true for testing
                while (true)
                {
                    if (_playingArea.IsValid(Position))
                    {
                        Move(Position);
                        IsVisible = true;
                        return Position;
                    }
                }
            }

            while (true)    // Normal game play Mouse moves and becomes visible every 3rd move
            {
                MouseMove msMove = MouseMove.GetMove();     //Gets a random move
                Position position = new Position(Position.X + msMove.DeltaX, Position.Y + msMove.DeltaY);
                if (_playingArea.IsValid(position))
                {
                    if (_mouseMoved == 3)
                    {
                        IsVisible = true;
                        Move(position);
                        _mouseMoved = 1;
                        return position;
                    }
                    else
                    {
                        IsVisible = false;
                        Move(position);
                        _mouseMoved++;
                        return position;
                    }
                }
            }
        }
    }
}
