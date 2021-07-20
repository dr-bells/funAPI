using funAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace funAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Names> Names { get; set; }
    }
}