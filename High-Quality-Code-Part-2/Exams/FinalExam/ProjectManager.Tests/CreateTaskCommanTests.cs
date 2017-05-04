using Moq;
using NUnit.Framework;
using Pesho.Core.Contracts;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Core.Commands;
using ProjectManager.CLI.Data.Contracts;
using System.Collections.Generic;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class CreateTaskCommanTests
    {
        [Test]
        public void Execute_ShouldThrow_WhenIvalidParametersCount_ArePassed()
        {
            var databaseMocked = new Mock<IDatabase>();
            var factoryMocked = new Mock<IModelsFactory>();
            var list = new List<string>() { "ag", "agsags", "agsgas", "asgasg", "asgasg" };

            var createCommand = new CreateTaskCommand(databaseMocked.Object,factoryMocked.Object);
            
            Assert.Throws<UserValidationException>(() => createCommand.Execute(list));
        }

        [Test]
        public void Execute_ShouldThrow_WhenEmptyParameters_ArePassed()
        {
            var databaseMocked = new Mock<IDatabase>();
            var factoryMocked = new Mock<IModelsFactory>();
            var createCommand = new CreateTaskCommand(databaseMocked.Object,factoryMocked.Object);
            var list = new List<string>() { "ag", "", "agsgas", "" };

            Assert.Throws<UserValidationException>(() => createCommand.Execute(list));
        }
        
        [Test]
        public void Execute_ShouldCall_TheProjectsPropertyIndexerOfTheDatabase_WithThePassedID()
        {

        }


        [Test]
        public void Execute_ShouldCall_UserPropertyIndexerOfTheDatabase_WithThePassedID()
        {

        }

        [Test]
        public void Execute_ShouldCeateTask_WithExactlyThoseParameters()
        {
            //var databaseMocked = new Mock<IDatabase>();
            //var factoryMocked = new Mock<IModelsFactory>();
            //var commandsFactory = new CommandsFactory(databaseMocked.Object,factoryMocked.Object);
            //var list = new List<string>() { "ag", "agsags", "agsgas", "asgasg", "asgasg" };           
        }

        [Test]
        public void Execute_AddsTheCreatedTask_ToTheProject()
        {

        }

        [Test]
        public void Execute_Returns_SuccessMessage_ContainingTheSubstring_SuccessfullyCreated()
        {

        }

    }
}
