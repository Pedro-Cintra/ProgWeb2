namespace Shared.Interfaces;

public interface IServiceManager
{
    IUsuarioService Usuario { get; }
    IComandaService Comanda { get; }
    IComandaItemService ComandaItem { get; }
}
