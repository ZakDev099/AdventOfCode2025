class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (StreamReader sr = new StreamReader("inputSource.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
