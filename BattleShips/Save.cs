﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleShips
{
    class Save
    {

        static StringBuilder data = new StringBuilder();

        static public void Stage(string turn)
        {

            if (turn.Equals("GameOver"))
            {
                DateTime now = DateTime.Now;
                string b = now.ToString();
                StringBuilder folder = new StringBuilder("Session" + b.ToString() + ".txt");
                folder.Replace(@"/", "_");
                folder.Replace(":", "_");
                StreamWriter writer = new StreamWriter(folder.ToString(), false);
                using (writer)
                {
                    writer.Write(data);
                }
            }
            else
            {
                data.AppendLine(turn);
            }
        }
    }
}
