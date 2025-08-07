namespace Shared.Dtos.Usuario;

public record ReadUsuarioDto : ReadDtoBase
{
    public string Nome { get; init; }
    public string Telefone { get; init; }
}