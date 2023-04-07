namespace MEVIO.Models.TelegramBot
{
    using DocumentFormat.OpenXml.Spreadsheet;
    using Microsoft.EntityFrameworkCore;
    using System.Data.Entity;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Telegram.Bot;
    using Telegram.Bot.Args;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;

    public class TelegramBot
    {
        private readonly ITelegramBotClient _botClient;
        private readonly Dictionary<long, string> _usernames = new();
        private readonly Dictionary<long, string> _passwords = new();
        private readonly HashSet<long> _authenticated = new();
        public MEVIOContext db { get; set; }

        public TelegramBot(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public void StartReceiving()
        {
            _botClient.OnMessage += BotOnMessageReceived;
            _botClient.StartReceiving();
        }

        public void StopReceiving()
        {
            _botClient.StopReceiving();
            _botClient.OnMessage -= BotOnMessageReceived;
        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            // Check if message has a command

            if (e.Message.Type == MessageType.Text && e.Message.Text.StartsWith('/'))
            {
                // Handle different commands
                switch (e.Message.Text.ToLower())
                {
                    case "/login":
                        await Login(e.Message.Chat);
                        break;

                    case "/logout":
                        await Logout(e.Message.Chat);
                        break;

                    default:
                        // Ignore unsupported commands
                        break;
                }
            }
            else if (_usernames.ContainsKey(e.Message.Chat.Id) && _passwords.ContainsKey(e.Message.Chat.Id))
            {
                // Check if bot is waiting for username or password
                if (_usernames[e.Message.Chat.Id] == null)
                {
                    // Store the received username and ask for password
                    _usernames[e.Message.Chat.Id] = e.Message.Text;
                    await _botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Please enter your password:");
                }
                else if (_passwords[e.Message.Chat.Id] == null)
                {
                    // Check if the entered credentials are correct
                    var users = db.Users.ToList();

                    bool isValidUser = false;
                    foreach (var item in users)
                    {
                        if (e.Message.Text == item.Password && _usernames[e.Message.Chat.Id] == item.UserName)
                        {
                            isValidUser = true;
                            // Mark the user as authenticated and notify them
                            _authenticated.Add(e.Message.Chat.Id);
                            await _botClient.SendTextMessageAsync(
                                chatId: e.Message.Chat,
                                text: "You have been logged in.");
                            //here I create telegram json key to the user for the future for his notifications
                            UserTelegram userTelegram = new UserTelegram();
                            userTelegram.TelegramJson = JsonSerializer.Serialize(e.Message.Chat);
                            userTelegram.UserId = item.Id;
                            await db.AddAsync(userTelegram);
                            await db.SaveChangesAsync();
                            break;
                        }
                    }

                    if (!isValidUser)
                    {
                        await _botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: "Invalid username or password. Please try again.");
                    }

                    // Reset user state
                    _usernames.Remove(e.Message.Chat.Id);
                    _passwords.Remove(e.Message.Chat.Id);
                }
            }
            else
            {
                string checkChat = JsonSerializer.Serialize(e.Message.Chat);
                UserTelegram userkey = db.UserTelegram.Where(o => o.TelegramJson == checkChat).FirstOrDefault();
                if (userkey != null)
                {
                    await _botClient.SendTextMessageAsync(
                                        chatId: e.Message.Chat,
                                        text: "You are logged in. If you want to logout, write a command /logout");
                }
                else
                {
                    await _botClient.SendTextMessageAsync(
                                        chatId: e.Message.Chat,
                                        text: "You are not logged in. If you want to login, write a command /login");
                }
            }
            //else if (!_authenticated.Contains(e.Message.Chat.Id))
            //{
            //    // User is not authenticated and not entering credentials, prompt them to log in
            //    await _botClient.SendTextMessageAsync(
            //        chatId: e.Message.Chat,
            //        text: "You are not logged in. Please use the /login command to authenticate.");
            //}
        }
        private async Task Login(Chat chat)
        {
            // Send a message asking for the username
            await _botClient.SendTextMessageAsync(chatId: chat, text: "Please enter your username:");

            // Keep track of the current user's state
            _usernames[chat.Id] = null;
            _passwords[chat.Id] = null;
        }

        private async Task Logout(Chat chat)
        {
            var keys = db?.UserTelegram.ToList();
            foreach (var item in keys)
            {
                Chat key = JsonSerializer.Deserialize<Chat>(item.TelegramJson);
                if (key.Id == chat.Id)
                {

                    UserTelegram userTelegram = db.UserTelegram
                        .Where(o => o.UserId == item.UserId && o.TelegramJson == item.TelegramJson)
                        .FirstOrDefault();

                    db.UserTelegram.Remove(userTelegram);
                    await db.SaveChangesAsync();
                    // Send a message confirming the logout
                    await _botClient.SendTextMessageAsync(chatId: chat, text: "You have been logged out.");
                }
            }
            //// Remove the user's authentication
            //_authenticated.Remove(chat.Id);
        }

        public async Task SendEvent(UserTelegram userTelegram, Event event1, ITelegramBotClient bot, string creator)
        {
            Chat key = JsonSerializer.Deserialize<Chat>(userTelegram.TelegramJson);
            await bot.SendTextMessageAsync(chatId: key, text: $"You got an upcomming Event!\nName: {event1.EventName}\nDescription: {event1.Description}\nBegin Time: {event1.Begin.ToString()}\nEnd Time: {event1.End.ToString()}\nCreator: {creator}");
        }
        public async Task SendMeasure(UserTelegram userTelegram, Measure measure, ITelegramBotClient bot, string creator)
        {
            Chat key = JsonSerializer.Deserialize<Chat>(userTelegram.TelegramJson);
            await bot.SendTextMessageAsync(chatId: key, text: $"You got an upcomming Measure!\nName: {measure.MeasureName}\nPlace: {measure.PlaceForMeasure.PlaceForMeasureName}\nBegin Time: {measure.Begin.ToString()}\nEnd Time: {measure.End.ToString()}\nCreator: {creator}");
        }
    }
}