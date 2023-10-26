using EventPlanning.Control;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EventPlanning.TelegramBot
{
    public class UpdateDistributor<T> where T : ITelegramUpdateListener, new()
    {
        public TelegramBotClient Client => Bot.GetTelegramBot();
        private Dictionary<long, T> listeners;
        public UpdateDistributor()
        {
            listeners = new Dictionary<long, T>();
        }
        
        public async Task GetUpdate(Telegram.Bot.Types.Update update, IRepozitory db)
        {
            if (update.Message != null)
            {
                long chatId = update.Message.Chat.Id;
                T? listener = listeners.GetValueOrDefault(chatId);
                if (listener is null)
                {
                    listener = new T();
                    listeners.Add(chatId, listener);
                    await listener.GetUpdate(update, db);
                    return;
                }
                await listener.GetUpdate(update, db);
            };
            if (update.CallbackQuery != null)
            {
                var data = update.CallbackQuery.Data;
                if (data != null)
                {
                    long chatId = update.CallbackQuery.From.Id;
                    BotCallbackData? botCallbackData = JsonConvert.DeserializeObject<BotCallbackData>(data);
                    if (botCallbackData != null)
                    {
                        var nom = db.GetNomenclature(botCallbackData.NomId);
                        if (nom != null && botCallbackData.LinkId != 0)
                        {
                            var link = db.GetLink(botCallbackData.LinkId);
                            nom.Links.Add(link);
                            db.UpNomenclature(nom);
                            var text = "Ссылка добавлена";
                            await Client.SendTextMessageAsync(chatId, text);
                        };
                    }
                }
            }

        }
    }
}

