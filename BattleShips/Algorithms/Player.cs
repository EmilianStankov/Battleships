using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Algorithms
{
    public abstract class Player
    {
        //private Matrix ocean;
        private static int n = 8;
        protected short[] ships = new short[7] { 1, 1, 2, 2, 3, 3, 4 };
        public byte[][] ocean = SetStartValue();//= Enumerable.Repeat(Enumerable.Repeat((byte)0, n).ToArray(), n).ToArray();

        private static byte[][] SetStartValue()
        {
            byte[][] o = new byte[n][];
            for (int br = 0; br < o.Length; br++)
            {
                o[br] = new byte[n];
                for(int br2=0;br2<o[br].Length;br2++)
                {
                    o[br][br2] = 0;
                }
            }
            return o;
        }

        protected void AddShip(Ship ship)
        {
            //Console.WriteLine("x="+ship.StartPoint.X+" "+ship.StartPoint.Y+"y="+ship.EndPoint.X+" "+ship.EndPoint.Y);
            if (ship.StartPoint.X == ship.EndPoint.X)
            {
                if ((ship.StartPoint.Y - ship.EndPoint.Y) > 0)
                {
                    for (int y = ship.StartPoint.Y; y >= ship.EndPoint.Y; y--)
                    {
                        ocean[ship.StartPoint.X][y] = 2;
                    }
                }
                else
                {
                    for (int y = ship.StartPoint.Y; y <= ship.EndPoint.Y; y++)
                    {
                        ocean[ship.StartPoint.X][y] = 2;
                    }
                }
            }
            else
            {
                if ((ship.StartPoint.X - ship.EndPoint.X) > 0)
                {
                    for (int x = ship.StartPoint.X; x >= ship.EndPoint.X; x--)
                    {
                        ocean[x][ship.StartPoint.Y] = 2;
                    }
                }
                else
                {
                    for (int x = ship.StartPoint.X; x <= ship.EndPoint.X; x++)
                    {
                        ocean[x][ship.StartPoint.Y] = 2;
                    }
                }
            }
        }

        
        //Check can you add a ship
        protected bool CheckShip(Ship ship)
        {
            if (!ValidatePoint(ship.StartPoint) || !ValidatePoint(ship.EndPoint)) return false;
            if (ship.StartPoint.X == ship.EndPoint.X)
            {
                if ((ship.StartPoint.Y - ship.EndPoint.Y) > 0)
                {
                    for (int y = ship.StartPoint.Y; y >= ship.EndPoint.Y; y--)
                    {
                        if (ocean[ship.StartPoint.X][y] == 2) return false;
                    }
                }
                else
                {
                    for (int y = ship.StartPoint.Y; y <= ship.EndPoint.Y; y++)
                    {
                        if (ocean[ship.StartPoint.X][y] == 2) return false;
                    }
                }
            }
            else
            {
                if ((ship.StartPoint.X - ship.EndPoint.X) > 0)
                {
                    for (int x = ship.StartPoint.X; x >= ship.EndPoint.X; x--)
                    {
                        if (ocean[x][ship.StartPoint.Y] == 2) return false;
                    }
                }
                else
                {
                    for (int x = ship.StartPoint.X; x <= ship.EndPoint.X; x++)
                    {
                        if (ocean[x][ship.StartPoint.Y] == 2) return false;
                    }
                }
            }
            return true;
        }
        //Check can you hit a point
        public bool IsLose()
        {
            foreach (var line in ocean)
            {
                foreach (var item in line)
                {
                    if (item == 2) return false;
                }
            }
            return true;
        }

        public bool ValidatePoint(Point point)
        {
            if ((point.X < 0) || (point.X > ocean.Length - 1) || (point.Y < 0) || (point.Y > ocean.Length - 1)) return false;
            else return true;
        }
    }
}
