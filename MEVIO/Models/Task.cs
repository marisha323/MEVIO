﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MEVIO.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }

        public ICollection<TasksUsers> TasksUsers { get; set; }

        public ICollection<UnderTask> UnderTasks { get; set; }//подзадача
        public bool IsImportant { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public ICollection<TasksClients> TaskClients { get; set; }
        public ICollection<ResponsiblePerson> ResponsiblePersons { get; set; }
        public ICollection<WatchingPerson> WatchingPersons { get; set; }
        public ICollection<TaskResponsiblePersons> TaskResponsiblePersons { get; set; }
        public ICollection<TasksWatchingPersons> TasksWatchingPersons { get; set; }
        public int? TaskChatId { get; set; }
        public virtual TaskChat TaskChat { get; set; }
        //public int? UserCalendarId { get; set; }
        //public virtual UserCalendar UserCalendar { get; set; }
        public ICollection<UserTaskAcceptStatus> UserTaskAcceptStatuses { get; set; }
        public Task()
        {
            ResponsiblePersons = new List<ResponsiblePerson>();
            WatchingPersons = new List<WatchingPerson>();
            UnderTasks = new List<UnderTask>();
            TaskClients = new List<TasksClients>();
            TaskResponsiblePersons = new List<TaskResponsiblePersons>();
            TasksWatchingPersons = new List<TasksWatchingPersons>();
            UserTaskAcceptStatuses = new List<UserTaskAcceptStatus>();
            TasksUsers = new List<TasksUsers>();
        }
    }
}
