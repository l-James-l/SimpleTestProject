using Project;

namespace ProjectTests;

public class HeapSorterTests
{
    [Test]
    public void GivenIntegerUnsortedInput_WhenSort_ThenReturnsSotedList()
    {
        //Arrange
        List<int> list = [5, 7, 1, -5, 7, 8, 3, 2, 1];
        
        int comparitor(int x, int y)
        {
            if (x == y) return 0;
            return y < x ? 1 : -1;
        }
        HeapSorter sorter = new HeapSorter();
        
        //Act
        sorter.Sort(list, comparitor);

        //Assert
        //Assert.That(list, Is.EquivalentTo(new List<int>([-5, 1, 1, 2, 3, 5, 7, 7, 8])));
        Assert.That(list, Is.EquivalentTo(new List<int>([-5, 1, 1, 2, 3, 5, 7, 7, 8])));
    }


}