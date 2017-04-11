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
        private string[,] ocean = new string[8, 8];
        private byte[,] oceanmanol = new byte[8, 8];


        private byte onezoneship = 0;
        private byte twozoneship = 0;
        private byte treezoneship = 0;
        private byte fourzoneship = 0;



        public void AddShip(Ship ship)
        {
            //vars
            byte startPointx = (byte)ship.StartPoint.X;
            byte startPointy = (byte)ship.StartPoint.Y;
            byte endPointx = (byte)ship.EndPoint.X;
            byte endPointy = (byte)ship.EndPoint.Y;
            byte count = 0;
            ocean[startPointx, startPointy] = "S";
            oceanmanol[startPointx, startPointy] = 2;
            ocean[endPointx, endPointy] = "S";
            oceanmanol[endPointx, endPointy] = 2;
            

            //one zone ship
            if (startPointx==endPointx && startPointy==endPointy)                            
            {
                ocean[startPointx, startPointy] = "S";
                oceanmanol[startPointx, startPointy] = 2;

                onezoneship++;                                                              
            }


            // horizontal ship
            if (startPointy == endPointy && startPointx != endPointx)                       
            {

                if (startPointx > endPointx)
                {
                    for (byte epx = (byte)(endPointx + 1); epx < startPointx; epx++)
                    {
                        count++;
                        ocean[epx, startPointy] = "S";
                        oceanmanol[epx, startPointy] = 2;
                        if (count == 1)treezoneship++;
                        if (count == 2)fourzoneship++;
                    }
                    if (count == 0)twozoneship++;
                    
                    count = 0;
                }


                if (startPointx < endPointx)
                {
                    for (byte spx = (byte)(startPointx + 1); spx < endPointx; spx++)
                    {
                        count++;
                        ocean[spx, startPointy] = "S";
                        oceanmanol[spx, startPointy] = 2;
                        if (count == 1)treezoneship++;
                        if (count == 2)fourzoneship++;
                    }
                    if (count == 0) twozoneship++;
                    count = 0;
                    
                       
                }
            }




            // vertical ship
            if(startPointx == endPointx && startPointy != endPointy)                        
            {

                if (startPointy > endPointy)
                {
                    for (byte epy = (byte)(endPointy + 1); epy < startPointy; epy++)
                    {
                        count++;
                        ocean[startPointx,epy] = "S";
                        oceanmanol[startPointx,epy] = 2;
                        if (count == 1) treezoneship++;
                        if (count == 2) fourzoneship++;
                    }
                    if (count == 0) twozoneship++;
                    count = 0;
                }
            }

                if (startPointy < endPointy) 
                {
                    for (byte spy = (byte)(startPointy + 1); spy < endPointy;spy++)
                    {
                        count++;
                        if (count == 1) treezoneship++;
                        if (count == 2) fourzoneship++;
                        ocean[startPointx,spy] = "S";
                        oceanmanol[startPointx,spy] = 2;
                    }
                    if (count == 0) twozoneship++;
                    count = 0;
            }

        }







        // is the ship damaged
        public bool HitPoint(Point point)  
        {
            byte pointx = (byte)point.X;
            byte pointy = (byte)point.Y;
            if (oceanmanol[pointx,pointy] == 2)
            {
                oceanmanol[pointx, pointy] = 3;
            }
            
            return true;
        }





        // can u make a ship 
        public bool CheckShip(Ship ship)
        {
            if (onezoneship > 2)
            {
                return false;
            }

                return true;
        }




        //can u hit this point (again)
        public bool CheckPoint(Point point)
        {
            return true;
        }
    }
}
