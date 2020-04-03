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
        string[] _pages;
        int currentPageIndex;

        public TutorialMenu()
        {
            _pages = new string[] 
            {
                Resources.TutorialIntroductionContent,
                Resources.TutorialBettingContent,
                Resources.TutorialShowdownContent,
                Resources.TutorialHandsContent
            };

            currentPageIndex = 0;
        }

        public void Open()
        {
            Console.Clear();
            GraphicsHelper.SetConsoleColor();

            Console.WriteLine(_pages[currentPageIndex]);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (currentPageIndex == 0)
                                return;

                            currentPageIndex--;
                            Console.Clear();
                            Console.WriteLine(_pages[currentPageIndex]);
                            break;

                        case ConsoleKey.RightArrow:
                            if (currentPageIndex == _pages.Length - 1)
                                continue;

                            currentPageIndex++;
                            Console.Clear();
                            Console.WriteLine(_pages[currentPageIndex]);
                            break;

                        case ConsoleKey.Escape:
                            return;
                    }

                    
                }
            }
        }

    }
}
