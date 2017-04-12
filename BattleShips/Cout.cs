using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    class Cout
    {
        public static void Sea()
        {
            Console.WriteLine("  A B C D E F G H");
            Console.WriteLine("1 ~ ~ ~ ~ ~ ~ ~ ~");
            Console.WriteLine("2 ~ ~ ~ ~ ~ ~ ~ ~");
            Console.WriteLine("3 ~ ~ ~ ~ ~ ~ ~ ~");
            Console.WriteLine("4 ~ ~ ~ ~ ~ ~ ~ ~");
            Console.WriteLine("5 ~ ~ ~ ~ ~ ~ ~ ~");
            Console.WriteLine("6 ~ ~ ~ ~ ~ ~ ~ ~");
            Console.WriteLine("7 ~ ~ ~ ~ ~ ~ ~ ~");
            Console.WriteLine("8 ~ ~ ~ ~ ~ ~ ~ ~");
        }

        protected static void WriteAt( int x, int y,string s="S")
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
}
