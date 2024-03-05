using AirportStorage.Domain.Entities.Staff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStorage.DataAccess.FluentConfigurations
{
    internal class AssuranceStaffFluentConfiguration : IEntityTypeConfiguration<AssuranceStaff>
    {
        public void Configure(EntityTypeBuilder<AssuranceStaff> builder)
        {
            builder.ToTable("AssuranceStaff");
            builder.HasBaseType<Staff>();
        }
    }
}

