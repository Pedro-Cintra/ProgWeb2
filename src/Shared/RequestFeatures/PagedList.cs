namespace Shared.RequestFeatures;

public class PagedList<T> : List<T>
{
    public PagingMetadata Metadata { get; init; }

    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        Metadata = new PagingMetadata
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };

        AddRange(items);
    }
}
