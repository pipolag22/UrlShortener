using static UrlShortener.Entities.Category;

using UrlShortener.Entities;
using UrlShortener.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;

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
            Category Pelicula = new Category()
            {
                Id = 1,
                Name = "peliculas"
            };
            Category Cualquiera = new Category()
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
            Url url = new Url()
            {
                Id = 1,
                UrlShort = "www.google.com.ar",
                UrlLong = "sadSaD1f",
                contador = 0,
                IdCategoria = Cualquiera.Id,
                IdUser = Usuario1.Id
            };
            Url url1 = new Url()
            {
                Id = 2,
                UrlShort = "www.elbananero.com",
                UrlLong = "as9f9pa3rmf",
                contador = 1,
                IdCategoria = Pelicula.Id,
                IdUser = Usuario2.Id

            };


            modelBuilder.Entity<Url>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.IdUser);
            modelBuilder.Entity<Url>()
            .HasOne(c => c.Categoria)
            .WithMany()
            .HasForeignKey(c => c.IdCategoria);




            modelBuilder.Entity<Category>().HasData(Pelicula, Cualquiera);
            modelBuilder.Entity<Url>().HasData(url, url1);
            modelBuilder.Entity<User>().HasData(Usuario1, Usuario2, Usuario3);

            base.OnModelCreating(modelBuilder);

        }
    }
}
