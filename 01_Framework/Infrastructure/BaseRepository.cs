using _01_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _01_Framework.Infrastructure;

public class BaseRepository<TKey, T> (DbContext dbContext) : IRepository<TKey, T> where T : DomainBase<TKey>
{
    private readonly DbContext _dbContext = dbContext;
    public void Create(T entity)
    {
        _dbContext.Add<T>(entity);
    }

    public bool Exist(Expression<Func<T , bool>> expression)
    {
        return _dbContext.Set<T>().Any(expression);
    }

    public T Get(TKey id)
    {
        return _dbContext.Find<T>(id);
    }

    public List<T> GetAll()
    {
        return _dbContext.Set<T>().ToList();
    }
}
