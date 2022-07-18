using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler : IUpdateHandler
    {
        private readonly ILogger<BotUpdateHandler> _logger;

        public BotUpdateHandler(ILogger<BotUpdateHandler> logger)
        {
            _logger = logger;

        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
                UpdateType.Unknown => HandleUnknownUpdate(botClient, update, cancellationToken)
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
