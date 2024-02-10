using System.Linq.Expressions;

namespace Airbnb.Service.Interface
{
    public interface IBaseService<T> where T : class
    {
        #region Methods
        Task<T?> GetByIdAsync(Guid id);

        Task<T?> GetAsync(Expression<Func<T, bool>> @where);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteManyAsync(Expression<Func<T, bool>> @where);
        #endregion
    }
}
