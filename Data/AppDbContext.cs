using Microsoft.EntityFrameworkCore;
using WebApi_Livros.Models;

namespace WebApi_Livros.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
    }

}
