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
    public class FamiliaConfiguracion : IEntityTypeConfiguration<Familia>
    {
        public void Configure(EntityTypeBuilder<Familia> builder)
        {
            builder.Property(x => x.IdFamilia).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
        }

    }
}
