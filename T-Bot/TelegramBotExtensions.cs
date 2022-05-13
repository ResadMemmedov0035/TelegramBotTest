using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace T_Bot
{

    public static class TelegramBotExtensions
    {
        public static async Task SendSubscriptionPlansAsync(this ITelegramBotClient botClient, long chatId, IEnumerable<SubscriptionPlan> plans)
        {
            foreach (var plan in plans)
            {
                var message = $"{plan.Title}:\n\n{plan.Details}";
                var button = new InlineKeyboardButton($"{plan.Price} {plan.Currency}")
                {
                    CallbackData = plan.Id.ToString()
                };

                await botClient.SendTextMessageAsync(new ChatId(chatId), message, replyMarkup: new InlineKeyboardMarkup(button));
            }
        }

        public static async Task SendTestButton(this ITelegramBotClient botClient, long chatId)
        {
            var buttons = new List<List<InlineKeyboardButton>>
            {
                new List<InlineKeyboardButton>
                {
                    new InlineKeyboardButton("Button 1") { CallbackData = "Test" },
                    new InlineKeyboardButton("Button 2") { CallbackData = "Test" },
                    new InlineKeyboardButton("Button 3") { CallbackData = "Test" }
                },                                         
                new List<InlineKeyboardButton>             
                {                                          
                    new InlineKeyboardButton("Button 4") { CallbackData = "Test" },
                    new InlineKeyboardButton("Button 5") { CallbackData = "Test" }
                }
            };

            //var button = new InlineKeyboardButton("Button 1") { CallbackData = "Some data" };

            await botClient.SendTextMessageAsync(new ChatId(chatId), "Testing",
                replyMarkup: new InlineKeyboardMarkup(buttons));
                //new InlineKeyboardMarkup(buttons));
        }
    }
}
