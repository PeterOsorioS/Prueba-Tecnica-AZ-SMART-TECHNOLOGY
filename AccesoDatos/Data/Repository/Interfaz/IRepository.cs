using System.Linq.Expressions;

namespace AccesoDatos.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Add(T entity);

        // READ
        T Get(int id);
        Task<T> GetAsync(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
        );

        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
        );

        T GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
        );

        Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
        );

        int GetAllCount();

        // DELETE
        Task Remove(T entity);

    }
}
