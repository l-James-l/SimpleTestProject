namespace Project;

public class BasicBooleanFunctions
{
    public bool And(bool a, bool b)
    {
        return a && b;
    }

    public bool Or(bool a, bool b)
    {
        return a || b;
    }

    public bool Not(bool a)
    {
        return !a;
    }

    public bool Xor(bool a, bool b)
    {
        return And(Or(a, b), Not(And(a, b)));
    }

    public bool Nand(bool a, bool b)
    {
        return Not(And(a, b));
    }
}
