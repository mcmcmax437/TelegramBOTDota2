using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Models;

namespace Telegram.Command.Commands
{
    public class GetWin_Lose : Command
    {
        public override string[] Names { get; set; } = new string[] { "/get_win_lose" };
        public override TelegramBotClient Bot { get; set; }

        public override async void Execute(Message message, TelegramBotClient client)
        {

            //  string win_lose_id = "406814811";

            Bot = client;

            _ = client.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 "Enter account id: ");
            Bot.OnMessage += GetString;

            Console.WriteLine(1);

        }

        private async void GetString(object sender, MessageEventArgs e)
        {
           
            string win_lose_id = e.Message.Text;
            string apiAddres = "https://dotaapiit.azurewebsites.net";
            var cl = new HttpClient();
            cl.BaseAddress = new Uri(apiAddres);

            var resultL = await cl.GetAsync($"DotaApi/Win_Lose?id={win_lose_id}");
            if (resultL.IsSuccessStatusCode)
            {
                var contentL = resultL.Content.ReadAsStringAsync().Result;
                var winlose = JsonConvert.DeserializeObject<Win_Lose>(contentL);
                SendInfAsync(winlose, e.Message);
            }
            else
            {
               await Bot.SendTextMessageAsync(e.Message.From.Id, "\n🧨🧨🧨ОШИБКА🧨🧨🧨" +
                   "\nОдна из причин неудачи:" +
                   "\n1)Такого аккаунта не существует" +
                   "\n2)Вы ввели не верный ID" +
                   "\n3)Вы ввели не число" +
                   "\n4)Пользователь ограничил доступ к личной информации");
            }
           
            Bot.OnMessage -= GetString;
        }

        private async Task SendInfAsync(Win_Lose winlose, Message message)
        {
            if (winlose != null)
            {
                double c;
                c = (winlose.Win * 100) / (winlose.Win + winlose.Lose);
                c = Math.Round(c, 2);
                var res = new Win_LoseResponce
                {
                    Win = winlose.Win,
                    Lose = winlose.Lose,
                    AllMatch = winlose.Win + winlose.Lose,

                    WinRate = c
                };
                _ =  Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    //$"\n Aккаунт ID - {win_lose_id}" +
                    $"\n Побед - {res.Win}" +
                    $"\n Поражений - {res.Lose}" +
                    $"\n Всего игр - {res.AllMatch} " +
                    $"\n Винрей - {res.WinRate}");

            }
            else
            {
                await Bot.SendTextMessageAsync(
               chatId: message.Chat.Id,
              "Fail!!! ",
              replyToMessageId: message.MessageId);
            }
        }
    }
}
