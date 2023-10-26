using EventPlanning.Control;
using EventPlanning.TelegramBot.Command;
using Telegram.Bot.Types;

namespace EventPlanning.TelegramBot
{
    public class CommandExecutor : ITelegramUpdateListener
    {
        private List<ICommand> commands;
        private IListener? listener;
        private NotFoundCommand _notFoundCommand = new();
        public CommandExecutor()
        {
            commands = new List<ICommand>()
            {
                new StartCommand(),
                new AddLinksCommand(this)
            };
        }

        public async Task GetUpdate(Update update, IRepozitory db)
        {
            if (listener == null)
            {
                await ExecuteCommand(update, db);
            }
            else
            {
                await listener.GetUpdate(update, db);
            }
        }

        private async Task ExecuteCommand(Update update, IRepozitory db)
        {
            Message msg = update.Message;
            var NameAddLink = "AddLink";
            var ComandExe = false;
            foreach (var command in commands)
            {     
                if (command.Name == msg.Text || (IsUrl(msg.Text) && command.Name == NameAddLink))
                {
                    ComandExe = true;
                    await command.Execute(update, db);
                }
            }
            if (!ComandExe) _notFoundCommand.Execute(update, db);
        }

        private bool IsUrl(string? text)
        {
            if (text == null) return false;
            return text.IndexOf("http://") == 0 || text.IndexOf("https://") == 0;
        }

        public void StartListen(IListener newListener)
        {
            listener = newListener;
        }

        public void StopListen()
        {
            listener = null;
        }
    }
}