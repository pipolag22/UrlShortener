using static UrlShortener.Entities.Category;

using UrlShortener.Entities;
using UrlShortener.Models.Enum;

namespace UrlShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
        public DbSet<Url> URLs { get; set; }
        public DbSet<Category> Categorias { get; set; }

        public DbSet<User> Users { get; set; }


        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Categoria Trabajo = new Categoria()
            {
                Id = 1,
                Name = "peliculas"
            };
            Categoria Diversion = new Categoria()
            {
                Id = 2,
                Name = "cualquiera"
            };
            User Usuario1 = new User()
            {
                Id = 1,
                Name = "string",
                Password = "string",
                RolUser = Role.Admin

            };

            User Usuario2 = new User()
            {
                Id = 2,
                Name = "pipo",
                Password = "asdasd",
                RolUser = Role.User

            };

            User Usuario3 = new User()
            {
                Id = 3,
                Name = "profe",
                Password = "asdasd",
                RolUser = Role.Guest

            };

           

            modelBuilder.Entity<Url>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.IdUser);
            modelBuilder.Entity<Url>()
            .HasOne(c => c.Categoria)
            .WithMany()
            .HasForeignKey(c => c.IdCategoria);




            modelBuilder.Entity<Categoria>().HasData(Trabajo, Diversion);
           
            modelBuilder.Entity<User>().HasData(Usuario1, Usuario2, Usuario3);

            base.OnModelCreating(modelBuilder);

        }
    }
}
