using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Hand : IComparable<Hand>, IEnumerable<Card>, IEquatable<Hand>
    {
        private const int MaxHandSize = 5;
        private Card[] hand;

        /// <summary>
        /// The size of the hand.
        /// </summary>
        public int Size { get { return hand.Length; } }

        /// <summary>
        /// The rank of the hand.
        /// </summary>
        public PokerHand Rank
        {
            get { return PokerHandEvaluator.EvaluatePokerHand(hand); }
        }

        /// <summary>
        /// The hand's high card.
        /// </summary>
        public Card HighCard
        {
            get { return hand[4]; }
        }

        /// <summary>
        /// Constructs a hand of maximum size.
        /// </summary>
        public Hand()
        {
            hand = new Card[MaxHandSize];
        }

        public Card this[int pIndex]
        {
            get
            {
                if (pIndex < 0 || pIndex > hand.Length - 1)
                    throw new IndexOutOfRangeException("Index out of range");

                return hand[pIndex];
            }
            set
            {
                if (pIndex < 0 || pIndex > hand.Length - 1)
                    throw new IndexOutOfRangeException("Index out of range");

                hand[pIndex] = value;
            }
        }

        /// <summary>
        /// Displays the hand.
        /// </summary>
        public void Display()
        {
            foreach (Card card in hand)
                card.Display();
        }

        /// <summary>
        /// Sorts the hand.
        /// </summary>
        public void Sort()
        {
            hand = hand.OrderBy(card => (int)card.Rank).ToArray();
        }

        /// <summary>
        /// Checks a hand object and another object for equality.
        /// </summary>
        /// <param name="pObject">The other object to be compared.</param>
        /// <returns>Returns true if the instances are equal; returns false otherwise.</returns>
        public override bool Equals(object pObject)
        {
            return this.Equals(pObject as Hand);
        }

        /// <summary>
        /// Checks two hand objects for equality.
        /// </summary>
        /// <param name="pOther">The other hand object to be compared.
        /// <returns>Returns true if the hand instances are equal; returns false otherwise.</returns>
        public bool Equals(Hand pOther)
        {
            if (ReferenceEquals(null, pOther))
                return false;

            if (ReferenceEquals(this, pOther))
                return true;

            return this.Rank.Equals(pOther.Rank);
        }

        /// <summary>
        /// Returns a hash code for this hand object.
        /// </summary>
        /// <returns>Returns a hash code for this object.</returns>
        public override int GetHashCode()
        {
            var hashCode = -162346762;
            hashCode = hashCode * -1521134295 + Rank.GetHashCode();
            hashCode = hashCode * -1521134295 + HighCard.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Compares two hand objects.
        /// </summary>
        /// <remarks>Compares the hand by their rank, and in the event of a tie, their high card..</remarks>
        /// <param name="pOther">The other hand object to be compared.</param>
        /// <returns>
        /// Returns an indication of their relative values.
        /// </returns>
        public int CompareTo(Hand pOther)
        {
            if (this.Equals(pOther))
                return this.HighCard.CompareTo(pOther.HighCard);

            return this.Rank.CompareTo(pOther.Rank);
        }

        // <summary>
        /// Returns a enumerator that iterates through the hand.
        /// </summary>
        /// <returns>An enumerator that iterates through the hand.</returns>
        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>)hand).GetEnumerator();
        }

        // <summary>
        /// Returns a enumerator that iterates through the hand.
        /// </summary>
        /// <returns>An enumerator that iterates through the hand.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Card>)hand).GetEnumerator();
        }

    }
}
