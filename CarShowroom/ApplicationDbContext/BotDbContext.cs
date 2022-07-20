using CarShowroom.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.ApplicationDbContext
{
    public class BotDbContext : DbContext
    {

         private readonly string _connectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite(_connectionString);
        }
        public BotDbContext(string connString )
        {
            _connectionString=connString;
            
        }
        public BotDbContext(DbContextOptions<BotDbContext> options) : base(options){}

        public DbSet<Brands> Brand { get; set; }
        public DbSet<CarModel> Car { get; set; }
        public DbSet<OrderModel> OrderModel { get; set; }
        public DbSet<UserModel> User { get; set; }
    }
}
