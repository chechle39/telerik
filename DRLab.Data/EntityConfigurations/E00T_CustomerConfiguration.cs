using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.EntityConfigurations
{
    internal class E00T_CustomerConfiguration : IEntityTypeConfiguration<E00T_Customer>
    {
        public void Configure(EntityTypeBuilder<E00T_Customer> builder)
        {
            builder.Property(e => e.customerCode).ValueGeneratedOnAdd();
        }
    }
}