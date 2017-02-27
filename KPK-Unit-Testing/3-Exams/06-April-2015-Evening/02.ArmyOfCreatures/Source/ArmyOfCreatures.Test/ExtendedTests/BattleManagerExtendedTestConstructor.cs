using ArmyOfCreatures.Extended;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ArmyOfCreatures.Test
{
    [TestClass]
    public class BattleManagerExtendedTestConstructor
    {
        [TestMethod]
        public void Constructor_ShouldCallBaseConstructor_AndInstantiateTheObjectWithAllPropertiesSetUp()
        {
            var mockedfact = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new ExtendedBattleManagerMock(mockedfact.Object, mockedLogger.Object);

            Assert.AreEqual(0, battleManager.FirstArmyCreatures.Count);
        }
    }
}
