using Project;

namespace ProjectTests;

public class MergeSorterTests
{
    private MergeSorter _mergeSorter;  //SUT

    [SetUp]
    public void Setup()
    {
        _mergeSorter = new MergeSorter();
    }

    [Test]
    public void GivenUnsortedIntegerList_WhenMergeSort_ThenReturnsSortedAscendingList()
    {
        // Arrange
        var input = new List<int> { 5, 1, 4, 2, 3 };
        // Note: MergeSorter expects a comparator that returns -1 when left > right,
        // 1 when left < right, and 0 when equal (inverted compared to natural CompareTo).
        Func<int, int, int> invertedIntComparer = (left, right) => left > right ? -1 : left < right ? 1 : 0;
        var expected = new List<int> { 1, 2, 3, 4, 5 };

        // Act
        var result = _mergeSorter.MergeSort(input, invertedIntComparer);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GivenAlreadySortedIntegerList_WhenMergeSort_ThenReturnsSameOrder()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3, 4, 5 };
        Func<int, int, int> invertedIntComparer = (left, right) => left > right ? -1 : left < right ? 1 : 0;
        var expected = new List<int> { 1, 2, 3, 4, 5 };

        // Act
        var result = _mergeSorter.MergeSort(input, invertedIntComparer);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GivenListWithDuplicates_WhenMergeSort_ThenReturnsSortedListPreservingDuplicates()
    {
        // Arrange
        var input = new List<int> { 3, 1, 2, 3, 1 };
        Func<int, int, int> invertedIntComparer = (left, right) => left > right ? -1 : left < right ? 1 : 0;
        var expected = new List<int> { 1, 1, 2, 3, 3 };

        // Act
        var result = _mergeSorter.MergeSort(input, invertedIntComparer);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GivenSingleElementList_WhenMergeSort_ThenReturnsSameSingleElementList()
    {
        // Arrange
        var input = new List<int> { 42 };
        Func<int, int, int> invertedIntComparer = (left, right) => left > right ? -1 : left < right ? 1 : 0;
        var expected = new List<int> { 42 };

        // Act
        var result = _mergeSorter.MergeSort(input, invertedIntComparer);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GivenEmptyList_WhenMergeSort_ThenReturnsEmptyList()
    {
        // Arrange
        var input = new List<int>();
        Func<int, int, int> invertedIntComparer = (left, right) => left > right ? -1 : left < right ? 1 : 0;

        // Act
        _mergeSorter.MergeSort(input, invertedIntComparer);

        //Assert
        Assert.That(input, Is.Empty);
    }

    [Test]
    public void GivenUnsortedStringList_WhenMergeSort_WithCustomComparer_ThenReturnsSortedAscendingList()
    {
        // Arrange
        var input = new List<string> { "delta", "alpha", "charlie", "bravo" };
        Func<string, string, int> invertedStringComparer = (left, right) =>
        {
            int cmp = string.CompareOrdinal(left, right);
            return cmp > 0 ? -1 : cmp < 0 ? 1 : 0;
        };
        var expected = new List<string> { "alpha", "bravo", "charlie", "delta" };

        // Act
        var result = _mergeSorter.MergeSort(input, invertedStringComparer);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}