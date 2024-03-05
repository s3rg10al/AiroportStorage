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
    internal class JetsFluentConfiguration : IEntityTypeConfiguration<Jets>
    {
        public void Configure(EntityTypeBuilder<Jets> builder)
        {
            builder.ToTable("Jets");
            builder.HasBaseType<Planes>();
        }
    }
}

