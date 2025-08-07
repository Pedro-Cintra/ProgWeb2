using System.Linq.Expressions;

namespace ApplicationCore.Interfaces;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    void Create(T entity);
    Task CreateAsync(T entity);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    Task CreateRangeAsync(IEnumerable<T> entities);
}
