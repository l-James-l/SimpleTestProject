namespace Project.StringMatching;

public static class StringMatching
{
    public static int SimpleStringMatcher(this string x, string pattern)
    {
        for (int i = 0; i < x.Length - pattern.Length + 1; i++)
        {
            for (int j = 0; j < pattern.Length; j++)
            {
                if (x[i + j]  == pattern[j] && j == pattern.Length - 1)
                {
                    return i;
                }
                if (x[i+j] != pattern[j])
                {
                    break;
                }
            }
        }

        return -1;
    }

    public static int MpMatching(this string x, string pattern)
    {
        List<int> mpValues = ComputeBorders(pattern);

        // i is the index in the pattern
        // j is the index in the text
        int i = 0, j = 0;
        while (j < x.Length)
        {
            while (i == pattern.Length || (i >= 0 && x[j] != pattern[i]))
            {
                i = mpValues[i];
            }
            i++;
            j++;
            if (i == pattern.Length)
            {
                return j - pattern.Length;
            }
        }

        return -1;
    }

    private static List<int> ComputeBorders(string pattern)
    {
        // Compute border table
        // A border is a substring that is both a proper prefix and a proper suffix
        // E.g. for "ababc", "ab" is a border because it is both a prefix and suffix

        List<int> mpValues = [-1];
        for (int i = 0; i < pattern.Length; i++)
        {
            // Initialize j to the length of the previous border
            // The length of the border can only increase by 1 if the next character matches
            // If it does not match, we need to fall back to the next largest border
            int j = mpValues[i];
            while (j >= 0 && pattern[i] != pattern[j])
            {
                j = mpValues[j];
            }
            mpValues.Add(j + 1);
        }

        return mpValues;
    }

    public static int KmpMatching(this string x, string pattern)
    {
        List<int> mpValues = ComputeStrictBorders(pattern);

        // Same as MpMatching but using strict borders
        int i = 0, j = 0;
        while (j < x.Length)
        {
            while (i == pattern.Length || (i >= 0 && x[j] != pattern[i]))
            {
                i = mpValues[i];
            }
            i++;
            j++;
            if (i == pattern.Length)
            {
                return j - pattern.Length;
            }
        }
        return -1;
    }

    private static List<int> ComputeStrictBorders(string pattern)
    {
        List<int> borders = ComputeBorders(pattern);
        // a strict border is a border where the characters following the border do not match
        
        List<int> strictBorders = [.. borders];
        for (int i = 1; i < pattern.Length; i++)
        {
            // If the character following the border matches, we need to fall back to the next largest border
            if (pattern[i] == pattern[borders[i]])
            {
                strictBorders[i] = strictBorders[borders[i]];
            }
        }
        return strictBorders;
    }
}

public static class LongestCommonSubstring
{
    /// <summary>
    /// Finds the longest sequence of characters that appears in both strings.
    /// not necessarily in 1 contiguous block.
    /// </summary>
    public static int LCS(this string s1, string s2)
    {
        int[,] counts = new int[s1.Length, s2.Length];

        for (int i=0; i < s1.Length; i++)
        {
            counts[i, 0] = s1[i] == s2[0] ? 1 : 0;
        }
        for (int j = 0; j < s2.Length; j++)
        {
            counts[0, j] = s1[0] == s2[j] ? 1 : 0;
        }

        for (int i=1; i < s1.Length; i++)
        {
            for (int j=1; j < s2.Length; j++)
            {
                int largestPre = Math.Max(counts[i - 1, j - 1], Math.Max(counts[i - 1, j], counts[i, j - 1]));
                counts[i, j] = s1[i] == s2[j] ? largestPre + 1 : largestPre;
            }
        }

        return counts[counts.GetLength(0)-1, counts.GetLength(1)-1];
    }
}