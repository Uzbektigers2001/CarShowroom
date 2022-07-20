using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler
    {
        private  Task HandleMessageAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(message);
            var result= message.Text switch 
            {
                "/start" =>HanddleStartButtonAsync(client,message,cancellationToken),
                

            };
            var from = message.From;
            _logger.LogInformation("Received message from {from!.FirstName} : {message.Text}", from!.FirstName, message.Text);
            return Task.CompletedTask;
        }

        private  Task HanddleStartButtonAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        private  Task HandleUnkownMessage(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {
           return Task.CompletedTask;
        }
    }
}
