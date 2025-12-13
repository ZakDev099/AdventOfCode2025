using System.Linq;

namespace Day5Puzzle2;



class Program
{
    static void Main(string[] args)
    {
        List<(long min, long max)?> ID_Ranges = [];

        try
        {
            using (StreamReader sr = new StreamReader("inputSource.txt"))
            {
                string? line;


                while (!string.IsNullOrWhiteSpace(line = sr.ReadLine()) && line != null)
                {
                    if (Utils.TrySplitStringToRange(line, '-', out var id_Range))
                    {
                        ID_Ranges.Add(id_Range);
                    }
                    else
                    {
                        Console.WriteLine("Error: failed to parse a line in input");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        if (ID_Ranges == null || ID_Ranges.Count < 1)
        {
            Console.WriteLine("Error: failed to load ID Ranges");
            return;
        }

        // Checking if any ranges interfere and correcting them
        List<(long min, long max)?> sorted_ID_Ranges = ID_Ranges.OrderBy(x => x!.Value.min).ToList();
        List<(long min, long max)> new_ID_Ranges = [];
        int lastIndex = -1;

        foreach ((long min, long max) range in sorted_ID_Ranges!)
        {
            if (lastIndex < 0)
            {
                new_ID_Ranges.Add(range);
            }
            else
            {
                var lastRange = new_ID_Ranges[lastIndex];
                
                if (lastRange.min <= range.min && range.min <= lastRange.max)
                {
                    if (range.max > lastRange.max)
                    {
                        new_ID_Ranges[lastIndex] = (lastRange.min, range.max);
                        continue;
                    }
                    else continue;
                }
                else 
                    new_ID_Ranges.Add(range);
            }

            lastIndex++;
        }


        // Now counting all possible valid IDs
        long valid_ID_Count = 0;

        foreach (var range in new_ID_Ranges)
        {
            valid_ID_Count += range.max - range.min + 1;
        }


        Console.WriteLine(valid_ID_Count);
    }
}
