namespace Shared.Interfaces;
using Shared.Dtos.Comanda;
public interface IComandaService
{
  Task<ReadComandaDto> CreateAsync(CreateComandaDto parameters);
}