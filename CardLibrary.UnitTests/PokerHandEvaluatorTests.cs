﻿using NUnit.Framework;
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
        static IEnumerable<Card[]> GetTestHand(PokerHand pPokerHand)
        {
            if (pPokerHand == PokerHand.Flush)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Club, Rank.Nine)
                };

                yield return new Card[]
                {
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Diamond, Rank.Four),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Diamond, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Spade, Rank.Three),
                    new Card(Suit.Spade, Rank.Four),
                    new Card(Suit.Spade, Rank.Five),
                    new Card(Suit.Spade, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Heart, Rank.Three),
                    new Card(Suit.Heart, Rank.Four),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Heart, Rank.Six)
                };
            }

            if (pPokerHand == PokerHand.Straight)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Spade, Rank.Four),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Diamond, Rank.Four),
                    new Card(Suit.Spade, Rank.Five),
                    new Card(Suit.Heart, Rank.Six),
                    new Card(Suit.Club, Rank.Seven)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Four),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Spade, Rank.Six),
                    new Card(Suit.Heart, Rank.Seven),
                    new Card(Suit.Club, Rank.Eight)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Diamond, Rank.Six),
                    new Card(Suit.Spade, Rank.Seven),
                    new Card(Suit.Heart, Rank.Eight),
                    new Card(Suit.Club, Rank.Nine)
                };
            }

            if (pPokerHand == PokerHand.StraightFlush)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Club, Rank.Four),
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Diamond, Rank.Four),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Diamond, Rank.Six),
                    new Card(Suit.Diamond, Rank.Seven)
                };

                yield return new Card[]
                {
                    new Card(Suit.Spade, Rank.Four),
                    new Card(Suit.Spade, Rank.Five),
                    new Card(Suit.Spade, Rank.Six),
                    new Card(Suit.Spade, Rank.Seven),
                    new Card(Suit.Spade, Rank.Eight)
                };

                yield return new Card[]
                {
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Heart, Rank.Six),
                    new Card(Suit.Heart, Rank.Seven),
                    new Card(Suit.Heart, Rank.Eight),
                    new Card(Suit.Heart, Rank.Nine)
                };
            }

            if (pPokerHand == PokerHand.RoyalFlush)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Club, Rank.Queen),
                    new Card(Suit.Club, Rank.King),
                    new Card(Suit.Club, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Diamond,Rank.Ten),
                    new Card(Suit.Diamond, Rank.Jack),
                    new Card(Suit.Diamond, Rank.Queen),
                    new Card(Suit.Diamond, Rank.King),
                    new Card(Suit.Diamond, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Heart, Rank.Ten),
                    new Card(Suit.Heart, Rank.Jack),
                    new Card(Suit.Heart, Rank.Queen),
                    new Card(Suit.Heart, Rank.King),
                    new Card(Suit.Heart, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Spade, Rank.Ten),
                    new Card(Suit.Spade, Rank.Jack),
                    new Card(Suit.Spade, Rank.Queen),
                    new Card(Suit.Spade, Rank.King),
                    new Card(Suit.Spade, Rank.Ace)
                };
            }

            if (pPokerHand == PokerHand.FullHouse)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.King),
                    new Card(Suit.Spade, Rank.King),
                    new Card(Suit.Diamond, Rank.King),
                    new Card(Suit.Heart, Rank.Three),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Spade, Rank.Deuce),
                    new Card(Suit.Diamond, Rank.Deuce),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Four),
                    new Card(Suit.Spade, Rank.Four),
                    new Card(Suit.Diamond, Rank.Ten),
                    new Card(Suit.Heart, Rank.Ten),
                    new Card(Suit.Club, Rank.Ten)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Five),
                    new Card(Suit.Diamond, Rank.Seven),
                    new Card(Suit.Heart, Rank.Seven),
                    new Card(Suit.Club, Rank.Seven)
                };
            }

            if (pPokerHand == PokerHand.FourOfAKind)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Spade, Rank.Jack),
                    new Card(Suit.Diamond, Rank.Jack),
                    new Card(Suit.Heart, Rank.Jack),
                    new Card(Suit.Club, Rank.Deuce)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Spade, Rank.Ten),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Heart, Rank.Ten),
                    new Card(Suit.Club, Rank.Ten)
                };

                yield return new Card[]
               {
                    new Card(Suit.Club, Rank.King),
                    new Card(Suit.Spade, Rank.Queen),
                    new Card(Suit.Diamond, Rank.Queen),
                    new Card(Suit.Heart, Rank.Queen),
                    new Card(Suit.Club, Rank.Queen)
               };
            }

            if (pPokerHand == PokerHand.ThreeOfAKind)
            {
                yield return new Card[]
                {          
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Deuce),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Jack)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Ten),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Queen),
                    new Card(Suit.Diamond, Rank.King),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Eight),
                    new Card(Suit.Heart, Rank.Nine),
                    new Card(Suit.Club, Rank.Ace)
                };
            }

            if (pPokerHand == PokerHand.TwoPair)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Heart, Rank.Three),
                    new Card(Suit.Club, Rank.Eight)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Nine),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Five)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Queen),
                    new Card(Suit.Heart, Rank.King),
                    new Card(Suit.Club, Rank.King)
                };
            }

            if (pPokerHand == PokerHand.OnePair)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Heart, Rank.Jack),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Jack),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Six),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Deuce),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Ace)
                };
            }

            if (pPokerHand == PokerHand.NotPokerHand)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Eight),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Spade, Rank.Eight),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Jack),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Spade, Rank.Queen),
                    new Card(Suit.Diamond, Rank.Jack),
                    new Card(Suit.Heart, Rank.King),
                    new Card(Suit.Club, Rank.Four)
                };
            }
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Flush })]
        public void Flush_IsFlush_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.Flush(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Straight })]
        public void Straight_IsStraight_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.Straight(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.StraightFlush })]
        public void StraightFlush_IsStraightFlush_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.StraightFlush(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.RoyalFlush })]
        public void RoyalFlush_IsRoyalFlush_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.RoyalFlush(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FullHouse })]
        public void FullHouse_IsFullHouse_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.FullHouse(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void FourOfAKind_IsFourOfAKind_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.FourOfAKind(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void ThreeOfAKind_IsThreeOfAKind_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.ThreeOfAKind(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void ThreeOfAKind_IsBetterThan_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.ThreeOfAKind(pTestHand);
            Assert.That(result == false);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void TwoPair_IsTwoPair_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.TwoPair(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void TwoPair_IsBetterThan_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.TwoPair(pTestHand);
            Assert.That(result == false);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.OnePair })]
        public void OnePair_IsOnePair_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.OnePair(pTestHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void OnePair_IsBetterThan_ReturnsTrue(Card[] pTestHand)
        {
            bool result = PokerHandEvaluator.OnePair(pTestHand);
            Assert.That(result == false);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Flush })]
        public void EvaluatePokerHand_AssignsFlush_ReturnsTrue(Card[] pTesthand)
        {
            
            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.Flush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Straight })]
        public void EvaluatePokerHand_AssignsStraight_ReturnsTrue(Card[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.Straight);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.StraightFlush })]
        public void EvaluatePokerHand_AssignsStraightFlush_ReturnsTrue(Card[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.StraightFlush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.RoyalFlush })]
        public void EvaluatePokerHand_AssignsRoyalFlush_ReturnsTrue(Card[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.RoyalFlush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FullHouse })]
        public void EvaluatePokerHand_AssignsFullHouse_ReturnsTrue(Card[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.FullHouse);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void EvaluatePokerHand_AssignsFourOfAKind_ReturnsTrue(Card[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.FourOfAKind);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void EvaluatePokerHand_AssignsThreeOfAKind_ReturnsTrue(Card[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.ThreeOfAKind);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void EvaluatePokerHand_AssignsTwoPair_ReturnsTrue(Card[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.TwoPair);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.OnePair })]
        public void EvaluatePokerHand_AssignsOnePair_ReturnsTrue(Card[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.OnePair);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.NotPokerHand })]
        public void EvaluatePokerHand_AssignsNotPokerHand_ReturnsTrue(Card[] pTesthand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(pTesthand);

            Assert.That(result == PokerHand.NotPokerHand);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.NotPokerHand })]
        public void EvaluateHandValue_ValidCalculation_ReturnsTrue(Card[] pTestHand)
        {
            int checkResult = 0;

            foreach (Card card in pTestHand)
            {
                checkResult += (int)card.CardRank;
            }

            int result = PokerHandEvaluator.EvaluateHandValue(pTestHand);

            Assert.That(result == checkResult);

        }
    }
}
