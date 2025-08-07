namespace ApplicationCore.Interfaces;

public interface IRepositoryManager
{
    IComandaRepository Comanda { get; }
    IComandaItemRepository ComandaItem { get; }
    IUsuarioRepository Usuario { get; }
    
    Task SaveAsync();
}
