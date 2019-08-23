﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// Represents the deck of cards.
    /// </summary>
    public class Deck : IEnumerable<Card>
    {
        private const int MaxDeckSize = 52;
        
        private Card[] deck;

        public int Size { get { return deck.Length; } }

        /// <summary>
        /// Constructs a deck of 52 playing cards.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws IndexOutOfRange if 
        /// the argument is not a valid index.</exception>
        public Deck()
        {
            deck = GetDeck();
            Shuffle();
        }
        
        public Card this[int pIndex]
        {
            get
            {
                if (pIndex < 0 || pIndex > deck.Length - 1)
                    throw new IndexOutOfRangeException("Index is out of range.");

                return deck[pIndex];
            }
            set
            {
                if (pIndex < 0 || pIndex > deck.Length - 1)
                    throw new IndexOutOfRangeException("Index is out of range.");

                deck[pIndex] = value;
            }
        }

        /// <summary>
        /// Builds a deck of cards.
        /// </summary>
        /// <returns>Returns the deck of cards.</returns>
        private static Card[] GetDeck()
        {
            Card[] temp = new Card[MaxDeckSize];
            int index = 0;

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    temp[index++] = new Card(suit, rank);
            }

            return temp;
        }

        /// <summary>
        /// Shuffles the deck.
        /// </summary>
        private void Shuffle()
        {
            Random random = new Random();

            for (int i = deck.Length - 1; i > 0; i--)
            {
                int secondCardIndex = random.Next(0, 52);
                Card temp = deck[i];
                deck[i] = deck[secondCardIndex];
                deck[secondCardIndex] = temp;
            }

        }

        /// <summary> 
        /// Retrieves a hand of cards.
        /// </summary>
        /// <param name="pSize">The size of the hand.
        /// <returns>Returns a hand of cards.</returns>
        public Card[] GetCards(int pSize)
        {
            Card[] hand = new Card[pSize];
            
            for (int i = 0; i < hand.Length; i++)
                hand[i] = GetCard();

            Array.Sort(hand);

            return hand;
            
        }

        /// <summary>
        /// Retrieves one card that is not inplay from the card deck.
        /// </summary>
        /// <returns>Returns a card that is not inplay.</returns>
        public Card GetCard()
        {
            Card newCard = deck.First(card => !card.Inplay);
            newCard.Inplay = true;
            return newCard;

        }

        /// <summary>
        /// Resets the deck.
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < deck.Length; i++)
                deck[i].Inplay = false;

            Shuffle();
        }

        /// <summary>
        /// Returns a string representation of the deck.
        /// </summary>
        /// <returns>Returns a readable string of the cards in the deck that are not inplay.</returns>
        public override string ToString()
        {
            return $"[{String.Join(", ", deck.Where(card => !card.Inplay))}]";
        }

        /// <summary>
        /// Returns a enumerator that iterates through the CardSet
        /// </summary>
        /// <returns>An enumerator that iterates through the CardSet</returns>
        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>)deck).GetEnumerator();
        }

        // <summary>
        /// Returns a enumerator that iterates through the CardSet
        /// </summary>
        /// <returns>An enumerator that iterates through the CardSet</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Card>)deck).GetEnumerator();
        }

    } // end of class Deck

} // end of namespace CardLibrary