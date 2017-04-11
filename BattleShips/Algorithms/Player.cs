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
        private string[,] ocean = new string[8, 8];
        private byte[,] oceanmanol = new byte[8, 8];

        public void AddShip(Ship ship)
        {
            byte startPointx=0;
            byte startPointy=3;
            byte endPointx=5;
            byte endPointy=9;
            if(startPointx==endPointx && startPointy==endPointy) //one zone ship
            {
                ocean[startPointx, startPointy] = "S";
                oceanmanol[startPointx, startPointy] = 2;

            }
            if (startPointy == endPointy) // horizontal ship
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


        }

        public void HitPoint(Point point)
        {

        }
    }
}
