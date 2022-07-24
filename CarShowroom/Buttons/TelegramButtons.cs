using CarShowroom.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace CarShowroom.Buttons;

public static class TelegramButtons
{
    public static InlineKeyboardMarkup? InLineButton(CarModel[] carModels,char key)
    {
        
        var buttons=new List<List<InlineKeyboardButton>>();
    
        for (int i = 0; i <carModels.Count(); i++)
        {  
            System.Console.WriteLine(carModels[i].BrandId);
            
            var button=new List<InlineKeyboardButton>();
            
            int k=0;
            for(int j=i;j<i+2;j++)
            {
              button.Add(InlineKeyboardButton.WithCallbackData(carModels[j].Name,$"{key}*{carModels[j].BrandId}"));
              k=j;
            }

            i=k;
          buttons.Add(button);
        }


    return new InlineKeyboardMarkup(buttons);

    }


    public static InlineKeyboardMarkup? InLineButtonBrand(Brands[] brands,char key)
    {
        
        var buttons=new List<List<InlineKeyboardButton>>();

        
        for (int i = 0; i <brands.Count(); i++)
        {  
          
            var button=new List<InlineKeyboardButton>();

            int k=0;
            for(int j=i;j<i+2;j++)
            {
              button.Add(InlineKeyboardButton.WithCallbackData(brands[j].BrandName,$"{key}*{brands[j].Id}"));
              k=j;
            }

            i=k;
            
          buttons.Add(button);
        }
        

        return new InlineKeyboardMarkup(buttons);

    }
  
}
