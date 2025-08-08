namespace Shared.Interfaces;

using Shared.Dtos.ComandaItem;

public interface IComandaItemService
{
    Task<ReadComandaItemDto> CreateAsync(CreateComandaItemDto parameters);
    Task<ReadComandaItemDto> GetAsync(int id);
}