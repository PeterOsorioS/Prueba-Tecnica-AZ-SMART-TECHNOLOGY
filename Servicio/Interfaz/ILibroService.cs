using Entidades;
using Entidades.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Servicio.Interfaz
{
    public interface ILibroService
    {
        public Task<IEnumerable<Libro>> ObtenerLibros();
        public Task<LibroVM> ObtenerLibroVM();
        public Task<Libro> ObtenerLibroPorID(int id);
        public Task<List<SelectListItem>> ObtenerListaAutores();
        public Task CrearLibro(LibroVM libroVM);
        public bool EliminarLibro(int id);
        public Task ActualizarLibro(LibroVM libroVM);
        public Task<LibroVM> ObtenerLibroVMPorID(int id);
    }
}
