using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    public class Point
    {
        public byte X { get; set; }
        public byte Y { get; set; }
        public Point(byte x, byte y)
        {
            X = x;
            Y = y;
        }
    }
}
