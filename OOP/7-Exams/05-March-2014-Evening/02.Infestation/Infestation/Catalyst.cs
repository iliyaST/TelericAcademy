
using System;

namespace Infestation
{
    public abstract class Catalyst : Supplement
    {
        public Catalyst(int health, int power, int agression) 
            : base(health, power, agression)
        {
        }
    }
}
