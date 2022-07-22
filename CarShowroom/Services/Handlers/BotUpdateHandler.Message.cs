using System.Globalization;
using CarShowroom.Models;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler
    {

        private  async Task HandleMessageAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(message);
         
            var handler = message.Text switch
            {
<<<<<<< HEAD
                "/start" =>HandleStartButtonAsync(client,message,cancellationToken),
                Constants.LanguageConstants.Uzb or
                Constants.LanguageConstants.Eng or
                Constants.LanguageConstants.Rus =>HandleChangeLanguageAsync(client,message,cancellationToken),
                _=>Task.CompletedTask
            };
             await result;
            var from = message.From;
            _logger.LogInformation("Received message from {from!.FirstName} : {message.Text}", from!.FirstName, message.Text); 
        }
        private async Task HandleChangeLanguageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            string languagecode=message.Text switch
            {
                Constants.LanguageConstants.Uzb =>"uz-Uz",
                Constants.LanguageConstants.Eng =>"en-En",
                Constants.LanguageConstants.Rus => "ru-Ru",
                _=>"uz-Uz"
            };
           if(await _userService.Exits(message?.From?.Id))
           {
               await _userService.UpdateUserLanguageCode(message?.From?.Id,languagecode);
           }
           else
           {
                await _userService.AddNewUser(new UserModel(){
                Id=message.From.Id,
                ChatId=message.Chat.Id,
                UserName=message.From.Username,
                FirstName=message.From.FirstName,
                LastName=message.From.LastName,
                LanguageCode=languagecode,
                CardNumber=null,
                CardBalance=null});            
           }
            CultureInfo.CurrentCulture=new CultureInfo(languagecode);
            CultureInfo.CurrentUICulture=new CultureInfo(languagecode);
            await client.SendTextMessageAsync(
            chatId:message!.Chat.Id,
            text:_localizer["languageSelected",message.Text],
            cancellationToken:cancellationToken 
           );
           
        }
        private  Task HandleUnkownMessage(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {
           _logger.LogInformation("UnkownMessage handled from{message.From.FirstName}", message.From.FirstName);
           return Task.CompletedTask;
        }
        private  async Task HandleStartButtonAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {

        var LanguageButton = new ReplyKeyboardMarkup("Languages choose");
        LanguageButton.Keyboard = new KeyboardButton[][]
            {
                new KeyboardButton[]
                    {
                        new KeyboardButton(Constants.LanguageConstants.Uzb),
                        new KeyboardButton(Constants.LanguageConstants.Rus),
                        new KeyboardButton(Constants.LanguageConstants.Eng)
                    }
            };
        LanguageButton.ResizeKeyboard=true;
        await client.SendTextMessageAsync(
            chatId:message?.Chat.Id,
            text:_localizer["greeting",message.From.FirstName],
            replyMarkup:LanguageButton,
            cancellationToken:cancellationToken
            );

           
        }
    
       
=======
                "/start" => await client.SendTextMessageAsync(
                         message.Chat.Id,
                        "O'zingizga yoqqan companyani tanlang",
                         replyMarkup: CarButtons.BrendsButtons()),
                "Chevrolet" => await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "O'zingizga yoqqan Mashinani tanlang",
                        replyMarkup: CarButtons.ChevroletButtons()),

                "Mercedes-Benz" => await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "O'zingizga yoqqan Mashinani tanlang",
                        replyMarkup: CarButtons.MersadesButtons()),

                "Hyundai" => await client.SendTextMessageAsync(
                       message.Chat.Id,
                       "O'zingizga yoqqan Mashinani tanlang",
                       replyMarkup: CarButtons.HundayButtons()),

                "BMW" => await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "O'zingizga yoqqan Mashinani tanlang",
                        replyMarkup: CarButtons.BMWButtons()),

                "Kia" => await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "O'zingizga yoqqan Mashinani tanlang",
                        replyMarkup: CarButtons.KiyaButtons()),

                "Lada" => await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "O'zingizga yoqqan Mashinani tanlang",
                        replyMarkup: CarButtons.LadaButtons()),
                "Tracker" => await client.SendPhotoAsync(
                        message.Chat.Id,
                       photo: @"https://www.supercars.net/blog/wp-content/uploads/2020/12/2021-BMW-M3-Competition-011-2160-scaled-1.jpg",
                        cancellationToken: cancellationToken
                )

            };

        }
          //  var result= message.Text switch 
          //  {
          //      "/start" =>HandleStartButtonAsync(client,message,cancellationToken),
          //      _=>Task.CompletedTask
//
          //      
//
          //  };
          //  await result;
          //  var from = message.From;
          //  _logger.LogInformation("Received message from {from!.FirstName} : {message.Text}", from!.FirstName, message.Text);
           
           
        

       // private  Task HandleUnkownMessage(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
       // {
       //     
       ////     return Task.CompletedTask;
       //// }
       //// private  async Task HandleStartButtonAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
       //// {
       ////     if( await _userService.Exits(message.From.Id)){
       ////        await client.SendTextMessageAsync(
       ////             chatId:message.Chat.Id,
       ////             text:"You already registerd",
       ////             replyToMessageId:message.MessageId,
       ////             cancellationToken:cancellationToken
       ////         );
       ////         return;
       ////        
       ////      }
////
       ////    await _userService.AddNewUser(new UserModel(){
       ////     Id=message.From.Id,
  //     //     ChatId=message.Chat.Id,
       ////     UserName=message.From.Username,
       ////     FirstName=message.From.FirstName,
       ////     LastName=message.From.LastName,
       ////     LanguageCode=message.From.LanguageCode,
       ////     CardNumber=null,
       ////     CardBalance=null});
       ////     await client.SendTextMessageAsync(
       ////             chatId:message.Chat.Id,
       ////             text:"Success added",
       ////             replyToMessageId:message.MessageId,
       ////             cancellationToken:cancellationToken
       ////         );
////
         //  
        //}
>>>>>>> ca8004bbb25b625aee73deebd10fe41ef2917d76
    }
}
