using CarShowroom.Buttons;
using CarShowroom.Models;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


namespace CarShowroom.Services
{
    public partial class BotUpdateHandler
    {
        private  async Task HandleMessageAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(message);
             
            var result= message.Text switch
            {
                "/start"=>SendMessaga( client , message, cancellationToken),
            };


            await result;
        }

        

        public async Task SendMessaga(ITelegramBotClient client ,Message? message, CancellationToken cancellationToken)
    {
           try
           {
        
            var brands= _brandService.GetBrands();
            System.Console.WriteLine(brands.Count());
            var btn=brands.ToArray();

            var BrandButtons=TelegramButtons.InLineButtonBrand(btn,'b');
            
        
        await client.SendTextMessageAsync(
            chatId:message.Chat.Id,
            text:"Brendni Tanlang",
            replyMarkup:BrandButtons
            );
           }
           catch(Exception e)
           {
             _logger.LogInformation(e.Message);
           }
        
    }
           
    }
}
