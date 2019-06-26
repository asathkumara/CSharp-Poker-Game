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
        /// Converts the enum literal to a readable string with formatting. 
        /// </summary>
        /// <param name="pPokerHand">This instance of the enum.</param>
        /// <returns>Returns output which is the formatted string.</returns>
        public static string ExtendToString(this PokerHand pPokerHand)
        {
            string output = String.Empty;

            switch (pPokerHand)
            {
                case PokerHand.OnePair:
                    output = "a one pair";
                    break;
                case PokerHand.TwoPair:
                    output = "a two pair";
                    break;
                case PokerHand.ThreeOfAKind:
                    output = "a three of a kind";
                    break;
                case PokerHand.Straight:
                    output = "a straight";
                    break;
                case PokerHand.Flush:
                    output = "a flush";
                    break;
                case PokerHand.FullHouse:
                    output = "a full house";
                    break;
                case PokerHand.FourOfAKind:
                    output = "a four of a kind";
                    break;
                case PokerHand.StraightFlush:
                    output = "a straight flush";
                    break;
                case PokerHand.RoyalFlush:
                    output = "a royal flush";
                    break;
                default:
                    output = "no poker hands";
                    break;
            }

            return output;
        }


    }
}
