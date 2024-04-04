using BGajda13.DiamondKata.Solver;

if (args.Length != 1)
{
    Console.Error.WriteLine("Argument Error. There must be one argument");
    Environment.Exit(1);
}

if (args[0].Length > 1)
{
    Console.Error.WriteLine("Argument Error. There should be only one char");
    Environment.Exit(1);
}
try
{
    Console.Write(DiamondKata.Solve(args[0][0]));
}
catch (ArgumentOutOfRangeException)
{
    Console.Error.WriteLine("Char out of range. Accepting A-Z only");
    Environment.Exit(1);
}
