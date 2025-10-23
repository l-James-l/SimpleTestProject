namespace Project;
public class BasicLinqOperation
{
    public List<int> FilterEvenNumbers(List<int> numbers)
    {
        return numbers.Where(x => x % 2 == 0).ToList();
    }

    public bool AreAllEven(List<int> numbers)
    {
        return numbers.All(x => x % 2 == 0);
    }

    public bool AnyEven(List<int> numbers)
    {
        return numbers.Any(x => x % 2 == 0);
    }

    public bool AreMinAndMaxEqual(List<int> numbers)
    {
        return numbers.Min() == numbers.Max();
    }

    public bool AnyDuplicated(List<int> numbers)
    {
        return numbers.Count != numbers.Distinct().Count();
    }

    public bool AnyUnique(List<int> numbers1, List<int> numbers2)
    {
        if (numbers1.Count == 0 && numbers2.Count == 0)
        {
            return false;
        }
        return numbers1.Except(numbers2).Any();
    }

    public bool IsOrdered(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (numbers[i] > numbers[i + 1])
            {
                return false;
            }
        }
        return true;
    }
}
