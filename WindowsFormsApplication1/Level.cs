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
    }
}
