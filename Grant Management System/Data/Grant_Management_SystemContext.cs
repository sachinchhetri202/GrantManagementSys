using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Grant_Management_System.Models;

namespace Grant_Management_System.Data
{
    public class Grant_Management_SystemContext : DbContext
    {
        public Grant_Management_SystemContext (DbContextOptions<Grant_Management_SystemContext> options)
            : base(options)
        {
        }
        public DbSet<Grant_Management_System.Models.Department> Department { get; set; } = default!;
        public DbSet<Grant_Management_System.Models.User> User { get; set; } = default!;

    }
}
