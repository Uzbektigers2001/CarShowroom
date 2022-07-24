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

    public async Task<bool> SaveCarDataAsync()
  {
    List<CarModel> carModels=new List<CarModel>()
    {
        new CarModel
        {
            Name="Nexia 1",
            Country="UZB",
            Brand="Chevrolet",
            Price=7000,
            ReleaseDate=DateTime.Today,
            BrandId=1,
            Description="Bu juda ajoyib Mashina",
            PictureUrl="https://i.ytimg.com/vi/7Gq4RhLLl88/hqdefault.jpg"
        },
        new CarModel
        {    
            Name="Nexia 2",
            Country="UZB",
            Brand="Chevrolet",
            ReleaseDate=DateTime.Today,
            Price=10000,
            Description="Bu juda ajoyib Mashina",
            BrandId=1,
            PictureUrl="https://my-zenit.ru/wp-content/uploads/2020/06/daewx022.jpg"
        },
        new CarModel
        {
            Name="Cobalt",
            Country="UZB",
            Brand="Chevrolet",
            ReleaseDate=DateTime.Today,
            BrandId=1,
            Price=13000,
            PictureUrl="https://img-c.drive.ru/models.large.main.images/0000/000/000/000/0d3/48cfd762ba0d7610-main.jpg"
        }, 
        new CarModel
        {
            Name="Tracker",
            Country="UZB",
            Brand="Chevrolet",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=1,
            Price=20000,
            PictureUrl="https://motor.ru/thumb/1500x0/filters:quality(75):no_upscale()/imgs/2022/07/18/14/5500454/fe912607833ca68e0a3032ab83cec3017a01fb7c.jpg"
        },
        new CarModel
        {
            Name="Tahoe",
            Country="UZB",
            Brand="Chevrolet",
            Price=240000,
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=1,
            PictureUrl="https://www.autostrada.uz/wp-content/uploads/2022/03/5afe12dc646ce9b8f9479.png"
        },
        new CarModel
        {
            Name="Malibu",
            Country="UZB",
            Brand="Chevrolet",
            Price=240000,
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=1,
            PictureUrl="https://repost.uz/storage/uploads/8-1643265234-mursyaev-post-material.png"
        },
        new CarModel
        {
            Name="Mercedes-Benz AMG GT",
            Country="GFR",
            Brand="Mercedes-Benz",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=2,
            Price=240000,
            PictureUrl="https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-AMG-GT-New-Price.jpg"
        },
        new CarModel
        {
            Name="Mercedes-Benz A-Class",
            Country="GFR",
            Brand="Mercedes-Benz",
            Price=240000,
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=2,
            PictureUrl="https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-A-Class-New-Price.jpg"
        },
        new CarModel
        {
            Name="Mercedes-Benz C-Class",
            Country="GFR",
            Brand="Mercedes-Benz",
            Price=240000,
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=2,
            PictureUrl="https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-C-Class-New-Price.jpg"
        },
        new CarModel
        {
            Name="Mercedes-Benz CLA-Class",
            Country="GFR",
            Brand="Mercedes-Benz",
            Price=240000,
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=2,
            PictureUrl="https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-CLA-Class-New-Price.jpg"
        },
        new CarModel
        {
            Name="Mercedes-Benz CLS-Class",
            Country="GFR",
            Brand="Mercedes-Benz",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=2,
            Price=240000,
            PictureUrl="https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-CLS-Class-New-Price.jpg"
        },
        new CarModel
        {
            Name="Mercedes-Benz E-Clas",
            Country="GFR",
            Brand="Mercedes-Benz",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=2,
            Price=240000,
            PictureUrl="https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-E-Class-New-Price.jpg"
        },
        new CarModel
        {
            Name="SUV",
            Country="UK",
            Brand="BMW",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=3,
            Price=240000,
            PictureUrl="https://cdn.autoportal.com/img/new-cars-gallery/bmw/3-series/colors/14547a03f3d32b6b6351262788b3c3c5.jpg"
        },
        new CarModel
        {
            Name="COUPE",
            Country="UK",
            Brand="BMW",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=3,
            Price=240000,
            PictureUrl="https://cdn.autoportal.com/img/new-cars-gallery/bmw/x3/colors/f0800280add41cb3ae670b8e2e9500b5.jpg"
        },
        new CarModel
        {
            Name="BMW SUPPER",
            Country="UK",
            Brand="BMW",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=3,
            Price=240000,
            PictureUrl="https://www.supercars.net/blog/wp-content/uploads/2020/12/2021-BMW-M3-Competition-011-2160-scaled-1.jpg"
        },
        new CarModel
        {
            Name="SEDAN",
            Country="UK",
            Brand="BMW",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=3,
            Price=240000,
            PictureUrl="https://storge.pic2.me/upload/903/57ca87071911e.jpg"
        },
        new CarModel
        {
            Name="LSLOVL",
            Country="UK",
            Brand="BMW",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=3,
            Price=240000,
            PictureUrl="https://storge.pic2.me/upload/903/57ca87071911e.jpg"
        },
        new CarModel
        {
            Name="PSYCHO",
            Country="UK",
            Brand="BMW",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=3,
            Price=240000,
            PictureUrl="https://i.pinimg.com/736x/04/a4/d8/04a4d8d0b73751550471f132836e4784.jpg"
        },
        new CarModel
        {
            Name="Elentra",
            Country="Koreya",
            Brand="HUNDAY",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=4,
            Price=240000,
            PictureUrl="https://static.autox.com/uploads/cars/2019/10/hyundai-elantra-3-oct-2019.jpg"
        },
        new CarModel
        {
            Name="Alcazar",
            Country="Koreya",
            Brand="HUNDAY",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=4,
            Price=240000,
            PictureUrl="https://images.hindustantimes.com/auto/img/2021/06/24/600x338/Hyundai_Alcazar_images_main_1624543806835_1624543815285.jpg"
        },
        new CarModel
        {
            Name="Xcent",
            Country="Koreya",
            Brand="HUNDAY",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=4,
            Price=240000,
            PictureUrl="https://cdn.autoportal.com/img/new-cars-gallery/hyundai/grand-i10-prime/colors/de63fd0677e4f726dbaa300a3ebe385e.jpg"
        },
        new CarModel
        {
            Name="Venue",
            Country="Koreya",
            Brand="HUNDAY",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=4,
            Price=240000,
            PictureUrl="https://www.hyundai.com/content/dam/hyundai/jo/en/data/vehicle-thumbnail/product/sonata-2019/default/sonata-dn8-quater-view-pc.png"
        },
        new CarModel
        {
            Name="Creta",
            Country="Koreya",
            Brand="HUNDAY",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=4,
            Price=240000,
            PictureUrl="https://motor.ru/thumb/1500x0/filters:quality(75):no_upscale()/imgs/2021/07/02/10/4745934/1a2bbf19a507226216f2205c2d21b30b05da9962.jpg"
        },
        new CarModel
        {
            Name="Seltos",
            Country="Koreya",
            Brand="KIYA",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=5,
            Price=240000,
            PictureUrl="//https://media.zigcdn.com/media/model/2022/Apr/seltos-6_360x240.jpg"
        },
        new CarModel
        {
            Name="Carnival",
            Country="Koreya",
            Brand="KIYA",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=5,
            Price=240000,
            PictureUrl="https://stimg.cardekho.com/images/carexteriorimages/930x620/Kia/Carnival/7341/1649825407650/front-left-side-47.jpg"
        },
        new CarModel
        {
            Name="Carens",
            Country="Koreya",
            Brand="KIYA",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=5,
            Price=240000,
            PictureUrl="https://www.automotivekia.in/uploads/product/1645090218_960X530.jpg"
        },
        new CarModel
        {
            Name="Sorento",
            Country="Koreya",
            Brand="KIYA",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=5,
            Price=240000,
            PictureUrl="https://avtoremont.uz/d/kia-sorento-2021.jpg"
        },
        new CarModel
        {
            Name="Stonie",
            Country="Koreya",
            Brand="KIYA",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=5,
            Price=240000,
            PictureUrl="https://kiamotors-portqasim.com/wp-content/uploads/2021/11/2-1.jpg"
        },
        new CarModel
        {
            Name="Seltos 2",
            Country="Koreya",
            Brand="KIYA",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=5,
            Price=240000,
            PictureUrl="https://www.indiacarnews.com/wp-content/uploads/2020/08/Kia-Seltos-Sales-1000x600.jpg"
        },
        new CarModel
        {
            Name="Vesta",
            Country="Russiya",
            Brand="Lada",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=6,
            Price=240000,
            PictureUrl="https://www.autocar.co.uk/sites/autocar.co.uk/files/images/car-reviews/first-drives/legacy/01lada_xray_1.jpg"
        },
        new CarModel
        {
            Name="Lada",
            Country="Russiya",
            Brand="Lada",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=6,
            Price=240000,
            PictureUrl="https://i.ytimg.com/vi/5rHbd8vZXow/maxresdefault.jpg"
        },
        new CarModel
        {
            Name="Lada 4x4",
            Country="Russiya",
            Brand="Lada",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=6,
            Price=240000,
            PictureUrl="https://acnews.blob.core.windows.net/imgnews/large/NAZ_2f0913b63220436a80ba5c06d3d6b96e.jpg"
        },
        new CarModel
        {
            Name="Lada Vesta",
            Country="Russiya",
            Brand="Lada",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=6,
            Price=240000,
            PictureUrl="https://acnews.blob.core.windows.net/imgnews/large/NAZ_2f0913b63220436a80ba5c06d3d6b96e.jpg"
        },
        new CarModel
        {
            Name="Niva",
            Country="Russiya",
            Brand="Lada",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=6,
            Price=240000,
            PictureUrl="https://bilder4.n-tv.de/img/incoming/crop22294387/5151326256-cImg_16_9-w1200/lada-niva-vision-1.jpg"
        },
        new CarModel
        {
            Name="Niva 2",
            Country="Russiya",
            Brand="Lada",
            Description="Bu juda ajoyib Mashina",
            ReleaseDate=DateTime.Today,
            BrandId=6,
            Price=240000,
            PictureUrl="https://i.pinimg.com/236x/2f/d9/09/2fd909135eab3ed349f6e274d2e87586.jpg"
        },

   };
    
   await _dbContext.Car.AddRangeAsync(carModels);
   await _dbContext.SaveChangesAsync();
    return true;  
   
   }
 
 
 }