namespace Shared.Dtos.Comanda;

public record ReadComandaDto : ReadDtoBase
{
    public int IdUsuario { get; set; }
    public string NomeUsuario { get; set; }
    public string TelefoneUsuario { get; set; }
}