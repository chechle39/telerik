using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.EntityConfigurations
{
    internal class E08T_Testing_DataConfiguration : IEntityTypeConfiguration<E08T_Testing_Data>
    {
        public void Configure(EntityTypeBuilder<E08T_Testing_Data> builder)
        {
            builder.Property(e => e.iD).ValueGeneratedNever();
        }
    }
}