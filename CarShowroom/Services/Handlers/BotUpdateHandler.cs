using System.Globalization;
using bot.Resources;
using Microsoft.Extensions.Localization;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler : IUpdateHandler
    {
        private readonly ILogger<BotUpdateHandler> _logger;
        private  UserService _userService;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly PurchaseService _purchaseService;
        private readonly CarService _carService;
        private  IStringLocalizer<BotLocalizer> _localizer;

        public BotUpdateHandler(ILogger<BotUpdateHandler> logger,UserService userService,IServiceScopeFactory scopeFactory, PurchaseService purchaseService, CarService carService )
        {
            _logger = logger;
            _userService=userService;
            _scopeFactory=scopeFactory;
            _purchaseService = purchaseService;
            _carService = carService;

        }
        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            _userService = scope.ServiceProvider.GetRequiredService<UserService>();
            var culture = await GetUserLocalizationFromDataBase(update.Message, cancellationToken);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            _localizer = scope.ServiceProvider.GetRequiredService<IStringLocalizer<BotLocalizer>>();
            var handler = update.Type switch
                {
                    UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
                    UpdateType.CallbackQuery => HandleCollbackButton(botClient, update.CallbackQuery, cancellationToken),
                    _ => throw new NotImplementedException()
                };
            await handler;
        }
        private Task HandleUnknownUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update type: {update.Type}", update.Type);
            return Task.CompletedTask;
        }
        private async Task<CultureInfo> GetUserLocalizationFromDataBase(Message? message, CancellationToken cancellationToken)
        {
            if(await _userService.Exits(message?.From?.Id))
            {
                var languageCode=await _userService.GetUserLanguageCode(message?.From?.Id);
                return new CultureInfo(languageCode??"uz-Uz");
            }
                return new CultureInfo("uz-Uz");  
        }     
    }
}
