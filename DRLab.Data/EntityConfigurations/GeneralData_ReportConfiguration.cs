using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRLab.Data.EntityConfigurations
{
    internal class GeneralData_ReportConfiguration : IEntityTypeConfiguration<GeneralData_Report>
    {
        public void Configure(EntityTypeBuilder<GeneralData_Report> builder)
        {
            builder.Property(e => e.ID).ValueGeneratedOnAdd();
        }
    }
}