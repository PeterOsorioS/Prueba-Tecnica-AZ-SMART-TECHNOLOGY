using Entidades;

namespace Servicio.Interfaz
{
    public interface IAutorService
    {
        public Task CrearAutor(Autor autor);
        public Task<bool> AutorExiste(string nombre);
        public Task<IEnumerable<Autor>> ObtenerAutores();

    }
}
