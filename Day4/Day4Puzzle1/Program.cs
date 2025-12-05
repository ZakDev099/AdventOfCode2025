using System.Diagnostics;

namespace Day4Puzzle1;

class Program
{
    static void Main(string[] args)
    {
        int accessibleRolls = 0;
        int accessibilityRequirement = 3;
        bool[,]? mineField = null;

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

                mineField = new bool[rows.Count, rows[0].Count];

                for (int row = 0; row < rows.Count; row++)
                {
                    for (int col = 0; col < rows[row].Count; col++)
                    {
                        try
                        {
                            mineField[row, col] = rows[row][col];
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

        if (mineField != null)
        {
            Minefield mines = new(mineField);
            MineSweeper mineSweeper = new(mines);

            foreach (bool mine in mineSweeper.Minefield.Mines)
            {
                if (mine)
                {
                    if (mineSweeper.SweepImmediateArea(1) <= accessibilityRequirement)
                    {
                        accessibleRolls++;
                    }

                    mineSweeper.StepDown();
                }
            }
        }

        Console.WriteLine(accessibleRolls);
    }
}
