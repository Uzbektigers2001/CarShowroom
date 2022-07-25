using System.Globalization;
using bot.Resources;
using CarShowroom.ApplicationDbContext;
using CarShowroom.Models;
using Microsoft.Extensions.Localization;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler : IUpdateHandler
    {
        private readonly BrandService _brandService;
        private readonly ILogger<BotUpdateHandler> _logger;
        private  UserService _userService;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly PurchaseService _purchaseService;
        private readonly CarService _carService;
        private readonly BotDbContext _dbcontext;
        private  IStringLocalizer<BotLocalizer> _localizer;

        public BotUpdateHandler(ILogger<BotUpdateHandler> logger,  BrandService brandService,UserService userService,IServiceScopeFactory scopeFactory, PurchaseService purchaseService, CarService carService, BotDbContext dbContext )
        {
            _brandService=brandService;
            _logger = logger;
            _userService=userService;
            _scopeFactory=scopeFactory;
            _purchaseService = purchaseService;
            _carService = carService;
            _dbcontext = dbContext;
            

        }
        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogInformation(exception.Message);
            return Task.CompletedTask;
        }
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
                _userService = scope.ServiceProvider.GetRequiredService<UserService>();
                var culture = await GetUserLocalizationFromDataBase(update, cancellationToken);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
                _localizer = scope.ServiceProvider.GetRequiredService<IStringLocalizer<BotLocalizer>>();

            var handler = update.Type switch
                {
                    UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
                    UpdateType.CallbackQuery => HandleCallbackQueryAsync(botClient, update.CallbackQuery, cancellationToken),
                    _ => throw new NotImplementedException()
                };

            await handler;
        }
        private Task HandleUnknownUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update type: {update.Type}", update.Type);
            return Task.CompletedTask;
        }
        private async Task<CultureInfo> GetUserLocalizationFromDataBase(Update? update, CancellationToken cancellationToken)
        {
            try
            {
                   if(await _userService.Exits(update.Message?.From?.Id ?? update.CallbackQuery.From.Id))
                {
                    var languageCode=await _userService.GetUserLanguageCode(update.Message?.From?.Id ?? update.CallbackQuery.From.Id);
                    return new CultureInfo(languageCode??"uz-Uz");
                }
                else
                {
                    await _userService.AddNewUser(new UserModel(){
                        UserName=update?.Message?.From?.Username,
                        FirstName=update?.Message?.From?.FirstName,
                        LanguageCode=update?.Message?.From?.LanguageCode,
                        LastName=update?.Message?.From?.LastName,
                        Id= update.Message.From.Id,
                        ChatId=update.Message.Chat.Id
                    });
                }
      
                if (await _userService.Exits(update.CallbackQuery?.From?.Id))
                {
                    var languageCode = await _userService.GetUserLanguageCode(update.CallbackQuery?.From?.Id);
                    return new CultureInfo(languageCode ?? "uz-Uz");
                }
            }
            catch (System.Exception e)
            {
                
                _logger.LogInformation(e.Message);
            }
            
             
          

                return new CultureInfo("uz-Uz");  
        }     
    }
}
