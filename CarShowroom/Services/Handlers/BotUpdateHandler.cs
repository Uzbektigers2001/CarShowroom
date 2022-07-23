using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CarShowroom.Buttons;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler : IUpdateHandler
    {
        private readonly CarService _carService;
        private readonly ILogger<BotUpdateHandler> _logger;
        private readonly UserService _userService;

        public BotUpdateHandler(ILogger<BotUpdateHandler> logger,UserService userService,CarService carService)
        {
            _carService=carService;
            _logger = logger;
            _userService=userService;
            
        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
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
