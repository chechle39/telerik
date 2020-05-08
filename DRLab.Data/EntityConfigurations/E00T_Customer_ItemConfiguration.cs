using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRLab.Data.EntityConfigurations
{
    internal class E00T_Customer_ItemConfiguration : IEntityTypeConfiguration<E00T_Customer_Item>
    {
        public void Configure(EntityTypeBuilder<E00T_Customer_Item> builder)
        {
            builder.Property(e => e.contactID).ValueGeneratedNever();
        }
    }
}