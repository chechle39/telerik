using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.EntityConfigurations
{
    internal class E08T_AnalysisRequest_ItemConfiguration : IEntityTypeConfiguration<E08T_AnalysisRequest_Item>
    {
        public void Configure(EntityTypeBuilder<E08T_AnalysisRequest_Item> builder)
        {
            builder.HasKey(e => new { e.requestNo, e.LVNCode});
        }
    }
}