using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Helper class that deals with console related graphics.
    /// </summary>
    public static class GraphicsHelper
    {
        /// <summary>
        /// Sets the foreground and background colors of the console window.
        /// </summary>
        public static void SetConsoleColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        /// <summary>
        /// Resets the console's foreground and background colors.
        /// </summary>
        public static void ResetConsoleColor()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        /// <summary>
        /// Types the given line. 
        /// </summary>
        /// <param name="value">The string value to be typed.</param>
        public static void TypeLine(string value)
        {
            Type(value + "\n");
        }

        /// <summary>
        /// Helper method for TypeLine
        /// </summary>
        /// <param name="value">The string value to be typed.</param>
        private static void Type(string value)
        {
            foreach (char character in value)
            {
                Console.Write(character);
                Thread.Sleep(50);
            }
        }
    }
}
