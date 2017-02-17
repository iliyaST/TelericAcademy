using System;
using ArmyOfCreatures.Logic.Specialties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ArmyOfCreatures.Logic.Battles;
using System.Text;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Test
{
    [TestClass]
    public class ArmyOfCreaturesSpecialtiesDoubleDefenseWhenDefendingTests
    {
        [TestMethod]
        public void ApplyWhenDefending_ShouldThrowArgumentNullException_WhenTheICreaturesInBattleDefenderWithSpecialty_IsNull()
        {
            var doubleDef = new DoubleDefenseWhenDefending(5);
            var deffenderSpecialty = new Mock<ICreaturesInBattle>();

            var exeption = Assert.ThrowsException<ArgumentNullException>(
                () => doubleDef.ApplyWhenDefending(
                    null, deffenderSpecialty.Object));

            Assert.AreEqual(exeption.ParamName, "defenderWithSpecialty");
        }

        [TestMethod]
        public void ApplyWhenDefending_ShouldThrowArgumentNullException_WhenTheICreaturesInBattleAttacker_IsNull()
        {
            var doubleDef = new DoubleDefenseWhenDefending(5);
            var attacker = new Mock<ICreaturesInBattle>();

            var exeption = Assert.ThrowsException<ArgumentNullException>(
                () => doubleDef.ApplyWhenDefending(
                    attacker.Object, null));

            Assert.AreEqual(exeption.ParamName, "attacker");
        }

        [TestMethod]
        public void ApplyWhenDefending_ShouldReturnAndNotChangeTheCurrentDefensePropertyOfDefenderWithSpecialty_WhenTheEffectIsExpired()
        {       
            var doubleDef = new DoubleDefenseWhenDefending(1);
            var attacker = new Mock<ICreaturesInBattle>().Object;
            var angel = new Angel();
            var deffenderSpecialty = new CreaturesInBattle(angel, 4);

            doubleDef.ApplyWhenDefending(deffenderSpecialty, attacker);

            Assert.AreEqual(deffenderSpecialty.PermanentDefense*2,
                deffenderSpecialty.CurrentDefense);
        }
    }
}
