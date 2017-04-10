﻿using System;
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
       
        public bool[] Health { get; set; }
       
        public Ship(Point startPoint,Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Health = Enumerable.Repeat(true,Math.Abs((startPoint.X + startPoint.Y) - (endPoint.X + endPoint.Y))).ToArray();
        }
    }
}