using _01_Framework.Domain;
using System.Linq.Expressions;

namespace _01_Framework.Infrastructure;

public interface IRepository<TKey, T> where T : DomainBase<TKey>
{
    void Create(T entity);
    T Get(TKey id);
    List<T> GetAll();
    bool Exist(Expression<Func<T , bool>> expression);
}
