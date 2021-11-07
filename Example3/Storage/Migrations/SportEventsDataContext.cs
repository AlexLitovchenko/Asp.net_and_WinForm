using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООP_Laba4.Storage.Entity;

namespace ООP_Laba4.Storage.Migrations
{
    public class SportEventsDataContext :DbContext
    {
        public SportEventsDataContext(DbContextOptions<SportEventsDataContext> options) : base(options)
        {

        }
        public DbSet<Event> Event { get; set; }
        public DbSet<Sport> Sport { get; set; }
        public DbSet<Participant> Participant { get; set; }
    }
}
