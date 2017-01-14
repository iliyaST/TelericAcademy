using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private bool hasEffect = true;

        public InfestationSpores()
            : base(0, -1, 20)
        {
        }

        public override int AggressionEffect
        {
            get
            {
                if (hasEffect)
                {
                    return base.AggressionEffect;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override int PowerEffect
        {
            get
            {
                if (!hasEffect)
                {
                    return 0;
                }
                else
                {
                    return base.PowerEffect;
                }
            }
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                hasEffect = false;
            }
        }
    }
}
