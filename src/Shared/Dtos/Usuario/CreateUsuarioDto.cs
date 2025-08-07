namespace Shared.Dtos.Usuario;

public record CreateUsuarioDto
{
    public string Nome { get; init; }
    public string Telefone { get; init; }
}