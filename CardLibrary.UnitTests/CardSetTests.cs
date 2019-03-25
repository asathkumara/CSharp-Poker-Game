using System.Linq;
using NUnit.Framework;

namespace CardLibrary.UnitTests
{
    [TestFixture]
    class CardSetTests
    {
        [Test]
        public void CardSet_ValidateDeck_ReturnsTrue()
        {
            SuperCard[] testDeck = new SuperCard[52];

            int i = 0;

            for (Rank r = Rank.Deuce; r <= Rank.Ace; r++)
            {

                testDeck[i++] = new CardClub(r);

                testDeck[i++] = new CardDiamond(r);

                testDeck[i++] = new CardHeart(r);

                testDeck[i++] = new CardSpade(r);
            }

            var totalClubCards = (from card in testDeck
                                  where card.CardSuit == Suit.Club
                                  select card).Count();

            var totalDiamondCards = (from card in testDeck
                                  where card.CardSuit == Suit.Diamond
                                  select card).Count();

            var totalHeartCards = (from card in testDeck
                                  where card.CardSuit == Suit.Heart
                                  select card).Count();

            var totalSpadeCards = (from card in testDeck
                                  where card.CardSuit == Suit.Spade
                                  select card).Count();

            bool result = false;

            if (totalClubCards == 13 && totalDiamondCards == 13 && totalHeartCards == 13 && totalSpadeCards == 13)
            {
                result = true;
            }

            Assert.That(result == true);

        }

    }
}
