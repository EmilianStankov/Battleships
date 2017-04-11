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

        public int Size
        {
            get
            {
                if (StartPoint.X == EndPoint.X)
                {
                    return Math.Abs(StartPoint.Y - EndPoint.Y) + 1;
                }
                else
                {
                    return Math.Abs(StartPoint.X - EndPoint.X) + 1;
                }
            }
        }

        public Ship(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}
