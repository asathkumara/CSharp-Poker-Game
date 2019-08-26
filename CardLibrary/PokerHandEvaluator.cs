using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// Evaluates the value and rarity of the hand. 
    /// </summary>
    /// <remarks>
    /// The code for most of these hand validations was inspired by their Java equivalents at http://www.mathcs.emory.edu/~cheung/Courses/170/Syllabus/10/pokerCheck.html 
    /// </remarks>
    public class PokerHandEvaluator
    {
        /// <summary>
        /// Checks for the flush hand.
        /// </summary>
        /// <remarks>A flush hand is 5 cards of the same suit.</remarks>
        /// <param name="pHand">The player's hand.</param>
        /// <returns>Returns true if the hand is a flush; returns false otherwise.</returns>
        public static bool IsFlush(Card[] pHand)
        {
            // Sorts by suit
            pHand = pHand.OrderBy(item => (int)item.Suit).ToArray();

            int maxCardIndex = pHand.Length - 1;

            // Checks the suit of the first card with the last card and if they are equal, it's a flush
            return pHand[0].Suit.Equals(pHand[maxCardIndex].Suit);

        } 


        /// <summary>
        /// Checks for a straight hand.
        /// </summary>
        /// <remarks>A straight hand is 5 cards of sequential rank.</remarks>
        /// <param name="pHand">The player's hand.</param>
        /// <returns>Returns true if the hand is a straight; returns false otherwise.</returns>
        public static bool IsStraight(Card[] pHand)
        {
            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.Rank).ToArray();

            // Increments the rank of the current position by 1, beginning the sequence.
            int sequentialRank = (int)pHand[0].Rank + 1;

            // If the next card does not match the sequence, the loop breaks. Otherwise, it succeeds.
            for (int i = 1; i < pHand.Length; i++)
            {
                if ((int)pHand[i].Rank != sequentialRank++)
                    return false;
            }

            return true;

        } 

        /// <summary>
        /// Checks for a straight flush hand.
        /// </summary>
        /// <remarks>A straight flush hand is a 5 cards of the same suit in sequential rank.</remarks>
        /// <param name="pHand">The player's hand.</param>
        /// <returns>Returns true if the hand is a straight flush; returns false otherwise.</returns>
        public static bool IsStraightFlush(Card[] pHand)
        {
            // If the hand is a straight and a flush, then we have a straight flush.
            return IsStraight(pHand) && IsFlush(pHand);
        } 


        /// <summary>
        /// Checks for the royal flush hand.
        /// </summary>
        /// <remarks>A royal flush hand is the highest straight flush with a high ace.</remarks>
        /// <param name="pHand">The player's hand</param>
        /// <returns>Returns true if the hand is a royal flush; returns false otherwise.</returns>
        public static bool IsRoyalFlush(Card[] pHand)
        {
            // If the hand is a straight flush containing an Ace, then we have a Royal Flush.
            return IsStraightFlush(pHand) && pHand[4].Rank == Rank.Ace;
        } 

        /// <summary>
        /// Checks for a full house hand
        /// </summary>
        /// <remarks>A full house hand has 3 cards of the same rank and 2 other cards of the same rank.</remarks>
        /// <param name="pHand">The player's hand.</param>
        /// <returns>Returns true if the hand is a full house; returns false otherwise.</returns>
        public static bool IsFullHouse(Card[] pHand)
        {
            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.Rank).ToArray();

            // Check for 3 cards of the same rank and the two high remaining cards of the same rank.
            // a a a b b
            bool lowFullHouse = (int)pHand[0].Rank == (int)pHand[1].Rank &&
                                (int)pHand[1].Rank == (int)pHand[2].Rank &&
                                (int)pHand[3].Rank == (int)pHand[4].Rank;

            // Check for 3 cards of the same rank and the two low remaining cards of the same rank.
            // a a b b b
            bool highFullHouse = (int)pHand[0].Rank == (int)pHand[1].Rank &&
                                 (int)pHand[2].Rank == (int)pHand[3].Rank &&
                                 (int)pHand[3].Rank == (int)pHand[4].Rank;

            return lowFullHouse || highFullHouse;

        } 


        /// <summary>
        /// Checks for a four of a kind hand.
        /// </summary>
        /// <remarks>A four of a kind hand has 4 cards of the same rank.</remarks>
        /// <param name="pHand">The player's hand.</param>
        /// <returns>Returns true if the hand is a four of a kind; returns false otherwise.</returns>
        public static bool IsFourOfAKind(Card[] pHand)
        {
            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.Rank).ToArray();

            // Checks for 4 cards of the same rank and a higher unmatched card.
            // a a a a b
            bool lowFourOfAKind = (int)pHand[0].Rank == (int)pHand[1].Rank &&
                                  (int)pHand[1].Rank == (int)pHand[2].Rank &&
                                  (int)pHand[2].Rank == (int)pHand[3].Rank;

            // Checks for 4 cards of the same rank and a lower unmatched card.
            // a b b b b 
            bool highFourOfAKind = (int)pHand[1].Rank == (int)pHand[2].Rank &&
                                   (int)pHand[2].Rank == (int)pHand[3].Rank &&
                                   (int)pHand[3].Rank == (int)pHand[4].Rank;

            // If either one of those hands are true, then we must have a four of a kind.
            return lowFourOfAKind || highFourOfAKind;

        } 

        /// <summary>
        /// Checks for a three of a kind hand.
        /// </summary>
        /// <remarks>A three of a kind hand has 3 cards of the same rank and 2 cards of any rank.</remarks>
        /// <param name="pHand">The player's hand.</param>
        /// <returns>Returns true if the hand is a three of a kind; returns false otherwise.</returns>
        public static bool IsThreeOfAKind(Card[] pHand)
        {
            // Check if the hand is not a three pair but better.    
            if (IsFourOfAKind(pHand) || IsFullHouse(pHand))
                return false;

            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.Rank).ToArray();

            // Check for 3 cards of the same rank and two high unmatched cards.
            // a a a b c
            bool lowThreeOfAKind = (int)pHand[0].Rank == (int)pHand[1].Rank &&
                                    (int)pHand[1].Rank == (int)pHand[2].Rank;

            // Check for 3 cards of the same rank, one low unmatched card and one high unmatched card.
            // a b b b c
            bool middleThreeOfAKind = (int)pHand[1].Rank == (int)pHand[2].Rank &&
                                      (int)pHand[2].Rank == (int)pHand[3].Rank;

            // Check for 3 cards of the same rank and two low unmatched cards
            // a b c c c
            bool highThreeOfAKind = (int)pHand[2].Rank == (int)pHand[3].Rank &&
                                     (int)pHand[3].Rank == (int)pHand[4].Rank;

            return lowThreeOfAKind || middleThreeOfAKind || highThreeOfAKind;

        } 

        /// <summary>
        /// Checks for a two pair hand.
        /// </summary>
        /// <remarks>A two pair hand has two cards of the same rank and two different cards of the same rank.</remarks>
        /// <param name="pHand">The player's hand.</param>
        /// <returns>Returns true if the hand is a two pair; returns false otherwise.</returns>
        public static bool IsTwoPair(Card[] pHand)
        {
            // Check whether the hand is not a two pair but better.
            if (IsFourOfAKind(pHand) || IsFullHouse(pHand) || IsThreeOfAKind(pHand))
                return false;

            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.Rank).ToArray();

            // Check for two cards of the same rank and two different cards of the same rank in the low position.
            // a a b b c
            bool lowTwoPair = (int)pHand[0].Rank == (int)pHand[1].Rank &&
                              (int)pHand[2].Rank == (int)pHand[3].Rank;

            // Check for two cards of the same rank and two different cards of the same rank in the corner positions.
            // a a b c c
            bool cornerTwoPair = (int)pHand[0].Rank == (int)pHand[1].Rank &&
                                 (int)pHand[3].Rank == (int)pHand[4].Rank;

            // Check for two cards of the same rank and two different cards of the same rank in the high position.
            // a b b c c
            bool highTwoPair = (int)pHand[1].Rank == (int)pHand[2].Rank &&
                               (int)pHand[3].Rank == (int)pHand[4].Rank;

            return lowTwoPair || cornerTwoPair || highTwoPair;

        } 

        /// <summary>
        /// Checks for a one pair hand.
        /// </summary>
        /// <remarks>A one pair hand has two cards of the same rank.</remarks>
        /// <param name="pHand">The player's hand.</param>
        /// <returns>Returns true if the hand is a one pair; returns false otherwise.</returns>
        public static bool IsOnePair(Card[] pHand)
        {
            // Check whether the hand is not a one pair but better.
            if (IsFourOfAKind(pHand) || IsFullHouse(pHand) || IsThreeOfAKind(pHand) || IsTwoPair(pHand))
                return false;

            // Sort pHand by rank.
            pHand = pHand.OrderBy(item => (int)item.Rank).ToArray();

            // Check for two cards of the same rank in the lower position. 
            // a a b c d
            bool lowPair = (int)pHand[0].Rank == (int)pHand[1].Rank;

            // Check for two cards of the same rank in the lower middle position.
            // a b b c d
            bool lowerMiddlePair = (int)pHand[1].Rank == (int)pHand[2].Rank;

            // Check for two cards of the same rank in the upper middle position.
            // a b c c d
            bool higherMiddlePair = (int)pHand[2].Rank == (int)pHand[3].Rank;

            // Check for two cards of the same rank in the higher position.
            // a b c d d
            bool higherPair = (int)pHand[3].Rank == (int)pHand[4].Rank;

            return lowPair || lowerMiddlePair || higherMiddlePair || higherPair;

        } 

        /// <summary>
        /// Evaluates the rarity of the hand. 
        /// </summary>
        /// <param name="pHand">The player's hand.</param>
        /// <returns>Returns a PokerHand enum that matches the rarity of the hand.</returns>
        public static PokerHand EvaluatePokerHand(Card[] pHand)
        {
            if (IsRoyalFlush(pHand))
                return PokerHand.RoyalFlush;

            if (IsStraightFlush(pHand))
                return PokerHand.StraightFlush;

            if (IsFourOfAKind(pHand))
                return PokerHand.FourOfAKind;

            if (IsFullHouse(pHand))
                return PokerHand.FullHouse;

            if (IsFlush(pHand))
                return PokerHand.Flush;

            if (IsStraight(pHand))
                return PokerHand.Straight;

            if (IsThreeOfAKind(pHand))
                return PokerHand.ThreeOfAKind;

            if (IsTwoPair(pHand))
                return PokerHand.TwoPair;

            if (IsOnePair(pHand))
                return PokerHand.OnePair;

            return PokerHand.HighCard;
       
        }
    }
}
