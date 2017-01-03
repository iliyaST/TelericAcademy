
namespace Infestation
{
    public class HoldingPenWithSupplements : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            var unitType = commandWords[1];
            var unitId = commandWords[2];

            Unit unitToBeAdded = null;

            switch (unitType)
            {
                case "Tank":
                    unitToBeAdded = new Tank(unitId);
                    break;
                case "Marine":
                    unitToBeAdded = new Marine(unitId);
                    break;
                case "Parasite":
                    unitToBeAdded = new Parasite(unitId);
                    break;
                case "Queen":
                    unitToBeAdded = new Queen(unitId);
                    break;

                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }

            if (unitToBeAdded != null)
            {
                InsertUnit(unitToBeAdded);
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var supplementType = commandWords[1];
            ISupplement supplement = null;

            switch (supplementType)
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
            }

            var unitId = commandWords[2];
            var unit = this.GetUnit(unitId);

            if (unit != null)
            {
                unit.AddSupplement(supplement);
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            if (interaction.InteractionType == InteractionType.Infest)
            {
                var unit = this.GetUnit(interaction.TargetUnit.Id);
                unit.AddSupplement(new InfestationSpores());
            }
            else
            {
                base.ProcessSingleInteraction(interaction);
            }
        }
    }
}
