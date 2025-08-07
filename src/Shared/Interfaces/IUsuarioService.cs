
using Shared.Dtos.Usuario;

namespace Shared.Interfaces;
public interface IUsuarioService
{
    Task<ReadUsuarioDto> CreateAsync(CreateUsuarioDto parameters);
}
