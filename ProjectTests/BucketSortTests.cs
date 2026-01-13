using Project;

namespace ProjectTests;

public class BucketSortTests
{
    [Test]
    public void GivenIntegerUnsortedInput_WhenSort_ThenReturnsSotedList()
    {
        //Arrange
        List<int> list = [5, 7, 1, -5, 7, 8, 3, 2, 1];

        BucketSort sorter = new BucketSort();

        //Act
        sorter.Sort(list);

        //Assert
        Assert.That(list, Is.EquivalentTo(new List<int>([-5, 1, 1, 2, 3, 5, 7, 7, 8])));
    }
}
