using Askmethat.Aspnet.JsonLocalizer.Extensions;
using AutoMapper;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.Repositories;
using DRLab.Services.IntegrationServices;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System;
using System.Collections.Generic;

namespace DRLab.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddAutoMapper();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IE08T_AnalysisRequest_DataRepository, E08T_AnalysisRequest_DataRepository>();
            services.AddTransient<IE08T_AnalysisRequest_ItemRepository, E08T_AnalysisRequest_ItemRepository>();
            services.AddTransient<IE00T_SampleMatrixRepository, E00T_SampleMatrixRepository>();
            services.AddTransient<IE00T_CustomerRepository, E00T_CustomerRepository>();
            services.AddTransient<IE00T_Customer_ItemRepository, E00T_Customer_ItemRepository>();
            services.AddTransient<IE08T_AnalysisRequest_InfoRepository, E08T_AnalysisRequest_InfoRepository>();
            services.AddTransient<IE00T_CustomerService, E00T_CustomerService>();
            services.AddTransient<IE00T_Customer_ItemService, E00T_Customer_ItemService>();
            services.AddTransient<IE08T_AnalysisRequest_InfoService, E08T_AnalysisRequest_InfoService>();
            services.AddTransient<IE00T_SampleMatrixService, E00T_SampleMatrixService>();
            services.AddTransient<IE08T_AnalysisRequest_DataService, E08T_AnalysisRequest_DataService>();
            services.AddScoped<DbContext, DataBaseContext>();
            services.AddControllersWithViews();
            services.AddKendo();

            //l10n
            services.AddControllersWithViews();
            services.AddJsonLocalization(options => {
                options.ResourcesPath = "I18N";
                options.CacheDuration = TimeSpan.FromSeconds(1);
                options.SupportedCultureInfos = new HashSet<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("fr-FR"), };
            });
            
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            var supportedCultures = new[] {
                new CultureInfo("en-US"),
                new CultureInfo("fr-FR"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
