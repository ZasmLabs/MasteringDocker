using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Core;
using Models;
using DAL;
using Microsoft.Extensions.Logging;
using MovieAPI.Controllers;

namespace MovieAPI
{
    public class Startup
    {
        ILoggerFactory _loggerFactory;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository<Movie>, Repository<Movie>>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, MvcMovieContext>();
            services.AddSingleton(_loggerFactory.CreateLogger<ILogger<MoviesController>>());
            services.AddDbContext<MvcMovieContext>(options => options.UseMySql(Configuration.GetConnectionString("MvcMovieContext")));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
