using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CardLibrary
{
    /// <summary>
    /// The SuperCard class contains the properties and the display method for the various card objects.
    /// </summary>
    /// <remarks>SuperCard uses an IComparable implementation to sort the cards by suit and then by rank.</remarks>
    public class Card : IComparable<Card>, IEquatable<Card>
    {
        /// <summary>
        /// The CardRank property represents the rank of the card.
        /// </summary>
        /// <value>The value for cardRank is retrieved through each of the card objects' constructor.</value>
        public Rank CardRank { get; set; }

        /// <summary>
        /// The CardSuit property represents the suit of the card.
        /// </summary>
        /// <value>the value for cardSuit is retrieved from each card object.</value>
        public Suit CardSuit { get; set; }

        /// <summary>
        /// The Inplay property represents whether the card is already being played.
        /// </summary>
        /// <value>The value for inplay is retrieved from the CardSet class's GetCard and ResetUsage methods.</value>
        public bool Inplay { get; set; }

        /// <summary>
        /// Contains the IComparable implementation for the SuperCard class
        /// </summary>
        /// <remarks>
        /// Sorts the cards by cardRank
        /// </remarks>
        /// <param name="other">Contains the other object that the current object is being compared with</param>
        /// <returns>
        /// Returns a 1 if this card is greater than the other card,
        ///         a -1 if this card is less than the other card,
        ///         or a 0 if both cards are equal.
        /// </returns>
        public int CompareTo(Card other)
        {
            #region Alternative Sort
            //// If the cardSuit is equal, then the cards will be sorted by cardRank. 
            //if (this.CardSuit.CompareTo(other.CardSuit) == 0)
            //{
            //    return this.CardRank.CompareTo(other.CardRank);
            //}
            //// Otherwise, the cards will be sorted by cardSuit.
            //else
            //{
            //    return this.CardSuit.CompareTo(other.CardSuit);
            //}
            #endregion

            return this.CardRank.CompareTo(other.CardRank);
        }

        public Card(Suit pSuit, Rank pRank)
        {
            CardSuit = pSuit;
            CardRank = pRank;
        }

        /// <summary>
        /// Contains the IEquatable implementation for the SuperCard class
        /// </summary>
        /// <param name="other">Contains the other object that the current object is being compared with</param>
        /// <returns>Returns true if the card suits are equal and false if they aren't.</returns>
        public bool Equals(Card other)
        {

            return this.CardSuit.Equals(other.CardSuit);

        }

        /// <summary>
        /// Displays the card objects on the console.
        /// </summary>
        /// <remarks>The following children classes are able to overwrite this method: CardClub, CardDiamond, CardHeart & CardSpade</remarks>
        public void Display()
        {
            ChangeColor();
            Console.WriteLine($"{CardRank} of {CardSuit}s {CardSuit.ExtendToSymbol()}");
            Console.ResetColor();
        }

        /// <summary>
        /// Changes the color of the cards.
        /// </summary>
        private void ChangeColor()
        {
            switch (CardSuit)
            {
                case Suit.Club:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Suit.Diamond:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case Suit.Heart:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.Spade:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                default:
                    break;
            }
        }



    }
}
