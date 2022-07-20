using CarShowroom.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.ApplicationDbContext
{
    public class BotDbContext : DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options) : base(options){}

        public DbSet<Brands> Brand { get; set; }
        public DbSet<CarModel> Car { get; set; }
        public DbSet<OrderModel> OrderModel { get; set; }
        public DbSet<UserModel> User { get; set; }
    }
}
