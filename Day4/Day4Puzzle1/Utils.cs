using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Day4Puzzle1
{
    public static class Utils
    {
        public static int KeepWithinRange (int input, Range range)
        {
            if (input > range.End.Value)
            {
                return range.End.Value;
            }
            else if (input < range.Start.Value)
            {
                return range.Start.Value;
            }
            
            return input;
        }
    }
}