using DRLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.EntityConfigurations
{
    class E08T_AnalysisRequest_DataConfiguration : IEntityTypeConfiguration<E08T_AnalysisRequest_Data>
    {
        public void Configure(EntityTypeBuilder<E08T_AnalysisRequest_Data> builder)
        {
            builder.HasKey(e => new { e.requestNo, e.LVNCode,e.analysisCode });
        }
    }
}
