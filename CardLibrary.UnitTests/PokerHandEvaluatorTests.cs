using NUnit.Framework;


namespace CardLibrary.UnitTests
{
    [TestFixture]
    public class PokerHandEvaluatorTests
    {
        [Test]
        public void Flush_IsFlush_ReturnsTrue()
        {

            SuperCard[] testHand =
            {
                new CardClub(Rank.Deuce),
                new CardClub(Rank.Deuce),
                new CardClub(Rank.Deuce),
                new CardClub(Rank.Deuce),
                new CardClub(Rank.Deuce)
            };

            bool result = PokerHandEvaluator.Flush(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void Straight_IsStraight_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Deuce),
                new CardDiamond(Rank.Three),
                new CardSpade(Rank.Four),
                new CardHeart(Rank.Five),
                new CardClub(Rank.Six)
            };

            bool result = PokerHandEvaluator.Straight(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void StraightFlush_IsStraightFlush_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Deuce),
                new CardClub(Rank.Three),
                new CardClub(Rank.Four),
                new CardClub(Rank.Five),
                new CardClub(Rank.Six)
            };

            bool result = PokerHandEvaluator.StraightFlush(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void RoyalFlush_IsRoyalFlush_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ten),
                new CardClub(Rank.Jack),
                new CardClub(Rank.Queen),
                new CardClub(Rank.King),
                new CardClub(Rank.Ace)
            };

            bool result = PokerHandEvaluator.RoyalFlush(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void FullHouse_IsLowFullHouse_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.King),
                new CardSpade(Rank.King),
                new CardDiamond(Rank.King),
                new CardHeart(Rank.Three),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.FullHouse(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void FullHouse_IsHighFullHouse_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Three),
                new CardSpade(Rank.Three),
                new CardDiamond(Rank.King),
                new CardHeart(Rank.King),
                new CardClub(Rank.King)
            };

            bool result = PokerHandEvaluator.FullHouse(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void FourOfAKind_IsLowFourOfAKind_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ace),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Ace),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.FourOfAKind(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void FourOfAKind_IsHighFourOfAKind_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Three),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Ace),
                new CardClub(Rank.Ace)
            };

            bool result = PokerHandEvaluator.FourOfAKind(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void ThreeOfAKind_IsLowThreeOfAKind_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ace),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Deuce),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.ThreeOfAKind(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void ThreeOfAKind_IsMiddleThreeOfAKind_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Deuce),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Ace),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.ThreeOfAKind(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void ThreeOfAKind_IsHighThreeOfAKind_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Four),
                new CardSpade(Rank.Jack),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Ace),
                new CardClub(Rank.Ace)
            };

            bool result = PokerHandEvaluator.ThreeOfAKind(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void ThreeOfAKind_BetterThanThreeOfAKind_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ace),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Ace),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.ThreeOfAKind(testHand);

            Assert.That(result == false);

        }

        [Test]
        public void TwoPair_IsLowPair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ace),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Jack),
                new CardHeart(Rank.Jack),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.TwoPair(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void TwoPair_IsCornerPair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ace),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Jack),
                new CardHeart(Rank.Three),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.TwoPair(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void TwoPair_IsHighPair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Deuce),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Jack),
                new CardClub(Rank.Jack)
            };

            bool result = PokerHandEvaluator.TwoPair(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void TwoPair_BetterThanTwoPair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ace),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Jack),
                new CardHeart(Rank.Jack),
                new CardClub(Rank.Jack)
            };

            bool result = PokerHandEvaluator.TwoPair(testHand);

            Assert.That(result == false);

        }

        [Test]
        public void OnePair_IsLowPair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ace),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Five),
                new CardHeart(Rank.Jack),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.OnePair(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void OnePair_IsLowerMiddlePair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Eight),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Jack),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.OnePair(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void OnePair_IsHigherMiddlePair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Jack),
                new CardSpade(Rank.Queen),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Ace),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.OnePair(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void OnePair_IsHighPair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Jack),
                new CardSpade(Rank.Deuce),
                new CardDiamond(Rank.Six),
                new CardHeart(Rank.Ace),
                new CardClub(Rank.Ace)
            };

            bool result = PokerHandEvaluator.OnePair(testHand);

            Assert.That(result == true);

        }

        [Test]
        public void OnePair_BetterThanOnePair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Jack),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Jack),
                new CardClub(Rank.Three)
            };

            bool result = PokerHandEvaluator.OnePair(testHand);

            Assert.That(result == false);

        }

        [Test]
        public void EvaluatePokerHand_AssignsFlush_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Jack),
                new CardClub(Rank.Deuce),
                new CardClub(Rank.Three),
                new CardClub(Rank.Queen),
                new CardClub(Rank.Deuce)
            };

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.Flush);

        }

        [Test]
        public void EvaluatePokerHand_AssignsStraight_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Deuce),
                new CardDiamond(Rank.Three),
                new CardSpade(Rank.Four),
                new CardHeart(Rank.Five),
                new CardClub(Rank.Six)
            };

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.Straight);

        }

        [Test]
        public void EvaluatePokerHand_AssignsStraightFlush_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Deuce),
                new CardClub(Rank.Three),
                new CardClub(Rank.Four),
                new CardClub(Rank.Five),
                new CardClub(Rank.Six)
            };

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.StraightFlush);

        }

        [Test]
        public void EvaluatePokerHand_AssignsRoyalFlush_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ten),
                new CardClub(Rank.Jack),
                new CardClub(Rank.Queen),
                new CardClub(Rank.King),
                new CardClub(Rank.Ace)
            };

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.RoyalFlush);

        }

        [Test]
        public void EvaluatePokerHand_AssignsFullHouse_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.King),
                new CardSpade(Rank.King),
                new CardDiamond(Rank.King),
                new CardHeart(Rank.Three),
                new CardClub(Rank.Three)
            };

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.FullHouse);

        }

        [Test]
        public void EvaluatePokerHand_AssignsFourOfAKind_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Three),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Ace),
                new CardClub(Rank.Ace)
            };

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.FourOfAKind);

        }

        [Test]
        public void EvaluatePokerHand_AssignsThreeOfAKind_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ace),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Deuce),
                new CardClub(Rank.Three)
            };

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.ThreeOfAKind);

        }

        [Test]
        public void EvaluatePokerHand_AssignsTwoPair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Ace),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Jack),
                new CardHeart(Rank.Jack),
                new CardClub(Rank.Three)
            };

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.TwoPair);

        }

        [Test]
        public void EvaluatePokerHand_AssignsOnePair_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Jack),
                new CardSpade(Rank.Queen),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Ace),
                new CardClub(Rank.Three)
            };

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.OnePair);

        }

        [Test]
        public void EvaluatePokerHand_AssignsNotPokerHand_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Deuce),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Eight),
                new CardHeart(Rank.Five),
                new CardClub(Rank.Six)
            };

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.NotPokerHand);

        }

        [Test]
        public void EvaluateHandValue_ValidCalculation_ReturnsTrue()
        {
            SuperCard[] testHand =
            {
                new CardClub(Rank.Jack),
                new CardSpade(Rank.Ace),
                new CardDiamond(Rank.Ace),
                new CardHeart(Rank.Jack),
                new CardClub(Rank.Three)
            };

            int checkResult = 0;

            foreach (SuperCard card in testHand)
            {
                checkResult += (int)card.CardRank;
            }

            int result = PokerHandEvaluator.EvaluateHandValue(testHand);

            Assert.That(result == checkResult);

        }
    }
}
