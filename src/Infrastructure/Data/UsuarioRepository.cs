using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data;
public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(progwebContext repositoryContext) : base(repositoryContext) { }
}
