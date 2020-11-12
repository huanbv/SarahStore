using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SarahStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace SarahStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:SarahStoreProducts:ConnectionString"]));
            //services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:SarahStore:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddMvc(opt => opt.EnableEndpointRouting = false);
            //services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
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
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Products", action = "List" });

                routes.MapRoute(name: null,
                    template: "Page{productPage:int}", defaults: new
                    {
                        controller = "Products",
                        action = "List",
                        productPage = 1
                    }
                    );

                routes.MapRoute(name: null,
                    template: "{category}",
                    defaults: new
                    {
                        controller = "Products",
                        action = "List",
                        productPage = 1
                    }
                    );

                routes.MapRoute(name: null,
                    template: "",
                    defaults: new
                    {
                        controller = "Products",
                        action = "List",
                        productPage = 1
                    });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
        SeedData.EnsurePopulated(app);
        }
    }
}
