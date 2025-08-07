using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data;
public class ComandaRepository : RepositoryBase<Comanda>, IComandaRepository
{
    public ComandaRepository(progwebContext repositoryContext) : base(repositoryContext) { }
}
