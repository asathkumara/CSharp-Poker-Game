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

        public void Open()
        {
            Console.Clear();
            GraphicsHelper.SetConsoleColor();

            bool optionSelected = false;
            Console.CursorVisible = false;
            Console.WriteLine(Resources.MainMenuContent);

            Console.CursorTop = _menuItems[currentMenuIndex].Y;
            GraphicsHelper.DrawSelector(_menuItems[currentMenuIndex].X, 15);

            while (!optionSelected)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            GraphicsHelper.EraseSelector(_menuItems[currentMenuIndex].X, 15);
                            currentMenuIndex--;

                            if (currentMenuIndex < 0)
                                currentMenuIndex = _menuItems.Length - 1;

                            break;

                        case ConsoleKey.DownArrow:
                            GraphicsHelper.EraseSelector(_menuItems[currentMenuIndex].X, 15);
                            currentMenuIndex++;

                            if (currentMenuIndex > _menuItems.Length - 1)
                                currentMenuIndex = 0;

                            break;

                        case ConsoleKey.Spacebar:
                        case ConsoleKey.Enter:
                            optionSelected = true;
                            break;

                    }

                    Console.CursorTop = _menuItems[currentMenuIndex].Y;
                    GraphicsHelper.DrawSelector(_menuItems[currentMenuIndex].X, 15);
                }
            }

            while (currentMenuIndex != -1)
            {
                _menuItems[currentMenuIndex].Select();
                Open();
            }
        }
    }
}
