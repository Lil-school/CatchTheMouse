using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public abstract class Player
    {
        static Random _rnd = new Random();
        public Position Position { get;}
        protected PlayingArea _playingArea;

        public Player(PlayingArea playingArea)
        {
            _playingArea = playingArea;
        }
        public void Move(Position position)
        {
            if (!_playingArea.IsValid(position)) { Position.X = position.X;Position.Y = position.Y; }
        }
        
        public virtual Position Move()
        {
            new Position(_rnd.Next(0, _playingArea.Width), _rnd.Next(0, _playingArea.Height));
            Move(Position);
            return Position;
        }
    }
}