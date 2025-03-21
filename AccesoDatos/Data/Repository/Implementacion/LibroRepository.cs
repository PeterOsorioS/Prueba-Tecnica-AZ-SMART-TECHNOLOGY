using AccesoDatos.Data.Repository.Interfaz;
using Entidades;

namespace AccesoDatos.Data.Repository.Implementacion
{
    public class LibroRepository : Repository<Libro>, ILibroRepository
    {
        private readonly ApplicationDbContext _db;
        public LibroRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(Libro libro)
        {
            Libro? libroDB = await _db.Libros.FindAsync(libro.ID);

            if (libroDB == null) return;

            libroDB!.Titulo = libro.Titulo;
            libroDB!.AutorID = libro.AutorID;
        }


        public void Update(Libro libro)
        {
            Libro? libroDB = _db.Libros.Find(libro.ID);

            if (libroDB != null) return;

            libroDB!.Titulo = libro.Titulo;
            libroDB!.AutorID = libro.AutorID;
        }
    }
}
