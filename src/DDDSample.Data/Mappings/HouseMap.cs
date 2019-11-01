using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.House.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample.Data.Mappings
{
    public class HouseMap : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.ToTable("DDDSample.Houses", "dbo");
            builder.Property(t => t.ConcurrencyToken).IsConcurrencyToken();
        }
    }
}
