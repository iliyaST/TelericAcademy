
using System.Collections.Generic;
using System.Linq;

namespace Infestation
{
    public class Parasite : InfestUnit
    {
        const int ParasitePower = 1;
        const int ParasiteAggression = 1;
        const int ParasiteHealth = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, ParasiteHealth, ParasitePower, ParasiteAggression)
        {
        }
       
    }
}
