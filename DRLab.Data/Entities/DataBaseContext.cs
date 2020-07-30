using DRLab.Data.EntityConfigurations;
using DRLab.Data.Identity;
using Microsoft.AspNetCore.Identity;
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
                .ApplyConfiguration(new E00T_SpecificationConfiguration())
                .ApplyConfiguration(new E08T_Testing_InfoConfiguration())
                .ApplyConfiguration(new E08T_WorkingOrder_ItemConfiguration())
                .ApplyConfiguration(new E08T_WorkingOrder_InfoConfiguration())
                .ApplyConfiguration(new E08T_TemplateMarkConfiguration())
                .ApplyConfiguration(new AssignmentConfiguration())
                .ApplyConfiguration(new FieldAutoTableCofiguration())
                .ApplyConfiguration(new GeneralData_ReportConfiguration())
                .ApplyConfiguration(new E00T_Customer_ItemConfiguration());
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("AppRoleClaims")
                .HasKey(x => x.Id);

            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("AppUserRoles")
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("AppUserTokens")
               .HasKey(x => new { x.UserId });
        }
        public DbSet<E08T_WorkingOrder_Info> E08T_WorkingOrder_Info { get; set; }
        public DbSet<E08T_WorkingOrder_Item> E08T_WorkingOrder_Item { get; set; }
        public DbSet<E08T_AnalysisRequest_Data> E08T_AnalysisRequest_Data { get; set; }
        public DbSet<E08T_AnalysisRequest_Info> E08T_AnalysisRequest_Info { get; set; }
        public DbSet<E08T_AnalysisRequest_Item> E08T_AnalysisRequest_Item { get; set; }
        public DbSet<E00T_Customer> E00T_Customer { get; set; }
        public DbSet<E08T_Testing_Data> E08T_Testing_Data { get; set; }
        public DbSet<E00T_Customer_Item> E00T_Customer_Item { get; set; }
        public DbSet<E08T_Testing_Info> E08T_Testing_Info { get; set; }
        public DbSet<E00T_Specification> E00T_Specification { get; set; }
        public DbSet<E08T_TemplateMark> E08T_TemplateMark { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<FieldAutoTable> FieldAutoTable { get; set; }
        public DbSet<GeneralData_Report> GeneralData_Report { get; set; }
    }
}
