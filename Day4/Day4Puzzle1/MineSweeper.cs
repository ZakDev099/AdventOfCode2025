using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Day4Puzzle1
{
    public class MineSweeper(Minefield minefield)
    {
        public Minefield Minefield = minefield;

        private int yPos = 0;
        public int YPos
        {
            get => yPos;
            set { yPos = ((value % Minefield.Height) + Minefield.Height) % Minefield.Height; }
            
        }
        private int xPos = 0;
        public int XPos
        {
            get => xPos;
            set { xPos = ((value % Minefield.Width) + Minefield.Width) % Minefield.Width; }
        }

        public int NorthBound => yPos * -1;
        public int EastBound => Minefield.Width - 1 - xPos;
        public int SouthBound => Minefield.Height - 1 - yPos;
        public int WestBound => xPos * -1;

        public bool IsMineFound => Minefield.Mines[XPos, YPos];


        public void Step(int x = 1, int y = 0)
        {
            XPos += x;
            YPos += y;
        }

        public void StepTo(int x, int y)
        {
            XPos = x;
            YPos = y;
        }

        public void StepDown(int steps = 1, bool moveVertically = false)
        {
            if (!moveVertically)
            {
                if (steps > EastBound)
                {
                    YPos += (XPos + steps) / Minefield.Width;
                }
                else if (steps < WestBound)
                {
                    YPos += (XPos + steps) / Minefield.Width - 1;
                }

                XPos += steps;
            }
            else
            {
                if (steps > SouthBound)
                {
                    XPos += (YPos + steps) / Minefield.Width;
                }
                else if (steps < NorthBound)
                {
                    XPos += (YPos + steps) / Minefield.Width - 1;
                }

                YPos += steps;
            }
            
        }

        public int SweepMinefield()
        {
            int minesFound = 0;

            foreach (bool mine in Minefield.Mines)
            {
                if (mine)
                {
                    minesFound++;
                }
            }

            return minesFound;
        }

        public int SweepImmediateArea(int searchRadius)
        {
            if (searchRadius < 1)
            {
                return 0;
            }

            // Limiting search radius by bounds..
            int northRadius = Utils.KeepWithinRange(searchRadius, ..(NorthBound * -1));
            int eastRadius = Utils.KeepWithinRange(searchRadius, ..EastBound);
            int southRadius = Utils.KeepWithinRange(searchRadius, ..SouthBound);
            int westRadius = Utils.KeepWithinRange(searchRadius, ..(WestBound * -1));

            (int x, int y) zoneStartPos = (XPos - westRadius, YPos - northRadius);
            (int x, int y) zoneEndPos = (XPos + eastRadius, YPos + southRadius);

            bool[,] targetArea = new bool[zoneEndPos.y - zoneStartPos.y, zoneEndPos.x - zoneStartPos.x];
            
            for (int y = zoneStartPos.y; y < zoneEndPos.y; y++)
            {
                for (int x = zoneStartPos.x; x < zoneEndPos.x; x++)
                {
                    targetArea[x - zoneStartPos.x, y - zoneStartPos.y] = Minefield.Mines[x, y];
                }
            }

            MineSweeper subSweeper = new(new Minefield (targetArea));

            return subSweeper.SweepMinefield();
        }
    }
}