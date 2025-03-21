using Microsoft.AspNetCore.Mvc.Rendering;

namespace Entidades.ViewModel
{
    public class LibroVM
    {
        public Libro Libro { get; set; }
        public List<SelectListItem> ListaAutores { get; set; }
    }
}
