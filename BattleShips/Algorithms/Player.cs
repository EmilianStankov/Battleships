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
        private List<List<byte>> ocean = Enumerable.Repeat(Enumerable.Repeat((byte)0, n).ToList(), n).ToList();


        protected void AddShip(Ship ship)
        {
            //Console.WriteLine("x="+ship.StartPoint.X+" "+ship.StartPoint.Y+"y="+ship.EndPoint.X+" "+ship.EndPoint.Y);
            if (ship.StartPoint.X == ship.EndPoint.X)
            {
                if ((ship.StartPoint.Y - ship.EndPoint.Y) > 0)
                {
                    for (int y = ship.StartPoint.Y; y <= ship.EndPoint.Y; y++)
                    {
                        ocean[ship.StartPoint.X][y] = 2;
                    }
                }
                else
                {
                    for (int y = ship.StartPoint.Y; y >= ship.EndPoint.Y; y--)
                    {
                        ocean[ship.StartPoint.X][y] = 2;
                    }
                }
            }
            else
            {
                if ((ship.StartPoint.X - ship.EndPoint.X) > 0)
                {
                    for (int x = ship.StartPoint.X; x <= ship.EndPoint.X; x++)
                    {
                        ocean[x][ship.StartPoint.Y] = 2;
                    }
                }
                else
                {
                    for (int x = ship.StartPoint.X; x >= ship.EndPoint.X; x--)
                    {
                        ocean[x][ship.StartPoint.Y] = 2;
                    }
                }
            }
        }

        protected bool HitPoint(Point point)
        {
            if (ocean[point.X][point.Y] == 3)
            {
                return false;
            }
            else
            {
                ocean[point.X][point.Y] = 3;
            }
            return true;
        }
        //Check can you add a ship
        protected bool CheckShip(Ship ship)
        {
            if (!ValidatePoint(ship.StartPoint) || !ValidatePoint(ship.EndPoint)) return false;
            if (ship.StartPoint.X == ship.EndPoint.X)
            {
                if ((ship.StartPoint.Y - ship.EndPoint.Y) > 0)
                {
                    for (int y = ship.StartPoint.Y; y <= ship.EndPoint.Y; y++)
                    {
                        if (ocean[ship.StartPoint.X][y] == 2) return false;
                    }
                }
                else
                {
                    for (int y = ship.StartPoint.Y; y >= ship.EndPoint.Y; y--)
                    {
                        if (ocean[ship.StartPoint.X][y] == 2) return false;
                    }
                }
            }
            else
            {
                if ((ship.StartPoint.X - ship.EndPoint.X) > 0)
                {
                    for (int x = ship.StartPoint.X; x <= ship.EndPoint.X; x++)
                    {
                        if (ocean[x][ship.StartPoint.Y] == 2) return false;
                    }
                }
                else
                {
                    for (int x = ship.StartPoint.X; x >= ship.EndPoint.X; x--)
                    {
                        if (ocean[x][ship.StartPoint.Y] == 2) return false;
                    }
                }
            }
            return true;
        }
        //Check can you hit a point
        protected bool CheckPoint(Point point)
        {
            if ((ocean[point.X][point.Y] == 3) || (ValidatePoint(point))) return false;
            else return true;
        }

        private bool ValidatePoint(Point point)
        {
            if ((point.X < 0) || (point.X > ocean.Count - 1) || (point.Y < 0) || (point.Y > ocean.Count - 1)) return false;
            else return true;
        }
    }
}
