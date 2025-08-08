namespace Shared.Interfaces;
using Shared.Dtos.Comanda;
public interface IComandaService
{
  Task<ReadComandaDto> CreateAsync(CreateComandaDto parameters);
  Task<IEnumerable<ReadComandaDto>> GetAllAsync();
  Task<ReadComandaDto> GetAsync(int id);
}