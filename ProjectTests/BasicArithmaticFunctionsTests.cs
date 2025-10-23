using Project;

namespace ProjectTests;

public class BasicArithmaticFunctionsTests
{
    private BasicArithmaticFunctions _mathsFunctions;

    [SetUp]
    public void Setup()
    {
        _mathsFunctions = new BasicArithmaticFunctions();
    }

    [Test]
    public void GivenTwoIntegers_WhenAdd_ThenReturnsTheirSum()
    {
        // Arrange
        int a = 3, b = 5;

        // Act
        int result = _mathsFunctions.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void GivenTwoIntegers_WhenSubtract_ThenReturnsTheirDifference()
    {
        // Arrange
        int a = 10, b = 4;

        // Act
        int result = _mathsFunctions.Subtract(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void GivenTwoIntegers_WhenMultiply_ThenReturnsTheirProduct()
    {
        // Arrange
        int a = 6, b = 7;

        // Act
        int result = _mathsFunctions.Multiply(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public void GivenNonZeroDenominator_WhenDivide_ThenReturnsQuotient()
    {
        // Arrange
        int a = 20, b = 4;

        // Act
        int result = _mathsFunctions.Divide(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void GivenZeroDenominator_WhenDivide_ThenThrowsDivideByZeroException()
    {
        // Arrange
        int a = 10, b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _mathsFunctions.Divide(a, b));
    }

    [Test]
    public void GivenTwoIntegers_WhenHCF_ThenReturnsGreatestCommonFactor()
    {
        // Arrange
        int a = 54, b = 24;

        // Act
        int result = _mathsFunctions.HCF(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void GivenNegativeInputs_WhenHCF_ThenReturnsPositiveHCF()
    {
        // Arrange
        int a = -8, b = 12;

        // Act
        int result = _mathsFunctions.HCF(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void GivenNonZeroIntegers_WhenLCM_ThenReturnsLeastCommonMultiple()
    {
        // Arrange
        int a = 4, b = 6;

        // Act
        int result = _mathsFunctions.LCM(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(12));
    }

    [Test]
    public void GivenZeroInput_WhenLCM_ThenThrowsArgumentException()
    {
        // Arrange
        int a = 0, b = 5;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _mathsFunctions.LCM(a, b));
    }
}