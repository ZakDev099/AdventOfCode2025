namespace Day5Puzzle1;



class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (StreamReader sr = new StreamReader("inputSource.txt"))
            {
                List<int> id_List = [];
                List<Range> id_Ranges = [];

                string? line;

                while (!string.IsNullOrWhiteSpace(line = sr.ReadLine()))
                {
                    if (Utils.TrySplitStringToRange(line, '-', out var id_Range))
                    {
                        id_Ranges.Add((Range)id_Range!);
                    }
                    else if (int.TryParse(line, out int id))
                    {
                        id_List.Add(id);
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
    }
}
