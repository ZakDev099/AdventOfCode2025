using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Puzzle2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (StreamReader sr = new StreamReader("inputSource.txt"))
            {
                int totalGenerators = 12;
                List<string> maxJoltages = new();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    int arrayIndex = 0;
                    int[] flippedLine = new int[line.Length];

                    foreach (char c in line.Reverse())
                    {
                        flippedLine[arrayIndex] = (int)char.GetNumericValue(c);
                        arrayIndex++;
                    }

                    string maxJoltage = string.Empty;
                    int lastGreatestIndex = flippedLine.Length;

                    for (int charPos = totalGenerators - 1; charPos >= 0; charPos--)
                    {
                        (int index, int value) greatestNum = (0, 0);

                        for (int i = charPos; i < lastGreatestIndex; i++)
                        {
                            if (flippedLine[i] >= greatestNum.value)
                            {
                                greatestNum.value = flippedLine[i];
                                greatestNum.index = i;
                            }
                        }

                        lastGreatestIndex = greatestNum.index;
                        maxJoltage += greatestNum.value;
                    }

                    maxJoltages.Add(maxJoltage);
                }

                long totalJoltage = 0;
                foreach (string i in maxJoltages)
                {
                    var iLong = long.Parse(i);
                    totalJoltage += iLong;
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
