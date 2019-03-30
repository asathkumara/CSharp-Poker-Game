using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// The CardSet class deals with the deck's definition and implementation.
    /// </summary>
    public class CardSet /*: Card*/
    {
        const int DeckSize = 52;

        public Card[] cardArray;     
        
        /// <summary>
        /// The constructor for the class CardSet further defines the size of the deck and populates it with card objects.
        /// </summary>
        public CardSet()
        {

            cardArray = new Card[DeckSize];


            int i = 0;

            // This for loop increments the underlying value of Rank.Deuce (that is, 2).
            //for (Rank r = Rank.Deuce; r <= Rank.Ace; r++) 
            //{

            //    cardArray[i++] = new CardClub(r);

            //    cardArray[i++] = new CardDiamond(r);

            //    cardArray[i++] = new CardHeart(r);

            //    cardArray[i++] = new CardSpade(r);
            //}
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cardArray[i] = new Card( suit, rank );
                    i++;
                }
            }

            ShuffleDeck();

            #region Alternative Foreach Loop
            //foreach (Rank r in Enum.GetValues(typeof(Rank))) // Increments the underlying value of Rank
            //{

            //    cardArray[i++] = new CardClub(r);

            //    cardArray[i++] = new CardDiamond(r);

            //    cardArray[i++] = new CardHeart(r);

            //    cardArray[i++] = new CardSpade(r);
            //}
            #endregion


            #region Alternative Nested Loop
            //for (Suit s = Suit.Club; s <= Suit.Spade; s++)
            //{
            //    for (Rank r = Rank.Deuce; r <= Rank.Ace; r++)
            //    {
            //        if ((int)s == 1) // When the Suit is equal to Club, the Club cards will be instantiated.
            //        {
            //            cardArray[i] = new CardClub(r);
            //        }

            //        if ((int)s == 2) // When the Suit is equal to Diamond, the Diamond cards will be instantiated.
            //        {
            //            cardArray[i] = new CardDiamond(r);
            //        }

            //        if ((int)s == 3) // When the Suit is equal to Heart, the Heart cards will be instantiated.
            //        {
            //            cardArray[i] = new CardHeart(r);
            //        }

            //        if ((int)s == 4) // When the Suit is equal to Spade, the Spade cards will be instantiated.
            //        {
            //            cardArray[i] = new CardSpade(r);
            //        }

            //        i++; // Without this increment, NullReferenceException will be thrown. 
            //    }
            //} // end of nested loop
            #endregion


        } // end of constructor CardSet()

        /// <summary>
        /// Shuffles the deck 1000 times.
        /// </summary>
        private void ShuffleDeck()
        {
            Random myRandom = new Random();
            Card card = null;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < DeckSize; j++)
                {
                    int secondCardIndex = myRandom.Next(13);
                    card = cardArray[j];
                    cardArray[j] = cardArray[secondCardIndex];
                    cardArray[secondCardIndex] = card;
                }
            }
        }


        /// <summary> 
        /// Retrieves a random collection of card objects, which are stored in the cardArray[] of type SuperCard, that are not inplay.
        /// </summary>
        /// <param name="pHowManyCards">Defines the size of the dealCards array of type SuperCard.</param>
        /// <returns>Returns the dealCards array which is of type SuperCard.</returns>
        public Card[] GetCards(int pHowManyCards)
        {
            Card[] dealCards = new Card[pHowManyCards];
            
            for (int i = 0; i < dealCards.Length; i++)
            {

                dealCards[i] = GetOneCard();

                #region Previous implementation for finding a usable card
                //int randomCard = myRandom.Next(0, 52);

                //// If the card is not inplay, assign it to the temp array and set inplay to true.
                //if (cardArray[randomCard].Inplay != true)
                //{
                //    cardArray[randomCard].Inplay = true;
                //    dealCards[i] = cardArray[randomCard];

                //}

                //// Otherwise, decrement the iterator until we find a card that is not inplay.
                //else
                //{
                //    i--;
                //}
                #endregion

            }

            return dealCards;
            
        } // end of GetCards()


        /// <summary>
        /// Loops through the collection stored in cardArray[] and sets each of the card objects' inplay property to false.
        /// </summary>
        public void ResetUsage()
        {
            for (int i = 0; i < cardArray.Length; i++)
            {
                // Loops through the cardArray and sets inplay property to false.
                cardArray[i].Inplay = false;
            }
        }


        /// <summary>
        /// Retrieves one card that is not inplay from the card deck.
        /// </summary>
        /// <returns>Returns oneCard which is an object of type SuperCard</returns>
        public Card GetOneCard()
        {
            Card oneCard = null;
            Random myRandom = new Random();

            for (int i = 0; i < cardArray.Length; i++)
            {
                
                int randomCard = myRandom.Next(0, 52);

                if (cardArray[randomCard].Inplay != true)
                {
                    cardArray[randomCard].Inplay = true;
                    oneCard = cardArray[randomCard];
                    break;    
                }

                else
                {
                    i--;
                }
  
            }

            return oneCard;

        }

    } // end of class CardSet

} // end of namespace CardLibrary
