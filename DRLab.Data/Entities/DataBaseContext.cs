using DRLab.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DRLab.Data.Entities
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new E08T_AnalysisRequest_DataConfiguration())
                .ApplyConfiguration(new E08T_AnalysisRequest_InfoConfiguration())
                .ApplyConfiguration(new E08T_AnalysisRequest_ItemConfiguration())
                .ApplyConfiguration(new E00T_CustomerConfiguration())
                .ApplyConfiguration(new E08T_Testing_DataConfiguration())
                .ApplyConfiguration(new E00T_Customer_ItemConfiguration())
                .ApplyConfiguration(new E08T_Testing_InfoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<E08T_AnalysisRequest_Data> E08T_AnalysisRequest_Data { get; set; }
        public DbSet<E08T_AnalysisRequest_Info> E08T_AnalysisRequest_Info { get; set; }
        public DbSet<E08T_AnalysisRequest_Item> E08T_AnalysisRequest_Item { get; set; }
        public DbSet<E00T_Customer> E00T_Customer { get; set; }
        public DbSet<E08T_Testing_Data> E08T_Testing_Data { get; set; }
        public DbSet<E00T_Customer_Item> E00T_Customer_Item { get; set; }
        public DbSet<E08T_Testing_Info> E08T_Testing_Info { get; set; }
    }
}
