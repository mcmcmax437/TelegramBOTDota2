using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Models;

namespace Telegram.Command.Commands
{
    public class GetTurnir : Command
    {
        public override string[] Names { get; set; } = new string[] { "/get_turnir" };

        public override TelegramBotClient Bot { get; set; }
        public override async void Execute(Message message, TelegramBotClient client)
        {
            string apiAddres = "https://dotaapiit.azurewebsites.net";
            var cl = new HttpClient();
            cl.BaseAddress = new Uri(apiAddres);
            string accID = "406814811";
            string pageid = "1"; 
            _ = client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                $"Список турниров:👇👇👇");
            var result4 = await cl.GetAsync($"https://api.pandascore.co/dota2/tournaments?page={pageid}&token=TY-0ZWiC6gInmPPvV35RzeFPg2aUQPIQNUamdpV460-oN9OJ03w");
            var content4 = result4.Content.ReadAsStringAsync().Result;
            var turnir = JsonConvert.DeserializeObject<List<Turnir>>(content4);
            int i = 1;
            foreach (var element in turnir)
            {
                _ = client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                $"\nНазвание: {element.league.name} " +
                $"\nПризовые: {element.prizepool}" +
                $"\nНачало турнира: {element.begin_at}" +
                $"\nКонец турнира: {element.end_at}" +
                $"\nЕтап: {element.name}:" +
                $"\nСсылка: {element.league.url}" +
                $"\nПобедитель: {element.winner_id}");
            }
        }
    }
}
