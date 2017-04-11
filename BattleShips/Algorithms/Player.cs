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
            byte startPointx=(byte)ship.StartPoint.X;
            byte startPointy= (byte)ship.StartPoint.Y ;
            byte endPointx= (byte)ship.EndPoint.X;
            byte endPointy= (byte)ship.EndPoint.Y;
            if(startPointx==endPointx && startPointy==endPointy) //one zone ship
            {
                ocean[startPointx, startPointy] = "S";
                oceanmanol[startPointx, startPointy] = 2;

            }
            if (startPointy == endPointy)                       // horizontal ship
            {
                if (startPointx > endPointx) 
                {
                    byte epx = endPointx;
                    while (epx < startPointx) 
                    {
                        epx++;
                        ocean[epx, startPointy] = "S";
                        oceanmanol[epx, startPointy] = 2;
                    }
                }
                else
                {
                    byte spx = startPointx;
                    while (spx < endPointx)
                    {
                        spx++;
                        ocean[spx, startPointy] = "S";
                        oceanmanol[spx, startPointy] = 2;
                    }
                }
            }
            if(startPointx == endPointx)                        // vertical ship
            {
                if (startPointy > endPointy)
                {
                    byte epy = endPointy;
                    while (epy < startPointy)
                    {
                        epy++;
                        ocean[startPointx,epy] = "S";
                        oceanmanol[startPointx,epy] = 2;
                    }
                }
            }
            else
            {
                byte spy = startPointy;
                while (spy < endPointy)
                {
                    spy++;
                    ocean[startPointx,spy] = "S";
                    oceanmanol[startPointx,spy] = 2;
                }
            }

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
