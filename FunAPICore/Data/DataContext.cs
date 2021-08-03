using System;
using System.Threading.Tasks;
using funAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace funAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Names> Names { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Names>().HasData(
                new Names { Id = 1, Name = "Tsitsi", DateGenerated = new DateTime(2021, 07, 20, 16, 23, 40), IsBooked = false },
                new Names
                {
                    Id = 2,
                    Name = "Anorld",
                    DateGenerated = new DateTime(2021, 07, 20, 09, 24, 40),
                    DateBooked = new DateTime(2021, 07, 21, 09, 24, 40),
                    IsBooked = true
                },
                new Names
                {
                    Id = 3,
                    Name = "Abjksabdflksdkfbiugbausdigbkjsdbgfui",
                    DateGenerated = new DateTime(2021, 07, 20, 09, 24, 40),
                    IsBooked = false
                },
                new Names
                {
                    Id = 4,
                    Name = "Panashe",
                    DateGenerated = new DateTime(2021, 07, 26, 09, 24, 40),
                    IsBooked = false
                }
                );
        }
    }
}