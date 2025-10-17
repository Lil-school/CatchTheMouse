using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.Lib
{
    public class User
    {
        public string FistName { get; set; }
        public string LastName { get; set; }  
        public DateTime LastGame { get; set; }
        public int HighScore { get; set; }
        public User(string name, DateTime lastGame, int score)
        {
            var parts = name.Split(' ');
            FistName = parts.Length > 0 ? parts[0] : "";
            LastName = parts.Length > 1 ?parts[1] : "";
            LastGame = lastGame;
            HighScore = score;
        }
        public User(User user) : this(user.FistName + " " + user.LastName, user.LastGame, user.HighScore) { }
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
            return $"{FistName} {LastName} - Highscore: {HighScore} - Last Game: {LastGame}";
        }
    }
}
