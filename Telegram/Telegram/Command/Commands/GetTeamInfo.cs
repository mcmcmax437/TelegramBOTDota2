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
    class GetTeamInfo : Command
    {
        public override string[] Names { get; set; } = new string[] { "/get_team" };

        public override TelegramBotClient Bot { get; set; }
        public override async void Execute(Message message, TelegramBotClient client)
        {

            Bot = client;

            _ = client.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 "Enter Team id: ");
            Bot.OnMessage += GetString;

            Console.WriteLine(1);
        }
        private async void GetString(object sender, MessageEventArgs e)
        {
            try
            {
                int teamID = Convert.ToInt32(e.Message.Text);
                string apiAddres = "https://dotaapiit.azurewebsites.net";
                var cl = new HttpClient();
                cl.BaseAddress = new Uri(apiAddres);

                var responce5 = await cl.GetAsync($"DotaApi/team");
                if (responce5.IsSuccessStatusCode)
                {
                    var content5 = responce5.Content.ReadAsStringAsync().Result;
                    var team = JsonConvert.DeserializeObject<List<TeamById>>(content5);
                    int i = 0;
                    foreach (var element in team)
                    {
                        if (element.team_id == teamID)
                        {
                            await Bot.SendTextMessageAsync(e.Message.From.Id,
                                $"\nНазвание команды - {element.name}" +
                                $"\nID командный - {element.team_id}" +
                                $"\nПобеды - {element.wins}" +
                                $"\nПоражения - {element.losses}" +
                                $"\nРейтинг команды - {element.rating}" +
                                $"\nЛоготип - {element.logo_url}");
                            i++;
                        }
                    }
                    if(i == 0)
                    {
                        await Bot.SendTextMessageAsync(e.Message.From.Id, "\n🧨🧨🧨ОШИБКА🧨🧨🧨" +
                                       "\nОдна из причин неудачи:" +
                                       "\n1)Такой команды не существует" +
                                       "\n2)Вы ввели не верный ID" +
                                       "\n3)Вы ввели не число" +
                                       "\n4)Сбой в роботе сервера");
                    }
                }

            }
            catch(FormatException p)
            {
                await Bot.SendTextMessageAsync(e.Message.From.Id, "\n🧨🧨🧨ОШИБКА🧨🧨🧨" +
                "\nОдна из причин неудачи:" +
                "\n1)Такого команды не существует" +
                "\n2)Вы ввели не верный ID" +
                "\n3)Вы ввели не число" +
                "\n4)Сбой в роботе сервера");
            }

           // SendInf(team, e.Message);
            Bot.OnMessage -= GetString;
        }

       
    }
}
