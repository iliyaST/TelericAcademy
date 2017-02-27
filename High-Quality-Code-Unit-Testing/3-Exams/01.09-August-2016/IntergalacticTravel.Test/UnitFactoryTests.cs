using System;
using IntergalacticTravel;
using IntergalacticTravel.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel.Test
{
    [TestClass]
    public class UnitFactoryTests
    {       
        [TestMethod]
        public void GetUnit_ShouldReturnNewProcyonUnit_WhenAValidCorrespondingCommandIsPassed_Procyon()
        {
            //Asign
            var factory = new UnitsFactory();

            //Act
            var unit = factory.GetUnit("create unit Procyon Gosho 1");

            //Assert
            Assert.IsInstanceOfType(unit, typeof(Procyon));
        }

        [TestMethod]
        public void GetUnit_ShouldReturnNewProcyonUnit_WhenAValidCorrespondingCommandIsPassed_Luyten()
        {
            //Asign
            var factory = new UnitsFactory();

            //Act
            var unit = factory.GetUnit("create unit Luyten Pesho 1");

            //Assert
            Assert.IsInstanceOfType(unit, typeof(Luyten));
        }

        [TestMethod]
        public void GetUnit_ShouldReturnNewProcyonUnit_WhenAValidCorrespondingCommandIsPassed_Lacaille()
        {
            //Asign
            var factory = new UnitsFactory();

            //Act
            var unit = factory.GetUnit("create unit Lacaille Tosho 1");

            //Assert
            Assert.IsInstanceOfType(unit, typeof(Lacaille));
        }

        [TestMethod]        
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenTheCommandPassed_IsNotInTheValidFormatDescribed()
        {
            //Asign
            var factory = new UnitsFactory();

            //Assert 
            Assert.ThrowsException<InvalidUnitCreationCommandException>
                (() => factory.GetUnit("create unit lepricon pesho 1"));
        }

    }
}
