using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreProject.Core.Repositories;
using AspNetCoreProject.Core.Services;
using AspNetCoreProject.Core.UnitOfWorks;
using AspNetCoreProject.Data.Context;
using AspNetCoreProject.Data.Repositories;
using AspNetCoreProject.Data.UnitOfWorks;
using AspNetCoreProject.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace AspNetCoreProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Servislerimi ekledi�im methot
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            // Bir interface ile kar��la��rsa ona kar��l�k gelen class� olu�tur dedik
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            /* Sql Servera Veri taban�n� ekledik.
             * Connection String dosyas�n� appsettings.json i�ine yazd�k
            */
            services.AddDbContext<AppDbContext>(options =>
            {

                //veri taban� ba�lant�s�
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(),
                    //o : SqlServer kullan�rken ki se�enekler gelir. Biz Migration kullanaca��z
                    o =>
                    {
                        o.MigrationsAssembly("AspNetCoreProject.Data");
                    });

            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Katmanlar�m� ekledi�im methot
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
