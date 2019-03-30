using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace CardLibrary.UnitTests
{

    [TestFixture]
    public class PokerHandEvaluatorTests
    {
        /// <summary>
        /// Retrieves a test hand based on the poker hand type.
        /// </summary>
        /// <param name="pPokerHand">The type of poker hand.</param>
        /// <returns>A SuperCard array that is initialized with cards matching the poker hand conditions.</returns>
        static IEnumerable<SuperCard[]> GetTestHand(PokerHand pPokerHand)
        {
            if (pPokerHand == PokerHand.Flush)
            {
                yield return new SuperCard[]
                {
                    new CardClub(Rank.Deuce),
                    new CardClub(Rank.Jack),
                    new CardClub(Rank.Ten),
                    new CardClub(Rank.Three),
                    new CardClub(Rank.Nine)
                };

                yield return new SuperCard[]
                {
                    new CardDiamond(Rank.Ace),
                    new CardDiamond(Rank.Three),
                    new CardDiamond(Rank.Four),
                    new CardDiamond(Rank.Five),
                    new CardDiamond(Rank.Six)
                };

                yield return new SuperCard[]
                {
                    new CardSpade(Rank.Ace),
                    new CardSpade(Rank.Three),
                    new CardSpade(Rank.Four),
                    new CardSpade(Rank.Five),
                    new CardSpade(Rank.Six)
                };

                yield return new SuperCard[]
                {
                    new CardHeart(Rank.Ace),
                    new CardHeart(Rank.Three),
                    new CardHeart(Rank.Four),
                    new CardHeart(Rank.Five),
                    new CardHeart(Rank.Six)
                };
            }

            if (pPokerHand == PokerHand.Straight)
            {
                yield return new SuperCard[]
                {
                    new CardClub(Rank.Deuce),
                    new CardDiamond(Rank.Three),
                    new CardSpade(Rank.Four),
                    new CardHeart(Rank.Five),
                    new CardClub(Rank.Six)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Three),
                    new CardDiamond(Rank.Four),
                    new CardSpade(Rank.Five),
                    new CardHeart(Rank.Six),
                    new CardClub(Rank.Seven)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Four),
                    new CardDiamond(Rank.Five),
                    new CardSpade(Rank.Six),
                    new CardHeart(Rank.Seven),
                    new CardClub(Rank.Eight)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Five),
                    new CardDiamond(Rank.Six),
                    new CardSpade(Rank.Seven),
                    new CardHeart(Rank.Eight),
                    new CardClub(Rank.Nine)
                };
            }

            if (pPokerHand == PokerHand.StraightFlush)
            {
                yield return new SuperCard[]
                {
                    new CardClub(Rank.Deuce),
                    new CardClub(Rank.Three),
                    new CardClub(Rank.Four),
                    new CardClub(Rank.Five),
                    new CardClub(Rank.Six)
                };

                yield return new SuperCard[]
                {
                    new CardDiamond(Rank.Three),
                    new CardDiamond(Rank.Four),
                    new CardDiamond(Rank.Five),
                    new CardDiamond(Rank.Six),
                    new CardDiamond(Rank.Seven)
                };

                yield return new SuperCard[]
                {
                    new CardSpade(Rank.Four),
                    new CardSpade(Rank.Five),
                    new CardSpade(Rank.Six),
                    new CardSpade(Rank.Seven),
                    new CardSpade(Rank.Eight)
                };

                yield return new SuperCard[]
                {
                    new CardHeart(Rank.Five),
                    new CardHeart(Rank.Six),
                    new CardHeart(Rank.Seven),
                    new CardHeart(Rank.Eight),
                    new CardHeart(Rank.Nine)
                };
            }

            if (pPokerHand == PokerHand.RoyalFlush)
            {
                yield return new SuperCard[]
                {
                    new CardClub(Rank.Ten),
                    new CardClub(Rank.Jack),
                    new CardClub(Rank.Queen),
                    new CardClub(Rank.King),
                    new CardClub(Rank.Ace)
                };

                yield return new SuperCard[]
                {
                    new CardDiamond(Rank.Ten),
                    new CardDiamond(Rank.Jack),
                    new CardDiamond(Rank.Queen),
                    new CardDiamond(Rank.King),
                    new CardDiamond(Rank.Ace)
                };

                yield return new SuperCard[]
                {
                    new CardHeart(Rank.Ten),
                    new CardHeart(Rank.Jack),
                    new CardHeart(Rank.Queen),
                    new CardHeart(Rank.King),
                    new CardHeart(Rank.Ace)
                };

                yield return new SuperCard[]
                {
                    new CardSpade(Rank.Ten),
                    new CardSpade(Rank.Jack),
                    new CardSpade(Rank.Queen),
                    new CardSpade(Rank.King),
                    new CardSpade(Rank.Ace)
                };
            }

            if (pPokerHand == PokerHand.FullHouse)
            {
                yield return new SuperCard[]
                {
                    new CardClub(Rank.King),
                    new CardSpade(Rank.King),
                    new CardDiamond(Rank.King),
                    new CardHeart(Rank.Three),
                    new CardClub(Rank.Three)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Deuce),
                    new CardSpade(Rank.Deuce),
                    new CardDiamond(Rank.Deuce),
                    new CardHeart(Rank.Ace),
                    new CardClub(Rank.Ace)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Four),
                    new CardSpade(Rank.Four),
                    new CardDiamond(Rank.Ten),
                    new CardHeart(Rank.Ten),
                    new CardClub(Rank.Ten)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Five),
                    new CardSpade(Rank.Five),
                    new CardDiamond(Rank.Seven),
                    new CardHeart(Rank.Seven),
                    new CardClub(Rank.Seven)
                };
            }

            if (pPokerHand == PokerHand.FourOfAKind)
            {
                yield return new SuperCard[]
                {
                    new CardClub(Rank.Ace),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Ace),
                    new CardHeart(Rank.Ace),
                    new CardClub(Rank.Three)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Jack),
                    new CardSpade(Rank.Jack),
                    new CardDiamond(Rank.Jack),
                    new CardHeart(Rank.Jack),
                    new CardClub(Rank.Deuce)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Five),
                    new CardSpade(Rank.Ten),
                    new CardDiamond(Rank.Ten),
                    new CardHeart(Rank.Ten),
                    new CardClub(Rank.Ten)
                };

                yield return new SuperCard[]
               {
                    new CardClub(Rank.King),
                    new CardSpade(Rank.Queen),
                    new CardDiamond(Rank.Queen),
                    new CardHeart(Rank.Queen),
                    new CardClub(Rank.Queen)
               };
            }

            if (pPokerHand == PokerHand.ThreeOfAKind)
            {
                yield return new SuperCard[]
                {          
                    new CardClub(Rank.Ace),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Ace),
                    new CardHeart(Rank.Deuce),
                    new CardClub(Rank.Three)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Five),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Ace),
                    new CardHeart(Rank.Ace),
                    new CardClub(Rank.Jack)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Five),
                    new CardSpade(Rank.Ten),
                    new CardDiamond(Rank.Ace),
                    new CardHeart(Rank.Ace),
                    new CardClub(Rank.Ace)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Ace),
                    new CardSpade(Rank.Queen),
                    new CardDiamond(Rank.King),
                    new CardHeart(Rank.Ace),
                    new CardClub(Rank.Ace)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Ace),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Eight),
                    new CardHeart(Rank.Nine),
                    new CardClub(Rank.Ace)
                };
            }

            if (pPokerHand == PokerHand.TwoPair)
            {
                yield return new SuperCard[]
                {
                    new CardClub(Rank.Ace),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Three),
                    new CardHeart(Rank.Three),
                    new CardClub(Rank.Eight)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Nine),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Ace),
                    new CardHeart(Rank.Five),
                    new CardClub(Rank.Five)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Ace),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Queen),
                    new CardHeart(Rank.King),
                    new CardClub(Rank.King)
                };
            }

            if (pPokerHand == PokerHand.OnePair)
            {
                yield return new SuperCard[]
                {
                    new CardClub(Rank.Ace),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Five),
                    new CardHeart(Rank.Jack),
                    new CardClub(Rank.Three)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Five),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Ace),
                    new CardHeart(Rank.Jack),
                    new CardClub(Rank.Three)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Five),
                    new CardSpade(Rank.Six),
                    new CardDiamond(Rank.Ace),
                    new CardHeart(Rank.Ace),
                    new CardClub(Rank.Three)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Five),
                    new CardSpade(Rank.Deuce),
                    new CardDiamond(Rank.Three),
                    new CardHeart(Rank.Ace),
                    new CardClub(Rank.Ace)
                };
            }

            if (pPokerHand == PokerHand.NotPokerHand)
            {
                yield return new SuperCard[]
                {
                    new CardClub(Rank.Deuce),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Eight),
                    new CardHeart(Rank.Five),
                    new CardClub(Rank.Six)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Three),
                    new CardSpade(Rank.Eight),
                    new CardDiamond(Rank.Ace),
                    new CardHeart(Rank.Five),
                    new CardClub(Rank.Six)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Deuce),
                    new CardSpade(Rank.Ace),
                    new CardDiamond(Rank.Jack),
                    new CardHeart(Rank.Five),
                    new CardClub(Rank.Six)
                };

                yield return new SuperCard[]
                {
                    new CardClub(Rank.Deuce),
                    new CardSpade(Rank.Queen),
                    new CardDiamond(Rank.Jack),
                    new CardHeart(Rank.King),
                    new CardClub(Rank.Four)
                };
            }
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Flush })]
        public void Flush_IsFlush_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.Flush(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Straight })]
        public void Straight_IsStraight_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.Straight(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.StraightFlush })]
        public void StraightFlush_IsStraightFlush_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.StraightFlush(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.RoyalFlush })]
        public void RoyalFlush_IsRoyalFlush_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.RoyalFlush(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FullHouse })]
        public void FullHouse_IsFullHouse_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.FullHouse(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void FourOfAKind_IsFourOfAKind_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.FourOfAKind(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void ThreeOfAKind_IsThreeOfAKind_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.ThreeOfAKind(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void ThreeOfAKind_IsBetterThan_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.ThreeOfAKind(pTestHand);
            Assert.That(result == false);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void TwoPair_IsTwoPair_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.TwoPair(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void TwoPair_IsBetterThan_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.TwoPair(pTestHand);
            Assert.That(result == false);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.OnePair })]
        public void OnePair_IsOnePair_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.OnePair(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void OnePair_IsBetterThan_ReturnsTrue(SuperCard[] pTestHand)
        {
            bool result = PokerHandEvaluator.OnePair(pTestHand);
            Assert.That(result == false);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Flush })]
        public void EvaluatePokerHand_AssignsFlush_ReturnsTrue(SuperCard[] pTesthand)
        {
            
            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.Flush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Straight })]
        public void EvaluatePokerHand_AssignsStraight_ReturnsTrue(SuperCard[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.Straight);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.StraightFlush })]
        public void EvaluatePokerHand_AssignsStraightFlush_ReturnsTrue(SuperCard[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.StraightFlush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.RoyalFlush })]
        public void EvaluatePokerHand_AssignsRoyalFlush_ReturnsTrue(SuperCard[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.RoyalFlush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FullHouse })]
        public void EvaluatePokerHand_AssignsFullHouse_ReturnsTrue(SuperCard[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.FullHouse);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void EvaluatePokerHand_AssignsFourOfAKind_ReturnsTrue(SuperCard[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.FourOfAKind);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void EvaluatePokerHand_AssignsThreeOfAKind_ReturnsTrue(SuperCard[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.ThreeOfAKind);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void EvaluatePokerHand_AssignsTwoPair_ReturnsTrue(SuperCard[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.TwoPair);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.OnePair })]
        public void EvaluatePokerHand_AssignsOnePair_ReturnsTrue(SuperCard[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.OnePair);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.NotPokerHand })]
        public void EvaluatePokerHand_AssignsNotPokerHand_ReturnsTrue(SuperCard[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.NotPokerHand);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.NotPokerHand })]
        public void EvaluateHandValue_ValidCalculation_ReturnsTrue(SuperCard[] pTestHand)
        {
            int checkResult = 0;

            foreach (SuperCard card in pTestHand)
            {
                checkResult += (int)card.CardRank;
            }

            int result = PokerHandEvaluator.EvaluateHandValue(pTestHand);

            Assert.That(result == checkResult);

        }
    }
}
