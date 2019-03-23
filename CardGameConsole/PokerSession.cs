using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameConsole
{
    /// <summary>
    /// Initiaizes the poker session with default properties.
    /// </summary>
     static class PokerSession
    {
        /// <summary>
        /// Defines the player's balance.
        /// </summary>
        public static int Balance { get; set; }

        /// <summary>
        /// Defines the hand size of the player and the computer.
        /// </summary>
        public static int HandSize { get; set; }

        /// <summary>
        /// Contains the player's total number of wins.
        /// </summary>
        public static int PlayerWinCounter { get; set; }

        /// <summary>
        /// Contains the computer's total number of wins.
        /// </summary>
        public static int ComputerWinCounter { get; set; }

        /// <summary>
        /// Contains the total number of rounds elapsed. 
        /// </summary>
        public static int RoundCounter { get; set; }
    }
}
