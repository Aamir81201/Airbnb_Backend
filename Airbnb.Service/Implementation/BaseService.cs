using Airbnb.Repository.Interface;
using Airbnb.Service.Interface;
using System.Linq.Expressions;

namespace Airbnb.Service.Implementation
{
    public abstract class BaseService<T> : IBaseService<T>
                where T : class
    {
        #region Properties
        protected readonly IGenericRepository<T> _repository;
        #endregion

        #region Constructor
        public BaseService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public virtual async Task<T?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> @where) => await _repository.GetAsync(where);

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> @where) => await _repository.GetManyAsync(where);

        public virtual async Task<T> InsertAsync(T entity) => await _repository.InsertAsync(entity);

        public virtual async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);

        public virtual async Task DeleteAsync(T entity)
        => await _repository.DeleteAsync(entity);

        public virtual async Task DeleteManyAsync(Expression<Func<T, bool>> @where)
        => await _repository.DeleteManyAsync(@where);
        #endregion
    }
}
