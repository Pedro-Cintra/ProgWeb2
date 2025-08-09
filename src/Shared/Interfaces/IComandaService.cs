namespace Shared.Interfaces;

using Shared.Dtos.Comanda;
using Shared.Dtos.ComandaItem;
public interface IComandaService
{
  Task<ReadComandaDto> CreateAsync(CreateComandaDto parameters);
  Task<IEnumerable<ReadComandaDto>> GetAllAsync();
  Task<ReadComandaProdutoDto> GetAsync(int id);
  Task<string> DeleteAsync(int id);
}