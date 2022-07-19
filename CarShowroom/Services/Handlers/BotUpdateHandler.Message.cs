using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace CarShowroom.Services
{
    public partial class BotUpdateHandler
    {
        private Task HandleMessageAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(message);

            var from = message.From;

            var keyboardCompany = new ReplyKeyboardMarkup(
                                       new[] {
                                            new[]{
                                                new KeyboardButton("Chevrolet"),
                                                new KeyboardButton("Mercedes-Benz"),
                                                new KeyboardButton("Hyundai")
                                            },
                                            new[]{
                                                new KeyboardButton("BMW"),
                                                new KeyboardButton("Kia"),
                                                new KeyboardButton("Lada")
                                            }
                                       })
            {
                ResizeKeyboard = true
            };


            var keyboardModel = new ReplyKeyboardMarkup(
                                       new[] {
                                            new[]{
                                                new KeyboardButton("Nexia 1"),
                                                new KeyboardButton("Nexia 2"),
                                                new KeyboardButton("Cobalt")
                                            },
                                            new[]{
                                                new KeyboardButton("Tracker"),
                                                new KeyboardButton("Tahoe"),
                                                new KeyboardButton("Malibu")
                                            }
                                       })
            {
                ResizeKeyboard = true
            };


            if (message.Text == "/start")
            {
                client.SendTextMessageAsync(message.Chat.Id, "aaa", replyMarkup: keyboardCompany);
            }
            if(message.Text == "    ")
            {
                client.SendTextMessageAsync(message.Chat.Id, "aaa", replyMarkup: keyboardModel);
            }
               





            _logger.LogInformation("Received message from {from!.FirstName} : {message.Text}", from!.FirstName, message.Text);
            return Task.CompletedTask;
        }
    }
}
