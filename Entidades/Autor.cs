using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Autor
    {
        [Key]
        public int AutorID { get; set; }

        [Required(ErrorMessage = "El nombre del autor es requerido.")]
        public string Nombre { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
