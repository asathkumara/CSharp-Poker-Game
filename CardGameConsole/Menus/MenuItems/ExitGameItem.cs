using CardGameConsole.Properties;
using PokerSessionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGameConsole.Menus.MenuItems
{
    public class ExitGameItem : IMenuItem
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ExitGameItem(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Select()
        {
            Console.Clear();
            GraphicsHelper.TypeLine(Resources.ExitMenuContent);
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}
