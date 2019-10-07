/************************
 Author: Asel Sathkumara
 Version: 3.0
 ************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerSessionLibrary;

namespace CardGameConsole
{
    class PokerProgram
    {   
        static void Main(string[] args)
        {
            Console.Title = "C# Poker Game v3";
            House.DisplayHouseRules();

            IDealer dealer = DealerFactory.CreateDealer();
            IPlayer player1 = PlayerFactory.CreatePlayer(PlayerType.Computer);
            IPlayer player2 = PlayerFactory.CreatePlayer(PlayerType.Human);
            List<IPlayer> players = new List<IPlayer>() { player1, player2 };
            PokerGame pokerGame = PokerGameFactory.CreateGame(players, dealer);
            pokerGame.Start();

            Console.ReadLine();
        } 

    } 

} 
