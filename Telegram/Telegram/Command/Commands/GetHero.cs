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
    class GetHero : Command
    {
        public override string[] Names { get; set; } = new string[] { "/post" };

        public override TelegramBotClient Bot { get; set; }

  

        public override async void Execute(Message message, TelegramBotClient client)
        {

           
        

            Bot = client;
           await client.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 "\nЧтобы добавить героя в базу данных нужно знать его ID:" +
                  "\n1 - Anti-Mage" +
                  "\n2 - Axe" +
                  "\n3 - Bane" +
                  "\n4 - Bloodseeker" +
                  "\n5 - Crystal Maiden"+ 
                  "\n6 - Drow Ranger"+
                  "\n7 - Earthshaker"+
                  "\n8 - Juggernaut"+
                  "\n9 - Mirana"+          
                  "\n10 - Morphling"+          
                  "\n11 - Shadow Fiend"+           
                  "\n12 -Phantom Lancer"+
                  "\n13 - Puck"+             
                  "\n14 - Pudge"+
                  "\n15 - Razor"+
                  "\n16 - Sand King"+
                  "\n17 - Storm Spirit"+           
                  "\n18 - Sven"+            
                  "\n19 - Tiny"+          
                  "\n20 - Vengeful Spirit"+                   
                  "\n21 - Windranger"+            
                  "\n22 - Zeus"+            
                  "\n23 - Kunkka"+          
                  "\n25 - Lina"+           
                  "\n26 - Lion"+           
                  "\n27 - Shadow Shaman"+           
                  "\n28 - Slardar"+           
                  "\n29 - Tidehunter"+           
                  "\n30 - Witch Doctor"+           
                  "\n31 - Lich"+         
                  "\n32 - Riki"+           
                  "\n33 - Enigma"+          
                  "\n34 - Tinker"+        
                  "\n35 - Sniper"+          
                  "\n36 - Necrophos"+          
                  "\n37 - Warlock"+          
                  "\n38 - Beastmaster"+
                  "\n39 - Queen of Pain"+           
                  "\n40 - Venomancer"+          
                  "\n41 - Faceless Void"+           
                  "\n42 - Wraith King"+          
                  "\n43 - Death Prophet"+          
                  "\n44 - Phantom Assassin"+           
                  "\n45 - Pugna"+           
                  "\n46 - Templar Assassin"+         
                  "\n47 - Viper"+           
                  "\n48 - Luna"+           
                  "\n49 - Dragon Knight"+           
                  "\n50 -Dazzle"+           
                  "\n51 - Clockwerk" +
                  "\n52 - Leshrac" +
                  "\n53 - Nature's Prophet" +
                  "\n54 - Lifestealer" +
                  "\n55 - Dark Seer" +
                  "\n56 - Clinkz" +
                  "\n57 - Omniknight" +
                  "\n58 - Enchantress" +
                  "\n59 - Huskar" +
                  "\n60 - Night Stalker" +
                  "\n61 - Broodmother" +
                  "\n62 - Bounty Hunter" +
                  "\n63 - Weaver" +
                  "\n64 - Jakiro" +
                  "\n65 - Batrider" +
                  "\n66 - Chen" +
                  "\n67 - Spectre" +
                  "\n68 - Ancient Apparition" +
                  "\n69 - Doom" +
                  "\n70 - Ursa" +
                  "\n71 - Spirit Breaker" +
                  "\n72 - Gyrocopter" +
                  "\n73 - Alchemist" +
                  "\n74 - Invoker" +
                  "\n75 - Silencer" +
                  "\n76 - Outworld Destroyer" +
                  "\n77 - Lycan" +
                  "\n78 - Brewmaster" +
                  "\n79 - Shadow Demon" +
                  "\n80 - Lone Druid" +
                  "\n81 - Chaos Knight" +
                  "\n82 - Meepo" +
                   "\n83 - Treant Protector" +
                  "\n84 - Ogre Magi" +
                  "\n85 - Undying" +
                  "\n86 - Rubick" +
                  "\n87 - Disruptor" +
                  "\n88 - Nyx Assassin" +
                  "\n89 - Naga Siren" +
                  "\n90 - Keeper of the Light" +
                  "\n91 - Io" +
                  "\n92 - Visage" +
                  "\n93 - Slark" +
                  "\n94 - Medusa" +
                  "\n95 - Troll Warlord" +
                  "\n96 - Centaur Warrunner" +
                  "\n97 - Magnus" +
                  "\n98 - Timbersaw" +
                  "\n99 - Bristleback" +
                  "\n100 - Tusk" +
                  "\n101 - Skywrath Mage" +
                  "\n102 - Abaddon" +
                  "\n103 - Elder Titan" +
                  "\n104 - Legion Commander" +
                  "\n105 - Techies" +
                  "\n106 - Ember Spirit" +
                  "\n107 - Earth Spirit" +
                  "\n108 - Underlord" +
                  "\n109 - Terrorblade" +
                  "\n110 - Phoenix" +
                  "\n111 - Oracle" +
                  "\n112 - Winter Wyvern" +
                  "\n113 - Arc Warden" +
                  "\n114 - Monkey King" +
                  "\n119 - Dark Willow" +
                  "\n120 - Pangolier" +
                  "\n121 - Grimstroke" +
                  "\n123 - Hoodwink" +
                  "\n126 - Void Spirit" +
                  "\n128 - Snapfire" +            
                  "\n129 - Mars"+
                  "\n135 - Dawnbreaker"
            
            );




            _ = client.SendTextMessageAsync(
                 chatId: message.Chat.Id,
                 "Enter hero id to post in DB: ");
            Bot.OnMessage += GetString;

            Console.WriteLine(1);
        }

        private async void GetString(object sender, MessageEventArgs e)
        {
            try
            {
                int heroid = Convert.ToInt32(e.Message.Text);



                string apiAddres = "https://dotaapiit.azurewebsites.net";
                var cl = new HttpClient();
                cl.BaseAddress = new Uri(apiAddres);

                var result1 = await cl.GetAsync($"/DotaApi/heroByid");
                if (result1.IsSuccessStatusCode)
                {

                    var content6 = result1.Content.ReadAsStringAsync().Result;
                    var hero = JsonConvert.DeserializeObject<List<HeroRoot>>(content6);
                    int i = 0;
                    foreach (var element in hero)
                    {

                        if (element.id == heroid)
                        {
                            var newHERO = new HeroRoot
                            {
                                id = element.id,
                                localized_name = element.localized_name,

                            };
                            SendInf(newHERO, e.Message);
                            i++;
                        }

                    }
                    if (i == 0)
                    {
                        await Bot.SendTextMessageAsync(e.Message.From.Id, "\n🧨🧨🧨ОШИБКА🧨🧨🧨" +
             "\nОдна из причин неудачи:" +
             "\n1)Такого героя не существует" +
             "\n2)Вы ввели не верный ID" +
             "\n3)Вы ввели не число"
             );
                    }
                }


                
            }catch(FormatException)
            {
                await Bot.SendTextMessageAsync(e.Message.From.Id, "\n🧨🧨🧨ОШИБКА🧨🧨🧨" +
                            "\nОдна из причин неудачи:" +
                            "\n1)Такого героя не существует" +
                            "\n2)Вы ввели не верный ID" +
                            "\n3)Вы ввели не число"
                            );
            }
            Bot.OnMessage -= GetString;
        }

        protected async void SendInf(HeroRoot heroRoot, Message e)
        {
            if (heroRoot != null)
            {
                string apiAddres = "https://dotaapiit.azurewebsites.net";
                var cl = new HttpClient();
                cl.BaseAddress = new Uri(apiAddres);

                await Bot.SendTextMessageAsync(e.Chat.Id,
                                                  $"\nГерой - {heroRoot.localized_name}" +
                                                  $"\nID героя - {heroRoot.id}" 
                                                  //$"\nГлавный атрибут - {heroRoot.primary_attr} "
                                                 );
              

                var json = JsonConvert.SerializeObject(heroRoot);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var post = await cl.PostAsync("DotaApi/add", data);
                // post.EnsureSuccessStatusCode();
                var postcontent = post.Content.ReadAsStringAsync().Result;
                Console.WriteLine(postcontent);
                if (post.IsSuccessStatusCode)
                {
                    await Bot.SendTextMessageAsync(e.Chat.Id,
                                                  $"\nГерой - {heroRoot.localized_name} " +
                                                  "был успешно добавлен в базу данных"

                                 );
                }
                else
                {
                    await Bot.SendTextMessageAsync(e.Chat.Id,
                                                $"FAIL!!!" +
                                                $"\nГерой - {heroRoot.localized_name} " +
                                                "скорее всего уже есть в базе данных или операция добавления была провалена"

                               );
                }




            }
        }

       
    }
}
