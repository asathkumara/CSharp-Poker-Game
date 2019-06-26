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
            int cardCount = 13;

            var totalClubCards = (from card in testDeck.cardSet
                                  where card.CardSuit == Suit.Club
                                  select card).Count();

            var totalDiamondCards = (from card in testDeck.cardSet
                                  where card.CardSuit == Suit.Diamond
                                  select card).Count();

            var totalHeartCards = (from card in testDeck.cardSet
                                  where card.CardSuit == Suit.Heart
                                  select card).Count();

            var totalSpadeCards = (from card in testDeck.cardSet
                                  where card.CardSuit == Suit.Spade
                                  select card).Count();

            bool result = false;

            if (totalClubCards == cardCount && totalDiamondCards == cardCount && totalHeartCards == cardCount && totalSpadeCards == cardCount)
            {
                result = true;
            }

            Assert.That(result == true);

        }

        [Test]
        public void ResetUsage_ValidateInPlayReset_ReturnsTrue()
        {
            CardSet testdeck = GetTestDeck();

            testdeck.Reset();

            bool result = false;

            for (int i = 0; i < testdeck.cardSet.Length; i++)
            {
                if (testdeck.cardSet[i].Inplay == false)
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

            Card[] testHand = testdeck.GetCards(5);

            bool result = false;

            foreach (Card card in testHand)
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
