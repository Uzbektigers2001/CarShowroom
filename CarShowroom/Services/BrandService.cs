
using CarShowroom.ApplicationDbContext;
using CarShowroom.Models;

namespace CarShowroom.Services;
public class BrandService
{
    private readonly BotDbContext _dbContext;

    public BrandService(BotDbContext dbContext)
    {
        
        _dbContext=dbContext;  
    }


    public List<Brands> GetBrands(int from=0,int lenght=10){
        
            var brands= _dbContext.Brand.Skip(from).Take(lenght).ToList();
            return brands;
      
      
    }
    public async Task<Brands?> AddNewBrand(Brands brand){
        try
        {
           var d = await _dbContext.Brand.AddAsync(brand);
            await _dbContext.SaveChangesAsync();
            return brand;
        }
        catch (System.Exception)
        {
            
           return null;
        }
          
    }
    public async Task<Brands?> GetBrandByIdAsync(long? brandId)
    {
        try
        {
            var brand=_dbContext.Brand.FirstOrDefault(d=>d.Id==brandId);
            return brand;
        }
        catch (System.Exception)
        {
            
            return null;
        }
    }

    public async Task<bool> RemoveBrandById(long id){
        try
        {
         var brand =   _dbContext.Brand.FirstOrDefault(b=>b.Id==id);
            _dbContext.Brand.Remove(brand);
            return true;
        }
        catch (System.Exception)
        {
            
            return false;
        }
        
    } 
    public async Task Hardcode()  {
        List<Brands> brands= new List<Brands>();
        brands.Add(
            new Brands(){
                BrandName="Chevrolet",
                Id=1
            }
        );
        brands.Add(
            new Brands(){
                BrandName="Mercedes-Benz",
                Id=2
            }
        );
        brands.Add(
            new Brands(){
                BrandName="BMW",
                Id=3
            }
        );
        brands.Add(
            new Brands(){
                BrandName="HUNDAY",
                Id=4
            }
        );
        brands.Add(
            new Brands(){
                BrandName="KIYA",
                Id=5
            }
        );
        brands.Add(
            new Brands(){
                BrandName="Lada",
                Id=6
            }
        );

        foreach(var d in brands){
            var v=await AddNewBrand(d);
           System.Console.WriteLine(v.BrandName); 
        }
    }
}
