using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CarShowroom.Buttons;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler
    {
        private  async Task HandleCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery? callbackQuery, CancellationToken cancellationToken)
        {
            // var car1= await _carService.FindCarByBrand(callbackQuery.Data);
            // var car2=await _carService.GetCarByNameAsync(callbackQuery.Data);


            //b bosilsa brand bosilgan bo'ladi
            //c bosilsa car bosilgan bo'ladi
            
            
            var result=callbackQuery.Data.First() switch
            {
               'b'=>HandleBrandCallbackQueryAsync(botClient,callbackQuery,cancellationToken),
               'c'=>HandleCarCallbackQueryAsync(botClient,callbackQuery,cancellationToken),
               _=>Task.CompletedTask
            };
           await result;
            
            // if(callbackQuery.Data[0]=='B')
            // {
            // try
            //     {

            //  await botClient.SendTextMessageAsync(
            //      chatId:callbackQuery.From.Id,
            //      text:"O'zingizga yoqqan Mashinani tanlang 🚐🚐",
            //     //  replyMarkup:TelegramButtons.InLineButton(car1),
            //      cancellationToken:cancellationToken);
            //     }
            // catch (System.Exception e)
            //     {
            //             _logger.LogInformation(e.Message);
                
            //     }
            // }
            
            // else
            // {

            //     try
            //     {

            //     await botClient.SendPhotoAsync(
            //         chatId:callbackQuery.From.Id,
            //         photo:car2.PictureUrl,
            //         caption:$" Mashina Brendi {car2.Brand}, Mashina narhi {car2.Price}",
            //         cancellationToken:cancellationToken);
                    
            //     }

            //     catch (System.Exception e)
            //     {
            //         _logger.LogInformation(e.Message);
            //     };
            // }
    
    }

        private async Task HandleCarCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
        {
            
            var car=callbackQuery.Data.Split('*');
            
            var  carId=int.Parse(car[1]);
            var car1=_carService.GetCarByIdAsync(carId);
            await botClient.SendPhotoAsync(
                chatId:callbackQuery.From.Id,
                photo:car1.PictureUrl,
                caption:$@" 
                
                Mashina nomi: {car1.Name} 
                Mashina Rusumi: {car1.Position}
                Mashina Ishlab chiqarilgan vaqti: {car1.ReleaseDate},
                Mashina Ish.Ch.M: {car1.Country},
                Mashina Haqida: {car1.Description}
                Mashina Narxi: {car1.Price}"
            );

            throw new NotImplementedException();
        }

        private async Task HandleBrandCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
        {
            System.Console.WriteLine(callbackQuery.Data);

            var brand=callbackQuery.Data.Split('*');
            var  brandId=int.Parse(brand[1]) ;
            System.Console.WriteLine(brandId);
            var cars= _carService.GetCarsByBrandIdAsync(brandId);
            var CarButtons= TelegramButtons.InLineButton(cars.ToArray(),'c');
            await botClient.SendTextMessageAsync(
                chatId:callbackQuery.From.Id,
                text:"Tanlandi",
                cancellationToken:cancellationToken,
                replyMarkup:CarButtons
            );
            
        }
    }
}
        
     
    
    




//            var car1= await _carService.FindCarByBrand(callbackQuery.Data);

//            TelegramButtons.BrandButtons();
        
//             try
//                 {

//             await botClient.SendTextMessageAsync(
//                 chatId:callbackQuery.From.Id,
//                 text:"O'zingizga yoqqan Mashinani tanlang 🚐🚐",
//                 replyMarkup:TelegramButtons.InLineButton(car1),
//                 cancellationToken:cancellationToken);
//                 }

//                 catch (System.Exception e)
//                 {
//                         _logger.LogInformation(e.Message);
//                 }
          
   
//    var cardatas=await _carService.GetCarByNameAsync(callbackQuery.Data);
             
//              try
//                 {

//                 await botClient.SendPhotoAsync(
//                     chatId:callbackQuery.From.Id,
//                     photo:cardatas.PictureUrl,
//                     cancellationToken:cancellationToken);

//             await botClient.SendTextMessageAsync(
//                 chatId:callbackQuery.From.Id,
//                 text:$" CarName --{cardatas.Name}, CarPrice is {cardatas.Price} \nCar Country is {cardatas.Country} "+
//                  $" CarBrand is, {cardatas.Brand}",
//                 cancellationToken:cancellationToken);

//                 }

//                 catch (System.Exception e)
//                 {

//                         _logger.LogInformation(e.Message);

//                 }
            
//             _logger.LogInformation($"{callbackQuery.Message}");
//             _logger.LogInformation($"{callbackQuery.Data}");
        
//          }

        
     
//     }
// }
