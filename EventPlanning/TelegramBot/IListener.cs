using EventPlanning.Control;
using Telegram.Bot.Types;

namespace EventPlanning.TelegramBot
{
    public interface IListener
    {
        public async Task GetUpdate(Update update, IRepozitory db) { }
        public CommandExecutor Executor { get; }
    }
}