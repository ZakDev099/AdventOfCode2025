using System.Diagnostics;

namespace Day4Puzzle1;

class Program
{
    static void Main(string[] args)
    {
        int accessibleRolls = 0;
        int accessibilityRequirement = 4;
        bool[,]? mines = null;

        try
        {
            using (StreamReader sr = new StreamReader("inputSource.txt"))
            {
                string? line;
                char mine = '@';
                List<List<bool>> rows = [];

                while ((line = sr.ReadLine()) != null)
                {
                    List<bool> columns = [];

                    foreach (char c in line)
                    {
                        if (c == mine)
                        {
                            columns.Add(true);
                        }
                        else
                        {
                            columns.Add(false);
                        }
                    }

                    rows.Add(columns);
                }

                mines = new bool[rows[0].Count, rows.Count];

                for (int row = 0; row < rows.Count; row++)
                {
                    for (int col = 0; col < rows[row].Count; col++)
                    {
                        try
                        {
                            mines[col, row] = rows[row][col];
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("ERROR:: Grid shape must be rectangular");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if (mines != null)
        {
            Minefield minefield = new(mines);
            MineSweeper mineSweeper = new(minefield);

            for (int i = 0; i < mineSweeper.Minefield.CellCount; i++)
            {
                if (mineSweeper.IsMineFound)
                {
                    if (mineSweeper.SweepImmediateArea(1) <= accessibilityRequirement)
                    {
                        accessibleRolls++;
                    }
                }

                mineSweeper.StepDown();
            }
        }

        Console.WriteLine(accessibleRolls);
    }
}
