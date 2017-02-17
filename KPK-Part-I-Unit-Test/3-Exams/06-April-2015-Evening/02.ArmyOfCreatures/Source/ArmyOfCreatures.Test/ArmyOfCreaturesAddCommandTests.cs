using ArmyOfCreatures.Console.Commands;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ArmyOfCreatures.Test
{
    [TestClass]
    public class ArmyOfCreaturesAddCommandTests
    {
        [TestMethod]
        public void Method_ShouldTwrowArgumentNullExeption_When_Null_Value_Is_Throwed()
        {
            var addCommand = new AddCommand();
            string[] arguments = new string[1];

            var exeption = Assert.ThrowsException<ArgumentNullException>
                (() => addCommand.ProcessCommand(null, arguments
                ));

            Assert.AreEqual(exeption.ParamName, "battleManager");
        }

        [TestMethod]
        public void Method_ShouldTwrowArgumentNullExeption_When_Null_Value_Is_Throwed_As_Array()
        {
            var addCommand = new AddCommand();
            var battleManagerMocked = new Mock<IBattleManager>();

            var exeption = Assert.ThrowsException<ArgumentNullException>
                (() => addCommand.ProcessCommand(battleManagerMocked.Object
                , null));

            Assert.AreEqual(exeption.ParamName, "arguments");
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void ProcessCommand_ShouldThrowArgumentException_WhenTheNumberOfParamsArguments_IsInvalid(int length)
        {
            var addCommand = new AddCommand();
            string[] arguments = new string[length];
            var battleMMocked = new Mock<IBattleManager>();

            var exeption = Assert.ThrowsException<ArgumentException>(
                () => addCommand.ProcessCommand(battleMMocked.Object,
                arguments));

            Assert.AreEqual(exeption.Message, 
                "Invalid number of arguments for add command");
        }

        [TestMethod]
        public void ProcessCommand_ShouldCallIBattleManagerAddCreaturesMethod_WhenTheCommandIsParsed_Successfully()
        {
            var addCommand = new AddCommand();
            var battleManagerMocked = new Mock<IBattleManager>();
            string[] arguments = { "10", "Angel(1)" };

            addCommand.ProcessCommand(battleManagerMocked.Object,
                arguments);

           battleManagerMocked
                .Verify(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(),
                It.IsAny<int>()), Times.Exactly(1));          
        }
    }
}
