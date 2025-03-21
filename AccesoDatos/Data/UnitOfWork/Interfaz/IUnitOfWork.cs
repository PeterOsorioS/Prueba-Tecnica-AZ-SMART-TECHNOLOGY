using AccesoDatos.Data.Repository.Interfaz;

namespace AccesoDatos.Data.UnitOfWork.Interfaz
{
    public interface IUnitOfWork : IDisposable
    {
        ILibroRepository Libro{ get; }
        IAutorRepository Autor { get; }
        void Save();
        Task SaveAsync();
    }
}
