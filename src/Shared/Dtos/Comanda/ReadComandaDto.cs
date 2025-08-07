namespace Shared.Dtos.Comanda;

public record ReadComandaDto : ReadDtoBase
{
    public int IdUsuario { get; init; }
}