using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data;

public sealed class RepositoryManager : IRepositoryManager
{

    private readonly progwebContext _repositoryContext;
    private readonly Lazy<IUsuarioRepository> _usuarioRepository;
    private readonly Lazy<IComandaRepository> _comandaRepository;

    public RepositoryManager(progwebContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _usuarioRepository = new(() => new UsuarioRepository(repositoryContext));
        _comandaRepository = new(() => new ComandaRepository(repositoryContext));
    } 

    public IUsuarioRepository Usuario => _usuarioRepository.Value;
    public IComandaRepository Comanda => _comandaRepository.Value;
    public IComandaItemRepository ComandaItem => new ComandaItemRepository(_repositoryContext);
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
