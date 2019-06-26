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
        /// <returns>Returns a card set.</returns>
        private CardSet GetTestDeck()
        {
            return new CardSet();
        }

        [Test]
        public void CardSet_ValidateDeck_ReturnsTrue()
        {
            CardSet testDeck = GetTestDeck();
            int cardCount = 13;

            int totalClubCards = (from card in testDeck.cardSet
                                  where card.CardSuit == Suit.Club
                                  select card).Count();

            int totalDiamondCards = (from card in testDeck.cardSet
                                  where card.CardSuit == Suit.Diamond
                                  select card).Count();

            int totalHeartCards = (from card in testDeck.cardSet
                                  where card.CardSuit == Suit.Heart
                                  select card).Count();

            int totalSpadeCards = (from card in testDeck.cardSet
                                  where card.CardSuit == Suit.Spade
                                  select card).Count();

            bool result = totalClubCards == cardCount && 
                          totalDiamondCards == cardCount && 
                          totalHeartCards == cardCount && 
                          totalSpadeCards == cardCount;

            Assert.That(result == true);

        }

        [Test]
        public void Reset_ValidateInPlayReset_ReturnsTrue()
        {
            CardSet testdeck = GetTestDeck();

            testdeck.Reset();

            bool result = false;

            for (int i = 0; i < testdeck.cardSet.Length; i++)
            {
                if (!testdeck.cardSet[i].Inplay)
                    result = true;
                
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
                if (card.Inplay)
                    result = true;
                
            }
            
            Assert.That(result = true);
        }

    }
}
