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
                    int x = rnd.Next(0, 8);
                    int y = rnd.Next(0, 8);
                    int axis = rnd.Next(0, 2);
                    int x1, y1;
                    Ship newShip;
                    int z = rnd.Next(0, 2);
                    if (z == 0) z--;
                    if (axis == 1)
                    {
                        x1 = (x + (ships[br] - 1) * z);
                        y1 = (0 + y);
                    }
                    else
                    {
                        x1 = (0 + x);
                        y1 = (y + (ships[br] - 1) * z);
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
                bool isValid = false;
                Point newPoint = new Point(0, 0);
                int r = rnd.Next(0, 3);
                if (r == 0)
                {
                    newPoint = new Point((lastPoint.X + 1), lastPoint.Y);
                    isValid = Game.CheckPoint(newPoint, true);
                    if (isValid) succes = Game.HitPoint(newPoint, true);
                    else r++;
                }
                if (r == 1)
                {
                    newPoint = new Point((lastPoint.X - 1), lastPoint.Y);
                    isValid = Game.CheckPoint(newPoint, true);
                    if (isValid) succes = Game.HitPoint(newPoint, true);
                    else r++;
                }
                if (r == 2)
                {
                    newPoint = new Point(lastPoint.X, (lastPoint.Y + 1));
                    isValid = Game.CheckPoint(newPoint, true);
                    if (isValid) succes = Game.HitPoint(newPoint, true);
                    else r++;
                }
                if (r == 3)
                {
                    newPoint = new Point(lastPoint.X, (lastPoint.Y - 1));
                    isValid = Game.CheckPoint(newPoint, true);
                    if (isValid) succes = Game.HitPoint(newPoint, true);
                    else r++;
                }
                lastPoint = newPoint;
                lastSuccess = succes;
                if (!isValid) lastSuccess = false;
            }
            if (!lastSuccess)
            {
                Point point;
                do
                {
                    int x = rnd.Next(0, 8);
                    int y = rnd.Next(0, 8);
                    point = new Point(x, y);
                }
                while (!Game.CheckPoint(point, true));
                lastSuccess = Game.HitPoint(point, true);
                lastPoint = point;
            }
        }
    }
}
