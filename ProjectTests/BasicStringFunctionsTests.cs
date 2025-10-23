using Project;

namespace ProjectTests;

public class BasicStringFunctionsTests
{
    private BasicStringFunctions _stringFunctions;

    [SetUp]
    public void Setup()
    {
        _stringFunctions = new BasicStringFunctions();
    }

    [Test]
    public void GivenTwoStrings_WhenConcatenate_ThenReturnsJoinedString()
    {
        // Arrange
        string a = "Hello", b = "World";

        // Act
        var result = _stringFunctions.Concatenate(a, b);

        // Assert
        Assert.That(result, Is.EqualTo("HelloWorld"));
    }

    [Test]
    public void GivenMixedCaseString_WhenToUpperCase_ThenReturnsUppercase()
    {
        // Arrange
        string s = "abC";

        // Act
        var result = _stringFunctions.ToUpperCase(s);

        // Assert
        Assert.That(result, Is.EqualTo("ABC"));
    }

    [Test]
    public void GivenMixedCaseString_WhenToLowerCase_ThenReturnsLowercase()
    {
        // Arrange
        string s = "AbC";

        // Act
        var result = _stringFunctions.ToLowerCase(s);

        // Assert
        Assert.That(result, Is.EqualTo("abc"));
    }

    [Test]
    public void GivenString_WhenReverse_ThenReturnsReversedString()
    {
        // Arrange
        string s = "abcd";

        // Act
        var result = _stringFunctions.Reverse(s);

        // Assert
        Assert.That(result, Is.EqualTo("dcba"));
    }

    [Test]
    public void GivenValidIndices_WhenGetSubstring_ThenReturnsSubstring()
    {
        // Arrange
        string s = "Hello";

        // Act
        var result = _stringFunctions.GetSubstring(s, 1, 3);

        // Assert
        Assert.That(result, Is.EqualTo("ell"));
    }

    [Test]
    public void GivenInvalidIndices_WhenGetSubstring_ThenThrowsArgumentOutOfRangeException()
    {
        // Arrange
        string s = "Hi";

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _stringFunctions.GetSubstring(s, 1, 5));
        Assert.Throws<ArgumentOutOfRangeException>(() => _stringFunctions.GetSubstring(s, -1, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _stringFunctions.GetSubstring(s, 0, -1));
    }
}