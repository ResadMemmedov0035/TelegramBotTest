using T_Bot;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.Payments;
using Telegram.Bot.Types.ReplyMarkups;
using static T_Bot.SubPlanDetails;

string providerTokenSG = "1877036958:TEST:3b4911ec93d4eca8df3201e836bca0b6567824b4"; // provider: Smart-Glocal (TEST)
string providerTokenYoo = "381764678:TEST:37158"; // provider: Yoo-Kassa (TEST)
string providerTokenStripe = "284685063:TEST:OTdhYjIzYTcyZTQw"; // provider: Stripe (TEST)
string botToken = "5235680161:AAGzCE2csQW46C5f-6q7jjrQpAnpmYJCFF8";

var botClient = new TelegramBotClient(botToken);

//await botClient.DeleteWebhookAsync();

var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { } // allow all updates
};


botClient.StartReceiving(async (bot, update, token) =>
{
    long chatId = 0;
    string message = string.Empty;

    if (update.Type == UpdateType.Message)
    {
        chatId = update.Message!.Chat.Id;
        message = update.Message!.Text ?? message;
    }
    else if (update.Type == UpdateType.ChannelPost)
    {
        chatId = update.ChannelPost!.Chat.Id;
        message = update.ChannelPost!.Text ?? message;

        if (message == "/subplans")
        {
            var plans = SubscriptionPlanInMemoryDb.GetAll();
            await bot.SendSubscriptionPlansAsync(chatId, plans);
        }
        else if (message == "/test")
        {
            await bot.SendTestButton(chatId);
        }
    }
    else if (update.Type == UpdateType.CallbackQuery)
    { 

    }

    //var btn = new InlineKeyboardButton("Button")
    //{
    //    CallbackData = "Callback data"
    //};

    //var rkm = new InlineKeyboardMarkup(btn);

    //await bot.SendTextMessageAsync(new ChatId(chatId), $"You said: {message}", replyMarkup: rkm);

    //if (message == "/subscribe")
    //{
    //    await bot.SendInvoiceAsync(
    //        chatId, 
    //        _1MonthSubTitle, 
    //        _1MonthSubDetail,
    //        "Test Payload", 
    //        providerTokenStripe, 
    //        "USD",
    //        new List<LabeledPrice> { new LabeledPrice("Some Label 1", 1234) }
    //        //replyMarkup: rkm
    //        );
    //}
}, 
ErrorHandler,
receiverOptions);

Console.ReadLine();

// methods //



//async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken token)
//{
//    string result = "<<Null>>";

//    if (update.Message != null)
//    {
//        result = $"Text: {update.Message.Text}\n" +
//                 $"Chat Id: {update.Message.Chat.Id}\n" +
//                 $"Username: {update.Message.Chat.Username}";

//        if (update.Message.Text == "Salam")
//        {
//            await bot.SendTextMessageAsync(new ChatId(update.Message.Chat.Id), "Sənə də salam.");
//        }

//    }

//    Console.WriteLine(result);
//}

Task ErrorHandler(ITelegramBotClient bot, Exception exception, CancellationToken token)
{
    throw exception;
}