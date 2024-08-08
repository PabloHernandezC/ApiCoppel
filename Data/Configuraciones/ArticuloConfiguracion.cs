using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuraciones
{
    public class ArticuloConfiguracion : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.Property(x => x.Sku).IsRequired();
            builder.Property(x => x.Article).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Marca).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(20);
            builder.Property(x => x.IdClase).IsRequired();
            builder.Property(x => x.IdDepartamento).IsRequired();
            builder.Property(x => x.IdFamilia).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Cantidad).IsRequired();
            builder.Property(x => x.Descontinuado).IsRequired();

            /*Relaciones*/
            builder.HasOne(x => x.clase).WithMany()
                .HasForeignKey(x => x.IdClase)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.departamento).WithMany()
                .HasForeignKey(x => x.IdDepartamento)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.familia).WithMany()
                .HasForeignKey(x => x.IdFamilia)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
