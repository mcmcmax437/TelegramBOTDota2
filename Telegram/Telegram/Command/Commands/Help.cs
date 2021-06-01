using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Telegram.Command.Commands
{
    class Help : Command
    {
        public override string[] Names { get; set; } = new string[] { "/help" };

        public override TelegramBotClient Bot { get; set; }
        public override async void Execute(Message message, TelegramBotClient client)
        {

            Bot = client;

            _ = client.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 "\nВоспомогательная информация по боту:" +
                 "\n/help - стартовая информация" +
                 "\n/post - сохранить героя в DB так же можно узнать какой герой соответствует какому id" +
                 "\n/get_info_from_db - проверить добавился ли персонаж в базу данных" +
                 "\n/get_account - поиск аккаунта по id" +
                 "\n/get_match - поиск матча по id" +
                 "\n/get_team - поиск Pro-команды по id" +
                 "\n/get_turnir - список турниров" +
                 "\n/get_win_lose - информация по матчам и винрейту на аккаунте");   
        }

   
    }
}
