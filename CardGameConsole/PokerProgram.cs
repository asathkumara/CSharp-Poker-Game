/************************
 Author: Asel S.
 Version: 4.0
 ************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameConsole.Menus;
using PokerSessionLibrary;

namespace CardGameConsole
{
    class PokerProgram
    {   
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 25);
            Console.Title = "C# Poker Game v4";
            MainMenu mainMenu = new MainMenu();
            mainMenu.Launch();

            Console.ReadLine();
        } 

    } 

} 
