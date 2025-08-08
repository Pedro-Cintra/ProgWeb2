namespace Shared.Dtos.Produto;

public record ProdutoDto : ReadDtoBase
{
  public string Nome { get; set; }
  public decimal Preco { get; set; }
}