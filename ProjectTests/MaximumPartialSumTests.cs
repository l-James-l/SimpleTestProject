using Project;

namespace ProjectTests;

public class  MaximumPartialSumTests
{
    [Test]
    public void GivenIntegerList_WhenCalculateMaximumPartialSum_ThenReturnsCorrectSum()
    {
        // Arrange
        int[] input = [-2, 1, -3, 4, -1, 2, 1, -5, 4 ];
        var expected = 6; // The maximum partial sum is from subarray [4, -1, 2, 1]

        MaximumPartialSum mps = new MaximumPartialSum();

        // Act
        var result = mps.FindMaxPartialSum(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}