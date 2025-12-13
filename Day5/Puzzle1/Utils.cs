using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Day5Puzzle1
{
    public static class Utils
    {
        public static bool TrySplitStringToRange(string input, char delimiter, out (long min, long max)? id_Range)
        {
            id_Range = null;

            if (input.Contains(delimiter))
            {
                var splitLine = input.Split('-');

                if (!long.TryParse(splitLine[0], out long val1) || !long.TryParse(splitLine[1], out long val2)) 
                    return false;
                else
                    id_Range = (val1 > val2) ? id_Range = (val2, val1) : id_Range = (val1, val2);
                    return true;
            }
            else return false;
        }
    }
}