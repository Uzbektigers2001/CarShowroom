using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace CarShowroom.Services
{
    public class BotBackgroundService : BackgroundService
    {
        private readonly ILogger<BotBackgroundService> _logger;
        private readonly TelegramBotClient _botClient;
        private readonly IUpdateHandler _handler;

        public BotBackgroundService(ILogger<BotBackgroundService> logger, TelegramBotClient botClient, IUpdateHandler handler)
        {
            _logger = logger;
            _botClient = botClient;
            _handler = handler;
        }
        


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var bot = await _botClient.GetMeAsync(stoppingToken);

            _logger.LogInformation("Bot started successfully : {bot.Username}", bot.Username);

            _botClient.StartReceiving(
                _handler.HandleUpdateAsync,
                _handler.HandlePollingErrorAsync,
                new ReceiverOptions()
                {
                    ThrowPendingUpdates = true
                },
                stoppingToken);
        }
    }
}
