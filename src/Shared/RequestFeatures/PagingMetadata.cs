using System.Text.Json;

namespace Shared.RequestFeatures;

public class PagingMetadata
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
