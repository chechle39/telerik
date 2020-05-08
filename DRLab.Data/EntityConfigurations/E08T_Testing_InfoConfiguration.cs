using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.EntityConfigurations
{
    internal class E08T_Testing_InfoConfiguration : IEntityTypeConfiguration<E08T_Testing_Info>
    {
        public void Configure(EntityTypeBuilder<E08T_Testing_Info> builder)
        {
            builder.HasKey(e => new { e.analysisCode});
        }
    }
}