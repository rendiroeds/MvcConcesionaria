using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcConcesionaria.Data;
using MvcConcesionaria.Models;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcConcesionariaContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcConcesionariaContext>>()))
        {
            // Look for any movies.
            if (context.Vehiculo.Any())
            {
                return;   // DB has been seeded
            }

            context.SaveChanges();
        }
    }
}
