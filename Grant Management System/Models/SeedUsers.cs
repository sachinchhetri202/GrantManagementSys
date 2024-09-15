using Grant_Management_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Grant_Management_System.Models
{
    public class SeedUsers
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Grant_Management_SystemContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Grant_Management_SystemContext>>()))
            {
                if (context == null || context.User == null)
                {
                    throw new ArgumentNullException("Null Grant_Management_SystemContext");
                }

                // Look for any movies.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        Email = "person1@weber.edu",
                        FirstName = "Bob",
                        LastName = "Smith",
                        WNumber = "12345678",
                        Password = "Password",
                        ConfirmPassword = "Password",
                        IsAdmin = true,
                        IsChair = false,
                        FacultyType = "Tenured",
                        Department = "Science"
                    },

                    new User
                    {
                        Email = "person2@weber.edu",
                        FirstName = "Dan",
                        LastName = "Jones",
                        WNumber = "11223344",
                        Password = "Password",
                        ConfirmPassword = "Password",
                        IsAdmin = false,
                        IsChair = true,
                        FacultyType = "Tenured",
                        Department = "History"
                    },

                    new User
                    {
                        Email = "person3@weber.edu",
                        FirstName = "Robert",
                        LastName = "Johnson",
                        WNumber = "55667788",
                        Password = "Password",
                        ConfirmPassword = "Password",
                        IsAdmin = false,
                        IsChair = false,
                        FacultyType = "Tenure-track",
                        Department = "English"
                    },

                    new User
                    {
                        Email = "person4@weber.edu",
                        FirstName = "Lebron",
                        LastName = "Robertson",
                        WNumber = "44556622",
                        Password = "Password",
                        ConfirmPassword = "Password",
                        IsAdmin = false,
                        IsChair = false,
                        FacultyType = "Adjunct",
                        Department = "Business"
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
