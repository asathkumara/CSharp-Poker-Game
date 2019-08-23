/************************
 Author: Asel Sathkumara
 Version: 2.5
 ************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

namespace CardGameConsole
{
    class PokerProgram
    {   
        static void Main(string[] args)
        {
            Console.Title = "C# Poker Game v2.5";

            PokerSession.Run();
                      
            Console.ReadKey();
            
        } 

    } // end of class Program

} // end of namespace CardGameConsole
