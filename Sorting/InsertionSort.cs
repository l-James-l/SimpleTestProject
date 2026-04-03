namespace Sorting;

public class InsertionSort
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="input"></param>
    /// <param name="comparitor">Return true if the elements should be swapped</param>
    /// <returns></returns>
    public void Sort<T>(List<T> input, Func<T, T, bool> comparitor)
    {
        // Start at the second element because a 1 element list is always sorted
        for (int i = 1; i < input.Count; i++)
        {
            int j = i - 1;
            // Move backwards through the list until we find an element that is 'less than' the inserted element
            while (j >= 0 && comparitor.Invoke(input[i], input[j]))
            {
                Swap(input, j, i);
                j--;
            }
        }
    }

    private void Swap<T>(List<T> input, int j, int i)
    {
        T temp = input[j];
        input[j] = input[i];
        input[i] = temp;
    }
}
