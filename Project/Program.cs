namespace Project;
public class Program
{
    public static void Main(string[] args)
    {
        // Entry point for the application.
        //Will execute some functions to prove build is successful.

        BasicArithmaticFunctions mathFuncs = new BasicArithmaticFunctions();
        int sum = mathFuncs.Add(5, 7);
        Console.WriteLine($"Sum of 5 and 7 is: {sum}");
        int minus = mathFuncs.Subtract(10, 3);
        Console.WriteLine($"Difference of 10 and 3 is: {minus}");
    }
}
