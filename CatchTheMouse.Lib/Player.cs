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
        public Position Position { get; } = new Position();
        protected PlayingArea _playingArea;

        public Player(PlayingArea playingArea)
        {
            _playingArea = playingArea;
            DoPosition();
        }
        public void Move(Position position)
        {
            if (_playingArea.IsValid(position))
            {
                Position.X = position.X;
                Position.Y = position.Y;
            }
        }

        public virtual Position Move()
        {
            DoPosition();
            return Position;
        }
        private Position DoPosition()
        {
            Move(new Position(_rnd.Next(_playingArea.Width), _rnd.Next(_playingArea.Height)));
            return Position;
        }
    }
}