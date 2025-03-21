using AccesoDatos.Data.Repository.Implementacion;
using AccesoDatos.Data.Repository.Interfaz;
using AccesoDatos.Data.UnitOfWork.Interfaz;

namespace AccesoDatos.Data.UnitOfWork.Implementacion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Libro = new LibroRepository(_db);
            Autor = new AutorRepository(_db);
        }
        public ILibroRepository Libro { get; private set; }

        public IAutorRepository Autor { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
