using System;
using Microsoft.EntityFrameworkCore;
using Leaning.Data.Models;
namespace Leaning.Data
{
    public class AppData: DbContext
    {
        public AppData(DbContextOptions<AppData> Uoptions):base(Uoptions)
        {

        }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
