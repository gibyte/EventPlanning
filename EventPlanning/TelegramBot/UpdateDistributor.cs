using EventPlanning.Control;
using EventPlanning.Model;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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
                    if (botCallbackData == null) return;
                    var nom = db.GetNomenclature(botCallbackData.NomId);
                    if (nom != null)
                    {
                        if (botCallbackData.LinkId != 0)
                        {
                            var link = db.GetLink(botCallbackData.LinkId);
                            nom.Links.Add(link);
                            db.UpNomenclature(nom);
                            var text = "Ссылка добавлена";
                            await Client.SendTextMessageAsync(chatId, text);
                        };
                        if (botCallbackData.View)
                        {
                            var textEvnt = "Ссылки:";
                            var listButton = new List<List<InlineKeyboardButton>>();
                            var list = new List<InlineKeyboardButton>();
                            foreach (var eObj in nom.Links)
                            {
                                var link = (NomenclatureLink)eObj;
                                if (link == null) continue;
                                var button = new InlineKeyboardButton(link.Name)
                                {
                                    Url = link.Link
                                };
                                list.Add(button);
                            }; 
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
            }

        }
    }


