using AccesoDatos.Data.UnitOfWork.Interfaz;
using Entidades;
using Servicio.Interfaz;

namespace Servicio.Implementacion
{
    public class AutorService : IAutorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AutorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CrearAutor(Autor autor)
        {
            await _unitOfWork.Autor.AddAsync(autor);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> AutorExiste(string nombre)
        {
            Autor? autor = await _unitOfWork.Autor.GetFirstOrDefaultAsync(
                filter: a => a.Nombre.ToLower() == nombre.ToLower()
            );

            return autor != null;
        }
        public async Task<IEnumerable<Autor>> ObtenerAutores()
        {
            IEnumerable<Autor> autores = await _unitOfWork.Autor.GetAllAsync();
            return autores ?? Enumerable.Empty<Autor>();
        }
    }
}
