using AccesoDatos.Data.Repository.Interfaz;
using Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Data.Repository.Implementacion
{
        public class AutorRepository : Repository<Autor>, IAutorRepository
        {
            private readonly ApplicationDbContext _db;

        public AutorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<SelectListItem>> AutoresLista() =>
            await _db.Autores
            .Select(autor => new SelectListItem
             {
                Text = autor.Nombre,
                Value = autor.AutorID.ToString()
             }
        ).ToListAsync();

    }
}
