namespace MEVIO.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserRoleId { get; set; }
        public virtual UserRole Role { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        
        public string TelegramJson { get; set; }

        public string PathImgAVA { get; set; }

        public ICollection<TasksUsers> TasksUsers { get; set; }
        public ICollection<MeasureUsers> MeasureUsers { get; set; }
    
        public ICollection<UserChatUser> UserChatUsers { get; set; }
        public ICollection<EventsUsers> EventsUsers { get; set; }
        public ICollection<TaskResponsiblePersons> TaskResponsiblePersons { get; set; }
        public ICollection<TasksWatchingPersons> TasksWatchingPersons { get; set; }
        public ICollection<ResponsiblePerson> ResponsiblePeople { get; set; }
        public ICollection<WatchingPerson> WatchingPeople { get; set; }
        public int? TaskChatId { get; set; }
        public virtual TaskChat TaskChat { get; set; }
        //and same here
        public DateTime LastTimeSignIn { get; set; }
        public DateTime Birthdate { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfPassportIssue { get; set; }
        public string TIN { get; set; }
        public bool IsActive { get; set; }//в сети не в сити
        public ICollection<UserAcceptStatus> UserAcceptStatuses { get; set; }
        //public int? UserCalendarId { get; set; }
        //public virtual UserCalendar UserCalendar { get; set; }
        public ICollection<DashBoard> DashBoards { get; set; }
        public User()
        {
            DashBoards = new List<DashBoard>(); 
            ResponsiblePeople = new List<ResponsiblePerson>();
            WatchingPeople = new List<WatchingPerson>();
            EventsUsers = new List<EventsUsers>();
            TaskResponsiblePersons = new List<TaskResponsiblePersons>();
            TasksWatchingPersons = new List<TasksWatchingPersons>();
            TasksUsers = new List<TasksUsers>();
            MeasureUsers = new List<MeasureUsers>();
            UserChatUsers = new List<UserChatUser>();
             UserAcceptStatuses = new List<UserAcceptStatus>();
             IsActive = false;
        }
    }
}
