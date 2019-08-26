using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Represents the poker game.
    /// </summary>
    public class PokerGame
    {
        public PokerTable Table { get; private set; }

        /// <summary>
        /// Constructs a poker game with the given players and dealer.
        /// </summary>
        /// <param name="pPlayers">The players of the game.</param>
        /// <param name="pDealer">The dealer of the game.</param>
        public PokerGame(List<IPlayer> pPlayers, IDealer pDealer)
        {
            Table = new PokerTable(pPlayers, pDealer);
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start()
        {
            IPlayer human = Table.Players.First(player => player.GetType() == typeof(Player));

            while (true)
            {
                Table.Dealer.Setup();
                Table.Dealer.CollectAnte();
                Table.Dealer.DealHands();
                Table.Dealer.CollectBets();
                Table.Dealer.CollectTrades();
                Table.Dealer.CollectBets();
                Table.Dealer.CompareHands();

                Console.WriteLine($"You have {human.Stack:C2} left");
                Console.Write("Would you like to play another hand? (Y/N): ");

                if (Console.ReadLine().Equals("N", StringComparison.CurrentCultureIgnoreCase))
                    break;

                else
                    Console.Clear();
            }

            End();
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        public void End()
        {
            Console.Clear();

            int totalHands = Table.Players.Sum(player => player.Wins);

            foreach (IPlayer player in Table.Players)
            {
                Console.WriteLine($"{player} won {player.Wins} hand(s) out of {totalHands} hand(s).");
                Console.WriteLine($"Their total winnings this game were {player.Stack:C2}.\n\n");
            }

            Console.WriteLine("Thank you for playing...");
        }

    }
}
