using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.EntityConfigurations
{
    class E00T_SampleMatrixConfiguration : IEntityTypeConfiguration<E00T_SampleMatrix>
    {
        public void Configure(EntityTypeBuilder<E00T_SampleMatrix> builder)
        {
            builder.Property(e => e.matrixID).ValueGeneratedOnAdd();
        }
    }
}