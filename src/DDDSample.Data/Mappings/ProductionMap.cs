using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample.Data.Mappings
{
    public class ProductionMap : IEntityTypeConfiguration<Domain.Production.Models.Production>
    {
        public void Configure(EntityTypeBuilder<Domain.Production.Models.Production> builder)
        {
            //builder.Property(t => t.Id).ValueGeneratedOnAdd();

            //builder.Property(t => t.EntityId)
            //    .HasColumnType("varchar(32)")
            //    .HasMaxLength(32)
            //    .IsRequired();

            //builder.Property(t => t.Name)
            //    .HasColumnType("nvarchar(50)")
            //    .HasMaxLength(50)
            //    .IsRequired();

            //builder.Property(t => t.FullName)
            //    .HasColumnType("nvarchar(200)")
            //    .HasMaxLength(200)
            //    .IsRequired();

            //builder.Property(t => t.Price).IsRequired();

            //builder.Property(t => t.CreateTime)
            //    .IsRequired();

            //builder.Property(t => t.UpdateTime).IsRequired();

            //builder.Property(t => t.Enable).IsRequired();

            builder.Property(t => t.ConcurrencyToken).IsConcurrencyToken();

            builder.Ignore("Desc");

            builder.ToTable("DDDSample.Productions", "dbo");
        }
    }
}
