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
                "/start" =>HandleStartButtonAsync(client,message,cancellationToken),
                Constants.LanguageConstants.Uzb or
                Constants.LanguageConstants.Eng or
                Constants.LanguageConstants.Rus =>HandleChangeLanguageAsync(client,message,cancellationToken),
                _=>Task.CompletedTask
            };
             await handler;
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


            var BrandsQueueAndSettings = new ReplyKeyboardMarkup("BrandsQueueAndSettings");
            BrandsQueueAndSettings.Keyboard = new KeyboardButton[][]
                {
                new KeyboardButton[]
                    {
                        new KeyboardButton(_localizer["Brands"]),
                        new KeyboardButton(_localizer["Queue"]),
                        new KeyboardButton(_localizer["Settings"])
                    }
                };
            BrandsQueueAndSettings.ResizeKeyboard = true;



            await client.SendTextMessageAsync(
            chatId:message!.Chat.Id,
            text:_localizer["languageSelected",message.Text],
            replyMarkup: BrandsQueueAndSettings,
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
    
       
    }
}
