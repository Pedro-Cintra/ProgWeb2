using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data;
public class ComandaItemRepository : RepositoryBase<ComandaItem>, IComandaItemRepository
{
    public ComandaItemRepository(progwebContext repositoryContext) : base(repositoryContext) { }
}
