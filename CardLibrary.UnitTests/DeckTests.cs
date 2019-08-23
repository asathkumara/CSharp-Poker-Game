using System;
using System.Linq;
using NUnit.Framework;

namespace CardLibrary.UnitTests
{
    [TestFixture]
    class DeckTests
    {
        /// <summary>
        /// Retrieves a test deck. 
        /// </summary>
        /// <returns>Returns a card set.</returns>
        private Deck GetTestDeck()
        {
            return new Deck();
        }

        [Test]
        public void Deck_IsValid_ReturnsTrue()
        {
            Deck testDeck = GetTestDeck();
            int cardCount = 13;
            int totalClubCards = testDeck.Count(card => card.Suit == Suit.Club);
            int totalDiamondCards = testDeck.Count(card => card.Suit == Suit.Diamond);
            int totalHeartCards = testDeck.Count(card => card.Suit == Suit.Heart);
            int totalSpadeCards = testDeck.Count(card => card.Suit == Suit.Spade);

            bool isValidDeck = totalClubCards == cardCount && 
                          totalDiamondCards == cardCount && 
                          totalHeartCards == cardCount && 
                          totalSpadeCards == cardCount;

            Assert.That(isValidDeck);

        }

        [Test]
        public void Reset_CardsNotInplay_ReturnsTrue()
        {
            Deck testDeck = GetTestDeck();

            testDeck.Reset();

            bool isReset = true;

            for (int i = 0; i < testDeck.Size; i++)
            {
                if (testDeck[i].Inplay)
                {
                    isReset = false;
                    break;
                }
                
            }

            Assert.That(isReset);
        }

        [Test]
        public void GetCards_CardsInplay_ReturnsTrue()
        {
            Deck testdeck = GetTestDeck();

            Card[] testHand = testdeck.GetCards(5);

            bool isValidCard = true;

            foreach (Card card in testHand)
            {
                if (!card.Inplay)
                {
                    isValidCard = false;
                    break;
                }
            }
            
            Assert.That(isValidCard);
        }

    }
}
