﻿using Telegram.Bot.Types;

namespace MEVIO.Models
{
    public class EventChat
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventChatName { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
