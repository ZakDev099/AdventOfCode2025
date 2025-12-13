namespace Day5Puzzle2;



class Program
{
    static void Main(string[] args)
    {

        List<long> id_List = [];
        List<(long min, long max)?> id_Ranges = [];

        try
        {
            using (StreamReader sr = new StreamReader("inputSource.txt"))
            {
                string? line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (Utils.TrySplitStringToRange(line, '-', out var id_Range))
                    {
                        id_Ranges.Add(id_Range);
                    }
                    else if (long.TryParse(line, out long id))
                    {
                        id_List.Add(id);
                    }
                    else if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
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



        if (id_List == null)
        {
            Console.WriteLine("Error: failed to load IDs");
            return;
        }
        else if (id_Ranges == null)
        {
            Console.WriteLine("Error: failed to load ID Ranges");
            return;
        }

        int validIdCount = 0;
        foreach (long id in id_List)
        {
            foreach ((long min, long max) rng in id_Ranges)
            {
                if (rng.min <= id && id <= rng.max)
                {
                    validIdCount++;
                    break;
                }
            }
        }

        Console.WriteLine(validIdCount);
    }
}
