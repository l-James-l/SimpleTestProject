namespace Project;

public class MergeSorter
{
    public List<T> MergeSort<T>(List<T> list, Func<T, T, int> comparitor)
    {
        List<List<T>> disassambedList = new List<List<T>>();
        //Disassemble the list into a list of single-item lists.
        //This accounts for spilitting the list in half recursively, but doing it one step.
        foreach (T item in list)
        {
            disassambedList.Add(new List<T> { item });
        }

        while (disassambedList.Count > 1)
        {
            //Iterate over every pair of lists, merging them into a single sorted list.
            List<List<T>> mergedLists = new List<List<T>>();
            for (int i = 0; i < disassambedList.Count; i += 2)
            {
                if (i + 1 < disassambedList.Count)
                {
                    List<T> merged = MergeSortedLists(disassambedList[i], disassambedList[i + 1], comparitor);
                    mergedLists.Add(merged);
                }
                else
                {
                    //If we have reached the end of the list and there is an odd number of lists,
                    //The final list is added as-is because there is nothing to comapre it to.
                    mergedLists.Add(disassambedList[i]);
                }
            }
            disassambedList = mergedLists;
        }

        return disassambedList.FirstOrDefault() ?? list; //If the input list was empty, return it as-is.
    }

    private List<T> MergeSortedLists<T>(List<T> leftHalf, List<T> rightHalf, Func<T, T, int> comparitor)
    {
        int previousAddedIndex = -1;
        while (rightHalf.Count > 0)
        {
            T itemToAdd = rightHalf[0];
            rightHalf.RemoveAt(0);
            int leftHalfInitialCount = leftHalf.Count;

            for (int i = previousAddedIndex + 1; i < leftHalf.Count; i++)
            {
                int comparisonResult = comparitor.Invoke(leftHalf[i], itemToAdd);
                if (comparisonResult == -1)
                {
                    //If the item in the left half is larger than the item to add,
                    //we insert the new item before the existing one.
                    leftHalf.Insert(i, itemToAdd);
                    previousAddedIndex = i;
                    break;
                }
                else if (comparisonResult == 0)
                {
                    //If the items are equal, we insert the new item after the existing one.
                    leftHalf.Insert(i + 1, itemToAdd);
                    previousAddedIndex = i + 1;
                    break;
                }
                //If we reach here, it means the item in the left half is smaller than the item to add.

                if (i == leftHalf.Count - 1)
                {
                    //If we reach the end of the left half without inserting the right item,
                    //it means the right item is larger than all items in the left half.
                    //And since we know the right half is sorted, we can just add the rest of it to the end.
                    leftHalf.Add(itemToAdd);
                    leftHalf.AddRange(rightHalf);
                    return leftHalf;
                }
            }
            if (leftHalf.Count == leftHalfInitialCount)
            {
                throw new Exception($"Merge sort failed to insert an item into the merged list. item: {itemToAdd}");
            }
        }

        return leftHalf;
    }
}
