using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    public static class PokerGameFactory
    {
        public static PokerGame CreateGame(List<IPlayer> pPlayers, IDealer pDealer)
        {
            return new PokerGame(pPlayers, pDealer);
        }
    }
}
 