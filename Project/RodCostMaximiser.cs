namespace Project;

public class RodCostMaximiser
{
    /// <summary>
    /// Given a rod of length n, and a list of cost c, where c[i] is the price of a rod of length i,
    /// and c contains all the values up to n. what is the best way partition the rod
    /// </summary>
    /// <returns>the max value</returns>
    public int Compute(int n, int[] c)
    {
        if (c.Length != n)
        {
            throw new ArgumentException("length of c must equal n");
        }

        // for each length of rod
        for (int j = 0; j < n; j++)
        {
            // consider a single cut at each possible position, and sum the max value up to that cut + the cost of the cut piece
            // We know the max value of both sides as we have already computed it
            // i.e., when considering a rod of length j, we have already computed the max values for all lengths < j
            for (int i = 0; i <j; i++)
            {
                c[j] = Math.Max(c[j], c[i] + c[j - i - 1]);
            }
        }

        return c[n - 1];

        // Time complexity: O(n^2)
        // Space complexity: O(1) (In place implementation)
    }
}