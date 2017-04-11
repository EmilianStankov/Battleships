using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    public class Ship
    {
        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public int Size { get; set; }

        public Ship(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            if (startPoint.X == endPoint.X)
            {
                Size = Math.Abs(startPoint.Y - endPoint.Y) + 1;
            }
            else
            {
                Size = Math.Abs(startPoint.X - endPoint.X) + 1;
            }
        }
    }
}
