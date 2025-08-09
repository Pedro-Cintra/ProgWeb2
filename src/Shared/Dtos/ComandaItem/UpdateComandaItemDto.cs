using Shared.Dtos.Produto;

namespace Shared.Dtos.ComandaItem;

public record UpdateComandaItemDto
{
    public ProdutoDto[] Produtos { get; set; }
}