using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MEVIO.Models.StartInitial
{
    public class MyInitial
    {
        public MEVIOContext context { get; set; }

        public MyInitial(MEVIOContext context)
        {
            this.context = context;
        }




        public async void InitClients()
        {
            context.ClientStatuses.Add(new() { StatusName = "Interested" });
            context.ClientStatuses.Add(new() { StatusName = "Explicit" });
            context.ClientStatuses.Add(new() { StatusName = "Active" });

            context.SaveChanges();



            context.Clients.Add(new()
            {
                ClientName = "Client 1",
                ClientStatusId = 1,
                DateOfPassportIssue = DateTime.Now,
                PassportNumber="11111",
                TIN="11111"
            });

            context.Clients.Add(new()
            {
                ClientName = "Client 2",
                ClientStatusId = 1,
                DateOfPassportIssue = DateTime.Now,
                PassportNumber = "22222",
                TIN = "22222"
            });

            context.Clients.Add(new()
            {
                ClientName = "Client 3",
                ClientStatusId = 2,
                DateOfPassportIssue = DateTime.Now,
                PassportNumber = "33333",
                TIN = "33333"
            });

            context.Clients.Add(new()
            {
                ClientName = "Client 4",
                ClientStatusId = 2,
                DateOfPassportIssue = DateTime.Now,
                PassportNumber = "44444",
                TIN = "44444"
            });

            context.Clients.Add(new()
            {
                ClientName = "Client 5",
                ClientStatusId = 3,
                DateOfPassportIssue = DateTime.Now,
                PassportNumber = "55555",
                TIN = "55555"
            });

            context.Clients.Add(new()
            {
                ClientName = "Client 6",
                ClientStatusId = 3,
                DateOfPassportIssue = DateTime.Now,
                PassportNumber = "66666",
                TIN = "66666"
            });



             context.SaveChanges();
        }


        public async void InitUsers()
        {
            context.UserRoles.Add(new() { UserRoleName = "Admin"});
            context.UserRoles.Add(new() { UserRoleName = "Director"});
            context.UserRoles.Add(new() { UserRoleName = "User"});
            context.UserRoles.Add(new() { UserRoleName = "Manager"});


             context.SaveChanges();

            context.Users.Add(new()
            {
                UserName="Admin",
                UserRoleId=1,
                Birthdate=DateTime.Now,
                DateOfPassportIssue=DateTime.Now,
                Email="admin@mail.com",
                Password="admin",
                IsActive=true,
                PassportNumber= "111111",
                Phone= "11111",
                TIN="11111"
            });

            context.Users.Add(new()
            {
                UserName = "Director",
                UserRoleId = 2,
                Birthdate = DateTime.Now,
                DateOfPassportIssue = DateTime.Now,
                Email = "director@mail.com",
                Password = "director",
                IsActive = true,
                PassportNumber = "22222",
                Phone = "22222",
                TIN = "22222"
            });

            context.Users.Add(new()
            {
                UserName = "User",
                UserRoleId = 3,
                Birthdate = DateTime.Now,
                DateOfPassportIssue = DateTime.Now,
                Email = "user@mail.com",
                Password = "user",
                IsActive = true,
                PassportNumber = "33333",
                Phone = "33333",
                TIN = "33333"
            });

            context.Users.Add(new()
            {
                UserName = "Manager 1",
                UserRoleId = 2,
                Birthdate = DateTime.Now,
                DateOfPassportIssue = DateTime.Now,
                Email = "manager1@mail.com",
                Password = "manager1",
                IsActive = true,
                PassportNumber = "44444",
                Phone = "44444",
                TIN = "44444"
            });

            context.Users.Add(new()
            {
                UserName = "Manager 2",
                UserRoleId = 2,
                Birthdate = DateTime.Now,
                DateOfPassportIssue = DateTime.Now,
                Email = "manager2@mail.com",
                Password = "manager2",
                IsActive = true,
                PassportNumber = "55555",
                Phone = "55555",
                TIN = "55555"
            });

            context.Users.Add(new()
            {
                UserName = "Manager 3",
                UserRoleId = 2,
                Birthdate = DateTime.Now,
                DateOfPassportIssue = DateTime.Now,
                Email = "manager3@mail.com",
                Password = "manager3",
                IsActive = true,
                PassportNumber = "66666",
                Phone = "66666",
                TIN = "66666"
            });

            context.Users.Add(new()
            {
                UserName = "Manager 4",
                UserRoleId = 2,
                Birthdate = DateTime.Now,
                DateOfPassportIssue = DateTime.Now,
                Email = "manager4@mail.com",
                Password = "manager4",
                IsActive = true,
                PassportNumber = "77777",
                Phone = "77777",
                TIN = "77777"
            });

            context.Users.Add(new()
            {
                UserName = "Manager 5",
                UserRoleId = 2,
                Birthdate = DateTime.Now,
                DateOfPassportIssue = DateTime.Now,
                Email = "manager5@mail.com",
                Password = "manager5",
                IsActive = true,
                PassportNumber = "88888",
                Phone = "88888",
                TIN = "88888"
            });



             context.SaveChanges();
        }

        public async void InitEvents()
        {
            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 1",
                EventName = "Event 1",
                UserId = 1
            });

            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 2",
                EventName = "Event 2",
                UserId = 2
            });

            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 3",
                EventName = "Event 3",
                UserId = 3
            });

            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 4",
                EventName = "Event 4",
                UserId = 4
            });

            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 5",
                EventName = "Event 5",
                UserId = 5
            });

            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 6",
                EventName = "Event 6",
                UserId = 6
            });

            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 7",
                EventName = "Event 7",
                UserId = 7
            });

            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 8",
                EventName = "Event 8",
                UserId = 8
            });


            context.SaveChanges();



            










            context.EventsChat.Add(new EventChat()
            {
                EventId = 1,
                EventChatName = "Event 1"
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 1,
                UserId = 1,
                IsCreator = true
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 1,
                UserId = 2,
                IsCreator = false
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 1,
                UserId = 3,
                IsCreator = false
            });












            context.EventsChat.Add(new EventChat()
            {
                EventId = 2,
                EventChatName = "Event 2"
            });



            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 2,
                UserId = 2,
                IsCreator = true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 2,
                UserId = 3,
                IsCreator = false
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 2,
                UserId = 4,
                IsCreator = false
            });








            context.EventsChat.Add(new EventChat()
            {
                EventId = 3,
                EventChatName = "Event 3"
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 3,
                UserId = 3,
                IsCreator = true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 3,
                UserId = 4,
                IsCreator = false
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 3,
                UserId = 5,
                IsCreator = false
            });













            context.EventsChat.Add(new EventChat()
            {
                EventId = 4,
                EventChatName = "Event 4"
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 4,
                UserId = 4,
                IsCreator = true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 4,
                UserId = 5,
                IsCreator = false
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 4,
                UserId = 6,
                IsCreator = false
            });








            context.EventsChat.Add(new EventChat()
            {
                EventId = 5,
                EventChatName = "Event 5"
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 5,
                UserId = 5,
                IsCreator = true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 5,
                UserId = 6,
                IsCreator = false
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 5,
                UserId = 7,
                IsCreator = false
            });










            context.EventsChat.Add(new EventChat()
            {
                EventId = 6,
                EventChatName = "Event 6"
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 6,
                UserId = 6,
                IsCreator = true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 6,
                UserId = 7,
                IsCreator = false
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 6,
                UserId = 8,
                IsCreator = false
            });









            context.EventsChat.Add(new EventChat()
            {
                EventId = 7,
                EventChatName = "Event 7"
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 7,
                UserId = 7,
                IsCreator = true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 7,
                UserId = 8,
                IsCreator = false
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 7,
                UserId = 1,
                IsCreator = false
            });










            context.EventsChat.Add(new EventChat()
            {
                EventId = 8,
                EventChatName = "Event 8"
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 8,
                UserId = 8,
                IsCreator = true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 8,
                UserId = 1,
                IsCreator = false
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = 8,
                UserId = 2,
                IsCreator = false
            });









            context.SaveChanges();




        }
    }
}
