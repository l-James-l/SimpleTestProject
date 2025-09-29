namespace Project;

public class BasicArithmaticFunctions
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        return b != 0 ? a / b : throw new DivideByZeroException("Denominator cannot be zero.");
    }

    public bool GreaterThan(int a, int b)
    {
        return a > b;
    }

    public bool LessThanOrEqualTo(int a, int b)
    {
        return a <= b;
    }
}
