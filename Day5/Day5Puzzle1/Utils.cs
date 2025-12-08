using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day5Puzzle1
{
    public static class Utils
    {
        public static bool TrySplitStringToRange(string input, char delimiter, out Range? id_Range)
        {
            id_Range = null;

            if (input.Contains(delimiter))
            {
                var splitLine = input.Split('-');

                if (!int.TryParse(splitLine[0], out int val1) || !int.TryParse(splitLine[1], out int val2)) 
                    return false;
                else
                    id_Range = (val1 > val2) ? val2..val1 : val1..val2;
                    return true;
            }
            else return false;
        }
    }
}