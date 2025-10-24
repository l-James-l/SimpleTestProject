namespace Project;

public class BinarySearch
{
    private readonly IOrderChecker _orderChecker;

    public BinarySearch(IOrderChecker orderChecker)
    {
        _orderChecker = orderChecker;
    }

    public int? NumericBinarySearch(List<int> numbers, int target)
    {
        return GenericBinarySearch(numbers, NumericComapritor, target);
    }

    /// <summary>
    /// Will perform a binary search on a generic list using the provided comparitor function.
    /// </summary>
    /// <param name="list">The list to search thrugh</param>
    /// <param name="comparitor">How the algorithm will decide how 2 values are ordered. the second param will be the target.
    /// should return 0 if the items are equal,
    /// should return -1 if the target is smaller than the other value
    /// Should return 1 if the target is larger than the other value
    /// </param>
    /// <param name="target">The item to search for</param>
    /// <returns>null if the targter is not found, otherwise the index of the item.</returns>
    public int? GenericBinarySearch<T>(List<T> list, Func<T, T, int> comparitor, T target)
    {
        if (!_orderChecker.IsOrdered(list, comparitor))
        {
            return null;
        }

        int start = 0;
        int end = list.Count-1;

        return SearchListSection(list, start, end, target, comparitor);
    }

    private int? SearchListSection<T>(List<T> list, int start, int end, T target, Func<T, T, int> comparitor)
    {
        if (start > end)
        {
            return null;
        }
        
        int center = start + (end - start)/2;
        int comparisonResult = comparitor.Invoke(list[center], target);
        switch (comparisonResult)
        {
            case 0:
                return center;
            case 1:
                return SearchListSection(list, center+1, end, target, comparitor);
            case -1:
                return SearchListSection(list, start, center-1, target, comparitor);
            default:
                throw new ArgumentOutOfRangeException("Comapritor function should only return -1, 0, or 1");
        }
    }

    private int NumericComapritor(int a, int target)
    {
        if (a > target)
        {
            return -1;
        }
        if (a < target)
        {
            return 1;
        } 
        else
        {
            return 0;
        }
    }
}
