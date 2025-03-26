using Microsoft.EntityFrameworkCore;
using PeliculasApi.Modelos;

namespace PeliculasApi
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genero> Genero { get; set; }
        public DbSet<Actor> Actor { get; set; }
    }
}
