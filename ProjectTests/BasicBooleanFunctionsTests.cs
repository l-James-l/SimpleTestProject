using Project;

namespace ProjectTests;

public class BasicBooleanFunctionsTests
{
    private BasicBooleanFunctions _booleanFunctions;

    [SetUp]
    public void Setup()
    {
        _booleanFunctions = new BasicBooleanFunctions();
    }

    [Test]
    public void GivenTwoBooleans_WhenAnd_ThenReturnsLogicalAnd()
    {
        // Arrange & Act & Assert
        Assert.That(_booleanFunctions.And(true, true), Is.True);
        Assert.That(_booleanFunctions.And(true, false), Is.False);
    }

    [Test]
    public void GivenTwoBooleans_WhenOr_ThenReturnsLogicalOr()
    {
        // Arrange & Act & Assert
        Assert.That(_booleanFunctions.Or(false, false), Is.False);
        Assert.That(_booleanFunctions.Or(true, false), Is.True);
    }

    [Test]
    public void GivenBoolean_WhenNot_ThenReturnsNegation()
    {
        // Arrange & Act & Assert
        Assert.That(_booleanFunctions.Not(true), Is.False);
        Assert.That(_booleanFunctions.Not(false), Is.True);
    }

    [Test]
    public void GivenTwoBooleans_WhenXor_ThenBehavesAsExclusiveOr()
    {
        // Arrange & Act & Assert
        Assert.That(_booleanFunctions.Xor(true, false), Is.True);
        Assert.That(_booleanFunctions.Xor(true, true), Is.False);
        Assert.That(_booleanFunctions.Xor(false, false), Is.False);
        Assert.That(_booleanFunctions.Xor(false, true), Is.True);
    }

    [Test]
    public void GivenTwoBooleans_WhenNand_ThenReturnsNegationOfAnd()
    {
        // Arrange & Act & Assert
        Assert.That(_booleanFunctions.Nand(true, true), Is.False);
        Assert.That(_booleanFunctions.Nand(true, false), Is.True);
    }
}