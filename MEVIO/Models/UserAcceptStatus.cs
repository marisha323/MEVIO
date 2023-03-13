﻿namespace MEVIO.Models
{
    public class UserAcceptStatus
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? MeasureId { get; set; }
        public virtual Measure Measure { get; set; }
        public bool IsAccept { get; set; } //принял не принял преглашения

        
    }
}
