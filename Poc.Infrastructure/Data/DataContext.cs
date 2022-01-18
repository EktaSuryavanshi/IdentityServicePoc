using Microsoft.EntityFrameworkCore;
using Poc.Infrastructure.Models;

namespace Poc.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<UserDetailEntity> UserDetails { get; set; }
    }
}
