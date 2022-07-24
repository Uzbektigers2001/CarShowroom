using CarShowroom.ApplicationDbContext;
using CarShowroom.Models;
using CarShowroom.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarShowroom.Controller;
[ApiController]
[Route("[controller]")]
public class CarController:ControllerBase{
    private BotDbContext _dbcontext;

    public CarController(BotDbContext dbContext)
    {
       _dbcontext=dbContext; 
    }

 [HttpGet]
 [Route("/getAllCars")] 
 public IActionResult GetAllCarsFromDb(){
    var result =_dbcontext.Car.ToList();

 return Ok(result);
 }
 
 [HttpPost]
 [Route("/addCar")]
public async Task<IActionResult> AddCar(CarModel carModel)
{
  var s= await _dbcontext.Car.AddAsync(carModel);
  

  await _dbcontext.SaveChangesAsync();

   return Ok(s.Entity);
   
}
 
 [HttpPost]
 public async Task<IActionResult> DeleteCar(long Id)
 {

    var car = _dbcontext.Car.FirstOrDefault(q=>q.Id==Id);
    _dbcontext?.Remove(car);
    await _dbcontext.SaveChangesAsync();
    return Ok("Success deleted");
 }
 [HttpGet]
 [Route("/addBrand")]
public async Task<IActionResult> AddBrand(string BrandName)
{

    var result= await _dbcontext.Brand.AddAsync(new Brands(){BrandName=BrandName});
    await _dbcontext.SaveChangesAsync();
    return Ok( result.Entity);
}
[HttpGet]
[Route("/getAllBrands")]
public async Task<IActionResult> GetAllBrands()
{

    var result=  _dbcontext.Brand.ToList();
    

    
    return Ok(result);
}


}