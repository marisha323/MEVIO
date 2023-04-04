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

        // Adding fields to keep track of user data
        private readonly Dictionary<long, string> _usernames = new();
        private readonly Dictionary<long, string> _passwords = new();
        private readonly HashSet<long> _authenticated = new();
        private readonly MEVIOContext db; // Add this field

        public TelegramBot(ITelegramBotClient botClient)
        {
            _botClient = botClient;
            var optionsBuilder = new DbContextOptionsBuilder<MEVIOContext>();
            optionsBuilder.UseSqlServer("DefaultConnection");

            db = new MEVIOContext(optionsBuilder.Options);
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

                    if(!isValidUser)
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
            else if (!_authenticated.Contains(e.Message.Chat.Id))
            {
                // User is not authenticated and not entering credentials, prompt them to log in
                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "You are not logged in. Please use the /login command to authenticate.");
            }
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
            var keys = db.UserTelegram.ToList();
            foreach(var item in keys)
            {
                UserTelegram userTelegram = new UserTelegram();
                userTelegram.UserId = item.UserId;
                userTelegram.TelegramJson = item.TelegramJson;
                Chat key = JsonSerializer.Deserialize<Chat>(item.TelegramJson);
                if(key == chat)
                {
                    db.UserTelegram.Remove(userTelegram);
                    await db.SaveChangesAsync();
                }
            }
            // Remove the user's authentication
            _authenticated.Remove(chat.Id);

            // Send a message confirming the logout
            await _botClient.SendTextMessageAsync(chatId: chat, text: "You have been logged out.");
        }
    }
}