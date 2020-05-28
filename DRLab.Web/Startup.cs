using Askmethat.Aspnet.JsonLocalizer.Extensions;
using AutoMapper;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.Repositories;
using DRLab.Services.IntegrationServices;
using DRLab.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

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
            services.AddTransient<IE08T_Testing_InfoRepository, E08T_Testing_InfoRepository>();
            services.AddTransient<IE00T_SampleMatrixRepository, E00T_SampleMatrixRepository>();
            services.AddTransient<IE00T_CustomerRepository, E00T_CustomerRepository>();
            services.AddTransient<IE00T_Customer_ItemRepository, E00T_Customer_ItemRepository>();
            services.AddTransient<IE00T_SpecificationRepository, E00T_SpecificationRepository>();
            services.AddTransient<IE08T_AnalysisRequest_InfoRepository, E08T_AnalysisRequest_InfoRepository>();
            services.AddTransient<IE00T_CustomerService, E00T_CustomerService>();
            services.AddTransient<IE00T_Customer_ItemService, E00T_Customer_ItemService>();
            services.AddTransient<ITesting_InfoService, Testing_InfoService>();
            services.AddTransient<ITesting_DataService, Testing_DataService>();
            services.AddTransient<ISpecificationService, SpecificationService>();
            services.AddTransient<IE00T_Customer_ItemService, E00T_Customer_ItemService>();
            services.AddTransient<IE08T_AnalysisRequest_InfoService, E08T_AnalysisRequest_InfoService>();
            services.AddTransient<IE00T_SampleMatrixService, E00T_SampleMatrixService>();
            services.AddTransient<IE08T_Testing_InfoRepository, E08T_Testing_InfoRepository>();
            services.AddTransient<IGetRequestNoDapperService, GetRequestNoDapperService>();
            services.AddTransient<IE08T_WorkingOrder_ItemRepository, E08T_WorkingOrder_ItemRepository>();
            services.AddTransient<IE08T_WorkingOrder_ItemService, E08T_WorkingOrder_ItemService>();
            services.AddTransient<IE08T_WorkingOrder_InfoService, E08T_WorkingOrder_InfoService>();
            services.AddTransient<IE08T_WorkingOrder_InfoRepository, E08T_WorkingOrder_InfoRepository>();
            services.AddScoped<DbContext, DataBaseContext>();
            services.AddControllers().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0); ;
            services.AddControllersWithViews();
            services.AddKendo();

            //l10n
            var languages = Configuration.GetSection("Languages").Get<string[]>();
            services.AddControllersWithViews();
            services.AddJsonLocalization(options => {
                options.ResourcesPath = "I18N";
                options.CacheDuration = TimeSpan.FromSeconds(1);
                options.FileEncoding = Encoding.GetEncoding("utf-8");
                options.SupportedCultureInfos =  languages.Select(language => new CultureInfo(language)).ToHashSet<CultureInfo>();
            });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = languages.Select(language => new CultureInfo(language)).ToList();
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services.AddControllers().AddNewtonsoftJson(options => 
            { 
              options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
              options.SerializerSettings.DateFormatString = "MM/dd/yyyy";
              options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            //Authen
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

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

            app.UseRouting();

            app.UseAuthentication();
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
