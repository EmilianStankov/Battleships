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
        public void AddShip(Ship ship)
        {

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
