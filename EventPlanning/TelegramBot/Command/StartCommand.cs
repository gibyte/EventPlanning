using EventPlanning.Control;
using System.Text;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace EventPlanning.TelegramBot.Command
{
    public class StartCommand : ICommand
    {
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public string Name => "/start";

        public async Task Execute(Update update, IRepozitory db)
        {
            long chatId = update.Message.Chat.Id;
            var usrName = update.Message.From.Username;
            string text = "Привет! ";
            await Client.SendTextMessageAsync(chatId, text + usrName + "!");
            
            //await Client.SendTextMessageAsync(chatId, "Привет! " + usrName + "!");
            // кнопки пример
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithUrl("Go url 1", "https://www.google.com/"),
                InlineKeyboardButton.WithUrl("Go url 2", "https://root:7043")
            });
            /*Message message = await Client.SendTextMessageAsync(
                    chatId,
                    text,
                    replyMarkup: inlineKeyboard,
                    parseMode: ParseMode.Markdown);*/

        }
    }
}
