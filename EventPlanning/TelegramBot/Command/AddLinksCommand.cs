using EventPlanning.Control;
using EventPlanning.Model;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace EventPlanning.TelegramBot.Command
{
    public class AddLinksCommand : ICommand, IListener
    {
        public TelegramBotClient Client => Bot.GetTelegramBot();
        public string Name => "AddLink";
        public CommandExecutor Executor { get; }
        public AddLinksCommand(CommandExecutor executor)
        {
            Executor = executor;
        }
        public async Task Execute(Update update, IRepozitory db)
        {
            var evnts = db.GetEvents("");
            var dbLink = db.AddLink(update.Message.Text);
            long chatId = update.Message.Chat.Id;
            string textMsg = "Куда добавить ссылку?\n";
            await Client.SendTextMessageAsync(chatId, textMsg);
            foreach (var eObj in evnts) 
            {
                var evnt = (Event)eObj;
                if (evnt == null || evnt.Nomenclatures.Count == 0) continue;
                var textEvnt = evnt.Name;
                var listButton = new List<List<InlineKeyboardButton>>();
                var list = new List<InlineKeyboardButton>();
                foreach (var nom in evnt.Nomenclatures) 
                {
                    string text = "==> " + nom.Name;
                    BotCallbackData botCallbackData = new BotCallbackData() { NomId = nom.Id, LinkId = dbLink.Id };
                    string json = JsonConvert.SerializeObject(botCallbackData, Formatting.Indented, new JsonSerializerSettings());
                    var button = new InlineKeyboardButton(text)
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

        public async Task GetUpdate(Update update)
        {
            long chatId = update.Message.Chat.Id;
            if (update.Message.Text == null) //Проверочка
                return;
        }
    }
}
