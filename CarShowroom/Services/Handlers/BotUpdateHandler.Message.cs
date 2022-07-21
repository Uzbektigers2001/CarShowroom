using CarShowroom.Models;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler
    {
        private  async Task HandleMessageAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(message);
         
            var handler = message.Text switch
            {
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
    }
}
