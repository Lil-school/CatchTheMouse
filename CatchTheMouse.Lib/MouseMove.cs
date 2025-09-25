using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class MouseMove
    {
        private static Random _random = new Random();
        private static MouseMove[] _allMoves;

        internal int DeltaX { get; }
        internal int DeltaY { get; }

        static MouseMove()
        {
            _allMoves = new MouseMove[]
            {
                new MouseMove(-1, -1), // oben links
                new MouseMove(-1,  0), // links
                new MouseMove(-1,  1), // unten links
                new MouseMove( 0, -1), // oben
                new MouseMove( 0,  1), // unten
                new MouseMove( 1, -1), // oben rechts
                new MouseMove( 1,  0), // rechts
                new MouseMove( 1,  1), // unten rechts  
            }; 
        }

        internal MouseMove(int deltaX, int deltaY)
        {
            DeltaX = deltaX;
            DeltaY = deltaY;
        }
       
        internal static MouseMove GetMove()
        {
            return _allMoves[_random.Next(_allMoves.Length)];
        }
    }
}
