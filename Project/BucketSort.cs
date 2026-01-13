namespace Project;

public class BucketSort
{
    public void Sort(List<int> input)
    {
        // Sorts in O(n*log(n/10)) = O(n), since we are using 10 buckets and log base change rule (log(n/k) = .

        int[][] buckets = new int[10][];
        int iterations = input.Max().ToString().Length;
        
        for (int i = 0; i < iterations; i++)
        {
            // Distribute input numbers into buckets
            foreach (int number in input)
            {
                // Find the digit at the current place value
                // E.g., for i=0 (units place), i=1 (tens place), etc.
                // E.g., number=345, i=1 -> (345 / 10^1) % 10 = 4
                int bucketIndex = number / (int)Math.Pow(10, i) % 10;
                Array.Resize(ref buckets[bucketIndex], buckets[bucketIndex].Length + 1);
                // This will maintain the order from the previous iteration
                // E.g., 345 and 245 both go to bucket 4 in the tens place, but 345 was before 245 in the previous iteration
                // So we append 345 first, then 245
                buckets[bucketIndex][buckets[bucketIndex].Length - 1] = number;
            }

            // Collect numbers from buckets
            input.Clear();
            foreach (int[] bucket in buckets)
            {
                input.AddRange(bucket);
            }
        }
    }
}
