using System.ComponentModel.DataAnnotations;

namespace Shared.RequestFeatures;

public abstract record PagingParameters
{
    private const int MAX_PAGE_SIZE = int.MaxValue;

    private int _pageSize;

    [Range(1, int.MaxValue)]
    public int PageNumber { get; set; }

    [Range(1, MAX_PAGE_SIZE)]
    public int PageSize
    {
        get => _pageSize;
        set { _pageSize = Math.Min(value, MAX_PAGE_SIZE); }
    }
}
