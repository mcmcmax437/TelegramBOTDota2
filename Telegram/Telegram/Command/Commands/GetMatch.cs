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
    public class GetMatch : Command
    {
        public override string[] Names { get; set; } = new string[] { "/get_match" };

        public override TelegramBotClient Bot { get; set; }
        public override async void Execute(Message message, TelegramBotClient client)
        {

            Bot = client;

            _ = client.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 "Enter match id: ");
            Bot.OnMessage += GetString;

            Console.WriteLine(1);
        }

        private async void GetString(object sender, MessageEventArgs e)
        {

            string AIDI = e.Message.Text;
            string apiAddres = "https://dotaapiit.azurewebsites.net";
            var cl = new HttpClient();
            cl.BaseAddress = new Uri(apiAddres);

            var result = await cl.GetAsync($"DotaApi/find_match?matchid={AIDI}");
            if (result.IsSuccessStatusCode)
            {
                var content3 = result.Content.ReadAsStringAsync().Result;
                var match = JsonConvert.DeserializeObject<MatchByID>(content3);

                SendInf(match, e.Message);
            }
            else
            {
                await Bot.SendTextMessageAsync(e.Message.From.Id, "\n🧨🧨🧨ОШИБКА🧨🧨🧨" +
             "\nОдна из причин неудачи:" +
             "\n1)Такого матча не существует" +
             "\n2)Вы ввели не верный ID" +
             "\n3)Вы ввели не число" +
             "\n4)Матч был скрыт или слишком давно проведён");
            }

            Bot.OnMessage -= GetString;
        }

        protected async void SendInf(MatchByID match, Message e)
        {
            if (match != null)
            {
                string winner;
                if (match.Radiant_win == true)
                {
                    winner = "Winner - Radiant";
                }
                else
                {
                    winner = "winner - Dire";
                }
                int i = 1;
                string hero = " ";
                await Bot.SendTextMessageAsync(
                e.From.Id,
                $"Матч: {match.Match_id}" +
                $"\nRadiant - {match.Radiant_score}/{match.Dire_score} - Dire" +
                $"\n{winner}");

                foreach (var element in match.Players)
                {
                    if (i == 1)
                    {
                        await Bot.SendTextMessageAsync(
                   chatId: e.Chat.Id,
                   "Radiant: ");
                    }
                    else if (i == 6)
                    {
                        await Bot.SendTextMessageAsync(
                   chatId: e.Chat.Id,
                   "Dire: ");
                    }


                    if (element.hero_id == 1)
                    {
                        hero = "Anti-Mage";
                    }
                    else if (element.hero_id == 2)
                    {
                        hero = "Axe";
                    }
                    else if (element.hero_id == 3)
                    {
                        hero = "Bane";
                    }
                    else if (element.hero_id == 4)
                    {
                        hero = "Bloodseeker";
                    }
                    else if (element.hero_id == 5)
                    {
                        hero = "Crystal Maiden";
                    }
                    else if (element.hero_id == 6)
                    {
                        hero = "Drow Ranger";
                    }
                    else if (element.hero_id == 7)
                    {
                        hero = "Earthshaker";
                    }
                    else if (element.hero_id == 8)
                    {
                        hero = "Juggernaut";
                    }
                    else if (element.hero_id == 9)
                    {
                        hero = "Mirana";
                    }
                    else if (element.hero_id == 10)
                    {
                        hero = "Morphling";
                    }

                    else if (element.hero_id == 11)
                    {
                        hero = "Shadow Fiend";
                    }
                    else if (element.hero_id == 12)
                    {
                        hero = "Phantom Lancer";
                    }
                    else if (element.hero_id == 13)
                    {
                        hero = "Puck";
                    }
                    else if (element.hero_id == 14)
                    {
                        hero = "Pudge";
                    }
                    else if (element.hero_id == 15)
                    {
                        hero = "Razor";
                    }
                    else if (element.hero_id == 16)
                    {
                        hero = "Sand King";
                    }
                    else if (element.hero_id == 17)
                    {
                        hero = "Storm Spirit";
                    }
                    else if (element.hero_id == 18)
                    {
                        hero = "Sven";
                    }
                    else if (element.hero_id == 19)
                    {
                        hero = "Tiny";
                    }
                    else if (element.hero_id == 20)
                    {
                        hero = "Vengeful Spirit";
                    }

                    else if (element.hero_id == 21)
                    {
                        hero = "Windranger";
                    }
                    else if (element.hero_id == 22)
                    {
                        hero = "Zeus";
                    }
                    else if (element.hero_id == 23)
                    {
                        hero = "Kunkka";
                    }

                    else if (element.hero_id == 25)
                    {
                        hero = "Lina";
                    }
                    else if (element.hero_id == 26)
                    {
                        hero = "Lion";
                    }
                    else if (element.hero_id == 27)
                    {
                        hero = "Shadow Shaman";
                    }
                    else if (element.hero_id == 28)
                    {
                        hero = "Slardar";
                    }
                    else if (element.hero_id == 29)
                    {
                        hero = "Tidehunter";
                    }
                    else if (element.hero_id == 30)
                    {
                        hero = "Witch Doctor";
                    }

                    else if (element.hero_id == 31)
                    {
                        hero = "Lich";
                    }
                    else if (element.hero_id == 32)
                    {
                        hero = "Riki";
                    }
                    else if (element.hero_id == 33)
                    {
                        hero = "Enigma";
                    }
                    else if (element.hero_id == 34)
                    {
                        hero = "Tinker";
                    }
                    else if (element.hero_id == 35)
                    {
                        hero = "Sniper";
                    }
                    else if (element.hero_id == 36)
                    {
                        hero = "Necrophos";
                    }
                    else if (element.hero_id == 37)
                    {
                        hero = "Warlock";
                    }
                    else if (element.hero_id == 38)
                    {
                        hero = "Beastmaster";
                    }
                    else if (element.hero_id == 39)
                    {
                        hero = "Queen of Pain";
                    }
                    else if (element.hero_id == 40)
                    {
                        hero = "Venomancer";
                    }

                    else if (element.hero_id == 41)
                    {
                        hero = "Faceless Void";
                    }
                    else if (element.hero_id == 42)
                    {
                        hero = "Wraith King";
                    }
                    else if (element.hero_id == 43)
                    {
                        hero = "Death Prophet";
                    }
                    else if (element.hero_id == 44)
                    {
                        hero = "Phantom Assassin";
                    }
                    else if (element.hero_id == 45)
                    {
                        hero = "Pugna";
                    }
                    else if (element.hero_id == 46)
                    {
                        hero = "Templar Assassin";
                    }
                    else if (element.hero_id == 47)
                    {
                        hero = "Viper";
                    }
                    else if (element.hero_id == 48)
                    {
                        hero = "Luna";
                    }
                    else if (element.hero_id == 49)
                    {
                        hero = "Dragon Knight";
                    }
                    else if (element.hero_id == 50)
                    {
                        hero = "Dazzle";
                    }

                    else if (element.hero_id == 51)
                    {
                        hero = "Clockwerk";
                    }
                    else if (element.hero_id == 52)
                    {
                        hero = "Leshrac";
                    }
                    else if (element.hero_id == 53)
                    {
                        hero = "Nature's Prophet";
                    }
                    else if (element.hero_id == 54)
                    {
                        hero = "Lifestealer";
                    }
                    else if (element.hero_id == 55)
                    {
                        hero = "Dark Seer";
                    }
                    else if (element.hero_id == 56)
                    {
                        hero = "Clinkz";
                    }
                    else if (element.hero_id == 57)
                    {
                        hero = "Omniknight";
                    }
                    else if (element.hero_id == 58)
                    {
                        hero = "Enchantress";
                    }
                    else if (element.hero_id == 59)
                    {
                        hero = "Huskar";
                    }
                    else if (element.hero_id == 60)
                    {
                        hero = "Night Stalker";
                    }

                    else if (element.hero_id == 61)
                    {
                        hero = "Broodmother";
                    }
                    else if (element.hero_id == 62)
                    {
                        hero = "Bounty Hunter";
                    }
                    else if (element.hero_id == 63)
                    {
                        hero = "Weaver";
                    }
                    else if (element.hero_id == 64)
                    {
                        hero = "Jakiro";
                    }
                    else if (element.hero_id == 65)
                    {
                        hero = "Batrider";
                    }
                    else if (element.hero_id == 66)
                    {
                        hero = "Chen";
                    }
                    else if (element.hero_id == 67)
                    {
                        hero = "Spectre";
                    }
                    else if (element.hero_id == 68)
                    {
                        hero = "Ancient Apparition";
                    }
                    else if (element.hero_id == 69)
                    {
                        hero = "Doom";
                    }
                    else if (element.hero_id == 70)
                    {
                        hero = "Ursa";
                    }

                    else if (element.hero_id == 71)
                    {
                        hero = "Spirit Breaker";
                    }
                    else if (element.hero_id == 72)
                    {
                        hero = "Gyrocopter";
                    }
                    else if (element.hero_id == 73)
                    {
                        hero = "Alchemist";
                    }
                    else if (element.hero_id == 74)
                    {
                        hero = "Invoker";
                    }
                    else if (element.hero_id == 75)
                    {
                        hero = "Silencer";
                    }
                    else if (element.hero_id == 76)
                    {
                        hero = "Outworld Destroyer";
                    }
                    else if (element.hero_id == 77)
                    {
                        hero = "Lycan";
                    }
                    else if (element.hero_id == 78)
                    {
                        hero = "Brewmaster";
                    }
                    else if (element.hero_id == 79)
                    {
                        hero = "Shadow Demon";
                    }
                    else if (element.hero_id == 80)
                    {
                        hero = "Lone Druid";
                    }

                    else if (element.hero_id == 81)
                    {
                        hero = "Chaos Knight";
                    }
                    else if (element.hero_id == 82)
                    {
                        hero = "Meepo";
                    }
                    else if (element.hero_id == 83)
                    {
                        hero = "Treant Protector";
                    }
                    else if (element.hero_id == 84)
                    {
                        hero = "Ogre Magi";
                    }
                    else if (element.hero_id == 85)
                    {
                        hero = "Undying";
                    }
                    else if (element.hero_id == 86)
                    {
                        hero = "Rubick";
                    }
                    else if (element.hero_id == 87)
                    {
                        hero = "Disruptor";
                    }
                    else if (element.hero_id == 88)
                    {
                        hero = "Nyx Assassin";
                    }
                    else if (element.hero_id == 89)
                    {
                        hero = "Naga Siren";
                    }
                    else if (element.hero_id == 90)
                    {
                        hero = "Keeper of the Light";
                    }

                    else if (element.hero_id == 91)
                    {
                        hero = "Io";
                    }
                    else if (element.hero_id == 92)
                    {
                        hero = "Visage";
                    }
                    else if (element.hero_id == 93)
                    {
                        hero = "Slark";
                    }
                    else if (element.hero_id == 94)
                    {
                        hero = "Medusa";
                    }
                    else if (element.hero_id == 95)
                    {
                        hero = "Troll Warlord";
                    }
                    else if (element.hero_id == 96)
                    {
                        hero = "Centaur Warrunner";
                    }
                    else if (element.hero_id == 97)
                    {
                        hero = "Magnus";
                    }
                    else if (element.hero_id == 98)
                    {
                        hero = "Timbersaw";
                    }
                    else if (element.hero_id == 99)
                    {
                        hero = "Bristleback";
                    }
                    else if (element.hero_id == 100)
                    {
                        hero = "Tusk";
                    }

                    else if (element.hero_id == 101)
                    {
                        hero = "Skywrath Mage";
                    }
                    else if (element.hero_id == 102)
                    {
                        hero = "Abaddon";
                    }
                    else if (element.hero_id == 103)
                    {
                        hero = "Elder Titan";
                    }
                    else if (element.hero_id == 104)
                    {
                        hero = "Legion Commander";
                    }
                    else if (element.hero_id == 105)
                    {
                        hero = "Techies";
                    }
                    else if (element.hero_id == 106)
                    {
                        hero = "Ember Spirit";
                    }
                    else if (element.hero_id == 107)
                    {
                        hero = "Earth Spirit";
                    }
                    else if (element.hero_id == 108)
                    {
                        hero = "Underlord";
                    }
                    else if (element.hero_id == 109)
                    {
                        hero = "Terrorblade";
                    }
                    else if (element.hero_id == 110)
                    {
                        hero = "Phoenix";
                    }

                    else if (element.hero_id == 111)
                    {
                        hero = "Oracle";
                    }
                    else if (element.hero_id == 112)
                    {
                        hero = "Winter Wyvern";
                    }
                    else if (element.hero_id == 113)
                    {
                        hero = "Arc Warden";
                    }
                    else if (element.hero_id == 114)
                    {
                        hero = "Monkey King";
                    }

                    else if (element.hero_id == 119)
                    {
                        hero = "Dark Willow";
                    }
                    else if (element.hero_id == 120)
                    {
                        hero = "Pangolier";
                    }

                    else if (element.hero_id == 121)
                    {
                        hero = "Grimstroke";
                    }
                    else if (element.hero_id == 123)
                    {
                        hero = "Hoodwink";
                    }
                    else if (element.hero_id == 126)
                    {
                        hero = "Void Spirit";
                    }
                    else if (element.hero_id == 128)
                    {
                        hero = "Snapfire";
                    }
                    else if (element.hero_id == 129)
                    {
                        hero = "Mars";
                    }
                    else if (element.hero_id == 135)
                    {
                        hero = "Dawnbreaker";
                    }
                    else
                    {
                        hero = "Nameless";
                    }
                    if (element.personaname == null)
                    {
                        await Bot.SendTextMessageAsync(
                   chatId: e.Chat.Id,
                   $"{i})  {hero} --- {element.kills}/{element.deaths}/{element.assists} --- {element.kda} ||| ({element.personaname})");
                        i++;
                    }
                    else
                    {
                        await Bot.SendTextMessageAsync(
                  chatId: e.Chat.Id,
                  $"{i})  {hero} --- {element.kills}/{element.deaths}/{element.assists} --- {element.kda} ||| ({element.personaname})");
                        i++;
                    }


                    //

                }


                await Bot.SendTextMessageAsync(
                    chatId: e.Chat.Id,
                    $"You can dawnload match replay here: {match.Replay_url}");
                // replyMarkup: GetButtons());
            }
            else
            {
                await Bot.SendTextMessageAsync(
                 chatId: e.Chat.Id,
                "Fail!!! ",
                replyToMessageId: e.MessageId);

            }

        }
        }

    }
