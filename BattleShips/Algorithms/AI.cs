using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Algorithms
{
    public class AI : Player
    {
        private bool lastSuccess = false;
        private Point lastPoint;

        public void GenerateShips()
        {
            Random rnd = new Random();
            for (int br = 0; br < ships.Length; br++)
            {
                while (true)
                {
                    byte x = (byte)rnd.Next(0, 8);
                    byte y = (byte)rnd.Next(0, 8);
                    int axis = rnd.Next(0, 2);
                    byte x1, y1;
                    Ship newShip;
                    byte z = (byte)rnd.Next(0, 2);
                    if (z == 0) z--;
                    if (axis == 1)
                    {
                        x1 = (byte)(x + (ships[br] - 1) * z);
                        y1 = (byte)(0 + y);
                    }
                    else
                    {
                        x1 = (byte)(0 + x);
                        y1 = (byte)(y + (ships[br] - 1) * z);
                    }
                    newShip = new Ship(new Point(x, y), new Point(x1, y1));
                    if (CheckShip(newShip))
                    {
                        AddShip(newShip);
                        break;
                    }
                }
            }
        }

        public void HitNewPoint()
        {
            Random rnd = new Random();
            if (lastSuccess)
            {
                bool succes = false;
                Point newPoint = new Point(0, 0);
                int r = rnd.Next(0, 3);
                if (r == 0)
                {
                    newPoint = new Point((byte)(lastPoint.X + 1), lastPoint.Y);
                    if (CheckPoint(newPoint)) succes = HitPoint(newPoint);
                    else r++;
                }
                if (r == 1)
                {
                    newPoint = new Point((byte)(lastPoint.X - 1), lastPoint.Y);
                    if (CheckPoint(newPoint)) succes = HitPoint(newPoint);
                    else r++;
                }
                if (r == 1)
                {
                    newPoint = new Point(lastPoint.X, (byte)(lastPoint.Y + 1));
                    if (CheckPoint(newPoint)) succes = HitPoint(newPoint);
                    else r++;
                }
                if (r == 1)
                {
                    newPoint = new Point(lastPoint.X, (byte)(lastPoint.Y - (byte)1));
                    if (CheckPoint(newPoint)) succes = HitPoint(newPoint);
                    else r++;
                }
                lastPoint = newPoint;
                lastSuccess = succes;
            }
            else
            {
                Point point;
                do
                {
                    byte x = (byte)rnd.Next(0, 8);
                    byte y = (byte)rnd.Next(0, 8);
                    point = new Point(x, y);
                }
                while (!CheckPoint(point));
                lastSuccess = HitPoint(point);
                lastPoint = point;
            }
        }
    }
}
