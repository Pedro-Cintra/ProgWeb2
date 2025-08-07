namespace Shared.Dtos.ComandaItem;

public record ReadComandaItemDto : ReadDtoBase
{
    public int IdComanda { get; set; }
    public int Sequencia { get; set; }
    public string Produto { get; set; }
    public double Preco { get; set; }
}