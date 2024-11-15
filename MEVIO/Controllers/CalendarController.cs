﻿using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using MEVIO.Models;
using MEVIO.Models.BackendClasses;
using MEVIO.Views.Calendar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Json;
using Task = MEVIO.Models.Task;

namespace MEVIO.Controllers
{
    public class CalendarController : Controller
    {
        public MEVIOContext db;
        public CalendarController(MEVIOContext db)
        {
            this.db = db;
        }
        // GET: CalendarController
        public async Task<ActionResult> Index()
        {
            User user = null;
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];
            if (UserLoggedIn != null && UserLoggedIn != "")
            {
                user = JsonSerializer.Deserialize<User>(UserLoggedIn);
            }

            if (user == null)
            {
                return Redirect("Registry/Index");
            }


            List<MonthGenerator> months = new List<MonthGenerator>();
            months = MonthGenerator.Fill();
            ViewBag.months = months;

            List<string> days = new List<string>() {  "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота","Неділя" };
            string[] monthNames = new string[] { "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень", "Липень ", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень" };
            List<int> spacesInDay = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            ViewBag.weekDays = days;
            ViewBag.spaces = spacesInDay;

            
            var eventsUsers = db.EventsUsers.Where(o => o.UserId == user.Id).AsNoTracking().ToList();
            var events = new List<Event>();

            foreach(var item in eventsUsers)
            {
                if(item.UserId == user.Id)
                {
                    events.Add(db.Events.Where(o => o.Id == item.EventId).AsNoTracking().FirstOrDefault());
                }
            }

            var measuresUsers = db.MeasuresUsers.Where(o => o.UserId == user.Id).AsNoTracking().ToList();
            var measures = new List<Measure>();
            foreach(var item in measuresUsers)
            {
                if(item.UserId == user.Id)
                {
                    measures.Add(db.Measures.Where(o=>o.Id == item.MeasureId).AsNoTracking().FirstOrDefault());
                }
            }

            var tasksUsers = db.TasksUsers.Where(o => o.UserId == user.Id).AsNoTracking().ToList();
            var tasks = new List<Task>();
            foreach (var item in tasksUsers)
            {
                if (item.UserId == user.Id)
                {
                    tasks.Add(db.Tasks.Where(o => o.Id == item.TaskId).AsNoTracking().FirstOrDefault());
                }
            }

            ViewBag.User = user;
            ViewBag.Events = events;
            ViewBag.Tasks = tasks;
            ViewBag.Measures = measures;
            ViewBag.PlaceForMeasures = db.PlaceForMeasures.AsNoTracking().ToList();
            ViewBag.MeasureClients = db.MeasuresClients.AsNoTracking().ToList();
            ViewBag.Clients = db.Clients.AsNoTracking().ToList();
            ViewBag.Monthnames = monthNames;
            ViewBag.users = db.Users.AsNoTracking().ToList();
            ViewBag.TasksUsers = tasksUsers;
            ViewBag.Responsible = db.TaskResponsiblePersons.AsNoTracking().ToList();
            ViewBag.Observers = db.TasksWatchingPersons.AsNoTracking().ToList();

            CultureInfo culture = CultureInfo.GetCultureInfo("uk-UA");
            int monthNow = DateTime.Now.Month;
            string monthName = culture.DateTimeFormat.GetMonthName(monthNow);

            ViewBag.monthNow = new { Name = monthName, Number = monthNow };


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditMeasure()
        {
            var addedclients = Request.Form["AddedClients"];
            var selectedVenue = Request.Form["selectedVenue"];
            var monthbegin = Request.Form["MeasureBeginI"];
            var monthend = Request.Form["MeasureEndI"];
            var measureName = Request.Form["MeasureNameI"];

            return Redirect("Calendar");
        }
        [HttpGet]
        public async Task<IActionResult> EditEvent(EventViewModel eventView)
        {
            Event ev = db.Events.FirstOrDefault(o => o.Id == eventView.EventId);
            DateTime beginDateTime = eventView.Date.Add(eventView.Time1.TimeOfDay);
            DateTime endDateTime = eventView.DateEnd.Add(eventView.Time2.TimeOfDay);

            ev.Begin = beginDateTime;
            ev.End = endDateTime;
            ev.Description = eventView.EventDescription;
            ev.EventName = eventView.EventName;

            db.Update(ev);
            await db.SaveChangesAsync();

            //return Json(new { success = true });
            return Redirect("Calendar");
        }
        [HttpPost]
        public ActionResult Action(int month)
        {
            // Create a ViewBag object with some data
            ViewBag.MyValue = "Hello, World!";
            // Return the Calendar view
            List<MonthGenerator> months = new List<MonthGenerator>();
            months = MonthGenerator.Fill();
            ViewBag.months = months;

            List<string> days = new List<string>() { "Понед", "Вівто", "Серед", "Четве", "П'ятн", "Субот", "Неділ" };
            List<int> spacesInDay = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            ViewBag.weekDays = days;
            ViewBag.spaces = spacesInDay;

            //var Events = db.Events.AsNoTracking().ToList();
            //List <BreakDate> breakDates= new List<BreakDate>();
            //foreach(var item in Events)
            //{
            //    BreakDate date = new BreakDate(item);
            //    breakDates.Add(date);
            //}
            //ViewBag.Events = breakDates;

            ViewBag.Events = db.Events.AsNoTracking().ToList();
            return View("Index");
        }
        // GET: CalendarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CalendarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalendarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalendarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalendarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalendarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalendarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
