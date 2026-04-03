namespace Project.Searching.RequiresSortedInput;

public class KShiftedBinarySearch
{
	public int Search(int[] array, int target)
	{
        // Standard binary search modified for k-shifted sorted array.
        // Time complexity: O(log n)
        // Assumes the the array is sorted, and then shifted by k positions.

        int left = 0;
		int right = array.Length - 1;
		while (left <= right)
		{
			int mid = left + (right - left) / 2;
			if (array[mid] == target)
			{
				return mid;
			}
			// Determine which side is properly sorted
			if (array[left] <= array[mid])
			{
				// Left side is sorted
				if (target >= array[left] && target < array[mid])
				{
					right = mid - 1; // Target is in the left side
				}
				else
				{
					left = mid + 1; // Target is in the right side
				}
			}
			else
			{
				// Right side is sorted
				if (target > array[mid] && target <= array[right])
				{
					left = mid + 1; // Target is in the right side
				}
				else
				{
					right = mid - 1; // Target is in the left side
				}
			}
		}
		return -1; // Target not found
    }
}