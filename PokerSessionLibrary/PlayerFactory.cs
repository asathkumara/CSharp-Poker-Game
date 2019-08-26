using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Factory for player objects.
    /// </summary>
    public static class PlayerFactory
    {
        private static int playersCreated = 1;

        /// <summary>
        /// Creates a player of the given type.
        /// </summary>
        /// <param name="pPlayerType">The type of player to be created.</param>
        /// <returns>Returns a player of the argument's type.</returns>
        public static IPlayer CreatePlayer(PlayerType pPlayerType)
        {
            switch (pPlayerType)
            {
                case PlayerType.Human:
                    return new Player($"Player {playersCreated++}", House.InitialStack);
                case PlayerType.Computer:
                    return new Computer($"Player {playersCreated++}", House.InitialStack);
                default:
                    throw new InvalidEnumArgumentException("Invalid player type, could not construct player.");
            }
        }
    }
}
