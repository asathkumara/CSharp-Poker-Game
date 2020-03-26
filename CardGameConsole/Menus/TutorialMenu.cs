using CardGameConsole.Properties;
using PokerSessionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CardGameConsole.Menus
{
    public class TutorialMenu
    {
        public void Launch()
        {
            Console.Clear();
            GraphicsHelper.SetConsoleColor();

            Console.WriteLine(Resources.TutorialMenuContent);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape))
                        return;
                }
            }
        }

    }
}
