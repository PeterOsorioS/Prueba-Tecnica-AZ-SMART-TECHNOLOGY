using System.Linq.Expressions;
using AccesoDatos.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Data.Repository.Implementacion
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        internal DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #region Métodos Privados

        /// Construye la  base para los métodos READ, aplicando filtros e includes.
        private IQueryable<T> BuildQuery(
            Expression<Func<T, bool>>? filter,
            string? includeProperties,
            bool asNoTracking = false)
        {
            IQueryable<T> query = _dbSet;

            // Filtro
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Propiedades relacionadas
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            // AsNoTracking para lecturas
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        #endregion

        #region Métodos CREATE

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        #endregion

        #region Métodos READ

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null)
        {
            IQueryable<T> query = BuildQuery(filter, includeProperties, asNoTracking: true);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null)
        {
            IQueryable<T> query = BuildQuery(filter, includeProperties, asNoTracking: true);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public T GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null)
        {
            IQueryable<T> query = BuildQuery(filter, includeProperties, asNoTracking: true);
            return query.FirstOrDefault()!;
        }

        public async Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null)
        {
            IQueryable<T> query = BuildQuery(filter, includeProperties, asNoTracking: true);
            return await query.FirstOrDefaultAsync();
        }

        public int GetAllCount()
        {
            return _dbSet.Count();
        }

        #endregion

        #region Métodos DELETE

        public async Task Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        #endregion
    }
}
