using System.Globalization;
using bot.Resources;
using CarShowroom.Constants;
using CarShowroom.Models;
using Microsoft.Extensions.Localization;
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

            //var res = _dbcontext.User.Where(x => x.Id != 0);

            //_dbcontext.Brand.Add(new Brands
            //{
            //    BrandName = "Chevrolet"
            //});


            //_dbcontext.Car.Add(new CarModel
            //{
            //    Name = "Nexia",
            //    BrandId = 1
            //});


            //_dbcontext.OrderModel.Add(new OrderModel
            //{
            //    CarId = 1,
            //    Sold = false,
            //    UserId = 1353460621,
            //});
            
            //_dbcontext.SaveChanges();   

            var handler = message.Text switch
            {
                "/start" =>HandleStartButtonAsync(client,message,cancellationToken),
                LanguageConstants.Uzb or
                LanguageConstants.Eng or
                LanguageConstants.Rus =>HandleChangeLanguageAsync(client,message,cancellationToken),
                LanguageConstants.Queue or
                LanguageConstants.Очередь or
                LanguageConstants.Navbat => HandleQueueButtonAsync(client,message,cancellationToken),
                LanguageConstants.Настройки or
                LanguageConstants.Settings or
                LanguageConstants.Sozlamalar => HandleSettingsButtonAsync(client,message,cancellationToken),

                _=> HandleOtherMessage(client,message,cancellationToken)
            };
             await handler;
            var from = message.From;
            _logger.LogInformation("Received message from {from!.FirstName} : {message.Text}", from!.FirstName, message.Text); 
        }

        private async Task HandleSettingsButtonAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            try
            {

                var markup = new ReplyKeyboardMarkup("");
                markup.Keyboard = new KeyboardButton[][]
                    {
                    new KeyboardButton[]
                        {
                            new KeyboardButton(_localizer["Choose language"])
                        }
                    };
                markup.ResizeKeyboard = true;



                await client.SendTextMessageAsync(
                    chatId: message!.Chat.Id,
                    text: message.Text!,
                    replyMarkup:  markup,
                    cancellationToken: cancellationToken);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        private async Task HandleOtherMessage(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            try
            {
                List<OrderModel> PurchasedCars = await _purchaseService.GetAllPurchasedCars(Convert.ToInt32(message.Chat.Id));

                if(PurchasedCars.Any(x => message.Text!.Contains(_carService.GetCarByIdAsync((long)x.Id)!.Name!)))
                {
                    _dbcontext.OrderModel.FirstOrDefault(x => x.UserId == message.From!.Id && x.CarId ==                    _dbcontext.Car.FirstOrDefault(y => y.Name! == message!.Text!)!.Id)!.Sold = true;
                    _dbcontext.SaveChanges();

                    await HandleQueueButtonAsync(client, message,cancellationToken); 

                }
                 

                var result = message.Text switch
                {
                    LanguageConstants.TilniTanlang or
                    LanguageConstants.ChooseLanguage or
                    LanguageConstants.ВыберитеЯзык => HandleStringKey(client,message,cancellationToken),
                    _  => throw new NotImplementedException()
                };
                await result;

                async Task HandleStringKey(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
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
                    LanguageButton.ResizeKeyboard = true;



                    await client.SendTextMessageAsync(
                                chatId: message?.Chat.Id,
                                text: _localizer["Choose language"],
                                replyMarkup: LanguageButton,
                                cancellationToken: cancellationToken
                                );
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            
        }

        

        private async Task HandleQueueButtonAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
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


            try
            {
                List<OrderModel> PurchasedCars = await _purchaseService.GetAllPurchasedCars(Convert.ToInt32(message.Chat.Id));

                var buttons = new List<InlineKeyboardButton>();
                PurchasedCars.ForEach(x => buttons.Add(new InlineKeyboardButton("").Text = _carService.GetCarByIdAsync((long)x.Id)!.Name));

                var markup = new InlineKeyboardMarkup(buttons);

                string queueText = "";
                int i = 1;
                PurchasedCars.ForEach(x => queueText += $"{i++}. { _carService.GetCarByIdAsync((long)x.Id)!.Name }" + "\n");

                await client.SendTextMessageAsync(message.Chat.Id,
                            text: String.IsNullOrEmpty(queueText) ? _localizer["Hech qanday ma'lumot topilmadi"] : queueText,
                            replyMarkup: markup,
                            cancellationToken: cancellationToken
                            );
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        private async Task HandleChangeLanguageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            string languagecode = message.Text switch
            {
                Constants.LanguageConstants.Uzb => "uz-Uz",
                Constants.LanguageConstants.Eng => "en-En",
                Constants.LanguageConstants.Rus => "ru-Ru",
                _ => "uz-Uz"
            };
            if (await _userService.Exits(message?.From?.Id))
            {
                await _userService.UpdateUserLanguageCode(message?.From?.Id, languagecode);
            }
            else
            {
                await _userService.AddNewUser(new UserModel()
                {
                    Id = Convert.ToInt32(message!.From!.Id),
                    ChatId = message.Chat.Id,
                    UserName = message.From.Username,
                    FirstName = message.From.FirstName,
                    LastName = message.From.LastName,
                    LanguageCode = languagecode,
                    CardNumber = null,
                    CardBalance = null
                });
            }

            CultureInfo.CurrentCulture = new CultureInfo(languagecode);
            CultureInfo.CurrentUICulture = new CultureInfo(languagecode);


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
