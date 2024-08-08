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
    public class DepartamentoConfiguracion : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.Property(x => x.IdDepartamento).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
        }
    }
}
