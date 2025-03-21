using AccesoDatos.Data.Repository.IRepository;
using Entidades;

namespace AccesoDatos.Data.Repository.Interfaz
{
    public interface ILibroRepository : IRepository<Libro>
    {
        public Task UpdateAsync(Libro libro);
        public void Update(Libro libro);

    }
}
