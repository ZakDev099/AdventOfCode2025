using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Day4Puzzle1
{
    public class Minefield(bool[,] mines)
    {
        public bool[,] Mines = mines;
        public int Width = mines.GetLength(0);        
        public int Height = mines.GetLength(1);
        public int CellCount => Width * Height;
    }
}