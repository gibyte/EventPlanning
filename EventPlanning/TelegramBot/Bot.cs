using Telegram.Bot;

namespace EventPlanning.TelegramBot
{
    public class Bot
    {
        private static TelegramBotClient? Client { get; set; }
        public static TelegramBotClient GetTelegramBot()
        {
            if (Client != null)
            {
                return Client;
            }
            Client = new TelegramBotClient("6227426398:AAFeaneO31mLRrrF68MPQgdhxiiX0iLyNcI");
            return Client;
        }
    }
}
