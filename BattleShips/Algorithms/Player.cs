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
        private string[,] ocean = new string[8, 8];
        private byte[,] oceanmanol = new byte[8, 8];

        public void AddShip(Ship ship)
        {
            int startPointx=ship.StartPoint.X;
            int startPointy=ship.StartPoint.Y;
            int endPointx=ship.EndPoint.X;
            int endPointy=ship.EndPoint.Y;
            if(startPointx==endPointx && startPointy==endPointy) //one zone ship
            {
                ocean[startPointx, startPointy] = "S";
                oceanmanol[startPointx, startPointy] = 2;

            }
            if (startPointy == endPointy) // horizontal ship
            {
                if (startPointx > endPointx) 
                {
                    int epx = endPointx;
                    while (epx < startPointx) 
                    {
                        epx++;
                        ocean[epx, startPointy] = "S";
                        oceanmanol[epx, startPointy] = 2;
                    }
                }
                else
                {
                    int spx = startPointx;
                    while (spx < endPointx)
                    {
                        spx++;
                        ocean[spx, startPointy] = "S";
                        oceanmanol[spx, startPointy] = 2;
                    }
                }
            }
          //  if()


        }

        public bool HitPoint(Point point)
        {
            return true;
        }

        public bool CheckShip(Ship ship)
        {
            return true;
        }
        public bool CheckPoint(Point point)
        {
            return true;
        }
    }
}
