namespace Project;

public class QuickSorter
{
    public void Sort<T>(List<T> input, Func<T, T, int> comparitor)
    {
        QuickSortRecursive(input, 0, input.Count - 1, comparitor);
    }

    private void QuickSortRecursive<T>(List<T> input, int start, int end, Func<T, T, int> comparitor)
    {
        if (start < end)
        {
            int pivotIndex = Partition(input, start, end, comparitor);
            QuickSortRecursive(input, start, pivotIndex - 1, comparitor);
            QuickSortRecursive(input, pivotIndex + 1, end, comparitor);
        }
    }

    private int Partition<T>(List<T> input, int start, int end, Func<T, T, int> comparitor)
    {
        //Complexity O(n), thus giving overall complexity of O(n log n) on average, and O(n^2) in the worst case.
        T pivot = input[end];
        int i = start;
        int j = end - 1;
        while (i <= j)
        {
            while (i <= j && comparitor.Invoke(input[i], pivot) <= 0)
            {
                i++;
            }
            while (i <= j && comparitor.Invoke(input[j], pivot) >= 0)
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
