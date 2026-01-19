namespace Project.StringMatching;

public static class ApproxStringMatching
{
    public static int FirstKMatch(this string s, string pattern, int k)
    {
        // Keep track of many mismatches have occurred  
        int[,] errors = new int[pattern.Length + 1, s.Length + 1];

        // We init the first row to 0 as we are not considering the pattern so there cant be any matches
        for (int i=0; i <= s.Length; i++)
        {
            errors[0, i] = 0;
        }

        // Init the first column to its index because we are not considering the string so each character is mismatched.
        for (int i=1; i <= pattern.Length; i++)
        {
            errors[i, 0] = i;
        }

        for (int j = 1; j <= s.Length; j++) 
        {
            for (int i = 1; i <= pattern.Length; i++)
            {
                if (pattern[i-1] == s[j-1])
                {
                    // If the character matches, then there's no mismatch so copy previous value
                    errors[i, j] = errors[i - 1, j - 1];
                }
                else
                {
                    // Mismatch, so take lowest value of predecesors and add 1 for the new mismatch
                    int previousError = Math.Min(errors[i - 1, j], Math.Min(errors[i, j - 1], errors[i - 1, j - 1]));
                    errors[i, j] = previousError + 1;
                }
            }
            // If we've found a string that has less than k errors, return the start index
            if (errors[pattern.Length, j] <= k)
            {
                return j - pattern.Length;
            }
        }

        // No match found
        return -1;
    }
}

