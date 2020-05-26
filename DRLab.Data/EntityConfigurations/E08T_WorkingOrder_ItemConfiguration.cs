using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRLab.Data.EntityConfigurations
{
    internal class E08T_WorkingOrder_ItemConfiguration : IEntityTypeConfiguration<E08T_WorkingOrder_Item>
    {
        public void Configure(EntityTypeBuilder<E08T_WorkingOrder_Item> builder)
        {
            builder.Property(e => e.WOID).ValueGeneratedOnAdd();
        }
    }
}