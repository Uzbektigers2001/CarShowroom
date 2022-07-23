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
           

           var car1= await _carService.FindCarByBrand(callbackQuery.Data);

           TelegramButtons.BrandButtons();
        
          if(car1.Count()>1)
          {
            try
                {

            await botClient.SendTextMessageAsync(
                chatId:callbackQuery.From.Id,
                text:"O'zingizga yoqqan Mashinani tanlang 🚐🚐",
                replyMarkup:TelegramButtons.InLineButton(car1),
                cancellationToken:cancellationToken);

                }

                catch (System.Exception e)
                {
                        _logger.LogInformation(e.Message);
                }
          }
   
   var cardatas=await _carService.GetCarByNameAsync(callbackQuery.Data);
             
             try
                {

                await botClient.SendPhotoAsync(
                    chatId:callbackQuery.From.Id,
                    photo:cardatas.PictureUrl,
                    cancellationToken:cancellationToken);

            await botClient.SendTextMessageAsync(
                chatId:callbackQuery.From.Id,
                text:$" CarName --{cardatas.Name}, CarPrice is {cardatas.Price} \nCar Country is {cardatas.Country} "+
                 $" CarBrand is, {cardatas.Brand}",
                cancellationToken:cancellationToken);

                }

                catch (System.Exception e)
                {

                        _logger.LogInformation(e.Message);

                }
            
            _logger.LogInformation($"{callbackQuery.Message}");
            _logger.LogInformation($"{callbackQuery.Data}");
        
        }

        
     
    }
}
