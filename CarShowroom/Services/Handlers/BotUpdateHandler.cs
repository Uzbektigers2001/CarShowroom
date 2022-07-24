﻿using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CarShowroom.Buttons;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler : IUpdateHandler
    {
       // private readonly AdminService _adminService;
        private readonly CarService _carService;
        private readonly ILogger<BotUpdateHandler> _logger;
        private readonly UserService _userService;
        private readonly BrandService _brandService;

        public BotUpdateHandler(ILogger<BotUpdateHandler> logger,
        UserService userService,
        CarService carService,
        BrandService brandService
        //AdminService adminService
        )
        {
           // _adminService=adminService;
            _carService=carService;
            _logger = logger;
            _userService=userService;
            _brandService=brandService;
            
        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
           // _carService.SaveCarDataAsync();
            var handler = update.Type switch
            {
                UpdateType.CallbackQuery=>HandleCallbackQueryAsync(botClient, update.CallbackQuery, cancellationToken),
                UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
                // UpdateType.CallbackQuery => HandleCollbackButton(botClient, update.CallbackQuery, cancellationToken),
                UpdateType.Unknown => HandleUnknownUpdate(botClient, update, cancellationToken),
                _ => throw new NotImplementedException()
            };

            return Task.CompletedTask;
        }

       private Task HandleUnknownUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update type: {update.Type}", update.Type);

            return Task.CompletedTask;
        }


       
    }
}
