using AirportStorage.Domain.Entities.Planes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.FluentConfigurations
{
       internal class CommercialFluentConfiguration : IEntityTypeConfiguration<Commercial>
    {   
        public void Configure(EntityTypeBuilder<Commercial> builder)
        {
            builder.ToTable("Commercials");
            builder.HasBaseType<Planes>();
        }
    }
}

