using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Models;
using Telegram.Command.Commands;

namespace Telegram
{
    class Program
    {
        
        private static TelegramBotClient client;
        private static List<Command.Command> commands;

        static void Main()
        {
            client = new TelegramBotClient(Config.Token);
            commands = new List<Command.Command>();

          
            commands.Add(new GetAcc());
            commands.Add(new GetWin_Lose());
            commands.Add(new GetMatch());
            commands.Add(new GetTurnir());
            commands.Add(new GetTeamInfo());
            commands.Add(new GetHero());
            commands.Add(new Help());
            commands.Add(new GetInfo());


            client.OnMessage += OnMessageHandler;
            client.OnUpdate += BotOnUpdateReceived;
            client.StartReceiving(Array.Empty<UpdateType>());
            
            Console.WriteLine("[Log]: Bot started");
            Console.WriteLine($"Start listening!!");
            Console.ReadLine();
            client.StopReceiving();

          
        }
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            string apiAddres = "https://localhost:44342";
            var cl = new HttpClient();
            cl.BaseAddress = new Uri(apiAddres);


            if (msg.Text != null)
            {
               foreach(var comm in commands)
                {
                    if (comm.Contains(msg.Text))
                    {
                        comm.Execute(msg, client);
                    }
                }
            }
        }

        private static async void BotOnUpdateReceived(object sender, UpdateEventArgs e)
        {
          var message = e.Update.Message;
          //  var message = e.Update.ChannelPost.Text;  // For Text Messages
            if (message == null || message.Type != MessageType.Text) return;
            var text = message.Text;
            Console.WriteLine(text);
            //await client.SendTextMessageAsync(message.Chat.Id, "_Received Update._", ParseMode.Markdown);
        }
      














       /*  private static IReplyMarkup GetButtons() // Knopki
          {
              return new ReplyKeyboardMarkup
              {
                  Keyboard = new List<List<KeyboardButton>>
                 {
                     new List<KeyboardButton>{new KeyboardButton { Text = "Привет"}, },
                 

                 }
              };
          }*/
        
    }
}


/*  case "Стикер":
                        var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://cdn.tlgrm.ru/stickers/697/ba1/697ba160-9c77-3b1a-9d97-86a9ce75ff4d/192/11.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;


                    case "Картинка":
                        var photo = await client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                            photo: "https://www.interfax.ru/ftproot/photos/photostory/2019/07/09/week4_700.jpg",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;


                    case "Привет":
                        var hi = await client.SendTextMessageAsync(
                             chatId: msg.Chat.Id,
                            "Hello, " + e.Message.Chat.Username,
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;*/