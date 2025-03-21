using AccesoDatos.Data.Repository.IRepository;
using Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AccesoDatos.Data.Repository.Interfaz
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<List<SelectListItem>> AutoresLista();
    }
}
