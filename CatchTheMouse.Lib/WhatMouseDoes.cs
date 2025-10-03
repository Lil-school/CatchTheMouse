using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class WhatMouseDoes : Player, IMouse
    {
        int _mouseMoved = 0;
        Mouse _mouse;
        public WhatMouseDoes(PlayingArea playingArea) : base(playingArea)
        {
            new Mouse(playingArea);
        }

        public bool IsVisible { get; private set; }

        public override Position Move()
        {
            if (_mouseMoved == 3)
            {
                IsVisible = true;
                Position position = _mouse.Move();
                _mouseMoved = 0;
                return position;
            }
            IsVisible = false;
            _mouseMoved++;
            return _mouse.Position;
            
        }
    }
}
