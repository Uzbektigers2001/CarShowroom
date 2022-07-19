using CarShowroom.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.ApplicationDbContext
{
    public class BotDbContext : DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options) : base(options)
        {

        }

        public DbSet<Brands> Brands { get; set; }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
