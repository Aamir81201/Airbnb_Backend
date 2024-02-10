using System.Linq.Expressions;

namespace Airbnb.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        #region Methods
        Task<T?> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetAsync(Expression<Func<T, bool>> @where);

        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> @where);

        Task<T> InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteManyAsync(Expression<Func<T, bool>> @where);

        void Dispose();
        #endregion
    }
}
