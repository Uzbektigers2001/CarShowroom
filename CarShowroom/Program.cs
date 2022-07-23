using CarShowroom.ApplicationDbContext;
using CarShowroom.Services;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue("BotToken", string.Empty);
// builder.Services.AddDbContext<BotDbContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("ConString")));
builder.Services.AddSingleton<BotDbContext>(s=>new BotDbContext(builder.Configuration.GetConnectionString("ConString")));
builder.Services.AddSingleton<TelegramBotClient>(new TelegramBotClient(token));
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<CarService>();

builder.Services.AddSingleton<IUpdateHandler,BotUpdateHandler>();

builder.Services.AddHostedService<BotBackgroundService>();



var app = builder.Build();
var supportedCultures = new[] { "uz-Uz","en-Us","ru-Ru" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.Run();
