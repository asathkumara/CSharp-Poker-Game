using CardGameConsole.Menus.MenuItems;
using CardGameConsole.Properties;
using PokerSessionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameConsole.Menus
{
    public class MainMenu
    {
        int currentMenuIndex;
        IMenuItem[] _menuItems;

        public MainMenu()
        {
            currentMenuIndex = 0;
            _menuItems = new IMenuItem[] { new StartGameItem(48, 11), new TutorialItem(48, 13), new ExitGameItem(48, 15) };
        }

        public void Launch()
        {
            Console.Clear();
            GraphicsHelper.SetConsoleColor();

            bool optionSelected = false;
            Console.CursorVisible = false;
            Console.WriteLine(Resources.MainMenuContent);

            Console.CursorTop = _menuItems[currentMenuIndex].Y;
            DrawSelector(_menuItems[currentMenuIndex].X);

            while (!optionSelected)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            EraseSelector(_menuItems[currentMenuIndex].X);
                            currentMenuIndex--;

                            if (currentMenuIndex < 0)
                                currentMenuIndex = 2;

                            Console.CursorTop = _menuItems[currentMenuIndex].Y;
                            DrawSelector(_menuItems[currentMenuIndex].X);
                            break;

                        case ConsoleKey.DownArrow:
                            EraseSelector(_menuItems[currentMenuIndex].X);
                            currentMenuIndex++;

                            if (currentMenuIndex > 2)
                                currentMenuIndex = 0;

                            Console.CursorTop = _menuItems[currentMenuIndex].Y;
                            DrawSelector(_menuItems[currentMenuIndex].X);
                            break;

                        case ConsoleKey.Spacebar:
                        case ConsoleKey.Enter:
                            optionSelected = true;
                            break;

                    }
                }
            }

            while (currentMenuIndex != -1)
            {
                _menuItems[currentMenuIndex].Select();
                Launch();
            }
        }

        private void EraseSelector(int x)
        {
            Console.CursorLeft = x;
            Console.Write(" ");

            Console.CursorLeft = x + 15;
            Console.Write(" ");
        }

        private void DrawSelector(int x)
        {
            Console.CursorLeft = x;
            Console.Write(">");

            Console.CursorLeft = x + 15;
            Console.Write("<");

        }

        
    }
}
