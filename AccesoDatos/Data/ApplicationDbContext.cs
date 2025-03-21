using Entidades;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Se establece la relacion de uno a muchos
            modelBuilder.Entity<Autor>()
                .HasMany(autor => autor.Libros)
                .WithOne(libro => libro.Autor)
                .HasForeignKey(Libro => Libro.AutorID)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
