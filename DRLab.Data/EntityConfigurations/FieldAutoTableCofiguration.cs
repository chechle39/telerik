using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRLab.Data.EntityConfigurations
{
    internal class FieldAutoTableCofiguration : IEntityTypeConfiguration<FieldAutoTable>
    {
        public void Configure(EntityTypeBuilder<FieldAutoTable> builder)
        {
            builder.Property(e => e.ID).ValueGeneratedOnAdd();
        }
    }
}