using Microsoft.EntityFrameworkCore;

namespace MEVIO.Models.StartInitial
{
    public class MyInitial
    {
        public MEVIOContext context { get; set; }

        public MyInitial(MEVIOContext context)
        {
            this.context = context;
        }


        public async Task<bool> InitEvents()
        {
            context.Events.Add(new Event()
            {
                Begin=DateTime.Now,
                End=DateTime.Now,
                Description="Event 1",
                EventName="Event 1",
                UserId=5
            });

            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 2",
                EventName = "Event 2",
                UserId = 8
            });

            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 3",
                EventName = "Event 3",
                UserId = 9
            });

            context.Events.Add(new Event()
            {
                Begin = DateTime.Now,
                End = DateTime.Now,
                Description = "Event 4",
                EventName = "Event 4",
                UserId = 10
            });


            await context.SaveChangesAsync();



            //Create EventChat

            Event event1 = await context.Events.FirstOrDefaultAsync(e => e.EventName.Equals("Event 1"));

            context.EventsChat.Add(new EventChat()
            {
                EventId = event1.Id,
                EventChatName = event1.EventName,
                Event = event1
            });



            context.EventsUsers.Add(new EventsUsers()
            {
                EventId= event1.Id,
                UserId= event1.UserId,
                IsCreator=true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = event1.Id,
                UserId = 8,
                IsCreator = true
            });










            event1 = await context.Events.FirstOrDefaultAsync(e => e.EventName.Equals("Event 2"));

            context.EventsChat.Add(new EventChat()
            {
                EventId = event1.Id,
                EventChatName = event1.EventName,
                Event = event1
            });



            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = event1.Id,
                UserId = event1.UserId,
                IsCreator = true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = event1.Id,
                UserId = 9,
                IsCreator = true
            });







            event1 = await context.Events.FirstOrDefaultAsync(e => e.EventName.Equals("Event 3"));

            context.EventsChat.Add(new EventChat()
            {
                EventId = event1.Id,
                EventChatName = event1.EventName,
                Event = event1
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = event1.Id,
                UserId = event1.UserId,
                IsCreator = true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = event1.Id,
                UserId = 10,
                IsCreator = true
            });












            event1 = await context.Events.FirstOrDefaultAsync(e => e.EventName.Equals("Event 4"));

            context.EventsChat.Add(new EventChat()
            {
                EventId = event1.Id,
                EventChatName = event1.EventName,
                Event = event1
            });


            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = event1.Id,
                UserId = event1.UserId,
                IsCreator = true
            });

            context.EventsUsers.Add(new EventsUsers()
            {
                EventId = event1.Id,
                UserId = 5,
                IsCreator = true
            });









            await context.SaveChangesAsync();





            return true;
        }
    }
}
