using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }  
        public DateTime LastGame { get; set; }
        public int HighScore { get; set; }
        public User(string FirstName,string LastName, DateTime lastGame, int score)
        {


            this.FirstName = FirstName;
            this.LastName = LastName;
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
    }
}
