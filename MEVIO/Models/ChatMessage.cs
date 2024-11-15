﻿namespace MEVIO.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Text { get; set; }
        public string? FilePath { get; set; }
        public string? ImagePath { get; set; }
        public int? TaskChatId { get; set; }
        public virtual TaskChat TaskChat { get; set; }
        public int? EventChatId { get; set; }
        public virtual EventChat EventChat { get; set; }

        public int? UserChatId { get; set; }
        public virtual UserChat UserChat { get; set; }
        public int? MeasureChatId { get; set; }
        public virtual MeasureChat MeasureChat { get; set; }



    }
}
