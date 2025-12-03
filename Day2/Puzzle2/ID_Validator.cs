using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2;

public class ID_Validator
{
    public List<long> Valid_IDs = [];
    public List<long> Invalid_IDs = [];
    private List<(long floor, long ceiling)> id_Ranges = [];

    public ID_Validator(string[] data)
    {
        foreach (string ss in data)
        {
            if (ValidateRange(ss, out var result)) 
            {
                id_Ranges.Add(result);
            }
        }

        foreach (var id_Range in id_Ranges)
        {
            for (long i = id_Range.floor; i <= id_Range.ceiling; i++)
            {
                switch (Validate_ID(i))
                {
                    case true:
                        Valid_IDs.Add(i);
                        break;

                    case false:
                        Invalid_IDs.Add(i);
                        break;
                }
            }
        }
    }


    // Removes whitespace and checks if the string is empty, verifies the string characters are valid,
    // then splits the string into an integer pair
    public static bool ValidateRange(string input, out (long floor, long ceiling) result)
    {
        result = new();
        if (string.IsNullOrWhiteSpace(input)) 
            return false;
        
        string validatedString = string.Empty;
        foreach (char i in input)
        {
            // Confirming the new string has only numbers and hyphens
            if (char.IsAsciiDigit(i) || i == '-')
                validatedString += i;
        }

        var stringParts = validatedString.Split('-');

        if(stringParts.Length == 2 && stringParts[0].Length > 0 && stringParts[1].Length > 0)
        {
            result.floor = long.Parse(stringParts[0]);
            result.ceiling = long.Parse(stringParts[1]);
            return true;
        }
        else 
            return false;
        
    }

    public static bool Validate_ID(long id_num)
    {
        string id = id_num.ToString();

        // If ID starts with a 0 -> invalid
        if (id[0] == '0') 
            return false;  
        
        List<int> factors = new();

        for (int i = 1; i <= id.Length / 2; i++)
        {
            if (id.Length % i == 0)
                factors.Add(i);
        }

        foreach (int factor in factors)
        {
            List<string> stringParts = [];
            bool isMatch = true;
            int index = 0;

            for (int i = 0; i < id.Length; i += factor)
            {
                stringParts.Add(id.Substring(i, factor));

                if (stringParts.Count > 1 && stringParts[index] != stringParts[index-1])
                {
                    isMatch = false;
                    break;
                }

                index++;
            }

            if (isMatch == true)
                return false;
        }

        // Finally, ID is valid if no other conditions were met
        return true;
    }
}