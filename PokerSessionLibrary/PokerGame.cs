using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// <param name="players">The players of the game.</param>
        /// <param name="dealer">The dealer of the game.</param>
        public PokerGame(List<IPlayer> players, IDealer dealer)
        {
            Table = new PokerTable(players, dealer);
        }

        /// <summary>
        /// Starts the poker game.
        /// </summary>
        public void Start()
        {
            IPlayer humanPlayer = Table.Players.First(player => player.GetType() == typeof(Player));

            while (true)
            {
                Table.Dealer.Setup();
                Table.Dealer.CollectAnte();
                Table.Dealer.DealHands();
                Table.Dealer.CollectBets();
                Table.Dealer.CollectTrades();
                Table.Dealer.CollectBets();
                Table.Dealer.AnnounceShowdown();

                Console.WriteLine($"You have {humanPlayer.Stack:C2} left");
                Console.Write("Play another hand? (Y/N): ");

                if (Console.ReadLine().Equals("N", StringComparison.CurrentCultureIgnoreCase))
                    break;

                else
                    Console.Clear();
            }

            End();
        }

        /// <summary>
        /// Ends the poker game.
        /// </summary>
        public void End()
        {
            Console.Clear();
            ShowStatistics();
            Console.WriteLine("Play again? (Y/N)");

            if (Console.ReadLine().Equals("N", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("Thank you for playing...");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }

            else
            {
                Console.Clear();
                House.DisplayHouseRules();
                Start();
            }
                
            

        }

        /// <summary>
        /// Shows the statistics for the game.
        /// </summary>
        private void ShowStatistics()
        {
            int totalHands = Table.Players.Sum(player => player.Wins);

            foreach (IPlayer player in Table.Players)
            {
                Console.WriteLine($"{player} won {player.Wins} hand(s) out of {totalHands} hand(s).");
                Console.WriteLine($"Their total winnings this game were {player.Stack:C2}.\n\n");
            }
        }
    }
}
