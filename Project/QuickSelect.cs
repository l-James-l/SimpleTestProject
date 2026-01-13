namespace Project;

public class QuickSelect
{
    /// <summary>
    /// Field to indicate whether to use Median of Medians for pivot selection.
    /// </summary>
    private bool _useMoM;

    /// <summary>
    /// Selects the element that would appear at index <paramref name="k"/> if the array
    /// were sorted.
    /// </summary>
    /// <param name="array">The input array. Must not be null.</param>
    /// <param name="k">Zero-based index of the desired element in sorted order.</param>
    /// <returns>The element that would be at index <paramref name="k"/> after sorting.</returns>
    public int Select(int[] array, int k)
	{
		if (k <0 || k > array.Length)
		{
			throw new ArgumentOutOfRangeException(nameof(k), "k must be between0 and the length of the array.");
		}

		return QuickSelectHelper((int[])array.Clone(), 0, array.Length -1, k);
	}

	public int QuickSelectWithMedianOfMedians(int[] array, int k)
	{
		if (k <0 || k > array.Length)
		{
			throw new ArgumentOutOfRangeException(nameof(k), "k must be between0 and the length of the array.");
		}

        // Implementation of QuickSelect using Median of Medians as pivot selection.
        _useMoM = true;
		return QuickSelectHelper((int[])array.Clone(), 0, array.Length -1, k);
    }

    /// <summary>
    /// Recursive helper that performs QuickSelect over the subarray defined by [left, right].
    /// </summary>
    private int QuickSelectHelper(int[] array, int left, int right, int k)
	{
		// If the subarray has one element, that's the answer.
		if (left == right)
		{
			return array[left];
		}

		// Partition the array and obtain the final pivot index.
		int pivotIndex = Partition(array, left, right);

		// If k matches the pivot index, we found the k-th element.
		if (k == pivotIndex)
		{
			return array[k];
		}
		// If k is smaller, continue searching left subarray.
		else if (k < pivotIndex)
		{
			return QuickSelectHelper(array, left, pivotIndex -1, k);
		}
		// Otherwise search right subarray.
		else
		{
			return QuickSelectHelper(array, pivotIndex +1, right, k);
		}
	}

	/// <summary>
	/// Partitions the subarray [left, right] around a pivot (chosen as the last element).
	/// After partitioning all elements less than the pivot are moved before the pivot and
	/// the pivot is placed at its final index which is returned.
	/// </summary>
	private int Partition(int[] array, int left, int right)
	{
		// Choose the rightmost element as pivot.
		int pivotValue = array[right];
		if (_useMoM)
		{
            // Use Median of Medians to select a better pivot, which ensures O(n) performance.
            pivotValue = MedianOfMedians(array, left, right);
            // Move the pivot to the end for partitioning.
            Swap(array, Array.IndexOf(array, pivotValue, left, right - left + 1), right);
        }		
		
		// 'storeIndex' will mark the position where the next smaller-than-pivot element
		// should be placed.
		int storeIndex = left;

		// Iterate through the subarray and move elements smaller than pivot to the left.
		for (int i = left; i < right; i++)
		{
			if (array[i] < pivotValue)
			{
				Swap(array, storeIndex, i);
				storeIndex++;
			}
		}

        // Start with: 6 4 3 76 8 4 2 9
        // After loop: 6 4 3 8 4 2 76 9
        // Finally, swap the pivot with the element at storeIndex: 6 4 3 8 4 2 9 76

        // Place the pivot after the last smaller element so that pivot is in its final sorted position.
        Swap(array, storeIndex, right);
		return storeIndex;
	}

	/// <summary>
	/// Swaps two elements in the array.
	/// </summary>
	private void Swap(int[] array, int i, int j)
	{
		int temp = array[i];
		array[i] = array[j];
		array[j] = temp;
	}

	private int MedianOfMedians(int[] array, int left, int right)
	{
        // Divide the array into segments of 5 elements each.
        int segmentCount = (int)Math.Ceiling((right - left + 1) / 5.0);
		List<int[]> arraySegments = new List<int[]>();
		
		for (int i = left; i <= right; i++)
		{
			try
			{
                int segmentIndex = (i - left) / 5;
                int positionInSegment = (i - left) % 5;
                if (segmentIndex > arraySegments.Count - 1)
                {
                    arraySegments.Add(new int[Math.Min(5, right - left - (5*segmentIndex) + 1)]);
                }
                arraySegments[segmentIndex][positionInSegment] = array[i];
            }
			catch (Exception ex)
			{

			}
			
        }

        // Find the median of each segment.
		List<int> medians = new List<int>();

        foreach (int[] segment in arraySegments)
		{
			Array.Sort(segment);
			medians.Add(segment[segment.Length / 2]);
        }

		// Find the median of the medians.
		medians.Sort();
		return medians[medians.Count / 2];
	}
}
