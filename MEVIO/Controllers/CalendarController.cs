﻿using MEVIO.Models;
using MEVIO.Models.BackendClasses;
using MEVIO.Views.Calendar;
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
            return View();
        }
        //[HttpPost]
        public IActionResult GetDigit()
        {
            return Json(1);
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
