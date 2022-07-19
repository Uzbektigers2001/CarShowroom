using CarShowroom.ApplicationDbContext;
using CarShowroom.Services;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue("BotToken", string.Empty);

builder.Services.AddSingleton(new TelegramBotClient(token));
builder.Services.AddSingleton<IUpdateHandler,BotUpdateHandler>();
builder.Services.AddHostedService<BotBackgroundService>();
builder.Services.AddDbContext<BotDbContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("ConString")));

var app = builder.Build();

app.Run();
