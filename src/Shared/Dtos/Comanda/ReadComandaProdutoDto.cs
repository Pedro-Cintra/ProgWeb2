using Shared.Dtos.Produto;

namespace Shared.Dtos.Comanda;

public record ReadComandaProdutoDto : ReadComandaDto
{
  public ProdutoDto[] Produtos { get; set; } = [];
}
