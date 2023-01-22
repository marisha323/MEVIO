namespace MEVIO.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public ICollection<User>? CoWorkers { get; set; }
        public string? TelegramJsonId { get; set; }
        public Events?[int](EventId) //I did not understand if this should be Icollection or not
            public Tasks?[int](TaskId)//same here
            public Measures?[int](MeasureId) //and same here
    }
}
