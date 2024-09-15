using Grant_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Grant_Management_System.Data;

namespace RazorPagesMovie.Models;

public static class SeedCollege
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Grant_Management_SystemContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Grant_Management_SystemContext>>()))
        {
            if (context == null || context.College == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any Colleges.
            if (context.College.Any())
            {
                return;   // DB has been seeded
            }



            context.College.AddRange(
                new College
                {
                    Name = "College of Engineering",
                    Location = "Main Ogden Campus",
                    Dean = "Darren White"
                },

                new College
                {
                    Name = "College of Nursing",
                    Location = "Main Ogden Campus",
                    Dean = "Sherry Eril"
                }

            );
            context.SaveChanges();
        }
    }
}