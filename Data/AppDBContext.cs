using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Familia> Familias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
