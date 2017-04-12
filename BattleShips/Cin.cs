using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships2
{
    class Cin
    {
        public static int ConvertX(char x)
        {
            if ((int)x >= (int)'A' && (int)x <= (int)'H')
                return ((int)x - (int)'A');
            if ((int)x >= (int)'a' && (int)x <= (int)'h')
                return ((int)x - (int)'a');
            return 0;
        }



        static bool Prov(char a)
        {
            if ((int)a >= (int)'A' && (int)a <= (int)'H')
                return true;
            if ((int)a >= (int)'a' && (int)a <= (int)'h')
                return true;
            return false;
        }

        static public int CinX()
        {
            char x;
            do
            {
                x = char.Parse(Console.ReadLine());
                if (Prov(x) == false) Console.WriteLine("try again");
            }
            while (Prov(x) == false);
            return ConvertX(x);
        }
        static public int CinY()
        {
            int y;
            do
            {
                try
                {
                    y = int.Parse(Console.ReadLine());
                    if (y >= 1 && y <= 8) break;
                    else Console.WriteLine("try again");
                }
                catch
                {
                    Console.WriteLine("try again");
                }

            }
            while (0 == 0);
            return y - 1;
        }
    }
}
