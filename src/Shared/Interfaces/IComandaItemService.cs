namespace Shared.Interfaces;

using Shared.Dtos.ComandaItem;

public interface IComandaItemService
{
    Task<ReadComandaItemDto> CreateAsync(CreateComandaItemDto parameters);
    void UpdateAsync(int id, UpdateComandaItemDto parameters);
}