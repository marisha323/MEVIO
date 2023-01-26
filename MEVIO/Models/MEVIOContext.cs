using Microsoft.EntityFrameworkCore;
namespace MEVIO.Models
{
    public class MEVIOContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Academy> Academys { get; set; } = null!;
        public DbSet<ChatMessage> ChatMessages { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<ClientHistory> ClientHistory { get; set; } = null!;
        public DbSet<ClientStatus> ClientStatuses { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;
        public DbSet<DashBoard> Dashboards { get; set; } = null!;
        public DbSet<EducationForm> EducationForms { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventChat> EventsChat { get; set; } = null!;
        public DbSet<EventChatMessage> EventChatMessages { get; set; } = null!;
        public DbSet<EventsClients> EventsClients { get; set; } = null!;
        public DbSet<EventsUsers> EventsUsers { get; set; } = null!;
        public DbSet<Measure> Measures { get; set; } = null!;
        public DbSet<MeasureBusyTable> MeasuresBusyTable { get; set; } = null!;
        public DbSet<MeasureChat> MeasureChats { get; set; } = null!;
        public DbSet<MeasureChatMessage> MeasureChatMessages { get; set; } = null!;
        public DbSet<MeasurePhotos> MeasuresPhotos { get; set; } = null!;
        public DbSet<MeasurePowerBi> MeasurePowerBis { get; set; } = null!;
        public DbSet<MeasuresClients> MeasuresClients { get; set; } = null!;
        public DbSet<MeasureUsers> MeasuresUsers { get; set; } = null!;
        public DbSet<MeasureVideos> MeasuresVideos { get; set; } = null!;
        public DbSet<PlaceForMeasure> Places { get; set; } = null!;
        public DbSet<Requisites> Requisites { get; set; } = null!;
        public DbSet<SeasonOfBeginning> SeasonOfBeginning { get; set; } = null!;
        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<TaskChat> TaskChats { get; set; } = null!;
        public DbSet<TaskChatMessage> TaskChatMessages { get; set; } = null!;
        public DbSet<TaskResponsiblePersons> TaskResponsiblePersons { get; set; } = null!;
        public DbSet<TasksClients> TasksClients { get; set; } = null!;
        public DbSet<TasksUsers> TasksUsers { get; set; } = null!;
        public DbSet<TasksWatchingPersons> TasksWatchingPersons { get; set; } = null!;
        public DbSet<UnderTask> UnderTasks { get; set; } = null!;
        public DbSet<UserAcceptStatus> UserAcceptStatuses { get; set; } = null;
        public DbSet<UserCalendar> UserCalendars { get; set; } = null!;
        public DbSet<UserEventAcceptStatus> UserEventAcceptStatuses { get; set; } = null!;
        public DbSet<UserMeasureAcceptStatus> UserMeasureAcceptStatuses { get; set; } = null;
        public DbSet<UserRole> Roles { get; set; } = null!;
        public DbSet<UserTaskAcceptStatus> UserTaskAcceptStatuses { get; set; } = null!;

        public MEVIOContext(DbContextOptions<MEVIOContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
