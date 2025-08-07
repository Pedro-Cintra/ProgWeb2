using Shared.RequestFeatures;

namespace ApplicationCore.Filters;

public static class Paging
{
    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, PagingParameters pagingParameters)
    {
        return query
              .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
              .Take(pagingParameters.PageSize);
    }
}
