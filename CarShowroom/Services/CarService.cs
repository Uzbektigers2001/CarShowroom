using CarShowroom.ApplicationDbContext;
using CarShowroom.Models;

namespace CarShowroom.Services;
 public class CarService
 {
    private readonly BotDbContext _dbContext;
    private readonly ILogger _logger;


    public CarService(BotDbContext dbContext,ILogger<CarService> logger)
    {
        _dbContext=dbContext;
        _logger=logger;
        
    }
    public CarModel? GetCarByIdAsync(long? carId)
    {
        ArgumentNullException.ThrowIfNull(carId);
        try
        {
            return _dbContext.Car.FirstOrDefault(c=>c.Id==carId);
        }
        catch (System.Exception)
        {
            
            return null;
        }
      
    }

    public  List<CarModel>? GetCarsByBrandIdAsync(long brandId,int from=0, int lenght=10)
    {
        try
        {
            return _dbContext.Car.Where(b=>b.BrandId==brandId).Skip(from).Take(lenght).ToList();
        }
        catch (System.Exception)
        {
            
            return null;
        }   
    }  
    public async Task<bool?> RemoveCarById(long carId)
    {
        try
        {
        var car=GetCarByIdAsync(carId);
        ArgumentNullException.ThrowIfNull(car);
        var result=_dbContext.Car.Remove(car);
        await _dbContext.SaveChangesAsync();
        return true;
        }
        catch (System.Exception)
        {
            
           return false;
        }
    }
    public async Task<bool> AddNewCarAsync(CarModel car)
    {
        try
        {
            _dbContext.Car.Add(car);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (System.Exception)
        {
            
            return false;
        }
        

    }
 
 
 }