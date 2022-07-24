using CarShowroom.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace CarShowroom.Buttons;

public static class TelegramButtons
{
    public static InlineKeyboardMarkup? InLineButton(CarModel[] carModels,char key)
    {
        
        var buttons=new List<List<InlineKeyboardButton>>();
        var carBtn=carModels.
            Select(e=>new List<InlineKeyboardButton>(){InlineKeyboardButton.WithCallbackData(e.Name,$"{key}*{e.Id}")})
            .ToList();

    return new InlineKeyboardMarkup(carBtn);

    }


    public static InlineKeyboardMarkup? InLineButtonBrand(Brands[] brands,char key)
    {
        
        var buttons=new List<List<InlineKeyboardButton>>();
        var btn= brands.Select(e=>new List<InlineKeyboardButton>(){InlineKeyboardButton.WithCallbackData(e.BrandName,$"{key}*{e.Id}")}).ToList();


        return new InlineKeyboardMarkup(btn);

    }
  
}
