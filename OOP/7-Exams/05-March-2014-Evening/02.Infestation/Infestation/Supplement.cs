
namespace Infestation
{
    using System;

    public class Supplement : ISupplement
    {
        public Supplement(int health, int power, int agression)
        {
            this.HealthEffect = health;
            this.PowerEffect = power;
            this.AggressionEffect = agression;
        }

        public virtual int AggressionEffect { get; }

        public virtual int HealthEffect { get; }

        public virtual int PowerEffect { get; }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
            
        }
    }
}
