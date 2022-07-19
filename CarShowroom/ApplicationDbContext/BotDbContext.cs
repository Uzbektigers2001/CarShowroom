using CarShowroom.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.ApplicationDbContext
{
    public class BotDbContext : DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options) : base(options)
        {

        }

        public DbSet<Brands> brands { get; set; }
        public DbSet<CarModel> cars { get; set; }
        public DbSet<OrderModel> orderModels { get; set; }
        public DbSet<UserModel> users { get; set; }
    }
}
