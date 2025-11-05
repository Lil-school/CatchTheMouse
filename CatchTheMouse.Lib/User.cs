using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class User : IComparable<User>
    {
        internal string FirstName { get; set; }
        internal string LastName { get; private set; }  
        internal DateTime LastGame { get; set; }
        public int HighScore { get; private set; }
        public User(string firstName,string lastName, DateTime lastGame, int score)
        {
            FirstName = firstName;
            LastName = lastName;
            LastGame = lastGame;
            HighScore = score;
        }
        public User(User user) : this(user.FirstName,user.LastName, user.LastGame, user.HighScore) { }
        public int ChangeHighScore(int newScore)
        {
            if (newScore > HighScore)
            {
                HighScore = newScore;
            }
            LastGame= DateTime.Now;
            return HighScore;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} - Highscore: {HighScore} - Last Game: {LastGame}";
        }

        public int CompareTo(User other)
        {
            int result = other.HighScore.CompareTo(HighScore);
            if (result==0)
            {
                return other.LastName.CompareTo(LastName);
            }
            return result;
        }
    }
}
