using System.Globalization;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace Day2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (StreamReader sr = new StreamReader("inputSource.txt"))
            {
                string[] substrings = sr.ReadToEnd().Split(',');
                ID_Validator id_Val = new(substrings);

                long invalidSum = 0;
                foreach (long id in id_Val.Invalid_IDs)
                {
                    invalidSum += id;
                }

                Console.WriteLine($"The total sum of invalid ID's is: {invalidSum}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
}
