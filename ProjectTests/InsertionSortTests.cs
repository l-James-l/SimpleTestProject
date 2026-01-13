using Project;

namespace ProjectTests;

public class InsertionSortTests
{
    [Test]
    public void GivenIntegerUnsortedInput_WhenSort_ThenReturnsSotedList()
    {
        //Arrange
        List<int> list = [5, 7, 1, -5, 7, 8, 3, 2, 1];
        
        bool comparitor(int x, int y)
        {
            return y < x;
        }

        InsertionSort sorter = new InsertionSort();

        //Act
        sorter.Sort(list, comparitor);

        //Assert
        Assert.That(list, Is.EquivalentTo(new List<int>([-5, 1, 1, 2, 3, 5, 7, 7, 8])));
    }
}

