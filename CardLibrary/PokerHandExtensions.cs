using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// Contains extensions for the PokerHand enum.
    /// </summary>
    public static class PokerHandExtensions
    {
        /// <summary>
        /// Returns a string representation of the PokerHand rank.
        /// </summary>
        /// <param name="pPokerHand">The PokerHand rank.</param>
        /// <returns>Returns a string representation of the PokerHand rank.</returns>
        public static string GetString(this PokerHand pPokerHand)
        {
            string output = String.Empty;

            switch (pPokerHand)
            {
                case PokerHand.OnePair:
                    output = "One Pair";
                    break;
                case PokerHand.TwoPair:
                    output = "Two Pair";
                    break;
                case PokerHand.ThreeOfAKind:
                    output = "Three Of A Kind";
                    break;
                case PokerHand.Straight:
                    output = "Straight";
                    break;
                case PokerHand.Flush:
                    output = "Flush";
                    break;
                case PokerHand.FullHouse:
                    output = "Full House";
                    break;
                case PokerHand.FourOfAKind:
                    output = "Four Of A Kind";
                    break;
                case PokerHand.StraightFlush:
                    output = "Straight Flush";
                    break;
                case PokerHand.RoyalFlush:
                    output = "Royal Flush";
                    break;
                default:
                    output = "High Card";
                    break;
            }

            return output;
        }

        /// <summary>
        /// Returns a lowercase string representation of the PokerHand rank.
        /// </summary>
        /// <param name="pPokerHand">The PokerHand rank.</param>
        /// <returns>Returns a lowercase string representation of the PokerHand rank.</returns>
        public static string GetLowerCaseString(this PokerHand pPokerHand)
        {
            return pPokerHand.GetString().ToLower();
        }
    }

    
}
