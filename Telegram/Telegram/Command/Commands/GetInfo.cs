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
    class GetInfo : Command
    {
        public override string[] Names { get; set; } = new string[] { "/get_info_from_db" };

        public override TelegramBotClient Bot { get; set; }
        public override async void Execute(Message message, TelegramBotClient client)
        {

            //string accID = "406814811";

            Bot = client;

            _ = await client.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 "Enter hero id to check, was it added or not: ");
            Bot.OnMessage += GetString;

            Console.WriteLine(1);
        }

        private async void GetString(object sender, MessageEventArgs e)
        {

            string heroid = e.Message.Text;
            string apiAddres = "https://dotaapiit.azurewebsites.net";
            var cl = new HttpClient();
            cl.BaseAddress = new Uri(apiAddres);
       
            var result1 = await cl.GetAsync($"/DotaApi/getINFOfromDB?privateID={heroid}");
            if (result1.IsSuccessStatusCode)
            {
                var content2 = result1.Content.ReadAsStringAsync().Result;
                var info = JsonConvert.DeserializeObject<DBresponce>(content2);

                SendInf(info, e.Message);
            }
            else
            {
                await Bot.SendTextMessageAsync(e.Message.From.Id, "\n🧨🧨🧨ОШИБКА🧨🧨🧨" +
              "\nОдна из причин неудачи:" +
              "\n1)Такого гуроя нету в базе данных" +
              "\n2)Вы ввели не верный ID" +
              "\n3)Вы ввели не число" +
              "\n4)Вы не добавили героя такого в базу даных");
            }

            Bot.OnMessage -= GetString;
        }

        protected async void SendInf(DBresponce dBresponce, Message e)
        {
            if (dBresponce != null)
            {
                _ = Bot.SendTextMessageAsync(
               chatId: e.Chat.Id,
               $"\nID: {dBresponce.id} " +
               $"\nГерой: {dBresponce.Hero}"
               );
            }
        }
    }
}
