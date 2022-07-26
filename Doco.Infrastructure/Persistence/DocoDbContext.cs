using System.Reflection;
using Doco.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doco.Infrastructure.Persistence
{
    public class DocoDbContext : DbContext
    {
        public DocoDbContext() : base()
        {
        }

        public DocoDbContext(DbContextOptions<DocoDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=DocoDb;Trusted_Connection=True;MultipleActiveResultSets=true;");

        public DbSet<User> Users => Set<User>();
    }
}
