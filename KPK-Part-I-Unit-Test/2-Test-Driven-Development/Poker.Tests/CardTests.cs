using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using Moq;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {

        /// <summary>
        /// Diamonds
        /// </summary>
        [TestMethod]
        public void TwoOfDiamonsToString()
        {
            //Asign
            var card = new Card(CardFace.Two, CardSuit.Diamonds);

            //Act
            var testOut = "Two of Diamonds";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }

        [TestMethod]
        [Ignore]
        public void TesMoq()
        {
            var mock = new Mock<ICard>();

            mock.Setup(c => c.Face);
            mock.Setup(c => c.Suit);

            var faceObj = mock.Object;

            string expected = "Eight of Clubs";
            var actual = faceObj.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSixOfDiamondsToString()
        {
            //Asign
            var card = new Card(CardFace.Six, CardSuit.Diamonds);
            
            //Act
            var testOut = "Six of Diamonds";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut,cardToString);
        }


        /// <summary>
        /// Spades
        /// </summary>
        [TestMethod]
        public void TestJackOfSpadesToString()
        {
            //Asign
            var card = new Card(CardFace.Jack, CardSuit.Spades);

            //Act
            var testOut = "Jack of Spades";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }

        [TestMethod]
        public void TestQueenOfSpadedsToString()
        {
            //Asign
            var card = new Card(CardFace.Queen, CardSuit.Spades);

            //Act
            var testOut = "Queen of Spades";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }

        /// <summary>
        /// Clubs
        /// </summary>
        [TestMethod]
        public void TestFiveOfClubsToString()
        {
            //Asign
            var card = new Card(CardFace.Five, CardSuit.Clubs);

            //Act
            var testOut = "Five of Clubs";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }

        [TestMethod]
        public void TestFourOfSpadesToString()
        {
            //Asign
            var card = new Card(CardFace.Four, CardSuit.Spades);

            //Act
            var testOut = "Four of Spades";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }


        /// <summary>
        /// Hearts
        /// </summary>
        [TestMethod]
        public void TestThreeOfHeartsToString()
        {
            //Asign
            var card = new Card(CardFace.Three, CardSuit.Hearts);

            //Act
            var testOut = "Three of Hearts";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }

        [TestMethod]
        public void TestKingOfHearts()
        {
            //Asign
            var card = new Card(CardFace.King, CardSuit.Hearts);

            //Act
            var testOut = "King of Hearts";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }

        [TestMethod]
        public void TestSevenOfHearts()
        {
            //Asign
            var card = new Card(CardFace.Seven, CardSuit.Hearts);

            //Act
            var testOut = "Seven of Hearts";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }

        [TestMethod]
        public void TestEightOfHeartsToString()
        {
            //Asign
            var card = new Card(CardFace.Eight, CardSuit.Hearts);

            //Act
            var testOut = "Eight of Hearts";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }

        [TestMethod]
        public void TestNineOfHeartsToString()
        {
            //Asign
            var card = new Card(CardFace.Nine, CardSuit.Hearts);

            //Act
            var testOut = "Nine of Hearts";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }

        [TestMethod]
        public void TestTenOfHeartsToString()
        {
            //Asign
            var card = new Card(CardFace.Ten, CardSuit.Hearts);

            //Act
            var testOut = "Ten of Hearts";
            var cardToString = card.ToString();

            //Assert
            Assert.AreEqual(testOut, cardToString);
        }

    }
}
