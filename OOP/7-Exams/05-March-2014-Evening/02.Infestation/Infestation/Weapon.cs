
namespace Infestation
{
    public class Weapon : Supplement
    {
        private bool hasEffect = false;

        public Weapon()
            : base(10, 0, 3)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponarySkill)
            {
                this.hasEffect = true;
            }
        }
    }
}
