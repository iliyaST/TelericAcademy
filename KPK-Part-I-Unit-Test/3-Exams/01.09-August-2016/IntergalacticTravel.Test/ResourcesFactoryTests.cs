using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntergalacticTravel.Test
{
    [TestClass]
    public class ResourcesFactoryTests
    {
        [TestMethod]
        [DataRow("gold(20)", "silver(30)", "bronze(40)")]
        [DataRow("gold(20)", "bronze(40)", "silver(30)")]
        [DataRow("silver(30)", "bronze(40)", "gold(20)")]
        [DataRow("silver(30)", "gold(20)", "bronze(40)")]
        [DataRow("bronze(40)", "gold(20)", "silver(30)")]
        [DataRow("bronze(40)", "silver(30)", "gold(20)")]
        public void GetResources_ShouldReturnANewlyCreatedResourcesObject_WithCorrectlySetUpProperties
            (string firstProp, string secondProp, string thirdProp)
        {
            var factory = new ResourcesFactory();

            var getResources = factory.GetResources($"create resources {firstProp} {secondProp} {thirdProp}");

            Assert.IsInstanceOfType(getResources, typeof(Resources));
        }

        [TestMethod]
        [DataRow("absolutelyRandomStringThatMustNotBeAValidCommand")]
        [DataRow("create resources x y z")]
        [DataRow("tansta resources a b")]
        public void GetResources_ShouldThrowInvalidOperationException_WhichContainsTheStringCcommand_WhenTheInputStringRepresentsAnInvalidCommand(string command)
        {
            var factory = new ResourcesFactory();

            Assert.ThrowsException<InvalidOperationException>(
                () => factory.GetResources(command), "Invalid command");
        }

        [TestMethod]
        [DataRow("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [DataRow("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [DataRow("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_ShouldThrowOverflowException_WhenTheInputStringCommandIsInTheCorrectFormat_ButAnyOfTheValueThatRepresentTheResourceAmount_IsLargerThanUintMaxValue(string command)
        {
            var factory = new ResourcesFactory();

            Assert.ThrowsException<OverflowException>(
                () => factory.GetResources(command));
        }
    }
}
