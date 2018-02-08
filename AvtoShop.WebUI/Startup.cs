using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Step.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Step.Identity.Stores;
using Microsoft.EntityFrameworkCore;
using AvtoShop.DataLayer.DbLayer;
using EFCoreGenericRepository.Common;
using EFCoreGenericRepository.Repositories;

namespace AvtoShop.WebUI
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
            services.AddDbContext<StepIdentityContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<StepIdentityContext>()
                .AddDefaultTokenProviders();
            //використовуємо встроєний контейнер створення залежностей


            services.AddScoped<DbContext, AvtoShopContext>();
            services.AddTransient<IGenericRepository<Brand>, BrandRepository>();
            services.AddTransient<IGenericRepository<Fuel>, FuelRepository>();
            services.AddTransient<IGenericRepository<KPP>, KPPRepository>();
            services.AddTransient<IGenericRepository<ModelAvto>, ModelAvtoRepository>();

            services.AddTransient<IGenericRepository<AutoBody>, AutoBodyRepository>();
            services.AddTransient<IGenericRepository<DriveUnit>, DriveUnitRepository>();
            services.AddTransient<IGenericRepository<Avto>, AvtoRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            StepIdentityContext context, 
            UserManager<AppUser> usermgr, 
            RoleManager<AppRole> rolemgr)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

			app.UseCulture(); //дивися файл CultureMiddleware.cs 
			// культуру можна зберегти в куках та ізвлєкати її звідти
			app.UseStaticFiles();
            //!!!!!!!!!!!!!!
            app.UseAuthentication();
            //створення БАЗИ ДАНИХ
            DbInitializer.Initialize(context, usermgr, rolemgr); //CREATE DATABASE
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Avto}/{action=Index}/{id?}");
            });
        }
    }
}
