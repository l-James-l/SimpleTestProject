namespace Sorting;

public class BubbleSort
{
    public void Sort<T>(List<T> input, Func<T, T, bool> comparitor)
    {
        for (int i = 0; i < input.Count - 1; i++)
        {
            for (int j = 0; j < input.Count - i - 1; j++)
            {
                if (comparitor.Invoke(input[j + 1], input[j]))
                {
                    Swap(input, j, j + 1);
                }
            }
        }
    }

    private void Swap<T>(List<T> input, int j, int v)
    {
        T temp = input[j];
        input[j] = input[v];
        input[v] = temp;
    }
}