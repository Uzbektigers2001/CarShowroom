using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler
    {
        private async Task HandleMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(message);

            var from = message.From;

            _logger.LogInformation($"Received message from {from!.FirstName} : {message.Text}");
        }
    }
}
