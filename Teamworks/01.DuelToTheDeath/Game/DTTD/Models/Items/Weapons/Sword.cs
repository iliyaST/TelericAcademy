﻿using System;
using DTTD.Contracts;

namespace DTTD.Items.Weapons
{
    public class Sword 
    {
        private int attackPoints;

        public Sword(int attackPoints)
        {
            this.AttackPoints = attackPoints;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("AttackPoints can not be negative!");
                }

                this.attackPoints = value;
            }
        }
    }
}
