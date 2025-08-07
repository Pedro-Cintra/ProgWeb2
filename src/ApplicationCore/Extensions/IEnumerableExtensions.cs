namespace ApplicationCore.Extensions;

public static class IEnumerableExtensions
{
    public static bool HasDuplicates<T>(this IEnumerable<T> list)
    {
        if (list is null)
            return false;

        HashSet<T> set = [];
        foreach (T item in list)
        {
            if (!set.Add(item))
                return true;
        }

        return false;
    }
}
