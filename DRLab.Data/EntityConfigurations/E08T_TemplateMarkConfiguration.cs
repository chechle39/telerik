using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRLab.Data.EntityConfigurations
{
    internal class E08T_TemplateMarkConfiguration : IEntityTypeConfiguration<E08T_TemplateMark>
    {
        public void Configure(EntityTypeBuilder<E08T_TemplateMark> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}