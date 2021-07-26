using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetShop.Backend.Lib.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PetShop.Backend.Repositories;

namespace PetShopWebApp
{
    public class Startup
    {
        private readonly IConfiguration _iConfig;
        public Startup(IConfiguration configuration)
        {
            _iConfig = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPetShopRepository, PetShopRepository>();

            var connectionString = _iConfig.GetConnectionString("DefaultConnection");
            //connectiong to the database using lazy loading design pattern
            services.AddDbContext<PetShopDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, PetShopDbContext anx)
        {
            anx.Database.EnsureDeleted();
            anx.Database.EnsureCreated();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
