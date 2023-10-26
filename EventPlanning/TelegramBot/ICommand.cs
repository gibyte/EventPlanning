﻿using EventPlanning.Control;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EventPlanning.TelegramBot
{
    public interface ICommand
    {
        public TelegramBotClient Client { get; }
        public string Name { get; }
        public async Task Execute(Update update, IRepozitory db) { }
    }
}
