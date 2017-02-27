using Cosmetics.Contracts;
using Cosmetics.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Products;
using Cosmetics.Common;

namespace Cosmetics.Test.CosmeticsEngineTest
{
    [TestClass]
    public class StartTest
    {
        [TestMethod]
        public void Start_ShouldRead_ParseAndExecute_CreateCategoryCommand_WhenThePassedInputStringIsInTheFormat_ThatRepresents_CreateCategoryCommand_whichShouldResultInAdding_TheNewCategory_InTheListOfCategories()
        {

            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCartMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();


            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("CreateCategory");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "ForMale" });

            var listOfCatgories = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfCatgories);


            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                factoryMocked.Object,
                shoppingCartMocked.Object,
                commandParserMocked.Object);


            cosmeticsEngine.Start();

            Assert.AreEqual(1, cosmeticsEngine.Categories.Count);
            Assert.IsTrue(cosmeticsEngine.Categories.ContainsKey("ForMale"));
        }

        [TestMethod]
        public void Start_ShouldReadParseAndExecute_AddToCategoryCommand_WhenThePassedInputStringIsInTheFormat_ThatRepresentsAAddToCategoryCommand_WhichShouldResultInAddingTheSelectedProductInTheRespectiveCategory()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCartMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();


            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("AddToCategory");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "ForMale", "White-" });

            var listOfCatgories = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfCatgories);


            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                factoryMocked.Object,
                shoppingCartMocked.Object,
                commandParserMocked.Object);

            var category = new Mock<ICategory>();
            cosmeticsEngine.Categories.Add("ForMale", category.Object);
            var product = new Mock<IProduct>();
            cosmeticsEngine.Products.Add("White-", product.Object);

            cosmeticsEngine.Start();

            category.Verify(m => m.AddProduct(It.IsAny<IProduct>()), Times.Once);
        }

        [TestMethod]
        public void Start_ShouldReadParseAndEecute_RemoveFromCategory_command_RemovingTheSelectedProduct_FromTheRespectiveCategory()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCartMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();


            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("RemoveFromCategory");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "ForMale", "White-" });

            var listOfCatgories = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfCatgories);


            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                factoryMocked.Object,
                shoppingCartMocked.Object,
                commandParserMocked.Object);

            var category = new Mock<ICategory>();
            cosmeticsEngine.Categories.Add("ForMale", category.Object);
            var product = new Mock<IProduct>();
            cosmeticsEngine.Products.Add("White-", product.Object);

            cosmeticsEngine.Start();

            category.Verify(m => m.RemoveProduct(It.IsAny<IProduct>()), Times.Once);
        }

        [TestMethod]
        public void Start_Should_ShowCategoryCommand_ShouldResulInCalling_ThePrintMethodOfTheRespectiveCateogry()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCartMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();


            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("ShowCategory");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "ForMale" });

            var listOfCatgories = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfCatgories);


            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                factoryMocked.Object,
                shoppingCartMocked.Object,
                commandParserMocked.Object);

            var category = new Mock<ICategory>();
            cosmeticsEngine.Categories.Add("ForMale", category.Object);

            cosmeticsEngine.Start();

            category.Verify(m => m.Print(), Times.Once);
        }

        [TestMethod]
        public void Start_ShouldCreateShampooCommand_WhichShouldResultInAddingTheNewlyCreatedShampoo_InTheListOfProducts()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCartMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("CreateShampoo");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "Cool", "Nivea", "0.50", "men", "500", "everyday" });

            var listOfCatgories = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfCatgories);


            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                factoryMocked.Object,
                shoppingCartMocked.Object,
                commandParserMocked.Object);

            cosmeticsEngine.Start();

            Assert.AreEqual(1, cosmeticsEngine.Products.Count);
            Assert.IsTrue(cosmeticsEngine.Products.ContainsKey("Cool"));
        }

        [TestMethod]
        public void Start_ShouldCreateToothpasteCommand_WhichShouldResultInAddingTheNewlyCreateToothpaste_InTheListOfProducts()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCartMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("CreateToothpaste");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "White +", "Colgate", "15.50", "men", "fluor,bqla,golqma" });

            var listOfCatgories = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfCatgories);


            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                factoryMocked.Object,
                shoppingCartMocked.Object,
                commandParserMocked.Object);

            cosmeticsEngine.Start();

            Assert.AreEqual(1, cosmeticsEngine.Products.Count);
            Assert.IsTrue(cosmeticsEngine.Products.ContainsKey("White +"));
        }

        [TestMethod]
        public void Start_ShouldExecute_AddToShoppingCart_WhichShouldResultInAdding_TheSelectedProduct_ToTheShoppingCart()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCartMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("AddToShoppingCart");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "White+" });

            var listOfCatgories = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfCatgories);


            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                factoryMocked.Object,
                shoppingCartMocked.Object,
                commandParserMocked.Object);

            var product = new Mock<IProduct>();
            cosmeticsEngine.Products.Add("White+", product.Object);

            cosmeticsEngine.Start();

            shoppingCartMocked.Verify(
                m => m.AddProduct(product.Object),Times.Once);
        }

        [TestMethod]
        public void Start_ShouldExecute_RemoveFromShoppingCart_WhichShouldResultInRemoving_TheSelectedProduct_FromTheShoppingCart()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCartMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();

            shoppingCartMocked.Setup
               (m => m.ContainsProduct(It.IsAny<IProduct>())).Returns(true);

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("RemoveFromShoppingCart");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "White+" });

            var listOfCatgories = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfCatgories);


            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                factoryMocked.Object,
                shoppingCartMocked.Object,
                commandParserMocked.Object);

            var product = new Mock<IProduct>();
            cosmeticsEngine.Products.Add("White+", product.Object);

            cosmeticsEngine.Start();

            shoppingCartMocked.Verify(
                m => m.RemoveProduct(product.Object), Times.Once);
        }
    }
}
