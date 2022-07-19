using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler
    {
        private Task HandleCollbackButton(ITelegramBotClient botClient, CallbackQuery? callback, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;   
        }
    }
}
