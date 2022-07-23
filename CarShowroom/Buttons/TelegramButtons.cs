using CarShowroom.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace CarShowroom.Buttons;

public static class TelegramButtons
{
    public static InlineKeyboardMarkup? InLineButton(CarModel[] carModels)
    {
        
        var buttons=new List<List<InlineKeyboardButton>>();

        var car=new CarModel[]{};
        for (int i = 0; i <carModels.Count(); i++)
        {  
          
            var button=new List<InlineKeyboardButton>();
           
              button.Add(InlineKeyboardButton.WithCallbackData(carModels[i].Name,$"{carModels[i].Brand}"));
             
            
          buttons.Add(button);
        }
        

        return new InlineKeyboardMarkup(buttons);
    }
    public static InlineKeyboardMarkup BrandButtons()
    {
     var markup = new InlineKeyboardMarkup(
            new InlineKeyboardButton[][]
            {
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData("Chevrolet",  "Chevrolet"),
                    
                    InlineKeyboardButton
                        .WithCallbackData(text: "Mercedes-Benz", callbackData: "Mercedes-Benz"),

                    InlineKeyboardButton
                        .WithCallbackData(text: "Hyundai", callbackData: "Hyundai")
                },
                 new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData("Chevrolet",  "Chevrolet"),
                    
                    InlineKeyboardButton
                        .WithCallbackData(text: "Kia", callbackData: "Kia"),

                    InlineKeyboardButton
                        .WithCallbackData(text: "Lada", callbackData: "Lada")
                }
            });


      return markup;
    }
}
