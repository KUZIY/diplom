using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomApp.Data
{
    public class DiplomDataContext : DbContext
    {
        public DiplomDataContext(DbContextOptions<DiplomDataContext> options):
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<UsersDB> UsersDB { get; set; }
        public DbSet<RatingsDB> RatingsDB { get; set; }
        public DbSet<MessagesDB> MessagesDB { get; set; }

    }
}
