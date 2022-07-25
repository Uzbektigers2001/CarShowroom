using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CarShowroom.Buttons;
using Telegram.Bot.Types.ReplyMarkups;
using System.Globalization;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler
    {
        private  async Task HandleCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery? callbackQuery, CancellationToken cancellationToken)
        {

            //b bosilsa brand bosilgan bo'ladi
            //c bosilsa car bosilgan bo'ladi
            //p bosilsa sotib olish bosilgan bo'ladi
            
            
            var result=callbackQuery?.Data?.FirstOrDefault() switch
            {
               'b'=>HandleBrandCallbackQueryAsync(botClient,callbackQuery,cancellationToken),
               'c'=>HandleCarCallbackQueryAsync(botClient,callbackQuery,cancellationToken),
               'p'=>HandleCarPurchaseCallbackQueryAsync(botClient,callbackQuery,cancellationToken),
               'd'=>HandleDeliveredCallbackQueryAsync(botClient,callbackQuery,cancellationToken),
               
               _=>Task.CompletedTask
            };
            await result;
    }

        private async Task HandleDeliveredCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
        {
            try
            {
                var car = callbackQuery?.Data?.Split('*');
                var carId = int.Parse(car[1]);
                var userId = callbackQuery?.From.Id;
                var carmodel = _carService.GetCarByIdAsync(carId);
                var usermodel = await _userService.GetUserAsync(userId);
                var carTobeDestroyed = _dbcontext.OrderModel.FirstOrDefault(x => x.Id == carId && x.UserId == userId);
                _dbcontext.OrderModel.Remove(carTobeDestroyed);
                _dbcontext.SaveChanges();

                var markup = new ReplyKeyboardMarkup(new KeyboardButton(_localizer["Back"]));
                markup.ResizeKeyboard = true;

                await botClient.SendTextMessageAsync(chatId:callbackQuery.From.Id,
                        text: _localizer["✅"],
                        replyMarkup: markup,
                        cancellationToken: cancellationToken);

            }catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        private async Task HandleCarPurchaseCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
        {
            try
            {
                var car = callbackQuery?.Data?.Split('*');
                var carId = int.Parse(car[1]);
                var useId = callbackQuery?.From.Id;

                var carmodel = _carService.GetCarByIdAsync(carId);
                var usermodel = await _userService.GetUserAsync(useId);

                await _purchaseService.Purchase(carmodel, usermodel);
                await botClient.SendTextMessageAsync(
                        chatId: callbackQuery.From.Id,
                        text: _localizer["buySuccess", carmodel.Name],
                        cancellationToken: cancellationToken,
                        parseMode: ParseMode.Html
                        );
            }
            catch (Exception ex)
            {
                
              await  botClient.SendTextMessageAsync(
                    chatId:callbackQuery.From.Id,
                    text: _localizer["buyUnsuccess"],
                    cancellationToken:cancellationToken,
                    parseMode:ParseMode.Html
                );
            }
            
        }

        private async Task HandleCarCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
        {
            try
            {
                var carString = callbackQuery?.Data?.Split('*');   
                var carId = int.Parse(carString![1]);
                var car = _carService.GetCarByIdAsync(carId);

                await botClient.SendPhotoAsync(
                    chatId:callbackQuery!.From.Id,
                    photo:car!.PictureUrl,
                    caption:$@"
                    {_localizer["carName"].ToString().Replace(" ","_")}_{car.Name.Replace(" ","_")} 
                    {_localizer["carModel"].ToString().Replace(" ","_")}_{car.Position}
                    {_localizer["carRelaeseDate"].ToString().Replace(" ","_")}_{car.ReleaseDate?.ToString("dd/M/yyyy",CultureInfo.InvariantCulture)??""}_y
                    {_localizer["carCountry"]} {car.Country} 
                    {_localizer["carDecription"].ToString().Replace(" ","_")}_{car.Description.Replace(" ","_")}
                    {_localizer["carPrice"]}_{car.Price} _{_localizer["carMoney"]}".Replace(" ",string.Empty).Replace('_',' '),
                    replyMarkup:new InlineKeyboardMarkup(new List<InlineKeyboardButton>(){InlineKeyboardButton.WithCallbackData(_localizer["carBuy"],$"p*{car.Id}")}),
                    parseMode: ParseMode.Html);
            }
            catch (System.Exception e)
            {
                
              System.Console.WriteLine( e.Message );;
            }
          

            
        }

        private async Task HandleBrandCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
        {

            var brand = callbackQuery?.Data?.Split('*');
            var brandId = int.Parse(brand![1]);

            var choosenBrand = await _brandService.GetBrandByIdAsync(brandId);
            var cars = _carService.GetCarsByBrandIdAsync(brandId);
            var CarButtons= TelegramButtons.InLineButton(cars!.ToArray(),'c');

            await botClient.SendTextMessageAsync(
                chatId:callbackQuery!.From.Id,
                text:_localizer["brandChoosen",choosenBrand?.BrandName??"empty"],
                cancellationToken:cancellationToken,
                replyMarkup:CarButtons,
                parseMode:ParseMode.Html
            );
            
        }
    }
}
        
     
    
    


