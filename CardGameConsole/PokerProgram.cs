/************************
 Author: Asel Sathkumara
 Version: 2.0
 ************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

namespace CardGameConsole
{
    /// <summary>
    /// This is the startup class for the game. 
    /// </summary>
    class PokerProgram
    {
        
        static void Main(string[] args)
        {
            Console.Title = "C# Poker Game v2.0";

            PokerSession.RunPokerSession();
                      
            Console.ReadLine();
            
        } 

        

    } // end of class Program

} // end of namespace CardGameConsole
