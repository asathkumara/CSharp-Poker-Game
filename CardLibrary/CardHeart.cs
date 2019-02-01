using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{

    /// <summary>
    /// The CardHeart class inherits from the SuperCard class.
    /// </summary>
    public class CardHeart : SuperCard 
    {
        // _cardSuit is set to the Suit enum's Heart value
        private Suit _cardSuit = Suit.Heart; 

        // The parent's cardSuit property is overidden. 
        public override Suit CardSuit
        {
            get
            {
                return _cardSuit;

            }
        }

        /// <summary>
        /// The CardHeart constructor sets the cardRank property to <paramref name="pRank"/>
        /// </summary>
        /// <param name="pRank">Contains the Rank enum value which is retrieved from the CardSet class</param>
        public CardHeart(Rank pRank)
        {
            CardRank = pRank;
        }

        /// <summary>
        /// Overwrites SuperCard's Display() and prints the Heart card to console.
        /// </summary>
        public override void Display() 
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(CardRank + " of " + _cardSuit + "s ♥");
            Console.ResetColor();
        }

    } // end of class CardHeart

} // end of namespace CardLibrary
