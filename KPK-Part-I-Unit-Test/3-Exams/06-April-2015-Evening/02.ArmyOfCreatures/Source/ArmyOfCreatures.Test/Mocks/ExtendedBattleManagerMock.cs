using ArmyOfCreatures.Extended;
using ArmyOfCreatures.Logic.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic;

namespace ArmyOfCreatures.Test.Mocks
{
    public class ExtendedBattleManagerMock : BattleManager
    {
        private CreatureIdentifier creatureIdentifier;
        private ICollection<ICreaturesInBattle> firstArmy;

        public ExtendedBattleManagerMock(ICreaturesFactory creaturesFactory, ILogger logger)
            : base(creaturesFactory, logger)
        {
            this.firstArmy = base.firstArmyCreatures;
        }

        public ICollection<ICreaturesInBattle> FirstArmyCreatures
        {
            get
            {
                return this.firstArmy;
            }
        }

        public CreatureIdentifier GetCreatureIdentifier
        {
            get
            {
                return this.creatureIdentifier;
            }
            set
            {
                this.creatureIdentifier = value;
            }
        }

        public ICreaturesInBattle GetCreature()
        {
            return this.secondArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == GetCreatureIdentifier.CreatureType);
        }
    }
}
