
using Infestation;

namespace Infestation
{
    public class HoldingPenExtended : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            Unit unitToBeAdded = null;

            switch (commandWords[1])
            {
                case "Marine":
                     unitToBeAdded = new Marine(commandWords[2]);
                    break;
                case "Parasite":
                     unitToBeAdded = new Parasite(commandWords[2]);
                    break;
                case "Queen":
                     unitToBeAdded = new Queen(commandWords[2]);
                    break;
                case "Tank":
                     unitToBeAdded = new Tank(commandWords[2]);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }

            if (unitToBeAdded != null)
            {
                this.InsertUnit(unitToBeAdded); 
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var supplementTargetName = commandWords[2];
            var targetUnit = this.GetUnit(supplementTargetName);
            ISupplement supplement = null;

            switch (commandWords[1])
            {
                case "AggressionCatalyst":
                    supplement = new AggressionCatalyst();
                    break;
                case "PowerCatalyst":
                    supplement = new PowerCatalyst();
                    break;
                case "HealthCatalyst":
                    supplement = new HealthCatalyst();
                    break;
                case "Weapon":
                    supplement = new Weapon();
                    break;
                default:
                    base.ExecuteAddSupplementCommand(commandWords);
                    break;                    
            }

            

            if (targetUnit != null)
            {
                targetUnit.AddSupplement(supplement);
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }         
        }

    }
}
