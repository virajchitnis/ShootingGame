using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootingGame
{
    public class Weapon
    {
        string type;
        int ammo;
        int damage;
        int timeReload;

        public Weapon(string t)
        {
            type = t;

            if (type == "handgun")
            {
                ammo = 10;
                damage = 1;
                timeReload = 5;
            }
            else if (type == "rifle")
            {
                ammo = 6;
                damage = 2;
                timeReload = 10;
            }
            else if (type == "shotgun")
            {
                ammo = 2;
                damage = 4;
                timeReload = 15;
            }
        }

        public Boolean TakenShot()
        {
            try
            {
                ammo -= 1;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Reload()
        {
            try
            {
                if (type == "handgun")
                {
                    ammo = 10;
                    damage = 1;
                    timeReload = 5;
                    return true;
                }
                else if (type == "rifle")
                {
                    ammo = 6;
                    damage = 2;
                    timeReload = 10;
                    return true;
                }
                else if (type == "shotgun")
                {
                    ammo = 2;
                    damage = 4;
                    timeReload = 15;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
