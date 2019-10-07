using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Represents the house.
    /// </summary>
    public static class House
    {
        public const decimal InitialStack = 100;
        public const decimal MinAnte = 1;
        public const decimal MaxBet = 1;
        public const int MaxHandSize = 5;
        public const int MaxDiscards = 3;
        public const int MaxPlayers = 2;

        /// <summary>
        /// Displays the house rules.
        /// </summary>
        public static void DisplayHouseRules()
        {
            SetMenuColor();

            StringBuilder sb = new StringBuilder();
            sb.Append("+----------------------------------------------------------------------------------------+\n");
            sb.Append("|                                     Introduction                                       |\n");
            sb.Append("+----------------------------------------------------------------------------------------+\n");
            sb.Append("\nThis game is based off 5 card draw.\n");
            sb.Append($"And as of now, only {MaxPlayers} players can participate: one human player and one computer player.\n\n");
            sb.Append("If you want to stop playing, type N when prompted to after the game has concluded.\n\n");

            sb.Append("+----------------------------------------------------------------------------------------+\n");
            sb.Append("|                                      House Rules                                       |\n");
            sb.Append("+----------------------------------------------------------------------------------------+\n");
            sb.Append(
                $"\n1) Each player is dealt {MaxHandSize} cards (after they have anteed) and start with a stack of {InitialStack:C2}.\n\n");
            sb.Append(
                $"2) During the betting round, each player bets {MaxBet:C2} which is added to the pot.\n\n"
                );
            sb.Append(
                $"3) Each player has the chance to trade in up to {MaxDiscards} of their cards." +
                $"\n   When prompted, enter the positions of the cards (separated by a space) you wish to discard.\n\n"
                );
            sb.Append(
                $"4) After player's have traded in their cards, they reveal their hands after another betting round.\n\n");

            sb.Append(
                "5) The winner (to whom the pot is awarded) is determined by the highest ranking poker hand " +
                $"\n   or in the event of a tie, the most valuable high card.\n\n"
                );

            sb.Append(
                $"6) If any player runs out of money at any point,\n" +
                $"   they will automatically replenish their stack at {InitialStack:C2}."
                );

            Console.WriteLine(sb.ToString());
            Console.Write("\n\nPress any key to play the first hand... ");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Sets the console's foreground and background colors for the menu.
        /// </summary>
        private static void SetMenuColor()
        {  
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        /// <summary>
        /// Resets the console's foreground and background colors.
        /// </summary>
        public static void ResetConsoleColor()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }
    }
}
