using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootingGame
{
    public class LevelBonusGH
    {
        int grndHogSpeed;
        int currScore;

        public LevelBonusGH(int speed)
        {
            grndHogSpeed = speed;
            currScore = 0;
        }

        public void updateScore(int add)
        {
            currScore += add;
        }

        public int getSpeed()
        {
            return grndHogSpeed;
        }

        public int getScore()
        {
            return currScore;
        }
    }
}
