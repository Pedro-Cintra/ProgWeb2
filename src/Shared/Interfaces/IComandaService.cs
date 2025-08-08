namespace Shared.Interfaces;

using Shared.Dtos.Comanda;
using Shared.Dtos.ComandaItem;
public interface IComandaService
{
  Task<ReadComandaDto> CreateAsync(CreateComandaDto parameters);
  Task<IEnumerable<ReadComandaDto>> GetAllAsync();
  Task<ReadComandaItemDto> GetAsync(int id);
}