using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootingGame
{
    public class Target
    {
        int size;                   // Size of the object
        string type;                // Type/Name of the object
        int life;                   // Amount of life of the target
        bool alive;                 // If target is alive
        int score;                  // Score for killing target

        public Target(string t)
        {
            type = t;
            alive = true;

            if (type == "bird")
            {
                size = 1;
                life = 1;
                score = 5;
            }
            else if (type == "deer")
            {
                size = 3;
                life = 3;
                score = 10;
            }
            else if (type == "buffalo")
            {
                size = 5;
                life = 5;
                score = 20;
            }
        }

        public Boolean Shot(int hit)
        {
            try
            {
                life -= hit;
                if (life <= 0)
                {
                    alive = false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean isAlive()
        {
            return alive;
        }

        public int getLife()
        {
            return life;
        }

        public int getScore()
        {
            return score;
        }
    }
}
