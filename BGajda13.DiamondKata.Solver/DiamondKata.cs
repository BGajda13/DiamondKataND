using System.Text;

namespace BGajda13.DiamondKata.Solver;

public static class DiamondKata
{
    private const char CharA = 'A';

    public static string Solve(char input)
    {
        CheckInput(input);
        
        var numberOfLevels = CalculateNumberOfLevels(input);
        var levelsSequence = GenerateLevelsSequence(input);
        var charsWithPaddings = CalculatePaddings(levelsSequence, numberOfLevels);

        var levels = charsWithPaddings
            .Select(x => BuildLevel(x.Item1, x.left, x.inner)).ToList()
            .MirrorVertically()
            ;

        return string.Join(Environment.NewLine, levels);
    }

    private static void CheckInput(char input)
    {
        if (input is < 'A' or > 'Z')
        {
            throw new ArgumentOutOfRangeException(nameof(input));
        }
    }
    
    public static int CalculateNumberOfLevels(char input)
    {
        return input - CharA + 1;
    }

    public static IEnumerable<char> GenerateLevelsSequence(char input)
    {
        var currentChar = CharA;
        
        while (currentChar < input)
        {
            yield return currentChar;
            currentChar++;
        }

        yield return input;
    }

    public static IEnumerable<(char, int left, int inner)> CalculatePaddings(IEnumerable<char> input, int numberOfLevels)
    {
        return input.Select((c, i) => (c, left: numberOfLevels - i - 1, inner: 2 * i - 1));
    }
    
    public static string BuildLevel(char c, int leftPadding, int innerSpace)
    {
        var sb = new StringBuilder(c.ToString().PadLeft(leftPadding + 1));
        
        if (innerSpace <= 0)
        {
            return sb.ToString();
        }

        sb.Append(c.ToString().PadLeft(innerSpace + 1));

        return sb.ToString();
    }
    
    public static List<T> MirrorVertically<T>(this List<T> levels)
    {
        levels.AddRange(levels.Take(levels.Count - 1).Reverse());

        return levels;
    }
}
