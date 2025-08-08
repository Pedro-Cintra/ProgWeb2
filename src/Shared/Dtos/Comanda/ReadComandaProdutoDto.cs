namespace Shared.Dtos.Comanda;

public record ReadComandaProdutoDto : ReadComandaDto
{
  public ProdutoDto Produto { get; set; }
}

public record ProdutoDto : ReadDtoBase
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}
