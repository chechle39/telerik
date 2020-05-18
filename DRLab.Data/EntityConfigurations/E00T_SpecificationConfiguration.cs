using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.EntityConfigurations
{
    class E00T_SpecificationConfiguration : IEntityTypeConfiguration<E00T_Specification>
    {
        public void Configure(EntityTypeBuilder<E00T_Specification> builder)
        {
            builder.Property(e => e.specID).ValueGeneratedOnAdd();
        }
    }
}