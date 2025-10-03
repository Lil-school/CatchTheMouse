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
        int _moves;
        public IMouse Mouse { get; }
        public Player Cat { get; }
        public int Score { get { return _maxScore - _moves * 10 - (int)(DateTime.Now - _startTime).TotalSeconds;  } }
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
        public Game(int width, int height, int moves)
        {
            
            PlayingArea playingArea = new PlayingArea(width, height);
            Cat = new Cat(playingArea);
            Mouse =(IMouse) new Mouse(playingArea);
            _moves = moves;
        }

        public void Play(Position catPosition)
        {
            Mouse.Move();
            Cat.Move(catPosition);
        }

    }
}
