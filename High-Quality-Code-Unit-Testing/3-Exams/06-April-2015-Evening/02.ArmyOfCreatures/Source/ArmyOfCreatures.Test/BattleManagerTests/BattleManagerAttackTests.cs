using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Test
{
    [TestClass]
    public class BattleManagerAttackTests
    {
        [TestMethod]
        public void Attacking_WithNullIdentifier_ShouldThwrow_ArgumentNullExeption()
        {
            var creaturesFactMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManager(creaturesFactMocked.Object,
                loggerMocked.Object);

            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(
                "Angel(1)");

            var exeption = Assert.ThrowsException<ArgumentNullException>(
                () => battleManager.Attack(null, creatureIdentifier));

            Assert.AreEqual(exeption.ParamName,
                "identifier");
        }

        [TestMethod]
        public void Attack_WithNullUnit_ShouldThrowArgumentNullExeption()
        {
            var creaturesFactMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManager(creaturesFactMocked.Object,
                loggerMocked.Object);

            var creatureIdentifierAttacker = CreatureIdentifier.CreatureIdentifierFromString("Pesho(1)");
            var creatureIdentifierDeffender = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            var exeption = Assert.ThrowsException<ArgumentException>(
                () => battleManager.Attack(creatureIdentifierAttacker,
                creatureIdentifierDeffender));

            Assert.AreEqual(exeption.Message,
               "Attacker not found: Pesho(1)");
        }

        [TestMethod]
        public void AttackingSuccsesfull_ShouldCall4TimesWriteLine_FromLogger()
        {
            var creaturesFactMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            creaturesFactMocked.Setup(
                m => m.CreateCreature("Devil")).
                Returns(new Devil());

            creaturesFactMocked.Setup(
                m => m.CreateCreature("Angel")).Returns(new Angel());

            loggerMocked.Setup(x => x.WriteLine(It.IsAny<string>()))
               ;

            var battleManager = new BattleManager(creaturesFactMocked.Object,
                loggerMocked.Object);

            var creatureIdentifierAttacker = CreatureIdentifier.CreatureIdentifierFromString("Devil(1)");
            var creatureIdentifierDeffender = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");

            battleManager.AddCreatures(creatureIdentifierAttacker, 2);
            battleManager.AddCreatures(creatureIdentifierDeffender, 1);

            battleManager.Attack(creatureIdentifierAttacker, creatureIdentifierDeffender);

            loggerMocked.Verify(
                m => m.WriteLine
                (It.Is<string>(str => !str.Contains(
                    "Creature added to army"))), Times.Exactly(4));
        }

        /*Method DealDamage can be changed so better not to test 
        that this (perhaps maybe test the DealDamage() method in
        CreaturesInBattle class*/

        //[TestMethod]
        //public void Attacking_WithTwoBehemoths_ShouldReturnTheRightResult()
        //{
        //    var creaturesFactMocked = new Mock<ICreaturesFactory>();
        //    var loggerMocked = new Mock<ILogger>();

        //    creaturesFactMocked.Setup(
        //        m => m.CreateCreature("Behemoth")).
        //        Returns(new Behemoth());

        //    var battleManager = new BattleManager(creaturesFactMocked.Object,
        //        loggerMocked.Object);

        //    var creatureIdentifierAttacker = CreatureIdentifier.CreatureIdentifierFromString("Behemoth(1)");
        //    var creatureIdentifierDeffender = CreatureIdentifier.CreatureIdentifierFromString("Behemoth(2)");

        //    battleManager.AddCreatures(creatureIdentifierAttacker, 2);
        //    battleManager.AddCreatures(creatureIdentifierDeffender, 1);

        //    battleManager.Attack(creatureIdentifierAttacker, creatureIdentifierDeffender);
        //}
    }
}
