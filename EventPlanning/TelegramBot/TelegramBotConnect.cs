using EventPlanning.Control;
using EventPlanning.Model;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EventPlanning.TelegramBot
{
    [ApiController]
    [Route("/api/telegram")]
    public class TelegramBotConnect
    {
        private readonly IRepozitory _db;
        private readonly UpdateDistributor<CommandExecutor> _updateDistributor = new();
        public TelegramBotConnect(IRepozitory db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task PostAsync(Update update)
        {
            await _updateDistributor.GetUpdate(update, _db);
        }

        [HttpGet]
        public string Get()
        {
            return "Telegram bot was started";
        }
    }
}
