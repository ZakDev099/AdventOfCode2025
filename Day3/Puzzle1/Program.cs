using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Puzzle1;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (StreamReader sr = new StreamReader("inputSource.txt"))
            {
                List<int> maxJoltages = new();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string maxJoltage = "00";

                    foreach (char c in line)
                    {
                        var maxJ = Int32.Parse(maxJoltage);

                        if (maxJ < Int32.Parse($"{maxJoltage[1]}{c}"))
                        {
                            maxJoltage = $"{maxJoltage[1]}{c}";
                        }
                        else if (maxJ < Int32.Parse($"{maxJoltage[0]}{c}"))
                        {
                            maxJoltage = $"{maxJoltage[0]}{c}";
                        }
                    }

                    maxJoltages.Add(Int32.Parse(maxJoltage));
                }

                int totalJoltage = 0;
                foreach (int i in maxJoltages)
                {
                    totalJoltage += i;
                }

                Console.WriteLine(totalJoltage);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
