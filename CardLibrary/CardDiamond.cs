using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardLibrary
{
    /// <summary>
    /// The CardDiamond class inherits from the SuperCard class.
    /// </summary>
    public class CardDiamond : SuperCard 
    {
        // _cardSuit is set to the Suit enum's Diamond value
        private Suit _cardSuit = Suit.Diamond;

        // The parent's cardSuit property is overidden. 
        public override Suit CardSuit
        {
            get
            {
                return _cardSuit;

            }
        }

        /// <summary>
        /// The CardDiamond constructor sets the cardRank property to the <paramref name="pRank"/>
        /// </summary>
        /// <param name="pRank">Contains the Rank enum value which is retrieved from the CardSet class</param>
        public CardDiamond(Rank pRank)
        {
            CardRank = pRank;
        }

        /// <summary>
        /// Overwrites SuperCard's Display() and prints the Diamond card to console.
        /// </summary>
        public override void Display() 
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(CardRank + " of " + _cardSuit + "s ♦");
            Console.ResetColor();
        }

    } // end of class CardDiamond

} // end of namespace CardLibrary
