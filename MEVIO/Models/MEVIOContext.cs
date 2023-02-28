using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace MEVIO.Models
{
    public class MEVIOContext : DbContext
    {
        //public DbSet<ChatMessage> ChatMessages { get; set; } = null!;
        //public DbSet<ClientHistory> ClientHistory { get; set; } = null!;
        //public DbSet<DashBoard> Dashboards { get; set; } = null!;

        //public DbSet<Event> Events { get; set; } = null!;
        //public DbSet<EventChat> EventsChat { get; set; } = null!;
        //public DbSet<EventChatMessage> EventChatMessages { get; set; } = null!;
        //public DbSet<EventsClients> EventsClients { get; set; } = null!;
        //public DbSet<EventsUsers> EventsUsers { get; set; } = null!;
        //public DbSet<Measure> Measures { get; set; } = null!;
        //public DbSet<MeasureBusyTable> MeasuresBusyTable { get; set; } = null!;
        //public DbSet<MeasureChat> MeasureChats { get; set; } = null!;
        //public DbSet<MeasureChatMessage> MeasureChatMessages { get; set; } = null!;
        //public DbSet<MeasurePhotos> MeasuresPhotos { get; set; } = null!;
        //public DbSet<MeasurePowerBi> MeasurePowerBis { get; set; } = null!;
        //public DbSet<MeasuresClients> MeasuresClients { get; set; } = null!;
        //public DbSet<MeasureUsers> MeasuresUsers { get; set; } = null!;
        //public DbSet<MeasureVideos> MeasuresVideos { get; set; } = null!;
        //public DbSet<PlaceForMeasure> Places { get; set; } = null!;
        //public DbSet<Task> Tasks { get; set; } = null!;
        //public DbSet<TaskChat> TaskChats { get; set; } = null!;
        //public DbSet<TaskChatMessage> TaskChatMessages { get; set; } = null!;
        //public DbSet<TaskResponsiblePersons> TaskResponsiblePersons { get; set; } = null!;
        //public DbSet<TasksClients> TasksClients { get; set; } = null!;
        //public DbSet<TasksUsers> TasksUsers { get; set; } = null!;
        //public DbSet<TasksWatchingPersons> TasksWatchingPersons { get; set; } = null!;
        //public DbSet<UnderTask> UnderTasks { get; set; } = null!;
        //public DbSet<UserAcceptStatus> UserAcceptStatuses { get; set; } = null;
        //public DbSet<UserCalendar> UserCalendars { get; set; } = null!;
        //public DbSet<UserEventAcceptStatus> UserEventAcceptStatuses { get; set; } = null!;
        //public DbSet<UserMeasureAcceptStatus> UserMeasureAcceptStatuses { get; set; } = null;
        //public DbSet<UserTaskAcceptStatus> UserTaskAcceptStatuses { get; set; } = null!;
        //public DbSet<UserChat> UserChats { get; set; } = null!;







        public DbSet<UserRole> Roles { get; set; } = null!;

        public DbSet<ClientStatus> ClientStatuses { get; set; } = null!;

        public DbSet<EducationForm> EducationForms { get; set; } = null!;

        public DbSet<SeasonOfBeginning> SeasonsOfBeginning { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Requisites> Requisites { get; set; } = null!;

        public DbSet<Academy> Academies { get; set; } = null!;

        public DbSet<Client> Clients { get; set; } = null!;

        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Contract> Contracts { get; set; } = null!;





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.modelBuilder.Entity<User>().HasOne(u => u.Team).WithMany(u => u.TeamMembers);


            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Event>()
            //    .HasOne(c => c.User)
            //    .WithMany(c => c.Events)
            //    .OnDelete(DeleteBehavior.NoAction);
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Measure>()
            //    .HasOne(c => c.User)
            //    .WithMany(c => c.Measures)
            //    .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Event>()
            //.HasOne(a => a.EventChat)
            //.WithOne(a => a.Event)
            //.HasForeignKey<EventChat>(c => c.EventId);

            ////Added by Yehor
            //modelBuilder.Entity<User>()
            //.HasDiscriminator<string>("Discriminator")
            //.HasValue("User");




            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Task>()
            //    .HasMany(c => c.ResponsiblePersons)
            //    .WithMany(c => c.Tasks);
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Task>()
            //    .HasMany(c => c.WatchingPersons)
            //    .WithMany(c => c.Tasks);
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Task>()
            //    .HasMany(c => c.UnderTasks)
            //    .WithOne(c => c.Task);
            //base.OnModelCreating(modelBuilder);
        }
        public MEVIOContext(DbContextOptions<MEVIOContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
