using Shared.Dtos.Produto;

namespace Shared.Dtos.ComandaItem;

public record ReadComandaItemDto : ReadDtoBase
{
    public int IdUsuario { get; set; }
    public string NomeUsuario { get; set; }
    public string TelefoneUsuario { get; set; }
    public ProdutoDto[] Produtos { get; set; }
}