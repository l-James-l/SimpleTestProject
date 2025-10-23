using Project;

namespace ProjectTests;

public class BasicLinqOperationTests
{
    private BasicLinqOperation _linqFunctions;

    [SetUp]
    public void Setup()
    {
        _linqFunctions = new BasicLinqOperation();
    }

    [Test]
    public void GivenMixedNumbers_WhenFilterEvenNumbers_ThenReturnsOnlyEvens()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3, 4, 5 };

        // Act
        var result = _linqFunctions.FilterEvenNumbers(input);

        // Assert
        Assert.That(result, Is.EquivalentTo(new[] { 2, 4 }));
    }

    [Test]
    public void GivenAllEvenNumbers_WhenAreAllEven_ThenReturnsTrue()
    {
        // Arrange
        var input = new List<int> { 2, 4, 6 };

        // Act
        var result = _linqFunctions.AreAllEven(input);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void GivenNotAllEvenNumbers_WhenAreAllEven_ThenReturnsFalse()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3 };

        // Act
        var result = _linqFunctions.AreAllEven(input);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void GivenAtLeastOneEven_WhenAnyEven_ThenReturnsTrue()
    {
        // Arrange
        var input = new List<int> { 1, 3, 4 };

        // Act
        var result = _linqFunctions.AnyEven(input);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void GivenNoEven_WhenAnyEven_ThenReturnsFalse()
    {
        // Arrange
        var input = new List<int> { 1, 3, 5 };

        // Act
        var result = _linqFunctions.AnyEven(input);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void GivenUniformElements_WhenAreMinAndMaxEqual_ThenReturnsTrue()
    {
        // Arrange
        var input = new List<int> { 5, 5, 5 };

        // Act
        var result = _linqFunctions.AreMinAndMaxEqual(input);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void GivenEmptyList_WhenAreMinAndMaxEqual_ThenThrowsInvalidOperationException()
    {
        // Arrange
        var input = new List<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _linqFunctions.AreMinAndMaxEqual(input));
    }

    [Test]
    public void GivenDuplicates_WhenAnyDuplicated_ThenReturnsTrue()
    {
        // Arrange
        var input = new List<int> { 1, 2, 2, 3 };

        // Act
        var result = _linqFunctions.AnyDuplicated(input);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void GivenAllUnique_WhenAnyDuplicated_ThenReturnsFalse()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3 };

        // Act
        var result = _linqFunctions.AnyDuplicated(input);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void GivenBothEmpty_WhenAnyUnique_ThenReturnsFalse()
    {
        // Arrange
        var a = new List<int>();
        var b = new List<int>();

        // Act
        var result = _linqFunctions.AnyUnique(a, b);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void GivenFirstHasUnique_WhenAnyUnique_ThenReturnsTrue()
    {
        // Arrange
        var a = new List<int> { 1, 2, 3 };
        var b = new List<int> { 2, 3 };

        // Act
        var result = _linqFunctions.AnyUnique(a, b);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void GivenOrderedList_WhenIsOrdered_ThenReturnsTrue()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3, 4 };

        // Act
        var result = _linqFunctions.IsOrdered(input);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void GivenUnorderedList_WhenIsOrdered_ThenReturnsFalse()
    {
        // Arrange
        var input = new List<int> { 1, 3, 2 };

        // Act
        var result = _linqFunctions.IsOrdered(input);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void GivenEmptyOrSingleElement_WhenIsOrdered_ThenReturnsTrue()
    {
        // Arrange & Act & Assert
        Assert.That(_linqFunctions.IsOrdered(new List<int>()), Is.True);
        Assert.That(_linqFunctions.IsOrdered(new List<int> { 1 }), Is.True);
    }
}