using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Algorithms
{
    public static class Game
    {
        private static AI ai;
        private static User user;
        public static void Run()
        {
            ai = new AI();
            user = new User();
            UpdateOcean();
            user.EnterShips();
            ai.GenerateShips();
            UpdateOcean();
            while (true)
            {
                user.HitNewPoint();
                if (user.IsLose())
                {
                    Console.WriteLine("YOU LOSE!");
                    break;
                }
                ai.HitNewPoint();
                if (ai.IsLose())
                {
                    Console.WriteLine("YOU WIN!");
                    break;
                }
                UpdateOcean();
                int a = 8;
            }
            Console.ReadKey();
        }



        public static bool HitPoint(Point point, bool source)
        {
            byte[][] ocean;
            if (!source) ocean = ai.ocean;
            else ocean = user.ocean;
            if (ocean[point.X][point.Y] == 2) ocean[point.X][point.Y] = 3;
            if (ocean[point.X][point.Y] == 0) ocean[point.X][point.Y] = 1;
            if (!source) ai.ocean = ocean;
            else user.ocean = ocean;
            return true;
        }
        public static bool CheckPoint(Point point, bool source)
        {
            byte[][] ocean;
            if (!source)
            {
                ocean = ai.ocean;
                if (ai.ValidatePoint(point))
                {
                    if ((ocean[point.X][point.Y] == 3)|| (ocean[point.X][point.Y] == 1)) return false;
                    else return true;
                }
                else return false;
            }
            else
            {
                ocean = user.ocean;
                if (user.ValidatePoint(point))
                {
                    if ((ocean[point.X][point.Y] == 3) || (ocean[point.X][point.Y] == 1)) return false;
                    else return true;
                }
                else return false;
            }

        }
        public static void UpdateOcean()
        {
            Console.Clear();
            Console.WriteLine("       USER      ");
            Console.WriteLine("  A B C D E F G H");
            for (int br = 0; br < user.ocean.Length; br++)
            {
                Console.Write((br + 1).ToString());
                for (int br2 = 0; br2 < user.ocean[br].Length; br2++)
                {
                    Console.Write(" ");
                    if (user.ocean[br][br2] == 0) Console.Write("~");
                    if (user.ocean[br][br2] == 1) Console.Write("Θ");
                    if (user.ocean[br][br2] == 2) Console.Write("▓");
                    if (user.ocean[br][br2] == 3) Console.Write("╬");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("        AI       ");
            Console.WriteLine("  A B C D E F G H");
            for (int br = 0; br < ai.ocean.Length; br++)
            {
                Console.Write((br + 1).ToString());
                for (int br2 = 0; br2 < ai.ocean[br].Length; br2++)
                {
                    Console.Write(" ");
                    if (ai.ocean[br][br2] == 0) Console.Write("~");
                    if (ai.ocean[br][br2] == 1) Console.Write("Θ");
                    if (ai.ocean[br][br2] == 2) Console.Write("~");
                    if (ai.ocean[br][br2] == 3) Console.Write("╬");
                }
                Console.WriteLine("");
            }
        }
    }
}
