using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected progwebContext RepositoryContext;

    public RepositoryBase(progwebContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }

    public void Create(T entity)
    {
        RepositoryContext.Set<T>().Add(entity);
    }

    public async Task CreateAsync(T entity)
    {
        await RepositoryContext.Set<T>().AddAsync(entity);
    }
    public async Task CreateRangeAsync(IEnumerable<T> entity)
    {
        await RepositoryContext.Set<T>().AddRangeAsync(entity);
    }

    public void Delete(T entity)
    {
        RepositoryContext.Set<T>().Remove(entity);        
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        if (!trackChanges)
            return RepositoryContext.Set<T>().AsNoTracking();

        return RepositoryContext.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        if (!trackChanges)
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();

        return RepositoryContext.Set<T>().Where(expression);
    }

    public void Update(T entity)
    {
        RepositoryContext.Set<T>().Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        RepositoryContext.Set<T>().UpdateRange(entities);
    }    
}
