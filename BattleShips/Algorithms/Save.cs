using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleShips.Algorithms
{
    public static class Save
    {

        private static StringBuilder data = new StringBuilder();

        public static void Stage(string turn)
        {
            try
            {
                if (turn.Equals("GameOver"))
                {
                    DateTime now = DateTime.Now;
                    StringBuilder folder = new StringBuilder("Session" + now.ToString() + ".txt");
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
            catch (Exception) { }
        }
    }
}
