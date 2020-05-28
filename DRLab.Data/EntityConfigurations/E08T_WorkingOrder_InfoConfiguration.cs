using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.EntityConfigurations
{
    internal class E08T_WorkingOrder_InfoConfiguration : IEntityTypeConfiguration<E08T_WorkingOrder_Info>
    {
        public void Configure(EntityTypeBuilder<E08T_WorkingOrder_Info> builder)
        {
            builder.Property(e => e.WOID).ValueGeneratedNever();
        }
    }
}