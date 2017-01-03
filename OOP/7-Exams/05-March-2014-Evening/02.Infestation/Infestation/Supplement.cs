
namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Supplement : ISupplement
    {
        public Supplement(int powerEffect, int healthEffect, int agressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = agressionEffect;
        }

        public virtual int AggressionEffect { get; set; }

        public virtual int HealthEffect { get; set; }

        public virtual int PowerEffect { get; set; }


        public virtual void ReactTo(ISupplement otherSupplement)
        {

        }
    }
}
