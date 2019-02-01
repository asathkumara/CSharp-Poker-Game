using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{

    /// <summary>
    /// The CardSpade class inherits from the SuperCard class.
    /// </summary>
    public class CardSpade : SuperCard 
    {
        // _cardSuit is set to the Suit enum's Spade value.
        private Suit _cardSuit = Suit.Spade;

        // The parent's cardSuit property is overidden. 
        public override Suit CardSuit
        {
            get
            {
                return _cardSuit;

            }
        }

        /// <summary>
        /// The CardSpade constructor sets the cardRank property to <paramref name="pRank"/>
        /// </summary>
        /// <param name="pRank">Contains the Rank enum value which is retrieved from the CardSet class</param>
        public CardSpade(Rank pRank)
        {
            CardRank = pRank;
        }


        /// <summary>
        /// Overwrites SuperCard's Display() and prints the Spade card to console.
        /// </summary>
        public override void Display() 
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(CardRank + " of " + _cardSuit + "s ♠");
            Console.ResetColor();
        }

    } // end of class CardSpade

} // end of namespace CardLibrary
