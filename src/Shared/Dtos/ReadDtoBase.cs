using System.Text.Json.Serialization;

namespace Shared.Dtos;

public abstract record ReadDtoBase
{
    [JsonPropertyOrder(int.MinValue)]
    public int Id { get; set; }
}
