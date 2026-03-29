using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ActivityTrackerAPI.Models;

namespace ActivityTrackerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

//DbContext = ponte tra codice e database