using System.Text;

namespace BGajda13.DiamondKata.Solver;

public static class DiamondKata
{
    private const char CharA = 'A';
    private const char CharSpace = ' ';

    public static string Solve(char input)
    {
        CheckInput(input);
        return PrepareString(input);
    }
    
    private static void CheckInput(char input)
    {
        if (input < 65 || input > 90)
        {
            throw new ArgumentOutOfRangeException(nameof(input));
        }
    }
    
    private static string PrepareString(char input)
    {
        var inputCharDistanceToCharA = input - CharA;
        
        var result = new List<StringBuilder>();
        var currentChar = input;
        
        do
        {
            var line = new StringBuilder();
            var currentCharDistanceToCharA = currentChar - CharA;
            var printableChar = (char)( input - currentCharDistanceToCharA);
            
            // Adding left padding
            for (var i = 0; i < currentCharDistanceToCharA; i++)
            {
                line.Append(CharSpace);
            }
            
            line.Append(printableChar);
    
            // Adding inner space 
            for (var i = 0; i < 2 * (inputCharDistanceToCharA - currentCharDistanceToCharA) - 1; i++)
            {
                line.Append(CharSpace);
            }

            if (inputCharDistanceToCharA - currentCharDistanceToCharA > 0)
            {
                line.Append(printableChar);
            }
    
            currentChar = (char)(currentChar - 1);
            result.Add(line);
        } while (currentChar >= CharA);

        if (result.Count > 1)
        {
            result.AddRange(result.Take(result.Count - 1).Reverse());
        }

        var final = string.Join(Environment.NewLine, result.Select(sb => sb.ToString()));

        return final;
    }
}
