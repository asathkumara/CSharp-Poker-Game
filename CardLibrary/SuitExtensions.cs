using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// Contains extensions for the Suit enum.
    /// </summary>
    public static class SuitExtensions
    {
        public static string GetSymbol(this Suit suit)
        {
            switch (suit)
            {
                case Suit.Club:
                    return "♣";
                case Suit.Diamond:
                    return "♦";
                case Suit.Heart:
                    return "♥";
                case Suit.Spade:
                    return "♠";
                default:
                    throw new InvalidEnumArgumentException("Invalid enum");
            }
        }
    }
}
