using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.API.Business;
using UrlShortener.Data;
using UrlShortener.Domain.Interfaces;


namespace UrlShortener.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                            options.UseInMemoryDatabase("shortenerInMemoryDb"));
            services.AddCors(options =>
                             {
                                 options.AddPolicy("AllowAngularDevServer",
                                                   builder => builder.AllowAnyOrigin()
                                                                     .AllowAnyHeader()
                                                                     .AllowAnyMethod());
                             });


            ManageDependencies(services);
            services.AddControllers();
        }

        private void ManageDependencies(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IShortenerManager, ShortenerManager>();
            services.AddScoped<IShortenerRepository, ShortenerRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Other app configurations

            app.UseCors("AllowAngularDevServer");

            app.UseRouting();
            app.UseForwardedHeaders();

            app.UseEndpoints(endpoints =>
                             {
                                 endpoints.MapControllers();
                             });
        }



    }
}
