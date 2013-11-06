﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            timeReload = 2;

            if (type == "handgun")
            {
                ammo = 10;
                damage = 1;
            }
            else if (type == "rifle")
            {
                ammo = 6;
                damage = 2;
            }
            else if (type == "shotgun")
            {
                ammo = 2;
                damage = 4;
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

        public Boolean needReload()
        {
            if (ammo <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean inReload()
        {
            if (ammo <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void reset()
        {
            if (type == "handgun")
            {
                ammo = 10;
            }
            else if (type == "rifle")
            {
                ammo = 6;
            }
            else if (type == "shotgun")
            {
                ammo = 2;
            }
        }

        public void Reload()
        {
            Timer tmrReload = new Timer();
            tmrReload.Interval = timeReload * 1000;
            tmrReload.Enabled = true;
            tmrReload.Tick += new EventHandler(tmrReload_Tick);
        }

        void tmrReload_Tick(object sender, EventArgs e)
        {
            reset();
            Timer tmrReload = (Timer)sender;
            tmrReload.Stop();
        }

        public int getDamage()
        {
            return damage;
        }

        public int getAmmo()
        {
            return ammo;
        }

        public int getInitialAmmo()
        {
            if (type == "handgun")
            {
                return 10;
            }
            else if (type == "rifle")
            {
                return 6;
            }
            else if (type == "shotgun")
            {
                return 2;
            }
            return 0;
        }

        public int getTimeReload()
        {
            return timeReload;
        }
    }
}