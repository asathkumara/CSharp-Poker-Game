using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// Contains the evaluations for the various types of hands.
    /// </summary>
    /// <remarks>
    /// The code for most of these hand validations was inspired by their Java equivalents at http://www.mathcs.emory.edu/~cheung/Courses/170/Syllabus/10/pokerCheck.html 
    /// While the code is similar, the implementation is very different due to the constraints of the assignment and the C# language.
    /// </remarks>
    public class PokerHandEvaluator
    {
        /// <summary>
        /// Checks for the flush hand.
        /// </summary>
        /// <remarks>A flush hand is 5 cards of the same suit.</remarks>
        /// <param name="pHand">The player or computer hand.</param>
        /// <returns>Returns a bool variable isFlush that is true if there is a flush and a false if there isn't one.</returns>
        public static bool Flush(Card[] pHand)
        {
            bool isFlush = false;

            // Sorts by suit
            pHand = pHand.OrderBy(item => (int)item.CardSuit).ToArray();

            int maxCardIndex = pHand.Length - 1;



            // Checks the first card with the last card and if they are equal, it's a flush.
            if (pHand[0].Equals(pHand[maxCardIndex]))
            {
                isFlush = true;
            }

            return isFlush;

        } // end of Flush()


        /// <summary>
        /// Checks for a straight hand.
        /// </summary>
        /// <remarks>A straight hand is 5 cards of sequential rank.</remarks>
        /// <param name="pHand">The player or computer hand.</param>
        /// <returns></returns>
        public static bool Straight(Card[] pHand)
        {
            bool isStraight = true;

            //// Prevents index errors.
            //if (pHand.Length != 5)
            //{
            //    return false;
            //}

            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.CardRank).ToArray();

            // Increments the rank of the current position by 1, beginning the sequence.
            int sequentialRank = (int)pHand[0].CardRank + 1;

            // If the next card does not match the sequence, the loop breaks. Otherwise, it succeeds.
            for (int i = 1; i < pHand.Length; i++)
            {
                if ((int)pHand[i].CardRank != sequentialRank)
                {
                    return isStraight = false;
                }

                // Next rank in sequence.
                sequentialRank++;
            }

            return isStraight;

        } // end of Straight()

        /// <summary>
        /// Checks for a straight flush hand.
        /// </summary>
        /// <remarks>A straight flush hand is a 5 cards of the same suit in sequential rank.</remarks>
        /// <param name="pHand">The player or computer hand.</param>
        /// <returns>Returns a bool isStraightFlush that is true if Straight() and Flush() return true.</returns>
        public static bool StraightFlush(Card[] pHand)
        {
            bool isStraightFlush = false;

            // If the hand is a straight and a flush, then we have a straight flush.
            if (Straight(pHand) && Flush(pHand))
            {
                isStraightFlush = true;
            }

            return isStraightFlush;

        } // end of Straight()


        /// <summary>
        /// Checks for the royal flush hand
        /// </summary>
        /// <remarks>A royal flush hand is the highest straight flush with a high ace.</remarks>
        /// <param name="pHand">The player or computer hand</param>
        /// <returns>Returns a bool variable isFlush that is true if Straight() and Flush() returns true, and if there's an high Ace</returns>
        public static bool RoyalFlush(Card[] pHand)
        {
            bool isRoyalFlush = false;

            // Prevents index errors.
            if (pHand.Length != 5)
            {
                return false;
            }


            // If the hand is a straight, a flush and contains an Ace, then we have a Royal Flush.
            if (Straight(pHand) && Flush(pHand) && (int)pHand[4].CardRank == 14)
            {
                isRoyalFlush = true;
            }

            return isRoyalFlush;

        } // end of RoyalFlush()

        /// <summary>
        /// Checks for a Full House hand
        /// </summary>
        /// <remarks>A full house hand has 3 cards of the same rank and 2 other cards of the same rank.</remarks>
        /// <param name="pHand">The player or computer hand.</param>
        /// <returns>Returns a bool isFullHouse if it finds 3 cards of the same rank and 2 other cards of same rank in the hand.</returns>
        public static bool FullHouse(Card[] pHand)
        {
            bool isFullHouse = false;

            // Prevents index errors.
            if (pHand.Length != 5)
            {
                return false;
            }

            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.CardRank).ToArray();

            // Check for 3 cards of the same rank and the two high remaining cards of the same rank.
            // a a a b b
            bool lowFullHouse = (int)pHand[0].CardRank == (int)pHand[1].CardRank &&
                                (int)pHand[1].CardRank == (int)pHand[2].CardRank &&
                                (int)pHand[3].CardRank == (int)pHand[4].CardRank;

            // Check for 3 cards of the same rank and the two low remaining cards of the same rank.
            // a a b b b
            bool highFullHouse = (int)pHand[0].CardRank == (int)pHand[1].CardRank &&
                                 (int)pHand[2].CardRank == (int)pHand[3].CardRank &&
                                 (int)pHand[3].CardRank == (int)pHand[4].CardRank;


            if (lowFullHouse || highFullHouse)
            {
                isFullHouse = true;
            }

            return isFullHouse;

        } // end of FullHouse()


        /// <summary>
        /// Checks for a Four Of A Kind hand.
        /// </summary>
        /// <remarks>A four of a kind hand has 4 cards of the same rank and a 5th card of any rank.</remarks>
        /// <param name="pHand">The player or computer hand.</param>
        /// <returns>Returns a bool isFourOfAKind that is true if it finds a four of a kind anywhere in the hand.</returns>
        public static bool FourOfAKind(Card[] pHand)
        {
            bool isFourOfAKind = false;

            // Prevents index errors.
            if (pHand.Length != 5)
            {
                return false;
            }

            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.CardRank).ToArray();

            // Checks for 4 cards of the same rank and a higher unmatched card.
            // a a a a b
            bool lowFourOfAKind = (int)pHand[0].CardRank == (int)pHand[1].CardRank &&
                                  (int)pHand[1].CardRank == (int)pHand[2].CardRank &&
                                  (int)pHand[2].CardRank == (int)pHand[3].CardRank;

            // Checks for 4 cards of the same rank and a lower unmatched card.
            // a b b b b 
            bool highFourOfAKind = (int)pHand[1].CardRank == (int)pHand[2].CardRank &&
                                   (int)pHand[2].CardRank == (int)pHand[3].CardRank &&
                                   (int)pHand[3].CardRank == (int)pHand[4].CardRank;

            // If either one of those hands are true, then we must have a four of a kind.
            if (lowFourOfAKind || highFourOfAKind)
            {
                isFourOfAKind = true;
            }


            return isFourOfAKind;

        } // end of FourOfAKind()

        /// <summary>
        /// Checks for a ThreeOfAKind hand.
        /// </summary>
        /// <remarks>A three of a kind hand has 3 cards of the same rank and 2 cards of any rank.</remarks>
        /// <param name="pHand">The player or computer hand.</param>
        /// <returns>Returns a bool isThreeOfAKind that is true if it finds a three of a kind anywhere in the hand.</returns>
        public static bool ThreeOfAKind(Card[] pHand)
        {
            bool isThreeOfAKind = false;

            // Prevents index errors.
            if (pHand.Length != 5)
            {
                return false;
            }

            // Check if the hand is not a three pair but better.    
            if (FourOfAKind(pHand) || FullHouse(pHand))
            {
                return isThreeOfAKind;
            }

            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.CardRank).ToArray();

            // Check for 3 cards of the same rank and two high unmatched cards.
            // a a a b c
            bool lowThreeOfAKind = (int)pHand[0].CardRank == (int)pHand[1].CardRank &&
                                    (int)pHand[1].CardRank == (int)pHand[2].CardRank;

            // Check for 3 cards of the same rank, one low unmatched card and one high unmatched card.
            // a b b b c
            bool middleThreeOfAKind = (int)pHand[1].CardRank == (int)pHand[2].CardRank &&
                                      (int)pHand[2].CardRank == (int)pHand[3].CardRank;

            // Check for 3 cards of the same rank and two low unmatched cards
            // a b c c c
            bool highThreeOfAKind =  (int)pHand[2].CardRank == (int)pHand[3].CardRank &&
                                     (int)pHand[3].CardRank == (int)pHand[4].CardRank;
                                    

            if (lowThreeOfAKind || middleThreeOfAKind || highThreeOfAKind)
            {
                isThreeOfAKind = true;
            }

            return isThreeOfAKind;

        } // end of ThreeOfAKind()

        /// <summary>
        /// Checks for a two pair hand.
        /// </summary>
        /// <remarks>A two pair hand has two cards of the same rank, two different cards of the same rank and one unmatched card.</remarks>
        /// <param name="pHand">The player or computer hand.</param>
        /// <returns>Returns a bool isTwoPair that is true if it finds two pairs anywhere in the hand.</returns>
        public static bool TwoPair(Card[] pHand)
        {
            bool isTwoPair = false;

            // Prevents index errors.
            if (pHand.Length != 5)
            {
                return false;
            }

            // Check whether the hand is not a two pair but better.
            if (FourOfAKind(pHand) || FullHouse(pHand) || ThreeOfAKind(pHand))
            {
                return isTwoPair;
            }

            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.CardRank).ToArray();

            // Check for two cards of the same rank and two different cards of the same rank in the low position.
            // a a b b c
            bool lowTwoPair = (int)pHand[0].CardRank == (int)pHand[1].CardRank &&
                              (int)pHand[2].CardRank == (int)pHand[3].CardRank;

            // Check for two cards of the same rank and two different cards of the same rank in the corner positions.
            // a a b c c
            bool cornerTwoPair = (int)pHand[0].CardRank == (int)pHand[1].CardRank &&
                                 (int)pHand[3].CardRank == (int)pHand[4].CardRank;

            // Check for two cards of the same rank and two different cards of the same rank in the high position.
            // a b b c c
            bool highTwoPair = (int)pHand[1].CardRank == (int)pHand[2].CardRank &&
                               (int)pHand[3].CardRank == (int)pHand[4].CardRank;


            if (lowTwoPair || cornerTwoPair || highTwoPair)
            {
                isTwoPair = true;
            }

            return isTwoPair;

        } // end of TwoPair()

        /// <summary>
        /// Checks for a one pair hand.
        /// </summary>
        /// <remarks>A one pair hand has two cards of the same rank and three other unmatched cards.</remarks>
        /// <param name="pHand">The player or computer hand.</param>
        /// <returns>Returns a bool isOnePair that is true if it finds a one pair anywhere in the hand.</returns>
        public static bool OnePair(Card[] pHand)
        {
            bool isOnePair = false;

            // Prevents index errors.
            if (pHand.Length != 5)
            {
                return false;
            }

            // Check whether the hand is not a one pair but better.
            if (FourOfAKind(pHand) || FullHouse(pHand) || ThreeOfAKind(pHand) || TwoPair(pHand))
            {
                return isOnePair;
            }

            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.CardRank).ToArray();

            // Check for two cards of the same rank in the lower position. 
            // a a b c d
            bool lowPair = (int)pHand[0].CardRank == (int)pHand[1].CardRank;

            // Check for two cards of the same rank in the lower middle position.
            // a b b c d
            bool lowerMiddlePair = (int)pHand[1].CardRank == (int)pHand[2].CardRank;

            // Check for two cards of the same rank in the upper middle position.
            // a b c c d
            bool higherMiddlePair = (int)pHand[2].CardRank == (int)pHand[3].CardRank;

            // Check for two cards of the same rank in the higher position.
            // a b c d d
            bool higherPair = (int)pHand[3].CardRank == (int)pHand[4].CardRank;

            //// Check for two cards of the same rank in the corners.
            //// a b c d a
            //bool cornerPair = (int)pHand[0].CardRank == (int)pHand[4].CardRank;


            if (lowPair || lowerMiddlePair || higherMiddlePair || higherPair /*|| cornerPair*/)
            {
                isOnePair = true;
            }

            return isOnePair;

        } // end of TwoPair()

        /// <summary>
        /// Evaluates the rarity of the hand, returning a PokerHand enum that matches that rarity.
        /// </summary>
        /// <param name="pHand">The player or computer hand.</param>
        /// <returns>Returns a PokerHand enum that matches the rarity of the hand.</returns>
        public static PokerHand EvaluatePokerHand(Card[] pHand)
        {
            if (RoyalFlush(pHand))
            {
                return PokerHand.RoyalFlush;
            }

            if (StraightFlush(pHand))
            {
                return PokerHand.StraightFlush;
            }

            if (FullHouse(pHand))
            {
                return PokerHand.FullHouse;
            }

            if (Flush(pHand))
            {
                return PokerHand.Flush;
            }

            if (Straight(pHand))
            {
                return PokerHand.Straight;
            }

            if (FourOfAKind(pHand))
            {
                return PokerHand.FourOfAKind;
            }

            if (ThreeOfAKind(pHand))
            {
                return PokerHand.ThreeOfAKind;
            }

            if (TwoPair(pHand))
            {
                return PokerHand.TwoPair;
            }

            if (OnePair(pHand))
            {
                return PokerHand.OnePair;
            }

            else
            {
                return PokerHand.NotPokerHand;
            }
        }

        /// <summary>
        /// Evaluates the underlying value of each Rank enum in the hand.
        /// </summary>
        /// <param name="pHand">The player or computer hand.</param>
        /// <returns>Returns handValue which is an int. </returns>
        public static int EvaluateHandValue(Card[] pHand)
        {
            int handValue = 0;

            foreach (Card card in pHand)
            {
                handValue += (int)card.CardRank;
            }

            return handValue;
        }
    }
}
