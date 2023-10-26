using EventPlanning.Control;
using Telegram.Bot.Types;

namespace EventPlanning.TelegramBot
{
    public interface ITelegramUpdateListener
    {
        Task GetUpdate(Update update, IRepozitory db);
    }
}