using Models;
using Microsoft.EntityFrameworkCore;

namespace ServerDb.Data
{
    public class AppDbContext: DbContext
    {
        //Список таблиц:
        public DbSet<Product> Product => Set<Product>();
        public DbSet<Account> Accounts => Set<Account>();

        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}