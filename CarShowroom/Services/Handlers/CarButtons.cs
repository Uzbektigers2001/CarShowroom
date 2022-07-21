using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
namespace CarShowroom.Services;
public  class CarButtons
{
    public  static ReplyKeyboardMarkup BrendsButtons()
    {
        var keyboardCompany = new ReplyKeyboardMarkup(
                                       new[] {
                                            new[]{
                                                new KeyboardButton("Chevrolet"),
                                                new KeyboardButton("Mercedes-Benz"),
                                                new KeyboardButton("Hyundai")
                                            },
                                            new[]{
                                                new KeyboardButton("BMW"),
                                                new KeyboardButton("Kia"),
                                                new KeyboardButton("Lada")
                                            }
                                       })
            {
                ResizeKeyboard = true
            };

     return keyboardCompany;

    }
   public static  ReplyKeyboardMarkup  ChevroletButtons()
   {

      var keyboardChevrolert = new ReplyKeyboardMarkup(
                                       new[] {
                                            new[]{
                                                new KeyboardButton("Nexia 1"),//https://i.ytimg.com/vi/7Gq4RhLLl88/hqdefault.jpg
                                                new KeyboardButton("Nexia 2"),//https://my-zenit.ru/wp-content/uploads/2020/06/daewx022.jpg
                                                new KeyboardButton("Cobalt")//https://img-c.drive.ru/models.large.main.images/0000/000/000/000/0d3/48cfd762ba0d7610-main.jpg
                                            },
                                            new[]{
                                                new KeyboardButton("Tracker"),//https://motor.ru/thumb/1500x0/filters:quality(75):no_upscale()/imgs/2022/07/18/14/5500454/fe912607833ca68e0a3032ab83cec3017a01fb7c.jpg
                                                new KeyboardButton("Tahoe"),//https://www.autostrada.uz/wp-content/uploads/2022/03/5afe12dc646ce9b8f9479.png
                                                new KeyboardButton("Malibu")//https://repost.uz/storage/uploads/8-1643265234-mursyaev-post-material.png
                                            }
                                       });
    

    return keyboardChevrolert;

   } 

  public static ReplyKeyboardMarkup MersadesButtons()
  {

    var keyboardMersades = new ReplyKeyboardMarkup(
                                       new[] {
                                            new[]{
                                                new KeyboardButton("Mercedes-Benz AMG GT"),//https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-AMG-GT-New-Price.jpg
                                                new KeyboardButton("Mercedes-Benz A-Class"),//https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-A-Class-New-Price.jpg
                                                new KeyboardButton("Mercedes-Benz C-Class")//https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-C-Class-New-Price.jpg
                                            },
                                            new[]{
                                                new KeyboardButton("Mercedes-Benz CLA-Class"),//https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-CLA-Class-New-Price.jpg
                                                new KeyboardButton("Mercedes-Benz CLS-Class"),//https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-CLS-Class-New-Price.jpg
                                                new KeyboardButton("Mercedes-Benz E-Clas")//https://news.maxabout.com/wp-content/uploads/2019/06/Mercedes-E-Class-New-Price.jpg
                                            }
                                       });

    return keyboardMersades;

  }
  public static ReplyKeyboardMarkup BMWButtons()
  {

    var keyboardBMW = new ReplyKeyboardMarkup(
                                       new[] {
                                            new[]{
                                                new KeyboardButton("SUV"),//https://cdn.autoportal.com/img/new-cars-gallery/bmw/3-series/colors/14547a03f3d32b6b6351262788b3c3c5.jpg
                                                new KeyboardButton("COUPE"),//https://cdn.autoportal.com/img/new-cars-gallery/bmw/x3/colors/f0800280add41cb3ae670b8e2e9500b5.jpg
                                                new KeyboardButton("BMW SUPPER")//https://www.supercars.net/blog/wp-content/uploads/2020/12/2021-BMW-M3-Competition-011-2160-scaled-1.jpg
                                            },
                                            new[]{
                                                new KeyboardButton("SEDAN"),//https://storge.pic2.me/upload/903/57ca87071911e.jpg
                                                new KeyboardButton("LSLOVL"),//https://storge.pic2.me/upload/903/57ca87071911e.jpg
                                                new KeyboardButton("PSYCHO")//https://i.pinimg.com/736x/04/a4/d8/04a4d8d0b73751550471f132836e4784.jpg
                                            }
                                       });

    return keyboardBMW;

  }
  public static ReplyKeyboardMarkup HundayButtons()
  {

    var keyboardHunday = new ReplyKeyboardMarkup(
                                       new[] {
                                            new[]{
                                                new KeyboardButton("Elentra"),//https://static.autox.com/uploads/cars/2019/10/hyundai-elantra-3-oct-2019.jpg
                                                new KeyboardButton("Alcazar"),//https://images.hindustantimes.com/auto/img/2021/06/24/600x338/Hyundai_Alcazar_images_main_1624543806835_1624543815285.jpg
                                                new KeyboardButton("Xcent")//https://cdn.autoportal.com/img/new-cars-gallery/hyundai/grand-i10-prime/colors/de63fd0677e4f726dbaa300a3ebe385e.jpg
                                            },
                                            new[]{
                                                new KeyboardButton("Venue"),//https://www.hyundai.com/content/dam/hyundai/jo/en/data/vehicle-thumbnail/product/sonata-2019/default/sonata-dn8-quater-view-pc.png
                                                new KeyboardButton("Verna"),//https://i.pinimg.com/originals/5e/a7/d0/5ea7d044f0a252fdb9bad9ecefe1ca9f.jpg
                                                new KeyboardButton("Creta")//https://motor.ru/thumb/1500x0/filters:quality(75):no_upscale()/imgs/2021/07/02/10/4745934/1a2bbf19a507226216f2205c2d21b30b05da9962.jpg
                                            }
                                       });

     return keyboardHunday;        

  }
  public static ReplyKeyboardMarkup KiyaButtons()
  {

    var keyboardKiya = new ReplyKeyboardMarkup(
                                       new[] {
                                            new[]{
                                                new KeyboardButton("Seltos"),//https://media.zigcdn.com/media/model/2022/Apr/seltos-6_360x240.jpg
                                                new KeyboardButton("Carnival"),//https://stimg.cardekho.com/images/carexteriorimages/930x620/Kia/Carnival/7341/1649825407650/front-left-side-47.jpg
                                                new KeyboardButton("Carens")//https://www.automotivekia.in/uploads/product/1645090218_960X530.jpg
                                            },
                                            new[]{
                                                new KeyboardButton("Sorento"),//https://avtoremont.uz/d/kia-sorento-2021.jpg
                                                new KeyboardButton("Stonie"),//https://kiamotors-portqasim.com/wp-content/uploads/2021/11/2-1.jpg
                                                new KeyboardButton("Seltos 2")//https://www.indiacarnews.com/wp-content/uploads/2020/08/Kia-Seltos-Sales-1000x600.jpg
                                            }
                                       });

    return keyboardKiya;  

  }
  public static ReplyKeyboardMarkup LadaButtons()
  {

    var keyboardLada = new ReplyKeyboardMarkup(
                                       new[] {
                                            new[]{
                                                new KeyboardButton("Vesta"),//https://www.autocar.co.uk/sites/autocar.co.uk/files/images/car-reviews/first-drives/legacy/01lada_xray_1.jpg
                                                new KeyboardButton("Lada"),//https://i.ytimg.com/vi/5rHbd8vZXow/maxresdefault.jpg
                                                new KeyboardButton("Lada 4x4")//https://acnews.blob.core.windows.net/imgnews/large/NAZ_2f0913b63220436a80ba5c06d3d6b96e.jpg
                                            },
                                            new[]{
                                                new KeyboardButton("Lada Vesta"),//https://cdn.motor1.com/images/mgl/7ZLYPo/s3/bespilotnaya-lada-vesta.jpg
                                                new KeyboardButton("Niva"),//https://bilder4.n-tv.de/img/incoming/crop22294387/5151326256-cImg_16_9-w1200/lada-niva-vision-1.jpg
                                                new KeyboardButton("Niva 2")//https://i.pinimg.com/236x/2f/d9/09/2fd909135eab3ed349f6e274d2e87586.jpg
                                            }
                                       });

    return keyboardLada;

  }
   
}