namespace Sorting;

public class QuickSorter
{
    public void Sort<T>(List<T> input, Func<T, T, int> comparator)
    {
        QuickSortRecursive(input, 0, input.Count - 1, comparator);
    }

    private void QuickSortRecursive<T>(List<T> input, int start, int end, Func<T, T, int> comparator)
    {
        if (start < end)
        {
            int pivotIndex = Partition(input, start, end, comparator);
            QuickSortRecursive(input, start, pivotIndex - 1, comparator);
            QuickSortRecursive(input, pivotIndex + 1, end, comparator);
        }
    }

    private int Partition<T>(List<T> input, int start, int end, Func<T, T, int> comparator)
    {
        //Complexity O(n), thus giving overall complexity of O(n log n) on average, and O(n^2) in the worst case.
        T pivot = input[end];
        int i = start;
        int j = end - 1;
        while (i <= j)
        {
            while (i <= j && comparator.Invoke(input[i], pivot) <= 0)
            {
                i++;
            }
            while (i <= j && comparator.Invoke(input[j], pivot) >= 0)
            {
                j--;
            }
            if (i < j)
            {
                Swap(input, i, j);
                i++;
                j--;
            }
        }
        Swap(input, i, end);
        return i;
    }

    private void Swap<T>(List<T> input, int i, int j)
    {
        T temp = input[i];
        input[i] = input[j];
        input[j] = temp;
    }
}
