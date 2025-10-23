namespace Project;

public class BasicStringFunctions
{
    public string Concatenate(string str1, string str2)
    {
        return str1 + str2;
    }

    public string ToUpperCase(string str)
    {
        return str.ToUpper();
    }

    public string ToLowerCase(string str)
    {
        return str.ToLower();
    }

    public string Reverse(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public string GetSubstring(string str, int startIndex, int length)
    {
        if (startIndex < 0 || length < 0 || startIndex + length > str.Length)
        {
            throw new ArgumentOutOfRangeException("Invalid startIndex or length for substring.");
        }
        return str.Substring(startIndex, length);
    }
}
