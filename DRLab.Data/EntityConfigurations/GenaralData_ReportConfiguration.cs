using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRLab.Data.EntityConfigurations
{
    internal class GenaralData_ReportConfiguration : IEntityTypeConfiguration<GenaralData_Report>
    {
        public void Configure(EntityTypeBuilder<GenaralData_Report> builder)
        {
            builder.Property(e => e.ID).ValueGeneratedOnAdd();
        }
    }
}