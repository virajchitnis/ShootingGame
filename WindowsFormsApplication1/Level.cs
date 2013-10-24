using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootingGame
{
    public class Level
    {
        int levelNumber;
        int maxScore;
        int currScore;
        int numTargetsSmall;
        int numTargetsMedium;
        int numTargetsBig;

        public Level(int lvlNum, int small, int medium, int big)
        {
            levelNumber = lvlNum;
            numTargetsSmall = small;
            numTargetsMedium = medium;
            numTargetsBig = big;
            currScore = 0;
            // initialize maxScore by multiplying the number of each type of target with its score and adding.
        }

        public Boolean updateScore(int add)
        {
            try
            {
                currScore += add;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int getLevel()
        {
            return levelNumber;
        }

        public int getScore()
        {
            return currScore;
        }

        public int getSmallTargets()
        {
            return numTargetsSmall;
        }

        public int getMediumTargets()
        {
            return numTargetsMedium;
        }

        public int getBigTargets()
        {
            return numTargetsBig;
        }
    }
}
