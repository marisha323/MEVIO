using MEVIO.Models;
using MEVIO.Models.BackendClasses;
using MEVIO.Views.Calendar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult Index()
        {
            List<MonthGenerator> months = new List<MonthGenerator>();
            months = MonthGenerator.Fill();
            ViewBag.months = months;

            List<string> days = new List<string>() { "Неділ", "Понед", "Вівто", "Серед", "Четве", "П'ятн", "Субот"};
            string[] monthNames = new string[] { "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень", "Липень ", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень" };
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
            ViewBag.Tasks = db.Tasks.AsNoTracking().ToList();
            ViewBag.Measures = db.Measures.AsNoTracking().ToList();
            ViewBag.Monthnames = monthNames;
            ViewBag.users = db.Users.AsNoTracking().ToList();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditEvent(EventViewModel eventView)
        {
            var test = eventView;
            Event ev = db.Events.Where(o => o.Id == test.EventId).AsNoTracking().FirstOrDefault();
            ev.Begin = test.Date;
            ev.End = test.DateEnd;
            ev.Description = test.EventDescription;
            ev.EventName = test.EventName;
            db.Update(ev);
            await db.SaveChangesAsync();
            return View("Calendar");
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
