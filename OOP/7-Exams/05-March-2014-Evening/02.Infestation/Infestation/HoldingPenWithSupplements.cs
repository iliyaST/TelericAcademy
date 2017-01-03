
namespace Infestation
{
    public class HoldingPenWithSupplements : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var supplementType = commandWords[0];
            ISupplement supplement;

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
        }
    }
}
