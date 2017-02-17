using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.SeasonTests
{
    [TestFixture]
    public class ListUsers_Should
    {

        [Test]
        public void IterateOverTheCollection_WhenTheCollectionIsNotEmpty()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.KidsAcademy);

            //var studentsMock = Create<Student>();
            //Arrange(() => studentsMock.ToString()).OccursOnce();

            //season.Students.Add(studentsMock);

            // Act
            var test = season.ListUsers();

            // Assert
           
        }

        [Test]
        public void IterateOverTheCollection_WhenTheCollectionIsNotEmpty_Moq()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.KidsAcademy);

            var studentsMock = new Mock<IStudent>();

            studentsMock.Setup(x=>x.ToString()).Returns("");

            season.Students.Add(studentsMock.Object);

            // Act
            var test = season.ListUsers();

            // Assert
            studentsMock.Verify(x => x.ToString(), Times.Exactly(1));
        }
    }
}
