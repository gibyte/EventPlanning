using EventPlanning.Control;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace EventPlanning.TelegramBot.Command
{
    public class NotFoundCommand : ICommand
    {
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public string Name => "/NotFound";

        public async Task Execute(Update update, IRepozitory db)
        {
            long chatId = update.Message.Chat.Id;
            var usrName = update.Message.From.Username;
            //await Client.SendTextMessageAsync(chatId, "Привет! " + usrName + "!");
            string text = "Не известная команда.!";

            // кнопки пример
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithUrl("Go url 1", "https://www.google.com/"),
                InlineKeyboardButton.WithUrl("Go url 2", "https://root:7043")
            });
            Message message = await Client.SendTextMessageAsync(
                    chatId,
                    text,
                    replyMarkup: inlineKeyboard,
                    parseMode: ParseMode.Markdown);

        }
    }
}
