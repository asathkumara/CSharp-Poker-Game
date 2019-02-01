using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CardLibrary
{
    /// <summary>
    /// The CardClub class inherits from the SuperCard class.
    /// </summary>
    public class CardClub : SuperCard 
    {
        // _cardSuit is set to the Suit enum's Club value
        private Suit _cardSuit = Suit.Club;

        // The parent's cardSuit property is overidden. 
        public override Suit CardSuit
        {
            get
            {
                return _cardSuit;
   
            }
        }

        /// <summary>
        /// The CardClub constructor sets the cardRank property to the <paramref name="pRank"/>
        /// </summary>
        /// <param name="pRank">Contains the Rank enum value which is retrieved from the CardSet class</param>
        public CardClub(Rank pRank)
        {
            CardRank = pRank;
        }

        /// <summary>
        /// Overwrites SuperCard's Display() and prints the Club card to console.
        /// </summary>
        public override void Display() 
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(CardRank + " of " + _cardSuit + "s ♣");
            Console.ResetColor();
        }

    } // end of class CardClub

} // end of namespace CardLibrary
