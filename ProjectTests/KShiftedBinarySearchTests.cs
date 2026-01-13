using Project;

namespace ProjectTests;

public class KShiftedBinarySearchTests
{
    [Test]
    public void GivenKShiftedSortedArray_WhenSearch_ThenReturnsCorrectIndex()
    {
        // Arrange
        int[] array = { 3, 4, 5, 1, 2 }; // K-shifted sorted array
        KShiftedBinarySearch searcher = new KShiftedBinarySearch();

        // Act
        for (int i = 0; i < array.Length; i++)
        {
            int resultIndex = searcher.Search(array, array[i]);

            // Assert
            Assert.That(resultIndex, Is.EqualTo(i), $"Failed for target {array[i]}");
        }
    }
}