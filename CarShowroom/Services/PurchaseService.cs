using CarShowroom.ApplicationDbContext;
using CarShowroom.Models;

namespace CarShowroom.Services
{
    public class PurchaseService
    {
        private readonly BotDbContext _dbcontext;
        private readonly ILogger<PurchaseService> _logger;

        public PurchaseService(ILogger<PurchaseService> logger, BotDbContext dbContext)
        {
            _dbcontext = dbContext;
            _logger = logger;
        }

        public Task Purchase(CarModel carModel, UserModel userModel)
        {

            try
            {
                OrderModel orderModel = new OrderModel
                {
                    CarId = carModel.Id,
                    UserId = (int)userModel.Id,
                    Sold = false,
                    Time = DateTime.Now
                };
                _dbcontext.OrderModel.Add(orderModel);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task Delivered(int orderCarId)
        {

            try
            {
                _dbcontext.OrderModel.FirstOrDefault(x => x.Id == orderCarId)!.Sold = true;
                _dbcontext.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return Task.CompletedTask;
        }
            

        public Task<List<OrderModel>> GetAllPurchasedCars(int userId)
        {
            return Task.FromResult(_dbcontext.OrderModel.Where(x => x.UserId == userId && x.Sold == false).ToList());
        }


    }
}
