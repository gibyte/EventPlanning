using EventPlanning.Control;
using EventPlanning.Model;
using Newtonsoft.Json;
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

            var evnts = db.GetEvents("");
            //var dbLink = db.AddLink(update.Message.Text);
            foreach (var eObj in evnts)
            {
                var evnt = (Event)eObj;
                if (evnt == null || evnt.Nomenclatures.Count == 0) continue;
                var textEvnt = evnt.Name;
                var listButton = new List<List<InlineKeyboardButton>>();
                var list = new List<InlineKeyboardButton>();
                foreach (var nom in evnt.Nomenclatures)
                {
                    string textEvn = "==> " + nom.Name;
                    BotCallbackData botCallbackData = new BotCallbackData() { NomId = nom.Id, View = true, };
                    string json = JsonConvert.SerializeObject(botCallbackData, Formatting.Indented, new JsonSerializerSettings());
                    var button = new InlineKeyboardButton(nom.Name)
                    {
                        CallbackData = json,
                    };
                    list.Add(button);
                }
                listButton.Add(list);
                var inline = new InlineKeyboardMarkup(listButton);
                try
                {
                    await Client.SendTextMessageAsync(chatId, textEvnt, replyMarkup: inline);
                }
                catch (Exception e)
                {
                    await Client.SendTextMessageAsync(chatId, e.Message.ToString());
                }

            }

        }
    }
}
