using System.Reflection;

namespace Puzzle2;

public class Password
{
    public int ZeroCount = 0;
    private int numTracker = 50;
    public int NumTracker
    {
        get => numTracker;
        set
        {
            if (value >= 100)
            {
                ZeroCount += value / 100;
            }
            else if (value <= 0)
            {
                if (numTracker != 0)
                {
                    ZeroCount++;
                }
                ZeroCount += value * -1 / 100;
            }

            numTracker = ((value % 100) + 100) % 100;
        }
    }


    public void RotateDial(string input)
    {
        if (input[0] == 'R')
        {
            input = input.TrimStart(input[0]);
            NumTracker = NumTracker + int.Parse(input);
        }
        else 
        {
            input = input.TrimStart(input[0]);
            NumTracker = NumTracker - int.Parse(input);
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Password password = new();
        try
        {
            using (StreamReader sr = new StreamReader("inputSource.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Console.WriteLine($"Current Number:{password.NumTracker}");
                    password.RotateDial(line);
                    // Console.WriteLine($"{line} => {password.NumTracker}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        Console.WriteLine(password.ZeroCount);
    }
}
