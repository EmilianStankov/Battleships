using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Algorithms
{
    public class User : Player
    {
        public void EnterShips()
        {
            foreach (var s in ships)
            {
                if (s == 1)
                {
                    while (true)
                    {

                        try
                        {
                            Console.WriteLine("Create 1-zone ship.");
                            Console.WriteLine("Enter point:");
                            string text = Console.ReadLine();
                            string[] array = text.Split(' ');
                            Point point = new Point(int.Parse(array[1]) - 1, (char.Parse(array[0]) - 65));
                            Ship ship = new Ship(point, point);
                            if (CheckShip(ship))
                            {
                                AddShip(ship);
                                break;
                            }
                        }
                        catch (Exception) { }
                        Console.WriteLine("Try again");
                    }
                }
                else
                {
                    while (true)
                    {

                        try
                        {
                            Console.WriteLine("Create {0}-zone ship.", s);
                            Console.WriteLine("Enter startpoint:");
                            string text = Console.ReadLine();
                            text += " ";
                            Console.WriteLine("Enter endpoint:");
                            text += Console.ReadLine();
                            string[] array = text.Split(' ');
                            Point startPoint = new Point(int.Parse(array[1]) - 1, (char.Parse(array[0]) - 65));
                            Point endPoint = new Point(int.Parse(array[3]) - 1, (char.Parse(array[2]) - 65));
                            Ship ship = new Ship(startPoint, endPoint);
                            if (CheckShip(ship) && (ship.Size == s))
                            {
                                AddShip(ship);
                                break;
                            }
                        }
                        catch (Exception) { }
                        Console.WriteLine("Try again");
                    }
                }
                Game.UpdateOcean();
            }
        }
        public void HitNewPoint()
        {
            while (true)
            {

                try
                {
                    Console.WriteLine("Enter point to hit:");
                    string text = Console.ReadLine();
                    string[] array = text.Split(' ');
                    Point point = new Point(int.Parse(array[1]) - 1, (char.Parse(array[0]) - 65));
                    if (Game.CheckPoint(point, false))
                    {
                        Game.HitPoint(point, false);
                        break;
                    }
                }
                catch (Exception) { }
                Console.WriteLine("Try again");
            }
        }
    }
}
