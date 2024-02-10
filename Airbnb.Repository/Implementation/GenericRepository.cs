using Airbnb.Model.Data;
using Airbnb.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace Airbnb.Repository.Implementation
{
    public abstract class GenericRepository<T> : IGenericRepository<T>, IDisposable
         where T : class
    {
        #region Properties
        protected readonly ApplicationDbContext _dbContext;

        protected DbSet<T> Dbset
        {
            get { return _dbContext.Set<T>(); }
        }
        #endregion

        #region Constructor
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        public virtual async Task<T?> GetByIdAsync(Guid id) => await Dbset.FindAsync(id);

        public virtual async Task<IEnumerable<T>> GetAllAsync() =>
             await Dbset.AsNoTracking().ToListAsync();

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> @where) => await Dbset.Where(where).AsNoTracking().FirstOrDefaultAsync();

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> @where) => await Dbset.Where(where).AsNoTracking().ToListAsync();

        public virtual async Task<T> InsertAsync(T entity)
        {
            Dbset.Add(entity);
            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            Dbset.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteManyAsync(Expression<Func<T, bool>> @where)
        {
            var entity = await Dbset.Where(where).ToListAsync();
            Dbset.RemoveRange(entity);
            await SaveChangesAsync();
        }

        public virtual async Task ExecuteSqlCommandAsync(string query, params object[] parameters)
        => await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);

        public IQueryable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        => Dbset.FromSqlRaw(query, parameters);

        public virtual async Task<IEnumerable<TEntity>> ExecuteStoredProcedureList<TEntity>(string sql, params object[] parameters)
            where TEntity : class
            => await _dbContext.Set<TEntity>().FromSqlRaw(sql, parameters).AsNoTracking().ToListAsync();

        public void Dispose() => _dbContext?.Dispose();

        public async Task SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
        #endregion
    }
}
