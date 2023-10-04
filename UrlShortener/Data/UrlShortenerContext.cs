using Microsoft.EntityFrameworkCore;
using System;
using System.IO.Pipelines;
using UrlShortener.Entities;

namespace UrlShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
        public DbSet<XYZ> Urls { get; set; }
       
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        XYZ karen = new XYZ()
        {
            Id = 1,
            Url = "http://www.google.com.ar",
            UrlShort = ""
            
        };

       
       


    }
}
