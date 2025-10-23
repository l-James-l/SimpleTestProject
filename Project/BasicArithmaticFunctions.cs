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

    public int HCF(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }

    public int LCM(int a, int b)
    {
        if (a == 0 || b == 0)
        {
            throw new ArgumentException("Numbers must be non-zero.");
        }
        return Math.Abs(a * b) / HCF(a, b);
    }
}
