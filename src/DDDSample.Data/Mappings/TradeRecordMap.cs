using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.TradeCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample.Data.Mappings
{
    public class TradeRecordMap : IEntityTypeConfiguration<TradeRecord>
    {
        public void Configure(EntityTypeBuilder<TradeRecord> builder)
        {
            builder.ToTable("DDDSample.TradeRecords", "dbo");
            builder.Property(t => t.ConcurrencyToken).IsConcurrencyToken();
        }
    }
}
