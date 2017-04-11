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
        protected short[] ships = new short[7] { 1, 1, 2, 2, 3, 3, 4 };
        private byte[,] ocean = new byte[8, 8];


        private byte onezoneship = 0;
        private byte twozoneship = 0;
        private byte treezoneship = 0;
        private byte fourzoneship = 0;


        public void AddShip(Ship ship)
        {
            if (ship.StartPoint.X == ship.EndPoint.X)
            {
                if ((ship.StartPoint.Y - ship.EndPoint.Y) > 0)
                {
                    for (int y = ship.StartPoint.Y; y <= ship.EndPoint.Y; y++)
                    {
                        ocean[ship.StartPoint.X, y] = 2;
                    }
                }
                else
                {
                    for (int y = ship.StartPoint.Y; y >= ship.EndPoint.Y; y--)
                    {
                        ocean[ship.StartPoint.X, y] = 2;
                    }
                }
            }
            else
            {
                if ((ship.StartPoint.X - ship.EndPoint.X) > 0)
                {
                    for (int x = ship.StartPoint.X; x <= ship.EndPoint.X; x++)
                    {
                        ocean[x, ship.StartPoint.Y] = 2;
                    }
                }
                else
                {
                    for (int x = ship.StartPoint.X; x >= ship.EndPoint.X; x--)
                    {
                        ocean[x, ship.StartPoint.Y] = 2;
                    }
                }
            }
        }

        public bool HitPoint(Point point)
        {
            if(ocean[point.X,point.Y]==3)
            {
                return false;
            }
            else
            {
                ocean[point.X, point.Y] = 3;
            }
            return true;
        }

        public bool CheckShip(Ship ship)
        {
           // if()
            return true;
        }

        public bool CheckPoint(Point point)
        {
            if (ocean[point.X, point.Y] == 3) return false;
            return true;
        }
    }
}
