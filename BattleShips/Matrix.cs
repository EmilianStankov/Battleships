﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    class Matrix
    {
        public byte[,] Ocean = new byte[8, 8];
        public byte[,] Initialise(byte x, byte y)
        {
            if (Ocean[x, y] == 0)
                Ocean[x, y] = 1;
            if (Ocean[x, y] == 2)
                Ocean[x, y] = 3;
            return Ocean;
        }
    }
}
