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
            string text = "Не известная команда.! нажмите для начала /start";
            await Client.SendTextMessageAsync(chatId, text);
        }
    }
}
