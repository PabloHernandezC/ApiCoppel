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
    public class ClaseConfiguracion : IEntityTypeConfiguration<Clase>
    {
        public void Configure(EntityTypeBuilder<Clase> builder)
        {
            builder.Property(x => x.IdClase).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IdDepartamento).IsRequired();

            builder.HasOne(x => x.departamento).WithMany()
                .HasForeignKey(x => x.IdDepartamento)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
