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
            var result= message.Text switch 
            {
                "/start" =>HandleStartButtonAsync(client,message,cancellationToken),
                _=>Task.CompletedTask

                

            };
            await result;
            var from = message.From;
            _logger.LogInformation("Received message from {from!.FirstName} : {message.Text}", from!.FirstName, message.Text);
           
           
        }

        private  Task HandleUnkownMessage(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {
            
            return Task.CompletedTask;
        }
        private  async Task HandleStartButtonAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {
            if( await _userService.Exits(message.From.Id)){
               await client.SendTextMessageAsync(
                    chatId:message.Chat.Id,
                    text:"You already registerd",
                    replyToMessageId:message.MessageId,
                    cancellationToken:cancellationToken
                );
                return;
               
             }

           await _userService.AddNewUser(new UserModel(){
            Id=message.From.Id,
            ChatId=message.Chat.Id,
            UserName=message.From.Username,
            FirstName=message.From.FirstName,
            LastName=message.From.LastName,
            LanguageCode=message.From.LanguageCode,
            CardNumber=null,
            CardBalance=null});
            await client.SendTextMessageAsync(
                    chatId:message.Chat.Id,
                    text:"Success added",
                    replyToMessageId:message.MessageId,
                    cancellationToken:cancellationToken
                );

           
        }
    }
}
