using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CardLibrary
{
    /// <summary>
    /// Represents a playing card.
    /// </summary>
    public class Card : IComparable<Card>, IEquatable<Card>
    {
        /// <summary>
        /// The rank of the playing card.
        /// </summary>
        /// <value>The value is one of possible values in the Rank enum.</value>
        public Rank Rank { get; set; }

        /// <summary>
        /// The suit of the card.
        /// </summary>
        /// <value>The value is one of possible values in the Suit enum.</value>
        public Suit Suit { get; set; }

        /// <summary>
        /// The state of the playing card.
        /// </summary>
        /// <value>The value is set by the CardSet class.</value>
        public bool Inplay { get; set; }

        /// <summary>
        /// Constructs a playing card based on the given suit and rank.
        /// </summary>
        /// <param name="pSuit">The suit of the playing card.</param>
        /// <param name="pRank">The rank of the playing card.</param>
        public Card(Suit pSuit, Rank pRank)
        {
            Suit = pSuit;
            Rank = pRank;
        }

        /// <summary>
        /// Displays the cards.
        /// </summary>
        public void Display()
        {
            SetDisplayColor();
            Console.WriteLine(this.ToString());
            Console.ResetColor();
        }

        /// <summary>
        /// Sets the foreground and background color of the displayed cards.
        /// </summary>
        private void SetDisplayColor()
        {
            switch (Suit)
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

        /// <summary>
        /// Compares two card objects.
        /// </summary>
        /// <remarks>Compares the cards by their rank.</remarks>
        /// <param name="pOther">The other card object to be compared.</param>
        /// <returns>
        /// Returns an indication of their relative values.
        /// </returns>
        public int CompareTo(Card pOther)
        {
            return this.Rank.CompareTo(pOther.Rank);
        }

        /// <summary>
        /// Returns a string representation of the card.
        /// </summary>
        /// <returns>Returns a readable string which contains the rank, suit and symbol of the card.</returns>
        public override string ToString()
        {
            return $"{Rank} of {Suit}s {Suit.ExtendToSymbol()}";
        }

        /// <summary>
        /// Checks two card objects for equality.
        /// </summary>
        /// <param name="pOther">The other card object to be compared.
        /// <returns>Returns true if the card instances are equal; returns false otherwise.</returns>
        public bool Equals(Card pOther)
        {
            if (ReferenceEquals(null, pOther))
                return false;

            if (ReferenceEquals(this, pOther))
                return true;

            return this.Suit.Equals(pOther.Suit) &&
                this.Rank.Equals(pOther.Rank);

        }

        /// <summary>
        /// Checks a card object and another object for equality.
        /// </summary>
        /// <param name="pObject">The other object to be compared.</param>
        /// <returns>Returns true if the instances are equal; returns false otherwise.</returns>
        public override bool Equals(object pObject)
        {
            return this.Equals(pObject as Card);
        }

        /// <summary>
        /// Returns a hash code for this card.
        /// </summary>
        /// <returns>Returns a hash code for this object.</returns>
        public override int GetHashCode()
        {
            var hashCode = 393341827;
            hashCode = hashCode * -1521134295 + Rank.GetHashCode();
            hashCode = hashCode * -1521134295 + Suit.GetHashCode();
            return hashCode;
        }
    }
}
