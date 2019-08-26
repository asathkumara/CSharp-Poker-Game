using CardLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Represents the poker table.
    /// </summary>
    public class PokerTable : IEnumerable<IPlayer>
    {
        /// <summary>
        /// The discard pile.
        /// </summary>
        private List<Card> muck;

        /// <summary>
        /// The player's at the table.
        /// </summary>
        public List<IPlayer> Players { get; set; }

        /// <summary>
        /// The dealer.
        /// </summary>
        public IDealer Dealer { get; set; }

        /// <summary>
        /// The total pot.
        /// </summary>
        public decimal Pot { get; set; }

        /// <summary>
        /// Constructs a poker table.
        /// </summary>
        private PokerTable()
        {
            Players = new List<IPlayer>(House.MaxPlayers);
            muck = new List<Card>();
        }

        /// <summary>
        /// Constructs a poker table with the given players and dealers.
        /// </summary>
        /// <param name="pPlayers">The players to be seated.</param>
        /// <param name="pDealer">The dealer to be seated.</param>
        public PokerTable(List<IPlayer> pPlayers, IDealer pDealer) : this()
        {
            SeatDealer(pDealer);
            SeatPlayers(pPlayers);
        }

        /// <summary>
        /// Seats the dealer at the table.
        /// </summary>
        /// <param name="pDealer">The dealer to be seated.</param>
        public void SeatDealer(IDealer pDealer)
        {
            Dealer = pDealer;
            Dealer.Table = this;
        }
        
        /// <summary>
        /// Seats the players at the table.
        /// </summary>
        /// <param name="pPlayers">The players to be seated.</param>
        public void SeatPlayers(List<IPlayer> pPlayers)
        {
            Players.AddRange(pPlayers);

            foreach (IPlayer player in this)
                player.Table = this;
        }

        /// <summary>
        /// Sets up the table for play.
        /// </summary>
        public void Setup()
        {
            this.ClearPot();
            this.ClearMuck();

        }

        /// <summary>
        /// Adds a card to the muck.
        /// </summary>
        /// <param name="pCard">The card to be discarded.</param>
        public void Muck(Card pCard)
        {
            muck.Add(pCard);
        }

        /// <summary>
        /// Adds cards to the muck.
        /// </summary>
        /// <param name="pCards">The cards to be added.</param>
        public void Muck(List<Card> pCards)
        {
            muck.AddRange(pCards);
        }

        /// <summary>
        /// Increases the current pot.
        /// </summary>
        /// <param name="pAmount">The amount to be added to the pot.</param>
        public void IncreasePot(decimal pAmount)
        {
            if (pAmount < 1)
                throw new ArgumentException("Pot increase cannot be negative.");

            this.Pot += pAmount;

        }

        /// <summary>
        /// Clears the current pot.
        /// </summary>
        /// <returns>The amount that was cleared.</returns>
        public decimal ClearPot()
        {
            decimal currentPot = this.Pot;
            this.Pot = 0;
            return currentPot;
        }

        /// <summary>
        /// Clears the muck.
        /// </summary>
        public void ClearMuck()
        {
            muck.Clear();
        }

        public IEnumerator<IPlayer> GetEnumerator()
        {
            return ((IEnumerable<IPlayer>)Players).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IPlayer>)Players).GetEnumerator();
        }
    }
}
