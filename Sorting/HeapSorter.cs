namespace Sorting;

public class HeapSorter
{
    public void Sort<T>(List<T> input, Func<T, T, int> comparitor)
    {
        // First create the heap structure from the input list.
        // Call the recurance on all the parent nodes, bottom up. This way when swaping a node with one of it children,
        // we know that the other subtree remains a heap
        for (int i = input.Count/2; i >= 0; i--)
        {
            CreateHeap(input, i, input.Count-1, comparitor);
        }

        // Now we can use heap sort.
        // The largest element will be first, so put it at the end.
        // Then fix the heap, ignoring the already sorted largest elements.
        // We do this n times, resulting in a O(nlogn) complexity
        int end = input.Count - 1;
        while (end > 0)
        {
            Swap(input, 0, end);
            end--;
            CreateHeap(input, 0, end, comparitor);
        }
    }

    private void CreateHeap<T>(List<T> input, int rootIndex, int end, Func<T, T, int> comparitor)
    {
        // Need to organise the list into a heap structure, such that the children are always less than the parent.
        // A nodes children are found at indices 2n + 1 and 2n + 2
        // This recursion runs in O(logn)

        T root = input[rootIndex];

        if (2*rootIndex + 1 > end)
        {
            // No children, already a heap
            return;
        }

        if (2*rootIndex + 1 == end)
        {
            // Only left child. Child must have no children of its own, so just compare and swap if needed.
            T leftChild = input[2 * rootIndex + 1];
            if (comparitor.Invoke(root, leftChild) < 0)
            {
                Swap(input, rootIndex, 2 * rootIndex + 1);
            }
            return;
        }

        // Both children exist
        int leftChildIndex = 2 * rootIndex + 1;
        int rightChildIndex = 2 * rootIndex + 2;
        if (comparitor.Invoke(input[leftChildIndex], input[rightChildIndex]) > 0)
        {
            // Left child is larger
            if (comparitor.Invoke(root, input[leftChildIndex]) < 0)
            {
                Swap(input, rootIndex, leftChildIndex);
                CreateHeap(input, leftChildIndex, end, comparitor);
            }
        }
        else
        {
            // Right child is larger
            if (comparitor.Invoke(root, input[rightChildIndex]) < 0)
            {
                Swap(input, rootIndex, rightChildIndex);
                CreateHeap(input, rightChildIndex, end, comparitor);
            }
        }
    }



    private void Swap<T>(List<T> input, int rootIndex, int largest)
    {
        T temp = input[rootIndex];
        input[rootIndex] = input[largest];
        input[largest] = temp;
    }
}