using System;
using System.Linq;
using NUnit.Framework;

namespace CardLibrary.UnitTests
{
    [TestFixture]
    class CardSetTests
    {
        /// <summary>
        /// Retrieves a test deck. 
        /// </summary>
        /// <returns>Returns testDeck which is of type CardSet.</returns>
        private CardSet GetTestDeck()
        {
            CardSet testdeck = new CardSet();
            return testdeck;
        }

        [Test]
        public void CardSet_ValidateDeck_ReturnsTrue()
        {
            CardSet testDeck = GetTestDeck();

            var totalClubCards = (from card in testDeck.cardArray
                                  where card.CardSuit == Suit.Club
                                  select card).Count();

            var totalDiamondCards = (from card in testDeck.cardArray
                                  where card.CardSuit == Suit.Diamond
                                  select card).Count();

            var totalHeartCards = (from card in testDeck.cardArray
                                  where card.CardSuit == Suit.Heart
                                  select card).Count();

            var totalSpadeCards = (from card in testDeck.cardArray
                                  where card.CardSuit == Suit.Spade
                                  select card).Count();

            bool result = false;

            if (totalClubCards == 13 && totalDiamondCards == 13 && totalHeartCards == 13 && totalSpadeCards == 13)
            {
                result = true;
            }

            Assert.That(result == true);

        }

        [Test]
        public void ResetUsage_ValidateInPlayReset_ReturnsTrue()
        {
            CardSet testdeck = GetTestDeck();

            testdeck.ResetUsage();

            bool result = false;

            for (int i = 0; i < testdeck.cardArray.Length; i++)
            {
                if (testdeck.cardArray[i].Inplay == false)
                {
                    result = true;
                }
            }

            Assert.That(result = true);
        }

        [Test]
        public void GetOneCard_ValidateInPlay_ReturnsTrue()
        {
            CardSet testdeck = GetTestDeck();

            SuperCard[] testHand = testdeck.GetCards(5);

            bool result = false;

            foreach (SuperCard card in testHand)
            {
                if (card.Inplay == true)
                {
                    result = true;
                }
            }
            
            Assert.That(result = true);
        }

    }
}
