using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootingGame
{
    public class Player
    {
        string name;                // Player name
        int totalScore;             // Total/Current score of the player

        public Player(string playerName)
        {
            name = playerName;
            totalScore = 0;
        }

        public Player(string playerName, int score)
        {
            name = playerName;
            totalScore = score;
        }

        public int getTotalScore()
        {
            return totalScore;
        }

        public string getName()
        {
            return name;
        }

        public Boolean updateTotalScore(int add)
        {
            try
            {
                totalScore += add;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
