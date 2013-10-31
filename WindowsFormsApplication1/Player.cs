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
        int highScore;              // All time high for player

        public Player(string n)
        {
            name = n;
            totalScore = 0;
            highScore = 0;
        }

        public int getHighScore()
        {
            return highScore;
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

        public Boolean updateHighScore(int add)
        {
            try
            {
                highScore += add;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
