using CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Represents a computer player.
    /// </summary>
    public class Computer : IPlayer
    {

        public string Name { get; set; }
        public decimal Stack { get; set; }
        public int Wins { get; set; }
        public Hand Hand { get; set; }
        public PokerTable Table { get; set; }

        /// <summary>
        /// Constructs a computer player.
        /// </summary>
        private Computer()
        {
            Wins = 0;
            Hand = new Hand();
        }

        /// <summary>
        /// Constructs a computer player with a given name and initial stack.
        /// </summary>
        /// <param name="pName">The name of the player.</param>
        /// <param name="pStack">The starting stack for the player.</param>
        public Computer(string pName, decimal pStack) : this()
        {
            Name = pName;
            Stack = pStack;
        }

        /// <summary>
        /// Reveals the player's hand.
        /// </summary>
        public void RevealHand()
        {
            Console.WriteLine($"{Name}'s hand");
            Hand.Sort();
            Hand.Display();
            House.ResetConsoleColor();

        }

        /// <summary>
        /// Antees the minimum amount.
        /// </summary>
        /// <returns>The amount that was anteed.</returns>
        public decimal Ante()
        {
            if (!IsValidAnte())
                this.Stack = House.InitialStack;

            this.Stack -= House.MinAnte;
            return House.MinAnte;
        }

        /// <summary>
        /// Bets the maximum.
        /// </summary>
        /// <returns>Returns the amount that was bet.</returns>
        public decimal Bet()
        {
            if (!IsValidBet())
                this.Stack = House.InitialStack;

            this.Stack -= House.MaxBet;
            return House.MaxBet;
        }

        /// <summary>
        /// Checks if the stack after the antee is valid.
        /// </summary>
        /// <returns>Returns true if the stack is positive; returns false otherwise.</returns>
        private bool IsValidAnte()
        {
            return this.Stack - House.MinAnte > 0;
        }

        /// <summary>
        /// Checks if the stack after the bet is valid.
        /// </summary>
        /// <returns>Returns true if the stack is positive; returns false otherwise.</returns>
        private bool IsValidBet()
        {
            return this.Stack - House.MaxBet > 0;
        }

        /// <summary>
        /// Collect prize money.
        /// </summary>
        /// <param name="pAmount">The amount to be collected.</param>
        /// <returns>Returns the amount that was collected.</returns>
        /// <exception cref="ArgumentException">When the amount to be collected is negative or 0.</exception>
        public decimal Collect(decimal pAmount)
        {
            if (pAmount < 1)
                throw new ArgumentException("Stack increase cannot be negative.");

            this.Stack += pAmount;

            return pAmount;
        }

        /// <summary>
        /// Discards cards from the hand.
        /// </summary>
        /// <returns>The cards that were discarded.</returns>
        public List<Card> Discard()
        {
            List<Card> discards = new List<Card>();
            Card discarded = null;
            int currentDiscards = 0;


            while (Hand.Rank == PokerHand.HighCard && currentDiscards < House.MaxDiscards)
            {
                int lowestCardIndex = 0;
                int lowestCardValue = (int)Hand[lowestCardIndex].Rank;

                if (lowestCardValue <= 7)
                {
                    discarded = Hand[lowestCardIndex];
                    Hand[lowestCardIndex] = Table.Dealer.DealCard();
                    discards.Add(discarded);
                    Hand.Sort();
                }

                currentDiscards++;
            }

            return discards;     
        }

        /// <summary>
        /// Returns a string representation of the player.
        /// </summary>
        /// <returns>Returns a string containing the player's name.</returns>
        public override string ToString()
        {
            return $"{this.Name}";
        }

        /// <summary>
        /// Compares two players.
        /// </summary>
        /// <param name="pOther">The other player to be compared.</param>
        /// <returns>Returns an indication of the relative values of the player's hands.</returns>
        public int CompareTo(IPlayer pOther)
        {
            return this.Hand.CompareTo(pOther.Hand);
        }
    }
}
