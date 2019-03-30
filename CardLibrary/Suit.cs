using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// The Suit enum contains the definitions for the four card suits. 
    /// </summary>
    public enum Suit
    {
        Club = 1,
        Diamond,
        Heart,
        Spade
    }

    /// <summary>
    /// Contains extensions for the Suit enum.
    /// </summary>
    public static class SuitExtensions
    {
        public static string ExtendToSymbol(this Suit pSuit)
        {
            string suitSymbol = String.Empty;

            switch (pSuit)
            {
                case Suit.Club:
                    return suitSymbol = "♣";
                case Suit.Diamond:
                    return suitSymbol = "♦";
                case Suit.Heart:
                    return suitSymbol = "♥";
                case Suit.Spade:
                    return suitSymbol = "♠";
                default:
                    return suitSymbol = "";
            }
        }
    }
}
