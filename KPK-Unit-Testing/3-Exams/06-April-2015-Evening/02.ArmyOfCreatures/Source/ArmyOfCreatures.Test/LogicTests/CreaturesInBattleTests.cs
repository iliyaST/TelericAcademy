using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Test.LogicTests
{
    [TestClass]
    public class CreaturesInBattleTests
    {
        [TestMethod]
        public void DealDamage_WithNullDefender_ShouldThrowArgumentNullExeption()
        {
            var angel = new Angel();

            var creatures = new CreaturesInBattle(angel, 1);

            var exeptin = Assert.ThrowsException<ArgumentNullException>
                (() => creatures.DealDamage(null));

            Assert.AreEqual(exeptin.ParamName, "defender");    
        }

        [TestMethod]
        public void DealDamage_ShouldReturnExpectedResult()
        {
            var angel = new Angel();
            var defender = new Behemoth();

            var creatures = new CreaturesInBattle(angel, 1);
            var defenders = new CreaturesInBattle(defender, 1);

            creatures.DealDamage(defenders);

            Assert.AreEqual(defenders.TotalHitPoints, 103);
        }

        [TestMethod]
        public void Skip_ShouldCallApplyOnSkip_TheCountOfTheSpecultiesTimes()
        {
            var specialityMock = new Mock<Specialty>();
            var creatureStub = new Mock<Creature>(10, 10, 10, 20m);

            creatureStub
                .SetupGet(x => x.Specialties)
                .Returns(new List<Specialty> { specialityMock.Object });
            
            var sut = new CreaturesInBattle(creatureStub.Object, 1);

            sut.Skip();

            specialityMock.Verify(x => x.ApplyOnSkip(sut), Times.Once());
        }

        [TestMethod]
        public void ToString_ShouldOutput_CorrectResult()
        {
            var angel = new Angel();

            var creatures = new CreaturesInBattle(angel, 1);

            Assert.AreEqual(creatures.ToString(),
                "1 Angel (ATT:20; DEF:20; THP:200; LDMG:0)");
        }
    }
}
