using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Libro
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "El título del libro es requerido.")]
        public string Titulo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un autor válido.")]
        public int AutorID { get; set; }

        [ForeignKey("AutorID")]
        public Autor Autor { get; set; }

    }
}
