using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SheduleParser;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class Program
    {
        private static string Token => "";
        private static ITelegramBotClient Bot;

        static async Task Main(string[] args)
        {

            try
            {
                Bot = new TelegramBotClient(Token); 
                await Bot.SetWebhookAsync(""); 
                int offset = 0;

                Console.WriteLine("Start!");
                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset); 

                    foreach (var update in updates) 
                    {
                        var message = update.Message;

                        if (message.Text == "/getShedule")
                        {
                            var keyboard = new ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                    new[]
                                    {
                                        new KeyboardButton("ИП-16-3"),
                                        new KeyboardButton("ИП-16-4"),
                                        new KeyboardButton("ИП-17-3"),
                                        new KeyboardButton("ИП-17-4"),
                                        new KeyboardButton("ИП-18-3"),
                                        new KeyboardButton("ИП-18-4")
                                    },
                                },
                                ResizeKeyboard = true
                            };

                            await Bot.SendTextMessageAsync(
                                message.Chat.Id,
                                "Хорошо. Из какой ты группы?",
                                ParseMode.Default,
                                false,
                                false,
                                0,
                                keyboard);
                        }

                        if (message.Text.ToUpper().Trim() == "ИП-16-3" || message.Text.ToUpper().Trim() == "ИП-16-4" ||
                            message.Text.ToUpper().Trim() == "ИП-17-3" || message.Text.ToUpper().Trim() == "ИП-17-4" ||
                            message.Text.ToUpper().Trim() == "ИП-18-3" || message.Text.ToUpper().Trim() == "ИП-18-4")
                        {
                            string result = await Parser.Parse(message.Text.ToUpper().Trim());

                            dynamic shedule = JsonConvert.DeserializeObject<dynamic>(result);

                            result =
                                $"Понедельник: \n {shedule.shedule["Понедельник"]} \n" +
                                $"Вторник: \n {shedule.shedule["Вторник"]} \n" +
                                $"Среда: \n {shedule.shedule["Среда"]} \n" +
                                $"Четверг: \n {shedule.shedule["Четверг"]} \n" +
                                $"Пятница: \n {shedule.shedule["Пятница"]}";
                                      

                            await Bot.SendTextMessageAsync(
                                message.Chat.Id,
                                result);
                        }

                        offset = update.Id + 1;
                    }

                }
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
