using Microsoft.EntityFrameworkCore;
using ApiCSharp.Models;

namespace ApiCSharp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
