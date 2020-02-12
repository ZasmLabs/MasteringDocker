using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using System;
using System.Linq;

namespace DAL
{
    public static class DatabaseSeedInitializer
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                Initialize(serviceProvider);
            }
            return host;
        }
        static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                if (!context.Movie.Any())
                {
                    context.Movie.AddRange(
                        new Movie
                        {
                            Title = "When Harry Met Sally", ReleaseDate = DateTime.Parse("1989-2-12"), Genre = "Romantic Comedy", Price = 7.99M
                        },
                        new Movie
                        {
                            Title = "Ghostbusters ", ReleaseDate = DateTime.Parse("1984-3-13"), Genre = "Comedy", Price = 8.99M
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}