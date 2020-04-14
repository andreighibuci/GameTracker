using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTracker_release.Interfaces;
using GameTracker_release.mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GameTracker_release.Repositories;
using GameTracker_release.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GameTracker_release
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

       
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("appsettings.json").Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().
                AddEntityFrameworkStores<AppDbContext>();    
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseSession();
                app.UseAuthentication();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                   name: "gamedetails",
                   template: "game/Details/{gameId?}",
                   defaults: new { Controller = "Game", action = "Details" });
                    routes.MapRoute(name: "categoryFilter", template: "Game/{action}/{category?}", defaults: new { Controller = "Game", action = "List" });
                    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");     
                });

        }
    }
}
