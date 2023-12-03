using System.Linq.Expressions;

namespace AddressBookApp.Server.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> RetrieveAll();
        IQueryable<T> RetrieveByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}