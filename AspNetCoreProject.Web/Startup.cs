using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCoreProject.Web.Filters;
using AspNetCoreProject.Web.ApiService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreProject.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Servislerimi ekledi�im k�s�m
        public void ConfigureServices(IServiceCollection services)
        {
            // API ile haberle�me
            services.AddHttpClient<CategoryApiService>(options=>
            {
                options.BaseAddress = new Uri(Configuration["baseUrl"]); //appsettings.json
            });
            services.AddHttpClient<ProductApiService>(options =>
            {
                options.BaseAddress = new Uri(Configuration["baseUrl"]); //appsettings.json
            });


            services.AddScoped<NotFoundFilter>();

            services.AddAutoMapper(typeof(Startup));

            // Bir interface ile kar��la��rsa ona kar��l�k gelen class� olu�tur dedik

            /*
             * Api katman� ekledi�imiz i�in art�k Service katman� ile haberle�miyoruz. Bu alana art�k gerek yok
              services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
              services.AddScoped(typeof(IService<>), typeof(Service<>));
              services.AddScoped<ICategoryService, CategoryService>();
              services.AddScoped<IProductService, ProductService>();
              services.AddScoped<IUnitOfWork, UnitOfWork>();

            /* Sql Servera Veri taban�n� ekledik.
             * Connection String dosyas�n� appsettings.json i�ine yazd�k
            
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
             */
           
            services.AddControllersWithViews();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Katmanlar�m� ekledi�im methot
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
