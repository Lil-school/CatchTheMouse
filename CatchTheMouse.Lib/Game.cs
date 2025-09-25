using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class Game
    {
        public Player Mouse { get; }
        public Player Cat { get; }
        public bool GameOver { get { if (Mouse.Position.X == Cat.Position.X && Mouse.Position.Y == Cat.Position.Y) { return true; } } }
        public Game(int width, int height)
        {
            
            PlayingArea playingArea=new PlayingArea(width, height);
            Cat= new Cat(playingArea);
            Mouse= new Mouse(playingArea);

        }
    }
}
