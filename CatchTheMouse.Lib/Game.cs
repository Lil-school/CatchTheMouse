using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class Game
    {
        int _maxScore = 1000;

        DateTime _startTime = DateTime.Now;

        int _moves=0;

        WhatMouseDoes _mouse;
        public IMouse Mouse { get; }
        public Player Cat { get; }
        public User CurrentUser { get; set; }

        public int Score { 
            get 
            { 
                int score= _maxScore - _moves * 10 - (int)(DateTime.Now - _startTime).TotalSeconds;
                if (score >= 0) { return score; }
                return 0;
            } 
        }
        public bool GameOver 
        { 
            get 
            { 
                if (Mouse.Position.X == Cat.Position.X && Mouse.Position.Y == Cat.Position.Y) 
                { 
                    return true; 
                }
                return false;
            } 
        }
        
        public Game(int width, int height)
        {
            
            PlayingArea playingArea = new PlayingArea(width, height);
            Cat = new Cat(playingArea);
            Mouse = new WhatMouseDoes(playingArea);
            _mouse = (WhatMouseDoes)Mouse;
            _mouse.Test = true;
        }

        public void Play(Position catPosition)
        {
            Mouse.Move();
            Cat.Move(catPosition);
            _moves++;
        }

    }
}
