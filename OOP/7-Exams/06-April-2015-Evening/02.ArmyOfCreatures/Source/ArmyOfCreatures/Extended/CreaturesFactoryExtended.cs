
namespace ArmyOfCreatures.Extended
{
    using ArmyOfCreatures.Extended.Creatures;
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Creatures;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreaturesFactoryExtended : CreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            switch (name)
            {
                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "Griffin":
                    return new Griffin();
                case "Goblin":
                    return new Goblin();
                case "WolfRaider":
                    return new WolfRaider();
                case "CyclopsKing":
                    return new CyclopsKing();       
                default:
                     return base.CreateCreature(name);
            }
        }
    }
}
