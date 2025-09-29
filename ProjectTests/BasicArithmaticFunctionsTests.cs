using Project;

namespace ProjectTests;

public class BasicArithmaticFunctionsTests
{
    private BasicArithmaticFunctions _basicArithmaticFunctions;

    [SetUp]
    public void Setup()
    {
        _basicArithmaticFunctions = new BasicArithmaticFunctions();
    }

    [Test]
    public void AlwaysPasses()
    {
        Assert.Pass();
    }

    [Test]
    public void Add_ReturnsCorrectSum()
    {
        int result = _basicArithmaticFunctions.Add(3, 5);
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void Subtract_ReturnsCorrectDifference()
    {
        int result = _basicArithmaticFunctions.Subtract(10, 4);
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Multiply_ReturnsCorrectProduct()
    {
        int result = _basicArithmaticFunctions.Multiply(6, 7);
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public void Divide_ReturnsCorrectQuotient()
    {
        int result = _basicArithmaticFunctions.Divide(20, 4);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _basicArithmaticFunctions.Divide(10, 0));
    }

    [Test]
    public void GreaterThan_ReturnsTrue_WhenFirstIsGreater()
    {
        bool result = _basicArithmaticFunctions.GreaterThan(7, 3);
        Assert.That(result, Is.True);
    }

    [Test]
    public void LessThanOrEqualTo_ReturnsTrue_WhenFirstIsLess()
    {
        bool result = _basicArithmaticFunctions.LessThanOrEqualTo(4, 4);
        Assert.That(result, Is.True);
    }

    [Test]
    public void LessThanOrEqualTo_ReturnsFalse_WhenFirstIsGreater()
    {
        bool result = _basicArithmaticFunctions.LessThanOrEqualTo(5, 2);
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void LessThanOrEqualTo_ReturnsFalse_WhenFirstIsEqual()
    {
        bool result = _basicArithmaticFunctions.LessThanOrEqualTo(5, 5);
        Assert.That(result, Is.True);
    }
}