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
    public class GetAcc : Command
    {
         public override string[] Names { get; set; } = new string[] { "/get_account" };

        public override TelegramBotClient Bot { get; set; }
        public override async void Execute(Message message, TelegramBotClient client)
        {
           
            //string accID = "406814811";

            Bot = client;

            _ = await client.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 "Enter account id: ");
            Bot.OnMessage += GetString;

            Console.WriteLine(1);
        }

        private async void GetString(object sender, MessageEventArgs e)
        {

            string idACC = e.Message.Text;
            string apiAddres = "https://dotaapiit.azurewebsites.net";
            var cl = new HttpClient();
            cl.BaseAddress = new Uri(apiAddres);

            var result1 = await cl.GetAsync($"/DotaApi/accountById?id={idACC}");
            if (result1.IsSuccessStatusCode)
            {
                var content2 = result1.Content.ReadAsStringAsync().Result;
                var acc = JsonConvert.DeserializeObject<AccountByID>(content2);
                if(acc != null)
                {
                    SendInf(acc, e.Message);
                }
                else
                {
                    await Bot.SendTextMessageAsync(e.Message.From.Id, "\n🧨🧨🧨ОШИБКА🧨🧨🧨" +
                  "\nОдна из причин неудачи:" +
                  "\n1)Такого пользователя не существует" +
                  "\n2)Вы ввели не верный ID" +
                  "\n3)Вы ввели не число" +
                  "\n4)Пользователь ограничил доступ ку своему аккаунту");
                }

            }
            else
            {
                await Bot.SendTextMessageAsync(e.Message.From.Id, "\n🧨🧨🧨ОШИБКА🧨🧨🧨" +
              "\nОдна из причин неудачи:" +
              "\n1)Такого пользователя не существует" +
              "\n2)Вы ввели не верный ID" +
              "\n3)Вы ввели не число" +
              "\n4)Пользователь ограничил доступ ку своему аккаунту");
            }
            
            Bot.OnMessage -= GetString;
        }

        protected async void SendInf(AccountByID account, Message e)
        {
            if (account.Profile != null)
            {
                _ = Bot.SendTextMessageAsync(
               chatId: e.Chat.Id,
               $"\nID аккаунта: {account.Profile.Account_id} " +
               $"\nНикнейм: {account.Profile.Personaname} " +
               $"\nМестонахождение: {account.Profile.Loccountrycode}" +
               $"\nПоследний раз заходил: {account.Profile.Last_login}" +
               $"\nСсылка на профиль: {account.Profile.Profileurl}");
            }
            else
            {
                await Bot.SendTextMessageAsync(e.Chat.Id, "\n🧨🧨🧨ОШИБКА🧨🧨🧨" +
              "\nОдна из причин неудачи:" +
              "\n1)Такого пользователя не существует" +
              "\n2)Вы ввели не верный ID" +
              "\n3)Вы ввели не число" +
              "\n4)Пользователь ограничил доступ ку своему аккаунту");
            }
        }
    }
}
