using AccesoDatos.Data.UnitOfWork.Interfaz;
using Entidades;
using Entidades.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicio.Interfaz;

namespace Servicio.Implementacion
{
    public class LibroService : ILibroService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LibroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Libro>> ObtenerLibros()
        {
            IEnumerable<Libro> libros = await _unitOfWork.Libro
                .GetAllAsync(includeProperties: "Autor");

            return libros ?? Enumerable.Empty<Libro>();
        }

        public async Task<LibroVM> ObtenerLibroVM()
        {
            List<SelectListItem> autoresLista = await ObtenerListaAutores();
        

            LibroVM libroVM = new LibroVM()
            {
                Libro = new Libro(),
                ListaAutores = autoresLista
            };

            return libroVM;
        }

        public async Task<Libro> ObtenerLibroPorID(int id)
        {
            Libro? libro = await _unitOfWork.Libro.GetFirstOrDefaultAsync(
                includeProperties: "Autor", filter: l => l.ID == id);

            return libro ?? new Libro();
        }

        public async Task<LibroVM> ObtenerLibroVMPorID(int id)
        {
            List<SelectListItem> autoresLista =  await ObtenerListaAutores();
            Libro libro = await ObtenerLibroPorID(id);

            LibroVM libroVM = new LibroVM()
            {
                Libro = libro,
                ListaAutores = autoresLista
            };
            
            return libroVM;
        }


        public async Task<List<SelectListItem>> ObtenerListaAutores()
        {
            List<SelectListItem> autoresLista = await _unitOfWork.Autor.AutoresLista();
            if (autoresLista.Any())
            {

                autoresLista.Insert(0, new SelectListItem { Text = "Seleccione un autor", Value = "0" });
            }
            else
            {
                autoresLista.Insert(0, new SelectListItem { Text = "No se encuentran autores.", Value = "0" });
            }

            return autoresLista;
        }
              
        public async Task CrearLibro(LibroVM libroVM)
        {        
            await _unitOfWork.Libro.AddAsync(libroVM.Libro);
            await _unitOfWork.SaveAsync();
        }

        public async Task ActualizarLibro(LibroVM libroVM)
        {
            await _unitOfWork.Libro.UpdateAsync(libroVM.Libro);
            await _unitOfWork.SaveAsync();
        }

        public bool EliminarLibro(int id)
        {
            Libro? libro = _unitOfWork.Libro.Get(id);
            if (libro != null)
            {
                _unitOfWork.Libro.Remove(libro);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
