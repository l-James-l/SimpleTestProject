using NSubstitute;
using Project;

namespace ProjectTests;

public class BinarySearchTests
{
    private BinarySearch _binarySearch;  //_binarySearch

    private IOrderChecker _orderChecker;

    [SetUp]
    public void SetUp()
    {
        _orderChecker = Substitute.For<IOrderChecker>();

        _binarySearch = new BinarySearch(_orderChecker);
    }

    [Test]
    public void GivenOrderedNumericList_WhenNumericBinarySearch_TargetExists_ThenReturnsIndex()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4, 5 };
        int target = 4;

        // Act
        int? result = _binarySearch.NumericBinarySearch(list, target);

        // Assert
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void GivenUnorderedNumericList_WhenNumericBinarySearch_ThenReturnsNull()
    {
        // Arrange
        _orderChecker.IsOrdered(Arg.Any<List<int>>(), Arg.Any<Func<int, int, int>>()).Returns(false);
        var list = new List<int> { 1, 2, 3, 4, 5 };
        int target = 3;

        // Act
        int? result = _binarySearch.NumericBinarySearch(list, target);

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenOrderedNumericList_WhenNumericBinarySearch_TargetMissing_ThenReturnsNull()
    {
        // Arrange
        _orderChecker.IsOrdered(Arg.Any<List<int>>(), Arg.Any<Func<int, int, int>>()).Returns(true);
        var list = new List<int> { 1, 2, 3, 4, 5 };
        int target = 10;

        // Act
        int? result = _binarySearch.NumericBinarySearch(list, target);

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenEmptyList_WhenGenericBinarySearch_ThenReturnsNull()
    {
        // Arrange
        _orderChecker.IsOrdered(Arg.Any<List<int>>(), Arg.Any<Func<int, int, int>>()).Returns(true);
        var empty = new List<int>();
        int target = 1;
        Func<int, int, int> comparer = (a, b) => a < b ? -1 : a > b ? 1 : 0;

        // Act
        int? result = _binarySearch.GenericBinarySearch(empty, comparer, target);

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenOrderedGenericList_WhenGenericBinarySearch_WithCustomComparer_ThenReturnsIndex()
    {
        // Arrange
        var orderChecker = Substitute.For<IOrderChecker>();
        orderChecker.IsOrdered(Arg.Any<List<string>>(), Arg.Any<Func<string, string, int>>()).Returns(true);
        var _binarySearch = new BinarySearch(orderChecker);

        var list = new List<string> { "a", "b", "c" };
        string target = "b";
        Func<string, string, int> comparer = (x, y) =>
        {
            int cmp = string.CompareOrdinal(x, y);
            return cmp < 0 ? -1 : cmp > 0 ? 1 : 0;
        };

        // Act
        int? result = _binarySearch.GenericBinarySearch(list, comparer, target);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void GivenComparatorReturnsInvalidValue_WhenGenericBinarySearch_ThenThrowsArgumentOutOfRangeException()
    {
        // Arrange
        _orderChecker.IsOrdered(Arg.Any<List<int>>(), Arg.Any<Func<int, int, int>>()).Returns(true);
        var list = new List<int> { 1 };
        int target = 1;
        Func<int, int, int> badComparer = (a, b) => 2; // invalid comparator return value

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _binarySearch.GenericBinarySearch(list, badComparer, target));
    }

    [Test]
    public void GivenSingleItemList_WhenGenericBinarySearch_TargetIsItem_ThenReturnsZero()
    {
        // Arrange
        _orderChecker.IsOrdered(Arg.Any<List<int>>(), Arg.Any<Func<int, int, int>>()).Returns(true);
        var list = new List<int> { 42 };
        int target = 42;
        Func<int, int, int> comparer = (a, b) => a < b ? -1 : a > b ? 1 : 0;

        // Act
        int? result = _binarySearch.GenericBinarySearch(list, comparer, target);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }
}